// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>内存缓存</summary>
// <remarks>处理内存缓存的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using Kunpo.Cur.Common.Options;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Reflection;

namespace Kunpo.Cur.Common.Cache
{
  /// <summary>
  /// 内置缓存实现
  /// </summary>
  public class KpMemoryCache : IKpCache, IDisposable
  {
    private readonly IMemoryCache _cache;
    private readonly KpCacheOption _options;
    private readonly Timer? _cleanupTimer;
    private bool _disposed;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="cache">内存缓存</param>
    /// <param name="options">缓存配置</param>
    public KpMemoryCache(IMemoryCache cache, IOptions<KpCacheOption> options)
    {
      _cache = cache;
      _options = options.Value;

      // 创建定时清理器，每5分钟检查一次
      _cleanupTimer = new Timer(CleanupCallback, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
    }

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <returns>缓存值</returns>
    public T? Get<T>(string key)
    {
      return _cache.Get<T>(key);
    }

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <returns>缓存值</returns>
    public Task<T?> GetAsync<T>(string key)
    {
      return Task.FromResult(Get<T>(key));
    }

    /// <summary>
    /// 设置缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <param name="value">缓存值</param>
    /// <param name="expire">过期时间</param>
    public void Set<T>(string key, T value, TimeSpan? expire = null)
    {
      var options = new MemoryCacheEntryOptions();

      // 设置过期时间
      var expireMinutes = expire?.TotalMinutes ?? _options.Expire.DefaultExpireMinutes;
      expireMinutes = Math.Min(Math.Max(expireMinutes, _options.Expire.MinExpireMinutes), _options.Expire.MaxExpireMinutes);

      if (_options.Expire.EnableSlidingExpiration)
      {
        options.SlidingExpiration = TimeSpan.FromMinutes(expireMinutes);
      }
      else
      {
        options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireMinutes);
      }

      // 添加内存压力回调
      options.RegisterPostEvictionCallback((key, value, reason, state) =>
      {
        if (reason == EvictionReason.Capacity)
        {
          // 当因内存压力被移除时，记录日志
          Debug.WriteLine($"Cache item removed due to memory pressure: {key}");
        }
      });

      _cache.Set(key, value, options);
    }

    /// <summary>
    /// 设置缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <param name="value">缓存值</param>
    /// <param name="expire">过期时间</param>
    public Task SetAsync<T>(string key, T value, TimeSpan? expire = null)
    {
      Set(key, value, expire);
      return Task.CompletedTask;
    }

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    public void Remove(string key)
    {
      _cache.Remove(key);
    }

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    public Task RemoveAsync(string key)
    {
      Remove(key);
      return Task.CompletedTask;
    }

    /// <summary>
    /// 是否存在缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    /// <returns>是否存在</returns>
    public bool Exists(string key)
    {
      return _cache.TryGetValue(key, out _);
    }

    /// <summary>
    /// 是否存在缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    /// <returns>是否存在</returns>
    public Task<bool> ExistsAsync(string key)
    {
      return Task.FromResult(Exists(key));
    }

    /// <summary>
    /// 清理回调
    /// </summary>
    private void CleanupCallback(object? state)
    {
      if (_disposed) return;

      try
      {
        // 获取当前进程的内存使用量（MB）
        var currentMemoryMB = Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024);

        if (currentMemoryMB >= _options.Memory.MemoryThresholdMB)
        {
          // 获取所有缓存项
          var field = typeof(MemoryCache).GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
          var entries = field?.GetValue(_cache) as IDictionary;

          if (entries != null)
          {
            var itemsToRemove = entries.Cast<DictionaryEntry>()
              .OrderBy(x => x.Value?.GetType().GetProperty("LastAccessed")?.GetValue(x.Value) ?? DateTime.MinValue)
              .Take(_options.Memory.MaxItemsToRemove)
              .Select(x => x.Key)
              .ToList();

            foreach (var key in itemsToRemove)
            {
              _cache.Remove(key);
            }
          }
        }
      }
      catch (Exception ex)
      {
        // 记录清理过程中的错误
        Debug.WriteLine($"Cache cleanup error: {ex.Message}");
      }
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
      if (_disposed) return;

      if (_cleanupTimer != null)
      {
        _cleanupTimer.Dispose();
      }

      _disposed = true;
      GC.SuppressFinalize(this);
    }
  }
}