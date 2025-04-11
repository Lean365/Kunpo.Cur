// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>防伪令牌中间件</summary>
// <remarks>用于防止跨站请求伪造(CSRF)攻击</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Options;

namespace Kunpo.Cur.Infrastructure.Middleware
{
  /// <summary>
  /// 防伪令牌中间件
  /// 用于防止跨站请求伪造(CSRF)攻击
  /// </summary>
  public class KpAntiforgeryMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly KpAntiForgeryOptions _options;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="next">下一个中间件</param>
    /// <param name="options">安全配置选项</param>
    public KpAntiforgeryMiddleware(RequestDelegate next, IOptions<KpSecurityOptions> options)
    {
      _next = next;
      _options = options.Value.AntiForgery;
    }

    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="context">HTTP上下文</param>
    public async Task InvokeAsync(HttpContext context)
    {
      if (_options.Enabled)
      {
        if (string.IsNullOrEmpty(_options.CookieName) || string.IsNullOrEmpty(_options.HeaderName))
        {
          await _next(context);
          return;
        }

        // 生成防伪令牌
        var token = Guid.NewGuid().ToString("N");

        // 将令牌存储在Cookie中
        context.Response.Cookies.Append(_options.CookieName, token, new CookieOptions
        {
          HttpOnly = true,    // 防止JavaScript访问
          Secure = true,      // 仅通过HTTPS传输
          SameSite = SameSiteMode.Strict  // 严格限制跨站请求
        });

        // 将令牌添加到响应头
        context.Response.Headers[_options.HeaderName] = token;
      }

      await _next(context);
    }
  }

  /// <summary>
  /// 防伪令牌中间件扩展方法
  /// </summary>
  public static class KpAntiforgeryMiddlewareExtensions
  {
    /// <summary>
    /// 使用防伪令牌中间件
    /// </summary>
    /// <param name="builder">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpAntiforgery(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<KpAntiforgeryMiddleware>();
    }
  }
}