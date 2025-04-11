// -----------------------------------------------------------------------
// <copyright file="KpHttpContext.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>HTTP上下文工具类</summary>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Http;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// HTTP上下文工具类
  /// </summary>
  public static class KpHttpContext
  {
    private static IHttpContextAccessor? _httpContextAccessor;

    /// <summary>
    /// 设置HTTP上下文访问器
    /// </summary>
    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 获取当前HTTP上下文
    /// </summary>
    public static HttpContext? Current => _httpContextAccessor?.HttpContext;
  }
}