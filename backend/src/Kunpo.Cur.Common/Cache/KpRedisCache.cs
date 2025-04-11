// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>Redis缓存</summary>
// <remarks>处理Redis缓存的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Kunpo.Cur.Common.Options;
using Kunpo.Cur.Common.Utils;

namespace Kunpo.Cur.Common.Cache
{
  /// <summary>
  /// Redis缓存实现
  /// </summary>
  public class KpRedisCache : IKpCache, IDisposable
  {
    private readonly IDistributedCache _cache;
    private readonly KpCacheOption _options;
    private bool _disposed;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="cache">Redis缓存</param>
    /// <param name="options">缓存配置</param>
    public KpRedisCache(IDistributedCache cache, IOptions<KpCacheOption> options)
    {
      _cache = cache;
      _options = options.Value;
    }

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <returns>缓存值</returns>
    public async Task<T?> GetAsync<T>(string key)
    {
      var value = await _cache.GetStringAsync(key);
      return value == null ? default : KpSerializerHelper.DeserializeFromJson<T>(value);
    }

    /// <summary>
    /// 设置缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <param name="value">缓存值</param>
    /// <param name="expire">过期时间</param>
    public async Task SetAsync<T>(string key, T value, TimeSpan? expire = null)
    {
      var options = new DistributedCacheEntryOptions();

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

      var serializedValue = KpSerializerHelper.SerializeToJson(value);
      if (serializedValue == null)
      {
        return;
      }
      await _cache.SetStringAsync(key, serializedValue, options);
    }

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    public async Task RemoveAsync(string key)
    {
      await _cache.RemoveAsync(key);
    }

    /// <summary>
    /// 是否存在缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    /// <returns>是否存在</returns>
    public async Task<bool> ExistsAsync(string key)
    {
      var value = await _cache.GetAsync(key);
      return value != null;
    }

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T">缓存类型</typeparam>
    /// <param name="key">缓存键</param>
    /// <returns>缓存值</returns>
    public T? Get<T>(string key)
    {
      return GetAsync<T>(key).GetAwaiter().GetResult();
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
      SetAsync(key, value, expire).GetAwaiter().GetResult();
    }

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    public void Remove(string key)
    {
      RemoveAsync(key).GetAwaiter().GetResult();
    }

    /// <summary>
    /// 是否存在缓存
    /// </summary>
    /// <param name="key">缓存键</param>
    /// <returns>是否存在</returns>
    public bool Exists(string key)
    {
      return ExistsAsync(key).GetAwaiter().GetResult();
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
      if (_disposed) return;

      if (_cache is IDisposable disposable)
      {
        disposable.Dispose();
      }

      _disposed = true;
    }
  }
}