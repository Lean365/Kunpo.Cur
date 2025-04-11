// -----------------------------------------------------------------------
// <copyright file="KpOnlineUserDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线用户数据传输对象</summary>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Dtos.SignalR
{
  /// <summary>
  /// 在线用户数据传输对象
  /// </summary>
  public class KpOnlineUserDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 用户头像
    /// </summary>
    public string? UserAvatar { get; set; }

    /// <summary>
    /// 设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）
    /// </summary>
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 连接ID
    /// </summary>
    public string? ConnectionId { get; set; }

    /// <summary>
    /// 是否在线
    /// </summary>
    public bool IsOnline { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    public string? LoginIp { get; set; }

    /// <summary>
    /// 最后活动时间
    /// </summary>
    public DateTime LastActiveTime { get; set; }
  }

  /// <summary>
  /// 在线用户查询数据传输对象
  /// </summary>
  public class KpOnlineUserQueryDto : KpPageRequest
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）
    /// </summary>
    public int? DeviceType { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 是否在线（0：离线，1：在线，2：忙碌，3：离开）
    /// </summary>
    public int? IsOnline { get; set; }

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
  /// 在线用户创建数据传输对象
  /// </summary>
  public class KpOnlineUserCreateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 连接ID
    /// </summary>
    [Required(ErrorMessage = "连接ID不能为空")]
    public string ConnectionId { get; set; } = string.Empty;

    /// <summary>
    /// 设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）
    /// </summary>
    [Required(ErrorMessage = "设备类型不能为空")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [Required(ErrorMessage = "设备ID不能为空")]
    [StringLength(50, ErrorMessage = "设备ID长度不能超过50个字符")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(50, ErrorMessage = "设备名称长度不能超过50个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [StringLength(50, ErrorMessage = "设备型号长度不能超过50个字符")]
    public string? DeviceModel { get; set; }
  }

  /// <summary>
  /// 在线用户更新数据传输对象
  /// </summary>
  public class KpOnlineUserUpdateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 连接ID
    /// </summary>
    [Required(ErrorMessage = "连接ID不能为空")]
    public string ConnectionId { get; set; } = string.Empty;

    /// <summary>
    /// 设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）
    /// </summary>
    [Required(ErrorMessage = "设备类型不能为空")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [Required(ErrorMessage = "设备ID不能为空")]
    [StringLength(50, ErrorMessage = "设备ID长度不能超过50个字符")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(50, ErrorMessage = "设备名称长度不能超过50个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [StringLength(50, ErrorMessage = "设备型号长度不能超过50个字符")]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 是否在线（0：离线，1：在线，2：忙碌，3：离开）
    /// </summary>
    [Required(ErrorMessage = "在线状态不能为空")]
    public int IsOnline { get; set; }
  }

  /// <summary>
  /// 在线用户删除数据传输对象
  /// </summary>
  public class KpOnlineUserDeleteDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }
  }

  /// <summary>
  /// 在线用户导出数据传输对象
  /// </summary>
  public class KpOnlineUserExportDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 用户头像
    /// </summary>
    public string? UserAvatar { get; set; }

    /// <summary>
    /// 设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）
    /// </summary>
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 是否在线
    /// </summary>
    public bool IsOnline { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    public string? LoginIp { get; set; }

    /// <summary>
    /// 最后活动时间
    /// </summary>
    public DateTime LastActiveTime { get; set; }
  }
}