/******************************************************************************
 * 文件名称：KpLeave.cs
 * 文件描述：请假记录实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Attendance
{
  /// <summary>
  /// 请假记录实体类
  /// </summary>
  [SugarTable("kp_hr_leave", "请假记录")]
  [SugarIndex("idx_leave_employee", nameof(EmployeeCode), OrderByType.Asc)]
  public class KpLeave : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 请假类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "leave_type", ColumnDescription = "请假类型", IsNullable = false)]
    public int LeaveType { get; set; }

    /// <summary>
    /// 请假状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "leave_status", ColumnDescription = "请假状态", IsNullable = false)]
    public int LeaveStatus { get; set; }

    /// <summary>
    /// 请假事由
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "leave_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "请假事由", IsNullable = false)]
    public string? LeaveReason { get; set; }
    #endregion

    #region 请假时间
    /// <summary>
    /// 开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "start_time", ColumnDataType = "datetime", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "end_time", ColumnDataType = "datetime", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 请假时长(小时)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "leave_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "请假时长(小时)", IsNullable = false)]
    public decimal LeaveHours { get; set; }

    /// <summary>
    /// 请假天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "leave_days", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "请假天数", IsNullable = false)]
    public decimal LeaveDays { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人", IsNullable = true)]
    public string? Approver { get; set; }

    /// <summary>
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDataType = "datetime", ColumnDescription = "审批时间", IsNullable = true)]
    public DateTime? ApprovalTime { get; set; }

    /// <summary>
    /// 审批意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "approval_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "审批意见", IsNullable = true)]
    public string? ApprovalComment { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否带薪
    /// </summary>
    [SugarColumn(ColumnName = "is_paid", ColumnDescription = "是否带薪", IsNullable = false, DefaultValue = "0")]
    public bool IsPaid { get; set; }

    /// <summary>
    /// 是否紧急
    /// </summary>
    [SugarColumn(ColumnName = "is_urgent", ColumnDescription = "是否紧急", IsNullable = false, DefaultValue = "0")]
    public bool IsUrgent { get; set; }

    /// <summary>
    /// 是否销假
    /// </summary>
    [SugarColumn(ColumnName = "is_canceled", ColumnDescription = "是否销假", IsNullable = false, DefaultValue = "0")]
    public bool IsCanceled { get; set; }

    /// <summary>
    /// 销假时间
    /// </summary>
    [SugarColumn(ColumnName = "cancel_time", ColumnDataType = "datetime", ColumnDescription = "销假时间", IsNullable = true)]
    public DateTime? CancelTime { get; set; }

    /// <summary>
    /// 请假备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "leave_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "请假备注", IsNullable = true)]
    public string? LeaveRemarks { get; set; }
    #endregion
  }
}