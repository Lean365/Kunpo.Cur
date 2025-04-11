// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL注入防护中间件</summary>
// <remarks>用于防止SQL注入攻击</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Options;
using System.Text.RegularExpressions;

namespace Kunpo.Cur.Infrastructure.Middleware
{
  /// <summary>
  /// SQL注入防护中间件
  /// 用于防止SQL注入攻击
  /// </summary>
  public class KpSqlInjectionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly KpSqlInjectionOptions _options;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="next">下一个中间件</param>
    /// <param name="options">安全配置选项</param>
    public KpSqlInjectionMiddleware(RequestDelegate next, IOptions<KpSecurityOptions> options)
    {
      _next = next;
      _options = options.Value.SqlInjection;
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

      // 检查查询字符串
      if (context.Request.QueryString.HasValue)
      {
        var queryString = context.Request.QueryString.Value;
        if (ContainsSensitiveChars(queryString))
        {
          context.Response.StatusCode = StatusCodes.Status400BadRequest;
          return;
        }
      }

      // 检查请求体
      if (context.Request.ContentLength > 0)
      {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;

        if (ContainsSensitiveChars(body))
        {
          context.Response.StatusCode = StatusCodes.Status400BadRequest;
          return;
        }
      }

      await _next(context);
    }

    /// <summary>
    /// 检查是否包含敏感字符
    /// </summary>
    /// <param name="input">输入字符串</param>
    /// <returns>是否包含敏感字符</returns>
    private bool ContainsSensitiveChars(string? input)
    {
      if (string.IsNullOrEmpty(input) || _options.SensitiveChars == null)
      {
        return false;
      }

      return _options.SensitiveChars.Any(sensitiveChar => input.Contains(sensitiveChar, StringComparison.OrdinalIgnoreCase));
    }
  }

  /// <summary>
  /// SQL注入防护中间件扩展方法
  /// </summary>
  public static class KpSqlInjectionMiddlewareExtensions
  {
    /// <summary>
    /// 使用SQL注入防护中间件
    /// </summary>
    /// <param name="builder">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpSqlInjection(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<KpSqlInjectionMiddleware>();
    }
  }
}