// -----------------------------------------------------------------------
// <copyright file="KpOnlineMessageService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线消息服务实现</summary>
// -----------------------------------------------------------------------
using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Entities.SignalR;
using Kunpo.Cur.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SqlSugar;
using Microsoft.AspNetCore.Http;

namespace Kunpo.Cur.Application.Services.SignalR
{
  /// <summary>
  /// 在线消息服务实现
  /// </summary>
  public class KpOnlineMessageService : KpBaseService, IKpOnlineMessageService
  {
    private readonly IKpBaseRepository<KpOnlineMessage> _messageRepository;
    private readonly IKpBaseRepository<KpOnlineUser> _userRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public KpOnlineMessageService(
      ILogger<KpOnlineMessageService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpOnlineMessage> messageRepository,
      IKpBaseRepository<KpOnlineUser> userRepository,
      IMapper mapper,
      IHttpContextAccessor httpContextAccessor) : base(logger, configuration, securityContext, localizationService)
    {
      _messageRepository = messageRepository;
      _userRepository = userRepository;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    public async Task<KpOnlineMessageDto?> GetAsync(long messageId)
    {
      var message = await _messageRepository.GetByIdAsync(messageId);
      if (message == null) return null;

      return _mapper.Map<KpOnlineMessageDto>(message);
    }

    /// <summary>
    /// 获取消息列表
    /// </summary>
    public async Task<KpPageResult<KpOnlineMessageDto>> GetListAsync(KpOnlineMessageQueryDto query)
    {
      var predicate = Expressionable.Create<KpOnlineMessage>()
        .AndIF(query.SenderId.HasValue, it => it.SenderId == query.SenderId)
        .AndIF(query.ReceiverId.HasValue, it => it.ReceiverId == query.ReceiverId)
        .AndIF(query.MessageType.HasValue, it => it.MessageType == query.MessageType)
        .AndIF(query.IsRead.HasValue, it => it.IsRead == query.IsRead)
        .AndIF(query.StartTime.HasValue, it => it.SendTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.SendTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _messageRepository.GetPageAsync<KpOnlineMessageDto>(request, predicate.ToExpression());

      return new KpPageResult<KpOnlineMessageDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取所有消息
    /// </summary>
    public async Task<List<KpOnlineMessageDto>> GetAllMessagesAsync(long userId)
    {
      var messages = await _messageRepository.GetListAsync(x => x.ReceiverId == userId);
      return messages.Select(m => _mapper.Map<KpOnlineMessageDto>(m)).ToList();
    }

    /// <summary>
    /// 获取未读消息
    /// </summary>
    public async Task<List<KpOnlineMessageDto>> GetUnreadMessagesAsync(long userId)
    {
      var messages = await _messageRepository.GetListAsync(x => x.ReceiverId == userId && x.IsRead == 0);
      return messages.Select(m => _mapper.Map<KpOnlineMessageDto>(m)).ToList();
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    public async Task<long> SendMessageAsync(KpOnlineMessageCreateDto input)
    {
      var sender = await _userRepository.GetByIdAsync(_securityContext.GetCurrentUserId());
      var message = _mapper.Map<KpOnlineMessage>(input);
      message.SenderId = _securityContext.GetCurrentUserId();
      message.SenderName = _securityContext.GetCurrentUserName();
      message.SenderAvatar = sender?.UserAvatar;
      message.IsRead = 0; // 未读
      message.SendTime = DateTime.Now;

      await _messageRepository.CreateAsync(message);
      return message.Id;
    }

    /// <summary>
    /// 创建消息
    /// </summary>
    public async Task<long> CreateAsync(KpOnlineMessageCreateDto input)
    {
      var sender = await _userRepository.GetByIdAsync(_securityContext.GetCurrentUserId());
      var message = _mapper.Map<KpOnlineMessage>(input);
      message.SenderId = _securityContext.GetCurrentUserId();
      message.SenderName = _securityContext.GetCurrentUserName();
      message.SenderAvatar = sender?.UserAvatar;
      message.IsRead = 0; // 未读
      message.SendTime = DateTime.Now;

      await _messageRepository.CreateAsync(message);
      return message.Id;
    }

    /// <summary>
    /// 更新消息
    /// </summary>
    public async Task<bool> UpdateAsync(KpOnlineMessageUpdateDto input)
    {
      var message = await _messageRepository.GetByIdAsync(input.Id);
      if (message == null) return false;

      message.IsRead = input.IsRead ?? message.IsRead;
      if (input.IsRead == 1) // 已读
      {
        message.ReadTime = DateTime.Now;
        message.ReaderId = _securityContext.GetCurrentUserId();
        message.ReaderName = _securityContext.GetCurrentUserName();
        message.ReadIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
      }

      await _messageRepository.UpdateAsync(message);
      return true;
    }

    /// <summary>
    /// 标记消息为已读
    /// </summary>
    public async Task<bool> MarkAsReadAsync(long messageId)
    {
      var message = await _messageRepository.GetByIdAsync(messageId);
      if (message == null) return false;

      message.IsRead = 1; // 已读
      message.ReadTime = DateTime.Now;
      message.ReaderId = _securityContext.GetCurrentUserId();
      message.ReaderName = _securityContext.GetCurrentUserName();
      message.ReadIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

      await _messageRepository.UpdateAsync(message);
      return true;
    }

    /// <summary>
    /// 标记所有消息为已读
    /// </summary>
    public async Task<bool> MarkAllAsReadAsync(long userId)
    {
      var messages = await _messageRepository.GetListAsync(x => x.ReceiverId == userId && x.IsRead == 0);
      foreach (var message in messages)
      {
        message.IsRead = 1; // 已读
        message.ReadTime = DateTime.Now;
        message.ReaderId = _securityContext.GetCurrentUserId();
        message.ReaderName = _securityContext.GetCurrentUserName();
        message.ReadIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        await _messageRepository.UpdateAsync(message);
      }
      return true;
    }

    /// <summary>
    /// 删除消息
    /// </summary>
    public async Task<bool> DeleteAsync(KpOnlineMessageDeleteDto input)
    {
      var message = await _messageRepository.GetByIdAsync(input.Id);
      if (message == null) return false;

      await _messageRepository.DeleteAsync(message.Id);
      return true;
    }

    /// <summary>
    /// 导出消息列表
    /// </summary>
    public async Task<List<KpOnlineMessageExportDto>> ExportListAsync(KpOnlineMessageQueryDto query)
    {
      var predicate = Expressionable.Create<KpOnlineMessage>()
        .AndIF(query.SenderId.HasValue, it => it.SenderId == query.SenderId)
        .AndIF(query.ReceiverId.HasValue, it => it.ReceiverId == query.ReceiverId)
        .AndIF(query.MessageType.HasValue, it => it.MessageType == query.MessageType)
        .AndIF(query.IsRead.HasValue, it => it.IsRead == query.IsRead)
        .AndIF(query.StartTime.HasValue, it => it.SendTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.SendTime <= query.EndTime);

      var messages = await _messageRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpOnlineMessageExportDto>>(messages);
    }
  }
}