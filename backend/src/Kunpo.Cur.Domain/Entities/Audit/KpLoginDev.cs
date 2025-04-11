// -----------------------------------------------------------------------
// <copyright file="KpLoginDevice.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录设备实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 登录设备实体
  /// </summary>
  [SugarTable("kp_aa_login_device", "登录设备")]
  [SugarIndex("idx_login_device_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_login_device_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_login_device_device_id", nameof(DeviceId), OrderByType.Asc)]
  public class KpLoginDev : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = false)]
    public long UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [SugarColumn(ColumnName = "device_id", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备ID", IsNullable = false)]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [SugarColumn(ColumnName = "device_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备名称", IsNullable = true)]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    /// <remarks>
    /// 0：未知，1：PC，2：手机，3：平板，4：其他，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "device_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "设备类型", IsNullable = false)]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备制造商
    /// </summary>
    [SugarColumn(ColumnName = "device_manufacturer", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备制造商", IsNullable = true)]
    public string? DeviceManufacturer { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [SugarColumn(ColumnName = "device_model", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "设备型号", IsNullable = true)]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    /// <remarks>
    /// 0：离线，1：在线，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "device_status", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "设备状态", IsNullable = false)]
    public int DeviceStatus { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [SugarColumn(ColumnName = "custom_data", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "自定义数据", IsNullable = true)]
    public string? CustomData { get; set; }

    #region 首次登录信息
    /// <summary>
    /// 首次登录时间
    /// </summary>
    [SugarColumn(ColumnName = "first_login_time", ColumnDataType = "datetime", ColumnDescription = "首次登录时间", IsNullable = true)]
    public DateTime? FirstLoginTime { get; set; }

    /// <summary>
    /// 首次登录环境ID
    /// </summary>
    [SugarColumn(ColumnName = "first_login_env_id", ColumnDataType = "int", ColumnDescription = "首次登录环境ID", IsNullable = true)]
    public long? FirstLoginEnvId { get; set; }
    #endregion

    #region 末次登录信息
    /// <summary>
    /// 末次登录时间
    /// </summary>
    [SugarColumn(ColumnName = "last_login_time", ColumnDataType = "datetime", ColumnDescription = "末次登录时间", IsNullable = true)]
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// 末次登录环境ID
    /// </summary>
    [SugarColumn(ColumnName = "last_login_env_id", ColumnDataType = "int", ColumnDescription = "末次登录环境ID", IsNullable = true)]
    public long? LastLoginEnvId { get; set; }
    #endregion

    #region 导航属性
    /// <summary>
    /// 首次登录环境信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(FirstLoginEnvId))]
    public KpLoginEnv? FirstLoginEnv { get; set; }

    /// <summary>
    /// 末次登录环境信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(LastLoginEnvId))]
    public KpLoginEnv? LastLoginEnv { get; set; }
    #endregion
  }
}