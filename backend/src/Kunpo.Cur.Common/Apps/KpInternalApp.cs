// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>内部应用程序</summary>
// <remarks>处理内部应用程序的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kunpo.Cur.Common.Apps
{
  /// <summary>
  /// 应用程序内部状态类
  /// </summary>
  public static class KpInternalApp
  {
    /// <summary>
    /// 服务提供器
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; set; }

    /// <summary>
    /// Web主机环境
    /// </summary>
    public static IWebHostEnvironment? WebHostEnvironment { get; set; }

    /// <summary>
    /// 全局配置
    /// </summary>
    public static IConfiguration? Configuration { get; set; }

    /// <summary>
    /// 初始化应用程序
    /// </summary>
    public static void Initialize(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
      ServiceProvider = serviceProvider;
      WebHostEnvironment = webHostEnvironment;
      Configuration = configuration;
    }
  }
}