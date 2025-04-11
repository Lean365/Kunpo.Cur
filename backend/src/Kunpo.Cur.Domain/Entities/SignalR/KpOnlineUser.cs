// -----------------------------------------------------------------------
// <copyright file="KpOnlineUser.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线用户实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Domain.Entities.SignalR
{
  /// <summary>
  /// 在线用户实体
  /// </summary>
  /// <remarks>
  /// 创建时间：2024-04-04
  /// 创建人：Kunpo
  /// </remarks>
  [SugarTable("kp_online_user")]
  public class KpOnlineUser : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDescription = "用户ID")]
    public long UserId { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名称")]
    public string? UserName { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    [SugarColumn(ColumnName = "user_nick_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户昵称", IsNullable = true)]
    public string? UserNickName { get; set; }

    /// <summary>
    /// 用户头像
    /// </summary>
    [SugarColumn(ColumnName = "user_avatar", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "用户头像", IsNullable = true)]
    public string? UserAvatar { get; set; }

    /// <summary>
    /// 连接ID
    /// </summary>
    [SugarColumn(ColumnName = "connection_id", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "连接ID")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [SugarColumn(ColumnName = "device_id", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "设备ID")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    [SugarColumn(ColumnName = "device_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "设备名称")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    [SugarColumn(ColumnName = "device_type", ColumnDataType = "int", ColumnDescription = "设备类型：1-Web，2-Android，3-iOS，4-Windows，5-Mac，6-Linux")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [SugarColumn(ColumnName = "device_model", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "设备型号")]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    [SugarColumn(ColumnName = "browser", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "浏览器")]
    public string? Browser { get; set; }

    /// <summary>
    /// 操作系统
    /// </summary>
    [SugarColumn(ColumnName = "os", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "操作系统")]
    public string? Os { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    [SugarColumn(ColumnName = "ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "IP地址")]
    public string? Ip { get; set; }

    /// <summary>
    /// 地理位置
    /// </summary>
    [SugarColumn(ColumnName = "location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "地理位置")]
    public string? Location { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [SugarColumn(ColumnName = "login_time", ColumnDataType = "datetime", ColumnDescription = "登录时间")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 最后活动时间
    /// </summary>
    [SugarColumn(ColumnName = "last_activity_time", ColumnDataType = "datetime", ColumnDescription = "最后活动时间")]
    public DateTime LastActivityTime { get; set; }

    /// <summary>
    /// 会话ID
    /// </summary>
    [SugarColumn(ColumnName = "session_id", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "会话ID", IsNullable = true)]
    public string? SessionId { get; set; }

    /// <summary>
    /// 访问令牌
    /// </summary>
    [SugarColumn(ColumnName = "access_token", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "访问令牌", IsNullable = true)]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    [SugarColumn(ColumnName = "refresh_token", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "刷新令牌", IsNullable = true)]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    [SugarColumn(ColumnName = "expire_time", ColumnDataType = "datetime", ColumnDescription = "过期时间", IsNullable = true)]
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// 在线状态
    /// </summary>
    [SugarColumn(ColumnName = "is_online", ColumnDataType = "int", ColumnDescription = "在线状态：0-离线，1-在线，2-忙碌，3-离开")]
    public int IsOnline { get; set; }
  }
}