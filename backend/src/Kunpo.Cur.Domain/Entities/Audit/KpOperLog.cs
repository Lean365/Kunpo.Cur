// -----------------------------------------------------------------------
// <copyright file="KpOperLog.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>操作日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 操作日志实体
  /// </summary>
  [SugarTable("kp_aa_oper_log", "操作日志")]
  [SugarIndex("idx_oper_log_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_oper_log_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_oper_log_oper_time", nameof(OperTime), OrderByType.Asc)]
  public class KpOperLog : KpBaseEntity
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
    /// 用户名
    /// </summary>
    [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名", IsNullable = false)]
    public string? UserName { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [SugarColumn(ColumnName = "oper_module", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "操作模块", IsNullable = true)]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    /// <remarks>
    /// 0：新增，1：修改，2：删除，3：查询，4：导入，5：导出，6：其他，默认为6
    /// </remarks>
    [SugarColumn(ColumnName = "oper_type", ColumnDataType = "int", DefaultValue = "6", ColumnDescription = "操作类型", IsNullable = false)]
    public int OperType { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [SugarColumn(ColumnName = "oper_function", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "操作功能", IsNullable = true)]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [SugarColumn(ColumnName = "oper_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "操作描述", IsNullable = true)]
    public string? OperDescription { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true, ColumnDescription = "请求方法")]
    public string? Method { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [SugarColumn(Length = 500, IsNullable = true, ColumnDescription = "请求URL")]
    public string? Url { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [SugarColumn(ColumnName = "request_params", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "请求参数", IsNullable = true)]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 响应结果
    /// </summary>
    [SugarColumn(ColumnName = "response_result", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "响应结果", IsNullable = true)]
    public string? ResponseResult { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    [SugarColumn(ColumnName = "oper_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "操作IP", IsNullable = true)]
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    [SugarColumn(ColumnName = "oper_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "操作地点", IsNullable = true)]
    public string? OperLocation { get; set; }

    /// <summary>
    /// 操作状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "oper_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "操作状态", IsNullable = false)]
    public int OperStatus { get; set; }

    /// <summary>
    /// 操作消息
    /// </summary>
    [SugarColumn(ColumnName = "oper_message", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "操作消息", IsNullable = true)]
    public string? OperMessage { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    [SugarColumn(ColumnName = "error_message", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "错误信息", IsNullable = true)]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [SugarColumn(ColumnName = "error_stack", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "错误堆栈", IsNullable = true)]
    public string? ErrorStack { get; set; }

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

    /// <summary>
    /// 操作时间
    /// </summary>
    [SugarColumn(ColumnName = "oper_time", ColumnDataType = "datetime", ColumnDescription = "操作时间", IsNullable = false)]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 执行时长(毫秒)
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnDescription = "执行时长(毫秒)", DefaultValue = "0")]
    public long Duration { get; set; }
  }
}