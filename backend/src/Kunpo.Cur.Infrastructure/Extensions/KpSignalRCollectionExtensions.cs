// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SignalR服务配置扩展</summary>
// <remarks>处理SignalR服务的配置扩展</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Kunpo.Cur.Infrastructure.SignalR;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.SignalR;
using Kunpo.Cur.Application.Services.SignalR;
using Kunpo.Cur.Infrastructure.Repositories;
using System;

namespace Kunpo.Cur.Infrastructure.Extensions
{
  /// <summary>
  /// SignalR 服务配置扩展
  /// </summary>
  public static class KpSignalRCollectionExtensions
  {
    /// <summary>
    /// 添加 SignalR 服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddKpSignalR(this IServiceCollection services)
    {
      // 添加 SignalR 服务
      services.AddSignalR(options =>
      {
        // 配置 SignalR 选项
        options.EnableDetailedErrors = true;
        options.ClientTimeoutInterval = TimeSpan.FromMinutes(5);
        options.HandshakeTimeout = TimeSpan.FromSeconds(15);
        options.KeepAliveInterval = TimeSpan.FromSeconds(15);
      });

      // 添加在线用户仓储服务
      services.AddScoped<IKpBaseRepository<KpOnlineUser>, KpBaseRepository<KpOnlineUser>>();

      // 添加在线消息仓储服务
      services.AddScoped<IKpBaseRepository<KpOnlineMessage>, KpBaseRepository<KpOnlineMessage>>();

      // 添加在线用户服务
      services.AddScoped<IKpOnlineUserService, KpOnlineUserService>();

      // 添加在线消息服务
      services.AddScoped<IKpOnlineMessageService, KpOnlineMessageService>();

      // 添加心跳检测服务
      services.AddHostedService<KpSignalRHeartbeatService>();

      return services;
    }

    /// <summary>
    /// 使用 SignalR 服务
    /// </summary>
    /// <param name="app">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseKpSignalR(this IApplicationBuilder app)
    {
      // 配置 SignalR 路由
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapHub<HbtSignalRHub>("/signalr/hub");
      });

      return app;
    }
  }
}