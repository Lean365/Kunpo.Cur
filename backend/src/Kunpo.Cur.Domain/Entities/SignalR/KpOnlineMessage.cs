// -----------------------------------------------------------------------
// <copyright file="KpOnlineMessage.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线消息实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Domain.Entities.SignalR
{
  /// <summary>
  /// 在线消息实体
  /// </summary>
  /// <remarks>
  /// 创建时间：2024-04-04
  /// 创建人：Kunpo
  /// </remarks>
  [SugarTable("kp_online_message")]
  public class KpOnlineMessage : KpBaseEntity
  {
    /// <summary>
    /// 发送者ID
    /// </summary>
    [SugarColumn(ColumnName = "sender_id", ColumnDescription = "发送者ID")]
    public long SenderId { get; set; }

    /// <summary>
    /// 发送者名称
    /// </summary>
    [SugarColumn(ColumnName = "sender_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "发送者名称")]
    public string? SenderName { get; set; }

    /// <summary>
    /// 发送者头像
    /// </summary>
    [SugarColumn(ColumnName = "sender_avatar", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "发送者头像", IsNullable = true)]
    public string? SenderAvatar { get; set; }

    /// <summary>
    /// 接收者ID
    /// </summary>
    [SugarColumn(ColumnName = "receiver_id", ColumnDescription = "接收者ID")]
    public long ReceiverId { get; set; }

    /// <summary>
    /// 接收者名称
    /// </summary>
    [SugarColumn(ColumnName = "receiver_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "接收者名称")]
    public string? ReceiverName { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    [SugarColumn(ColumnName = "message_type", ColumnDataType = "int", ColumnDescription = "消息类型：1-文本，2-图片，3-文件，4-系统通知")]
    public int MessageType { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [SugarColumn(ColumnName = "message_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "消息内容")]
    public string? MessageContent { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    [SugarColumn(ColumnName = "send_time", ColumnDataType = "datetime", ColumnDescription = "发送时间")]
    public DateTime SendTime { get; set; }

    /// <summary>
    /// 是否已读
    /// </summary>
    [SugarColumn(ColumnName = "is_read", ColumnDataType = "int", ColumnDescription = "是否已读：0-未读，1-已读，2-已撤回")]
    public int IsRead { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    [SugarColumn(ColumnName = "read_time", ColumnDataType = "datetime", ColumnDescription = "阅读时间", IsNullable = true)]
    public DateTime? ReadTime { get; set; }

    /// <summary>
    /// 阅读者ID
    /// </summary>
    [SugarColumn(ColumnName = "reader_id", ColumnDataType = "bigint", ColumnDescription = "阅读者ID", IsNullable = true)]
    public long? ReaderId { get; set; }

    /// <summary>
    /// 阅读者名称
    /// </summary>
    [SugarColumn(ColumnName = "reader_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "阅读者名称", IsNullable = true)]
    public string? ReaderName { get; set; }

    /// <summary>
    /// 阅读IP
    /// </summary>
    [SugarColumn(ColumnName = "read_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "阅读IP", IsNullable = true)]
    public string? ReadIp { get; set; }


  }
}