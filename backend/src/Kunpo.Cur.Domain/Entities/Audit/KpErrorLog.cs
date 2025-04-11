// -----------------------------------------------------------------------
// <copyright file="KpErrorLog.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>异常日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 错误日志实体
  /// </summary>
  [SugarTable("kp_aa_error_log", "错误日志")]
  [SugarIndex("idx_error_log_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_error_log_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_error_log_error_time", nameof(ErrorTime), OrderByType.Asc)]
  public class KpErrorLog : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = true)]
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名", IsNullable = true)]
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    /// <remarks>
    /// 0：系统错误，1：业务错误，2：权限错误，3：数据错误，4：其他错误，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "error_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "错误类型", IsNullable = false)]
    public int ErrorType { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    [SugarColumn(ColumnName = "error_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "错误代码", IsNullable = true)]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    [SugarColumn(ColumnName = "error_message", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "错误消息", IsNullable = true)]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [SugarColumn(ColumnName = "error_detail", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "错误详情", IsNullable = true)]
    public string? ErrorDetail { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [SugarColumn(ColumnName = "error_stack", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "错误堆栈", IsNullable = true)]
    public string? ErrorStack { get; set; }

    /// <summary>
    /// 错误来源
    /// </summary>
    [SugarColumn(ColumnName = "error_source", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "错误来源", IsNullable = true)]
    public string? ErrorSource { get; set; }

    /// <summary>
    /// 错误时间
    /// </summary>
    [SugarColumn(ColumnName = "error_time", ColumnDataType = "datetime", ColumnDescription = "错误时间", IsNullable = false)]
    public DateTime ErrorTime { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    [SugarColumn(ColumnName = "error_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "错误IP", IsNullable = true)]
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 错误地点
    /// </summary>
    [SugarColumn(ColumnName = "error_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "错误地点", IsNullable = true)]
    public string? ErrorLocation { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [SugarColumn(ColumnName = "request_url", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "请求URL", IsNullable = true)]
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [SugarColumn(ColumnName = "request_method", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "请求方法", IsNullable = true)]
    public string? RequestMethod { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [SugarColumn(ColumnName = "request_params", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "请求参数", IsNullable = true)]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    [SugarColumn(ColumnName = "request_headers", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "请求头", IsNullable = true)]
    public string? RequestHeaders { get; set; }

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
    /// 设备信息
    /// </summary>
    [SugarColumn(ColumnName = "device_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "设备信息", IsNullable = true)]
    public string? DeviceInfo { get; set; }
  }
}