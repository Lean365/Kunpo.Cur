// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>限流中间件</summary>
// <remarks>用于限制客户端在指定时间内的请求次数</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Options;

namespace Kunpo.Cur.Infrastructure.Middleware
{
  /// <summary>
  /// 限流中间件
  /// 用于限制客户端在指定时间内的请求次数
  /// </summary>
  public class KpRateLimitMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly KpRateLimitOptions _options;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="next">下一个中间件</param>
    /// <param name="cache">内存缓存</param>
    /// <param name="options">安全配置选项</param>
    public KpRateLimitMiddleware(RequestDelegate next, IMemoryCache cache, IOptions<KpSecurityOptions> options)
    {
      _next = next;
      _cache = cache;
      _options = options.Value.RateLimit;
    }

    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="context">HTTP上下文</param>
    public async Task InvokeAsync(HttpContext context)
    {
      if (!_options.Enabled)
      {
        await _next(context);
        return;
      }

      var path = context.Request.Path.Value;
      if (_options.ExcludePaths?.Contains(path) == true)
      {
        await _next(context);
        return;
      }

      // 获取客户端IP
      var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
      var cacheKey = $"rate_limit:{clientIp}:{path}";

      // 获取当前请求计数
      if (!_cache.TryGetValue(cacheKey, out int requestCount))
      {
        requestCount = 0;
      }

      // 检查是否超过限制
      if (requestCount >= _options.MaxRequests)
      {
        context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        return;
      }

      // 更新请求计数
      var cacheEntryOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromSeconds(_options.TimeWindow));

      _cache.Set(cacheKey, requestCount + 1, cacheEntryOptions);

      await _next(context);
    }
  }

  /// <summary>
  /// 限流中间件扩展方法
  /// </summary>
  public static class KpRateLimitMiddlewareExtensions
  {
    /// <summary>
    /// 使用限流中间件
    /// </summary>
    /// <param name="builder">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpRateLimit(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<KpRateLimitMiddleware>();
    }
  }
}