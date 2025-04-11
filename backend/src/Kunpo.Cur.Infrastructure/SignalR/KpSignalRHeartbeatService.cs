// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SignalR心跳检测服务</summary>
// <remarks>处理SignalR心跳检测服务</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Services.SignalR;
using Kunpo.Cur.Application.Dtos.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Kunpo.Cur.Infrastructure.SignalR
{
  /// <summary>
  /// SignalR 心跳检测服务
  /// </summary>
  public class KpSignalRHeartbeatService : BackgroundService
  {
    private readonly IHubContext<HbtSignalRHub> _hubContext;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<KpSignalRHeartbeatService> _logger;
    private readonly TimeSpan _heartbeatInterval = TimeSpan.FromSeconds(30);

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="hubContext">Hub 上下文</param>
    /// <param name="serviceScopeFactory">服务作用域工厂</param>
    /// <param name="logger">日志服务</param>
    public KpSignalRHeartbeatService(
      IHubContext<HbtSignalRHub> hubContext,
      IServiceScopeFactory serviceScopeFactory,
      ILogger<KpSignalRHeartbeatService> logger)
    {
      _hubContext = hubContext;
      _serviceScopeFactory = serviceScopeFactory;
      _logger = logger;
    }

    /// <summary>
    /// 执行心跳检测
    /// </summary>
    /// <param name="stoppingToken">停止令牌</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          using (var scope = _serviceScopeFactory.CreateScope())
          {
            var onlineUserService = scope.ServiceProvider.GetRequiredService<IKpOnlineUserService>();

            // 获取所有在线用户
            var users = await onlineUserService.GetAllAsync();
            foreach (var user in users)
            {
              if (!string.IsNullOrEmpty(user.ConnectionId))
              {
                try
                {
                  // 发送心跳消息
                  await _hubContext.Clients.Client(user.ConnectionId).SendAsync("Heartbeat", DateTime.Now);
                  _logger.LogDebug("发送心跳消息到用户 {UserId}，连接ID：{ConnectionId}", user.UserId, user.ConnectionId);
                }
                catch (Exception ex)
                {
                  _logger.LogError(ex, "发送心跳消息到用户 {UserId} 失败，连接ID：{ConnectionId}", user.UserId, user.ConnectionId);

                  // 如果发送失败，可能是连接已断开，更新用户状态
                  await onlineUserService.UpdateAsync(new KpOnlineUserUpdateDto
                  {
                    UserId = user.UserId,
                    ConnectionId = null,
                    OnlineStatus = 0 // 离线
                  });
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "心跳检测服务执行失败");
        }

        // 等待下一次心跳
        await Task.Delay(_heartbeatInterval, stoppingToken);
      }
    }
  }
}