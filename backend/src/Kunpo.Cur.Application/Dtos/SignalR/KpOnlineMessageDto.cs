// -----------------------------------------------------------------------
// <copyright file="KpOnlineMessageDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线消息数据传输对象</summary>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Dtos.SignalR
{
  /// <summary>
  /// 在线消息数据传输对象
  /// </summary>
  public class KpOnlineMessageDto
  {
    /// <summary>
    /// 消息ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 发送者ID
    /// </summary>
    public long SenderId { get; set; }

    /// <summary>
    /// 发送者名称
    /// </summary>
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// 发送者头像
    /// </summary>
    public string? SenderAvatar { get; set; }

    /// <summary>
    /// 接收者ID
    /// </summary>
    public long ReceiverId { get; set; }

    /// <summary>
    /// 接收者名称
    /// </summary>
    public string ReceiverName { get; set; } = string.Empty;

    /// <summary>
    /// 接收者头像
    /// </summary>
    public string? ReceiverAvatar { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 消息类型（1：文本，2：图片，3：文件，4：系统通知）
    /// </summary>
    public int MessageType { get; set; }

    /// <summary>
    /// 是否已读（0：未读，1：已读，2：已撤销）
    /// </summary>
    public int IsRead { get; set; }

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    public DateTime SendTime { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    public DateTime? ReadTime { get; set; }

    /// <summary>
    /// 阅读者ID
    /// </summary>
    public long? ReaderId { get; set; }

    /// <summary>
    /// 阅读者名称
    /// </summary>
    public string? ReaderName { get; set; }

    /// <summary>
    /// 阅读IP
    /// </summary>
    public string? ReadIp { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除原因
    /// </summary>
    public string? DeleteReason { get; set; }

    /// <summary>
    /// 撤销时间
    /// </summary>
    public DateTime? RevokeTime { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    public string? RevokeReason { get; set; }
  }

  /// <summary>
  /// 在线消息查询数据传输对象
  /// </summary>
  public class KpOnlineMessageQueryDto : KpPageRequest
  {
    /// <summary>
    /// 发送者ID
    /// </summary>
    public long? SenderId { get; set; }

    /// <summary>
    /// 接收者ID
    /// </summary>
    public long? ReceiverId { get; set; }

    /// <summary>
    /// 消息类型（1：文本，2：图片，3：文件，4：系统通知）
    /// </summary>
    public int? MessageType { get; set; }

    /// <summary>
    /// 是否已读（0：未读，1：已读，2：已撤销）
    /// </summary>
    public int? IsRead { get; set; }

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }
  }

  /// <summary>
  /// 在线消息创建数据传输对象
  /// </summary>
  public class KpOnlineMessageCreateDto
  {
    /// <summary>
    /// 接收者ID
    /// </summary>
    [Required(ErrorMessage = "接收者ID不能为空")]
    public long ReceiverId { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [Required(ErrorMessage = "消息内容不能为空")]
    [StringLength(2000, ErrorMessage = "消息内容长度不能超过2000个字符")]
    public string MessageContent { get; set; } = string.Empty;

    /// <summary>
    /// 消息类型（1：文本，2：图片，3：文件，4：系统通知）
    /// </summary>
    [Required(ErrorMessage = "消息类型不能为空")]
    public int MessageType { get; set; }
  }

  /// <summary>
  /// 在线消息更新数据传输对象
  /// </summary>
  public class KpOnlineMessageUpdateDto
  {
    /// <summary>
    /// 消息ID
    /// </summary>
    [Required(ErrorMessage = "消息ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [StringLength(2000, ErrorMessage = "消息内容长度不能超过2000个字符")]
    public string? Content { get; set; }

    /// <summary>
    /// 是否已读（0：未读，1：已读，2：已撤销）
    /// </summary>
    public int? IsRead { get; set; }

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// 删除原因
    /// </summary>
    [StringLength(200, ErrorMessage = "删除原因长度不能超过200个字符")]
    public string? DeleteReason { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    [StringLength(200, ErrorMessage = "撤销原因长度不能超过200个字符")]
    public string? RevokeReason { get; set; }
  }

  /// <summary>
  /// 在线消息删除数据传输对象
  /// </summary>
  public class KpOnlineMessageDeleteDto
  {
    /// <summary>
    /// 消息ID
    /// </summary>
    [Required(ErrorMessage = "消息ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 删除原因
    /// </summary>
    [StringLength(200, ErrorMessage = "删除原因长度不能超过200个字符")]
    public string? DeleteReason { get; set; }
  }

  /// <summary>
  /// 在线消息导出数据传输对象
  /// </summary>
  public class KpOnlineMessageExportDto
  {
    /// <summary>
    /// 消息ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 发送者ID
    /// </summary>
    public long SenderId { get; set; }

    /// <summary>
    /// 发送者名称
    /// </summary>
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// 发送者头像
    /// </summary>
    public string? SenderAvatar { get; set; }

    /// <summary>
    /// 接收者ID
    /// </summary>
    public long ReceiverId { get; set; }

    /// <summary>
    /// 接收者名称
    /// </summary>
    public string ReceiverName { get; set; } = string.Empty;

    /// <summary>
    /// 接收者头像
    /// </summary>
    public string? ReceiverAvatar { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 消息类型（1：文本，2：图片，3：文件，4：系统通知）
    /// </summary>
    public int MessageType { get; set; }

    /// <summary>
    /// 是否已读（0：未读，1：已读，2：已撤销）
    /// </summary>
    public int IsRead { get; set; }

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    public DateTime SendTime { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    public DateTime? ReadTime { get; set; }

    /// <summary>
    /// 阅读者ID
    /// </summary>
    public long? ReaderId { get; set; }

    /// <summary>
    /// 阅读者名称
    /// </summary>
    public string? ReaderName { get; set; }

    /// <summary>
    /// 阅读IP
    /// </summary>
    public string? ReadIp { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除原因
    /// </summary>
    public string? DeleteReason { get; set; }

    /// <summary>
    /// 撤销时间
    /// </summary>
    public DateTime? RevokeTime { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    public string? RevokeReason { get; set; }
  }
}