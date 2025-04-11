// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>服务集合扩展</summary>
// <remarks>处理服务集合的扩展</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Kunpo.Cur.Common.Options;
using Kunpo.Cur.Infrastructure.Middleware;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Infrastructure.Data;
using System;
using System.Linq;
using System.Reflection;
using Kunpo.Cur.Infrastructure.Data.Seeds;
using Kunpo.Cur.Application.Services;
using Kunpo.Cur.Application.Services.Identity;
using Kunpo.Cur.Application.Services.Localization;
using Kunpo.Cur.Infrastructure.Repositories;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Infrastructure.Services;

namespace Kunpo.Cur.Infrastructure.Extensions
{
  /// <summary>
  /// 服务集合扩展
  /// </summary>
  public static class KpServiceCollectionExtensions
  {
    /// <summary>
    /// 添加数据库服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <param name="configuration">配置</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddKpDatabase(this IServiceCollection services, IConfiguration configuration)
    {
      // 配置数据库选项
      services.Configure<KpDatabaseOption>(configuration.GetSection("Database"));

      // 注册数据库上下文
      services.AddScoped<KpSqlSugarDbContext>();

      // 注册数据库初始化器
      services.AddScoped<KpDbInitializer>();

      // 注册种子数据初始化器
      services.AddScoped<KpSeedInitializer>();

      // 注册所有种子类
      var seedTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
        .Where(t => t.IsClass &&
                   !t.IsAbstract &&
                   t.Namespace?.Contains("Seeds") == true &&
                   t.Name.EndsWith("Seed"));

      foreach (var seedType in seedTypes)
      {
        services.AddScoped(seedType);
      }

      return services;
    }

    /// <summary>
    /// 添加安全服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <param name="configuration">配置</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddKpSecurity(this IServiceCollection services, IConfiguration configuration)
    {
      // 配置安全选项
      services.Configure<KpSecurityOptions>(configuration.GetSection("Security"));

      // 添加内存缓存（用于限流）
      services.AddMemoryCache();

      return services;
    }

    /// <summary>
    /// 使用安全中间件
    /// </summary>
    /// <param name="app">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpSecurity(this IApplicationBuilder app)
    {
      // 使用防伪令牌中间件
      app.UseKpAntiforgery();

      // 使用限流中间件
      app.UseKpRateLimit();

      // 使用SQL注入防护中间件
      app.UseKpSqlInjection();

      return app;
    }

    /// <summary>
    /// 添加自定义服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <param name="configuration">配置</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddKpServices(this IServiceCollection services, IConfiguration configuration)
    {
      // 添加身份认证服务
      services.AddScoped<IKpUserService, KpUserService>();
      services.AddScoped<IKpJwtService, KpJwtService>();
      services.AddScoped<IKpTenantService, KpTenantService>();

      // 添加本地化服务
      services.AddScoped<IKpLocalizationService, KpLocalizationService>();

      // 添加仓储
      services.AddScoped(typeof(IKpBaseRepository<>), typeof(KpBaseRepository<>));

      return services;
    }
  }
}