// -----------------------------------------------------------------------
// <copyright file="KpLoginLog.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 登录日志实体
  /// </summary>
  [SugarTable("kp_aa_login_log", "登录日志")]
  [SugarIndex("idx_login_log_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_login_log_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_login_log_login_time", nameof(LoginTime), OrderByType.Asc)]
  public class KpLoginLog : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    /// <remarks>
    /// 关联用户表(kp_user)的主键
    /// </remarks>
    [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = false)]
    public long UserId { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    /// <remarks>
    /// 关联用户表(kp_user)的userName字段
    /// </remarks>
    [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名称", IsNullable = false)]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 登录时间
    /// </summary>
    [SugarColumn(ColumnName = "login_time", ColumnDataType = "datetime", ColumnDescription = "登录时间", IsNullable = false)]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    /// <remarks>
    /// 0：未知，1：账号密码，2：手机验证码，3：邮箱验证码，4：第三方登录，5：其他，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "login_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "登录类型", IsNullable = false)]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "login_status", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "登录状态", IsNullable = false)]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [SugarColumn(ColumnName = "login_message", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "登录消息", IsNullable = true)]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    /// <remarks>
    /// 关联设备信息表(kp_login_device)的主键
    /// </remarks>
    [SugarColumn(ColumnName = "device_id", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备ID", IsNullable = true)]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    [SugarColumn(ColumnName = "login_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "登录IP", IsNullable = true)]
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    [SugarColumn(ColumnName = "login_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "登录地点", IsNullable = true)]
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录浏览器
    /// </summary>
    [SugarColumn(ColumnName = "login_browser", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "登录浏览器", IsNullable = true)]
    public string? LoginBrowser { get; set; }

    /// <summary>
    /// 登录操作系统
    /// </summary>
    [SugarColumn(ColumnName = "login_os", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "登录操作系统", IsNullable = true)]
    public string? LoginOs { get; set; }

    /// <summary>
    /// 环境ID
    /// </summary>
    [SugarColumn(ColumnName = "env_id", ColumnDataType = "int", ColumnDescription = "环境ID", IsNullable = true)]
    public long? EnvId { get; set; }

    #region 导航属性
    /// <summary>
    /// 登录设备信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(DeviceId))]
    public KpLoginDev? Device { get; set; }

    /// <summary>
    /// 登录环境信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(EnvId))]
    public KpLoginEnv? Environment { get; set; }
    #endregion
  }
}