// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>限流工具类</summary>
// <remarks>处理限流的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Kunpo.Cur.Common.Options;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 限流工具类
  /// </summary>
  public static class KpRateLimiter
  {
    private static KpRateLimitOptions _options = new();
    private static IMemoryCache? _cache;
    private static Serilog.ILogger? _logger;

    /// <summary>
    /// 配置
    /// </summary>
    public static KpRateLimitOptions Options
    {
      get => _options;
      set => _options = value ?? new KpRateLimitOptions();
    }

    /// <summary>
    /// 缓存
    /// </summary>
    public static IMemoryCache? Cache
    {
      get => _cache;
      set => _cache = value;
    }

    /// <summary>
    /// 日志记录器
    /// </summary>
    public static Serilog.ILogger? Logger
    {
      get => _logger;
      set => _logger = value;
    }

    /// <summary>
    /// 检查是否超过限流
    /// </summary>
    /// <param name="key">限流键</param>
    /// <param name="limit">限制次数</param>
    /// <param name="period">时间周期（秒）</param>
    /// <returns>是否超过限流</returns>
    public static bool IsLimited(string key, int? limit = null, int? period = null)
    {
      if (!_options.Enabled || string.IsNullOrEmpty(key))
      {
        return false;
      }

      try
      {
        // 获取限流规则
        var rule = GetRateLimitRule(key);
        var actualLimit = limit ?? rule?.Limit ?? _options.DefaultLimit;
        var actualPeriod = period ?? rule?.Period ?? _options.DefaultPeriod;

        // 获取当前计数
        var cacheKey = $"RateLimit:{key}";
        var count = _cache?.GetOrCreate(cacheKey, entry =>
        {
          entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(actualPeriod);
          return 0;
        }) ?? 0;

        // 增加计数
        count++;
        _cache?.Set(cacheKey, count, TimeSpan.FromSeconds(actualPeriod));

        // 检查是否超过限制
        var isLimited = count > actualLimit;

        if (isLimited)
        {
          _logger?.Warning("请求超过限流：{Key}，限制：{Limit}/{(double)actualPeriod}秒，当前：{Count}次",
            key, actualLimit, actualPeriod, count);
        }
        else
        {
          _logger?.Debug("请求未超过限流：{Key}，限制：{Limit}/{(double)actualPeriod}秒，当前：{Count}次",
            key, actualLimit, actualPeriod, count);
        }

        return isLimited;
      }
      catch (Exception ex)
      {
        _logger?.Error(ex, "限流检查失败：{Key}", key);
        return false;
      }
    }

    private static KpRateLimitRule? GetRateLimitRule(string key)
    {
      if (_options.Rules.TryGetValue(key, out var rule))
      {
        return rule;
      }

      // 尝试匹配通配符规则
      foreach (var kvp in _options.Rules)
      {
        if (kvp.Key.EndsWith("*") && key.StartsWith(kvp.Key[..^1]))
        {
          return kvp.Value;
        }
      }

      return null;
    }
  }
}