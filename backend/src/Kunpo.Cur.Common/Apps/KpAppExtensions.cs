// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>KpApp 扩展方法</summary>
// <remarks>处理KpApp的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Kunpo.Cur.Common.Apps
{
  /// <summary>
  /// KpApp 扩展方法
  /// </summary>
  public static class KpAppExtensions
  {
    /// <summary>
    /// 初始化 KpApp
    /// </summary>
    /// <param name="app">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpApp(this IApplicationBuilder app)
    {
      var serviceProvider = app.ApplicationServices;
      var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
      var configuration = serviceProvider.GetRequiredService<IConfiguration>();

      KpInternalApp.Initialize(serviceProvider, webHostEnvironment, configuration);

      return app;
    }

    /// <summary>
    /// 初始化 KpApp
    /// </summary>
    /// <param name="app">Web应用程序</param>
    /// <returns>Web应用程序</returns>
    public static WebApplication UseKpApp(this WebApplication app)
    {
      var serviceProvider = app.Services;
      var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
      var configuration = serviceProvider.GetRequiredService<IConfiguration>();

      KpInternalApp.Initialize(serviceProvider, webHostEnvironment, configuration);

      return app;
    }
  }
}