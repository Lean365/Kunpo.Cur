// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SignalR Hub 实现类</summary>
// <remarks>处理SignalR Hub的实现</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.SignalR;
using Kunpo.Cur.Application.Services.SignalR;
using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Common.Models;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Helpers;

namespace Kunpo.Cur.Infrastructure.SignalR
{
  /// <summary>
  /// SignalR Hub 实现类
  /// </summary>
  public class HbtSignalRHub : Hub
  {
    private readonly IKpOnlineUserService _onlineUserService;
    private readonly IKpOnlineMessageService _onlineMessageService;
    private readonly ILogger<HbtSignalRHub> _logger;
    private readonly IKpSecurityContext _securityContext;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="onlineUserService">在线用户服务</param>
    /// <param name="onlineMessageService">在线消息服务</param>
    /// <param name="logger">日志服务</param>
    /// <param name="securityContext">安全上下文</param>
    public HbtSignalRHub(
      IKpOnlineUserService onlineUserService,
      IKpOnlineMessageService onlineMessageService,
      ILogger<HbtSignalRHub> logger,
      IKpSecurityContext securityContext)
    {
      _onlineUserService = onlineUserService;
      _onlineMessageService = onlineMessageService;
      _logger = logger;
      _securityContext = securityContext;
    }

    /// <summary>
    /// 客户端连接时调用
    /// </summary>
    public override async Task OnConnectedAsync()
    {
      var userId = _securityContext.GetCurrentUserId();
      var userName = _securityContext.GetCurrentUserName();
      var connectionId = Context.ConnectionId;

      // 创建在线用户
      var user = new KpOnlineUserCreateDto
      {
        UserId = userId,
        UserName = userName,
        ConnectionId = connectionId,
        DeviceType = KpDeviceHelper.GetDeviceType(Context.GetHttpContext()),
        DeviceId = KpDeviceHelper.GenerateDeviceId(Context.GetHttpContext()),
        DeviceName = KpDeviceHelper.GetDeviceName(Context.GetHttpContext()),
        DeviceModel = KpDeviceHelper.GetDeviceModel(Context.GetHttpContext())
      };

      await _onlineUserService.CreateAsync(user);

      _logger.LogInformation("用户 {UserId} 已连接，连接ID：{ConnectionId}", userId, connectionId);
      await base.OnConnectedAsync();
    }

    /// <summary>
    /// 客户端断开连接时调用
    /// </summary>
    /// <param name="exception">异常信息</param>
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
      var userId = _securityContext.GetCurrentUserId();
      var connectionId = Context.ConnectionId;

      // 删除在线用户
      await _onlineUserService.DeleteAsync(new KpOnlineUserDeleteDto { UserId = userId });

      _logger.LogInformation("用户 {UserId} 已断开连接，连接ID：{ConnectionId}", userId, connectionId);
      await base.OnDisconnectedAsync(exception);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="input">消息信息</param>
    public async Task SendMessageAsync(KpOnlineMessageCreateDto input)
    {
      var senderId = _securityContext.GetCurrentUserId();
      var senderName = _securityContext.GetCurrentUserName();

      // 创建消息
      var messageId = await _onlineMessageService.CreateAsync(input);

      // 获取接收者连接ID
      var receiver = await _onlineUserService.GetAsync(input.ReceiverId);
      if (receiver != null && !string.IsNullOrEmpty(receiver.ConnectionId))
      {
        // 发送消息给接收者
        await Clients.Client(receiver.ConnectionId).SendAsync("ReceiveMessage", new
        {
          MessageId = messageId,
          SenderId = senderId,
          SenderName = senderName,
          ReceiverId = input.ReceiverId,
          MessageType = input.MessageType,
          MessageContent = input.MessageContent,
          SendTime = DateTime.Now
        });
      }
    }

    /// <summary>
    /// 标记消息为已读
    /// </summary>
    /// <param name="messageId">消息ID</param>
    public async Task MarkAsReadAsync(long messageId)
    {
      await _onlineMessageService.MarkAsReadAsync(messageId);
    }

    /// <summary>
    /// 获取未读消息
    /// </summary>
    /// <returns>未读消息列表</returns>
    public async Task<List<KpOnlineMessageDto>> GetUnreadMessagesAsync()
    {
      var userId = _securityContext.GetCurrentUserId();
      return await _onlineMessageService.GetUnreadMessagesAsync(userId);
    }

    /// <summary>
    /// 处理心跳
    /// </summary>
    public async Task Heartbeat()
    {
      var userId = _securityContext.GetCurrentUserId();
      await _onlineUserService.UpdateLastActivityTimeAsync(userId);
    }
  }
}