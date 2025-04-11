/******************************************************************************
 * 文件名称：KpAttendanceSummary.cs
 * 文件描述：考勤统计实体类
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
  /// 考勤统计实体类
  /// </summary>
  [SugarTable("kp_hr_attendance_summary", "考勤统计")]
  [SugarIndex("idx_attendance_summary_employee_month", nameof(EmployeeCode), nameof(YearMonth), OrderByType.Asc)]
  public class KpAttendanceSummary : KpBaseEntity
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
    /// 统计年月
    /// </summary>
    [Required]
    [StringLength(6)]
    [SugarColumn(ColumnName = "year_month", ColumnDataType = "nvarchar", Length = 6, ColumnDescription = "统计年月", IsNullable = false)]
    public string? YearMonth { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "部门编码", IsNullable = true)]
    public string? DepartmentCode { get; set; }
    #endregion

    #region 出勤统计
    /// <summary>
    /// 应出勤天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "should_work_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "应出勤天数", IsNullable = false)]
    public decimal ShouldWorkDays { get; set; }

    /// <summary>
    /// 实际出勤天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "actual_work_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "实际出勤天数", IsNullable = false)]
    public decimal ActualWorkDays { get; set; }

    /// <summary>
    /// 正常出勤天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "normal_work_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "正常出勤天数", IsNullable = false)]
    public decimal NormalWorkDays { get; set; }

    /// <summary>
    /// 迟到次数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "late_times", ColumnDescription = "迟到次数", IsNullable = false)]
    public int LateTimes { get; set; }

    /// <summary>
    /// 早退次数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "early_leave_times", ColumnDescription = "早退次数", IsNullable = false)]
    public int EarlyLeaveTimes { get; set; }

    /// <summary>
    /// 旷工天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "absent_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "旷工天数", IsNullable = false)]
    public decimal AbsentDays { get; set; }
    #endregion

    #region 加班统计
    /// <summary>
    /// 加班总时长(小时)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "overtime_hours", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "加班总时长(小时)", IsNullable = false)]
    public decimal OvertimeHours { get; set; }

    /// <summary>
    /// 工作日加班时长
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "workday_overtime", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "工作日加班时长", IsNullable = false)]
    public decimal WorkdayOvertime { get; set; }

    /// <summary>
    /// 休息日加班时长
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "weekend_overtime", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "休息日加班时长", IsNullable = false)]
    public decimal WeekendOvertime { get; set; }

    /// <summary>
    /// 节假日加班时长
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "holiday_overtime", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "节假日加班时长", IsNullable = false)]
    public decimal HolidayOvertime { get; set; }
    #endregion

    #region 请假统计
    /// <summary>
    /// 年假天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "annual_leave_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "年假天数", IsNullable = false)]
    public decimal AnnualLeaveDays { get; set; }

    /// <summary>
    /// 病假天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "sick_leave_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "病假天数", IsNullable = false)]
    public decimal SickLeaveDays { get; set; }

    /// <summary>
    /// 事假天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "personal_leave_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "事假天数", IsNullable = false)]
    public decimal PersonalLeaveDays { get; set; }

    /// <summary>
    /// 其他假天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "other_leave_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "其他假天数", IsNullable = false)]
    public decimal OtherLeaveDays { get; set; }
    #endregion

    #region 其他统计
    /// <summary>
    /// 出差天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "business_trip_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "出差天数", IsNullable = false)]
    public decimal BusinessTripDays { get; set; }

    /// <summary>
    /// 外出天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "out_days", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "外出天数", IsNullable = false)]
    public decimal OutDays { get; set; }

    /// <summary>
    /// 补卡次数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "repair_times", ColumnDescription = "补卡次数", IsNullable = false)]
    public int RepairTimes { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 统计状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "summary_status", ColumnDescription = "统计状态", IsNullable = false)]
    public int SummaryStatus { get; set; }

    /// <summary>
    /// 统计时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "summary_time", ColumnDataType = "datetime", ColumnDescription = "统计时间", IsNullable = false)]
    public DateTime SummaryTime { get; set; }

    /// <summary>
    /// 统计人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "summary_by", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "统计人", IsNullable = true)]
    public string? SummaryBy { get; set; }

    /// <summary>
    /// 统计备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "summary_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "统计备注", IsNullable = true)]
    public string? SummaryRemarks { get; set; }
    #endregion
  }
}