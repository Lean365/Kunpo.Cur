/******************************************************************************
 * 文件名称：KpAttendanceRule.cs
 * 文件描述：考勤规则实体类
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
  /// 考勤规则实体类
  /// </summary>
  [SugarTable("kp_hr_attendance_rule", "考勤规则")]
  [SugarIndex("idx_attendance_rule_code", nameof(RuleCode), OrderByType.Asc)]
  public class KpAttendanceRule : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 规则编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "rule_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "规则编码", IsNullable = false)]
    public string? RuleCode { get; set; }

    /// <summary>
    /// 规则名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "rule_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "规则名称", IsNullable = false)]
    public string? RuleName { get; set; }

    /// <summary>
    /// 规则类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "rule_type", ColumnDescription = "规则类型", IsNullable = false)]
    public int RuleType { get; set; }

    /// <summary>
    /// 规则状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "rule_status", ColumnDescription = "规则状态", IsNullable = false)]
    public int RuleStatus { get; set; }

    /// <summary>
    /// 规则描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "rule_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "规则描述", IsNullable = true)]
    public string? RuleDescription { get; set; }
    #endregion

    #region 工作时间
    /// <summary>
    /// 上班时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "work_start_time", ColumnDataType = "time", ColumnDescription = "上班时间", IsNullable = false)]
    public TimeSpan WorkStartTime { get; set; }

    /// <summary>
    /// 下班时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "work_end_time", ColumnDataType = "time", ColumnDescription = "下班时间", IsNullable = false)]
    public TimeSpan WorkEndTime { get; set; }

    /// <summary>
    /// 工作时长(小时)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "work_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "工作时长(小时)", IsNullable = false)]
    public decimal WorkHours { get; set; }

    /// <summary>
    /// 午休开始时间
    /// </summary>
    [SugarColumn(ColumnName = "lunch_start_time", ColumnDataType = "time", ColumnDescription = "午休开始时间", IsNullable = true)]
    public TimeSpan? LunchStartTime { get; set; }

    /// <summary>
    /// 午休结束时间
    /// </summary>
    [SugarColumn(ColumnName = "lunch_end_time", ColumnDataType = "time", ColumnDescription = "午休结束时间", IsNullable = true)]
    public TimeSpan? LunchEndTime { get; set; }

    /// <summary>
    /// 午休时长(小时)
    /// </summary>
    [SugarColumn(ColumnName = "lunch_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "午休时长(小时)", IsNullable = true)]
    public decimal? LunchHours { get; set; }
    #endregion

    #region 考勤规则
    /// <summary>
    /// 迟到时间(分钟)
    /// </summary>
    [SugarColumn(ColumnName = "late_minutes", ColumnDescription = "迟到时间(分钟)", IsNullable = true)]
    public int? LateMinutes { get; set; }

    /// <summary>
    /// 早退时间(分钟)
    /// </summary>
    [SugarColumn(ColumnName = "early_leave_minutes", ColumnDescription = "早退时间(分钟)", IsNullable = true)]
    public int? EarlyLeaveMinutes { get; set; }

    /// <summary>
    /// 旷工时间(小时)
    /// </summary>
    [SugarColumn(ColumnName = "absent_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "旷工时间(小时)", IsNullable = true)]
    public decimal? AbsentHours { get; set; }

    /// <summary>
    /// 加班开始时间
    /// </summary>
    [SugarColumn(ColumnName = "overtime_start_time", ColumnDataType = "time", ColumnDescription = "加班开始时间", IsNullable = true)]
    public TimeSpan? OvertimeStartTime { get; set; }

    /// <summary>
    /// 加班结束时间
    /// </summary>
    [SugarColumn(ColumnName = "overtime_end_time", ColumnDataType = "time", ColumnDescription = "加班结束时间", IsNullable = true)]
    public TimeSpan? OvertimeEndTime { get; set; }

    /// <summary>
    /// 加班时长(小时)
    /// </summary>
    [SugarColumn(ColumnName = "overtime_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "加班时长(小时)", IsNullable = true)]
    public decimal? OvertimeHours { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否弹性工作制
    /// </summary>
    [SugarColumn(ColumnName = "is_flexible", ColumnDescription = "是否弹性工作制", IsNullable = false, DefaultValue = "0")]
    public bool IsFlexible { get; set; }

    /// <summary>
    /// 是否允许补卡
    /// </summary>
    [SugarColumn(ColumnName = "is_allow_repair", ColumnDescription = "是否允许补卡", IsNullable = false, DefaultValue = "0")]
    public bool IsAllowRepair { get; set; }

    /// <summary>
    /// 补卡次数限制
    /// </summary>
    [SugarColumn(ColumnName = "repair_limit", ColumnDescription = "补卡次数限制", IsNullable = true)]
    public int? RepairLimit { get; set; }

    /// <summary>
    /// 规则备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "rule_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "规则备注", IsNullable = true)]
    public string? RuleRemarks { get; set; }
    #endregion
  }
}