// -----------------------------------------------------------------------
// <copyright file="KpLoginEnv.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录环境实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 登录环境实体
  /// </summary>
  [SugarTable("kp_aa_login_env", "登录环境")]
  [SugarIndex("idx_login_env_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_login_env_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_login_env_login_time", nameof(LoginTime), OrderByType.Asc)]
  public class KpLoginEnv : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = false)]
    public long UserId { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [SugarColumn(ColumnName = "login_time", ColumnDataType = "datetime", ColumnDescription = "登录时间", IsNullable = false)]
    public DateTime LoginTime { get; set; }

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
    /// 浏览器信息
    /// </summary>
    [SugarColumn(ColumnName = "browser_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "浏览器信息", IsNullable = true)]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [SugarColumn(ColumnName = "os_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "操作系统信息", IsNullable = true)]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 网络信息
    /// </summary>
    [SugarColumn(ColumnName = "network_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "网络信息", IsNullable = true)]
    public string? NetworkInfo { get; set; }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    [SugarColumn(ColumnName = "location_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "地理位置信息", IsNullable = true)]
    public string? LocationInfo { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [SugarColumn(ColumnName = "custom_data", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "自定义数据", IsNullable = true)]
    public string? CustomData { get; set; }

    #region 导航属性
    /// <summary>
    /// 登录设备信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(DeviceId))]
    public KpLoginDev? Device { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [SugarColumn(ColumnName = "device_id", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备ID", IsNullable = true)]
    public string? DeviceId { get; set; }
    #endregion
  }
}