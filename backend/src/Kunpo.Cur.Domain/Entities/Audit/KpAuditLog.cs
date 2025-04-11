// -----------------------------------------------------------------------
// <copyright file="KpAuditLog.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>业务审计日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 业务审计日志实体
  /// </summary>
  [SugarTable("kp_aa_audit_log", "财务预算审核日志")]
  [SugarIndex("idx_audit_log_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_audit_log_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_audit_log_business_id", nameof(BusinessId), OrderByType.Asc)]
  [SugarIndex("idx_audit_log_audit_status", nameof(AuditStatus), OrderByType.Asc)]
  public class KpAuditLog : KpBaseEntity
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
    /// 业务类型
    /// </summary>
    /// <remarks>
    /// 0：预算审核，1：预算撤销，2：报销审核，3：报销撤销，4：合同审核，5：合同撤销，6：采购审核，7：采购撤销，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "business_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "业务类型", IsNullable = false)]
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    /// <remarks>
    /// 关联业务表的主键，根据业务类型关联不同的表：
    /// 0,1：预算表(kp_budget)
    /// 2,3：报销表(kp_expense)
    /// 4,5：合同表(kp_contract)
    /// 6,7：采购表(kp_purchase)
    /// </remarks>
    [SugarColumn(ColumnName = "business_id", ColumnDataType = "int", ColumnDescription = "业务ID", IsNullable = false)]
    public long BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    [SugarColumn(ColumnName = "business_no", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "预算编号", IsNullable = true)]
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    [SugarColumn(ColumnName = "business_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "预算标题", IsNullable = true)]
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 审核类型
    /// </summary>
    /// <remarks>
    /// 0：提交，1：同意，2：拒绝，3：退回，4：转交，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "audit_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "审核类型", IsNullable = false)]
    public int AuditType { get; set; }

    /// <summary>
    /// 审核意见
    /// </summary>
    [SugarColumn(ColumnName = "audit_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "审核意见", IsNullable = true)]
    public string? AuditComment { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    /// <remarks>
    /// 0：待审核，1：审核中，2：已通过，3：已拒绝，4：已退回，5：已转交，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "audit_status", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "审核状态", IsNullable = false)]
    public int AuditStatus { get; set; }

    /// <summary>
    /// 审核人ID
    /// </summary>
    [SugarColumn(ColumnName = "auditor_id", ColumnDataType = "int", ColumnDescription = "审核人ID", IsNullable = true)]
    public long? AuditorId { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    [SugarColumn(ColumnName = "auditor", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "审核人", IsNullable = true)]
    public string? Auditor { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    [SugarColumn(ColumnName = "audit_time", ColumnDataType = "datetime", ColumnDescription = "审核时间", IsNullable = true)]
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核IP
    /// </summary>
    [SugarColumn(ColumnName = "audit_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "审核IP", IsNullable = true)]
    public string? AuditIp { get; set; }

    /// <summary>
    /// 审核地点
    /// </summary>
    [SugarColumn(ColumnName = "audit_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "审核地点", IsNullable = true)]
    public string? AuditLocation { get; set; }

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
    /// 操作时间
    /// </summary>
    [SugarColumn(ColumnName = "oper_time", ColumnDataType = "datetime", ColumnDescription = "操作时间", IsNullable = false)]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 附件列表
    /// </summary>
    [SugarColumn(ColumnName = "attachments", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "附件列表", IsNullable = true)]
    public string? Attachments { get; set; }

    /// <summary>
    /// 服务名称
    /// </summary>
    [SugarColumn(ColumnName = "service_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "服务名称", IsNullable = false)]
    public string? ServiceName { get; set; }

    /// <summary>
    /// 方法名称
    /// </summary>
    [SugarColumn(ColumnName = "method_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "方法名称", IsNullable = false)]
    public string? MethodName { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    [SugarColumn(ColumnName = "parameters", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "参数", IsNullable = true)]
    public string? Parameters { get; set; }

    /// <summary>
    /// 返回值
    /// </summary>
    [SugarColumn(ColumnName = "return_value", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "返回值", IsNullable = true)]
    public string? ReturnValue { get; set; }

    /// <summary>
    /// 执行时间
    /// </summary>
    [SugarColumn(ColumnName = "execution_time", ColumnDataType = "datetime", ColumnDescription = "执行时间", IsNullable = false)]
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// 执行时长
    /// </summary>
    [SugarColumn(ColumnName = "execution_duration", ColumnDataType = "int", ColumnDescription = "执行时长", IsNullable = false)]
    public int ExecutionDuration { get; set; }

    /// <summary>
    /// 客户端IP
    /// </summary>
    [SugarColumn(ColumnName = "client_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "客户端IP", IsNullable = true)]
    public string? ClientIp { get; set; }

    /// <summary>
    /// 客户端名称
    /// </summary>
    [SugarColumn(ColumnName = "client_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "客户端名称", IsNullable = true)]
    public string? ClientName { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [SugarColumn(ColumnName = "browser_info", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "浏览器信息", IsNullable = true)]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    [SugarColumn(ColumnName = "exception", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "异常信息", IsNullable = true)]
    public string? Exception { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [SugarColumn(ColumnName = "custom_data", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "自定义数据", IsNullable = true)]
    public string? CustomData { get; set; }
  }
}