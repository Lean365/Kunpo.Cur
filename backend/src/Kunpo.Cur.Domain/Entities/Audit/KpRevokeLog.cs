// -----------------------------------------------------------------------
// <copyright file="KpRevokeLog.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>撤销日志实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Audit
{
  /// <summary>
  /// 撤销日志实体
  /// </summary>
  [SugarTable("kp_aa_revoke_log", "撤销日志")]
  [SugarIndex("idx_revoke_log_tenant_id", nameof(TenantId), OrderByType.Asc)]
  [SugarIndex("idx_revoke_log_user_id", nameof(UserId), OrderByType.Asc)]
  [SugarIndex("idx_revoke_log_revoke_time", nameof(RevokeTime), OrderByType.Asc)]
  public class KpRevokeLog : KpBaseEntity
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
    /// 业务类型
    /// </summary>
    /// <remarks>
    /// 0：预算审核，1：预算撤销，2：费用审核，3：费用撤销，4：合同审核，5：合同撤销，6：采购审核，7：采购撤销
    /// </remarks>
    [SugarColumn(ColumnName = "business_type", ColumnDataType = "int", ColumnDescription = "业务类型", IsNullable = false)]
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    /// <remarks>
    /// 0,1：预算表(kp_budget)，2,3：费用表(kp_expense)，4,5：合同表(kp_contract)，6,7：采购表(kp_purchase)
    /// </remarks>
    [SugarColumn(ColumnName = "business_id", ColumnDataType = "int", ColumnDescription = "业务ID", IsNullable = false)]
    public long BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    [SugarColumn(ColumnName = "business_no", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "业务编号", IsNullable = false)]
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    [SugarColumn(ColumnName = "business_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "业务标题", IsNullable = false)]
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    [SugarColumn(ColumnName = "revoke_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "撤销原因", IsNullable = true)]
    public string? RevokeReason { get; set; }

    /// <summary>
    /// 撤销时间
    /// </summary>
    [SugarColumn(ColumnName = "revoke_time", ColumnDataType = "datetime", ColumnDescription = "撤销时间", IsNullable = false)]
    public DateTime RevokeTime { get; set; }

    /// <summary>
    /// 撤销IP
    /// </summary>
    [SugarColumn(ColumnName = "revoke_ip", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "撤销IP", IsNullable = true)]
    public string? RevokeIp { get; set; }

    /// <summary>
    /// 撤销地点
    /// </summary>
    [SugarColumn(ColumnName = "revoke_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "撤销地点", IsNullable = true)]
    public string? RevokeLocation { get; set; }

    /// <summary>
    /// 撤销状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "revoke_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "撤销状态", IsNullable = false)]
    public int RevokeStatus { get; set; }

    /// <summary>
    /// 撤销消息
    /// </summary>
    [SugarColumn(ColumnName = "revoke_message", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "撤销消息", IsNullable = true)]
    public string? RevokeMessage { get; set; }

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