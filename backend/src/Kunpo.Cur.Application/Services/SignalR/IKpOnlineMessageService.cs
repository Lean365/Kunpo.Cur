// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线消息服务接口</summary>
// -----------------------------------------------------------------------
using Kunpo.Cur.Domain.Entities.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.SignalR
{
  /// <summary>
  /// 在线消息服务接口
  /// </summary>
  public interface IKpOnlineMessageService
  {
    /// <summary>
    /// 获取消息
    /// </summary>
    /// <param name="messageId">消息ID</param>
    /// <returns>消息信息</returns>
    Task<KpOnlineMessageDto?> GetAsync(long messageId);

    /// <summary>
    /// 获取消息列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>消息列表</returns>
    Task<KpPageResult<KpOnlineMessageDto>> GetListAsync(KpOnlineMessageQueryDto query);

    /// <summary>
    /// 获取所有消息
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>消息列表</returns>
    Task<List<KpOnlineMessageDto>> GetAllMessagesAsync(long userId);

    /// <summary>
    /// 获取未读消息
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>未读消息列表</returns>
    Task<List<KpOnlineMessageDto>> GetUnreadMessagesAsync(long userId);

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="input">消息信息</param>
    /// <returns>消息ID</returns>
    Task<long> SendMessageAsync(KpOnlineMessageCreateDto input);

    /// <summary>
    /// 创建消息
    /// </summary>
    /// <param name="input">消息信息</param>
    /// <returns>消息ID</returns>
    Task<long> CreateAsync(KpOnlineMessageCreateDto input);

    /// <summary>
    /// 更新消息
    /// </summary>
    /// <param name="input">消息信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpOnlineMessageUpdateDto input);

    /// <summary>
    /// 标记消息为已读
    /// </summary>
    /// <param name="messageId">消息ID</param>
    /// <returns>是否成功</returns>
    Task<bool> MarkAsReadAsync(long messageId);

    /// <summary>
    /// 标记所有消息为已读
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>是否成功</returns>
    Task<bool> MarkAllAsReadAsync(long userId);

    /// <summary>
    /// 删除消息
    /// </summary>
    /// <param name="input">消息信息</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(KpOnlineMessageDeleteDto input);

    /// <summary>
    /// 导出消息列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>消息列表</returns>
    Task<List<KpOnlineMessageExportDto>> ExportListAsync(KpOnlineMessageQueryDto query);
  }
}