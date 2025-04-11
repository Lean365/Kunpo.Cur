// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>全局应用程序访问类</summary>
// <remarks>处理全局应用程序的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using Kunpo.Cur.Common.Options;

namespace Kunpo.Cur.Common.Apps
{
  /// <summary>
  /// 全局应用程序访问类
  /// </summary>
  public static class KpApp
  {
    /// <summary>
    /// 服务提供器
    /// </summary>
    public static IServiceProvider? ServiceProvider => KpInternalApp.ServiceProvider;

    /// <summary>
    /// 获取请求上下文
    /// </summary>
    public static HttpContext? HttpContext => ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext;

    /// <summary>
    /// 获取请求上下文用户
    /// </summary>
    public static ClaimsPrincipal? User => HttpContext?.User;

    /// <summary>
    /// 获取用户名
    /// </summary>
    public static string? UserName => User?.Identity?.Name;

    /// <summary>
    /// 获取Web主机环境
    /// </summary>
    public static IWebHostEnvironment? WebHostEnvironment => KpInternalApp.WebHostEnvironment;

    /// <summary>
    /// 获取全局配置
    /// </summary>
    public static IConfiguration? Configuration => KpInternalApp.Configuration;

    /// <summary>
    /// 获取请求生命周期的服务
    /// </summary>
    /// <typeparam name="TService">服务类型</typeparam>
    /// <returns>服务实例</returns>
    public static TService? GetService<TService>()
      where TService : class
    {
      return GetService(typeof(TService)) as TService;
    }

    /// <summary>
    /// 获取请求生命周期的服务
    /// </summary>
    /// <param name="type">服务类型</param>
    /// <returns>服务实例</returns>
    public static object? GetService(Type type)
    {
      return ServiceProvider?.GetService(type);
    }

    /// <summary>
    /// 获取请求生命周期的服务
    /// </summary>
    /// <typeparam name="TService">服务类型</typeparam>
    /// <returns>服务实例</returns>
    public static TService? GetRequiredService<TService>()
      where TService : class
    {
      return GetRequiredService(typeof(TService)) as TService;
    }

    /// <summary>
    /// 获取请求生命周期的服务
    /// </summary>
    /// <param name="type">服务类型</param>
    /// <returns>服务实例</returns>
    public static object? GetRequiredService(Type type)
    {
      return ServiceProvider?.GetRequiredService(type);
    }

    /// <summary>
    /// 处理获取对象异常问题
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="action">获取对象委托</param>
    /// <param name="defaultValue">默认值</param>
    /// <returns>T</returns>
    private static T? CatchOrDefault<T>(Func<T?> action, T? defaultValue = default)
      where T : class
    {
      try
      {
        return action();
      }
      catch
      {
        return defaultValue;
      }
    }
  }
}