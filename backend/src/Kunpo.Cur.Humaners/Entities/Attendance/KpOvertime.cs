/******************************************************************************
 * 文件名称：KpOvertime.cs
 * 文件描述：加班记录实体类
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
  /// 加班记录实体类
  /// </summary>
  [SugarTable("kp_hr_overtime", "加班记录")]
  [SugarIndex("idx_overtime_employee", nameof(EmployeeCode), OrderByType.Asc)]
  public class KpOvertime : KpBaseEntity
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
    /// 加班类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "overtime_type", ColumnDescription = "加班类型", IsNullable = false)]
    public int OvertimeType { get; set; }

    /// <summary>
    /// 加班状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "overtime_status", ColumnDescription = "加班状态", IsNullable = false)]
    public int OvertimeStatus { get; set; }

    /// <summary>
    /// 加班事由
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "overtime_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "加班事由", IsNullable = false)]
    public string? OvertimeReason { get; set; }
    #endregion

    #region 加班时间
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
    /// 加班时长(小时)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "overtime_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "加班时长(小时)", IsNullable = false)]
    public decimal OvertimeHours { get; set; }

    /// <summary>
    /// 加班天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "overtime_days", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "加班天数", IsNullable = false)]
    public decimal OvertimeDays { get; set; }
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
    /// 是否调休
    /// </summary>
    [SugarColumn(ColumnName = "is_compensatory", ColumnDescription = "是否调休", IsNullable = false, DefaultValue = "0")]
    public bool IsCompensatory { get; set; }

    /// <summary>
    /// 是否计薪
    /// </summary>
    [SugarColumn(ColumnName = "is_paid", ColumnDescription = "是否计薪", IsNullable = false, DefaultValue = "0")]
    public bool IsPaid { get; set; }

    /// <summary>
    /// 是否紧急
    /// </summary>
    [SugarColumn(ColumnName = "is_urgent", ColumnDescription = "是否紧急", IsNullable = false, DefaultValue = "0")]
    public bool IsUrgent { get; set; }

    /// <summary>
    /// 加班地点
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "overtime_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "加班地点", IsNullable = true)]
    public string? OvertimeLocation { get; set; }

    /// <summary>
    /// 加班备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "overtime_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "加班备注", IsNullable = true)]
    public string? OvertimeRemarks { get; set; }
    #endregion
  }
}