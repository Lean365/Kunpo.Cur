// -----------------------------------------------------------------------
// <copyright file="KpSqlDiff.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>SQL差异日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// SQL差异实体
  /// </summary>
  [SugarTable("kp_aa_sql_diff", "SQL差异")]
  [SugarIndex("idx_sql_diff_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_sql_diff_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_sql_diff_oper_time", nameof(OperTime), OrderByType.Asc)]
  public class KpSqlDiff : KpBaseEntity
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = false)]
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名", IsNullable = false)]
    public string? UserName { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    /// <remarks>
    /// 0：新增，1：修改，2：删除，3：查询，4：导入，5：导出，6：其他，默认为6
    /// </remarks>
    [SugarColumn(ColumnName = "oper_type", ColumnDataType = "int", DefaultValue = "6", ColumnDescription = "操作类型", IsNullable = false)]
    public int OperType { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [SugarColumn(ColumnName = "oper_module", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "操作模块", IsNullable = true)]
    public string? OperModule { get; set; }

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
    /// 操作时间
    /// </summary>
    [SugarColumn(ColumnName = "oper_time", ColumnDataType = "datetime", ColumnDescription = "操作时间", IsNullable = false)]
    public DateTime OperTime { get; set; }

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
    /// 表名
    /// </summary>
    [SugarColumn(ColumnName = "table_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "表名", IsNullable = false)]
    public string? TableName { get; set; }

    /// <summary>
    /// 主键值
    /// </summary>
    [SugarColumn(ColumnName = "primary_key", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "主键值", IsNullable = false)]
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// 字段名
    /// </summary>
    [SugarColumn(ColumnName = "field_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "字段名", IsNullable = false)]
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    [SugarColumn(ColumnName = "field_description", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字段描述", IsNullable = true)]
    public string? FieldDescription { get; set; }

    /// <summary>
    /// 原值
    /// </summary>
    [SugarColumn(ColumnName = "original_value", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "原值", IsNullable = true)]
    public string? OriginalValue { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    [SugarColumn(ColumnName = "new_value", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "新值", IsNullable = true)]
    public string? NewValue { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    [SugarColumn(ColumnName = "field_type", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "字段类型", IsNullable = true)]
    public string? FieldType { get; set; }

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
  }
}