/******************************************************************************
 * 文件名称：KpAttendance.cs
 * 文件描述：考勤记录实体类
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
  /// 考勤记录实体类
  /// </summary>
  [SugarTable("kp_hr_attendance", "考勤记录")]
  [SugarIndex("idx_attendance_employee", nameof(EmployeeCode), OrderByType.Asc)]
  public class KpAttendance : KpBaseEntity
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
    /// 考勤日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "attendance_date", ColumnDataType = "date", ColumnDescription = "考勤日期", IsNullable = false)]
    public DateTime AttendanceDate { get; set; }

    /// <summary>
    /// 考勤类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "attendance_type", ColumnDescription = "考勤类型", IsNullable = false)]
    public int AttendanceType { get; set; }

    /// <summary>
    /// 考勤状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "attendance_status", ColumnDescription = "考勤状态", IsNullable = false)]
    public int AttendanceStatus { get; set; }
    #endregion

    #region 打卡信息
    /// <summary>
    /// 上班打卡时间
    /// </summary>
    [SugarColumn(ColumnName = "clock_in_time", ColumnDataType = "datetime", ColumnDescription = "上班打卡时间", IsNullable = true)]
    public DateTime? ClockInTime { get; set; }

    /// <summary>
    /// 下班打卡时间
    /// </summary>
    [SugarColumn(ColumnName = "clock_out_time", ColumnDataType = "datetime", ColumnDescription = "下班打卡时间", IsNullable = true)]
    public DateTime? ClockOutTime { get; set; }

    /// <summary>
    /// 打卡地点
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "clock_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "打卡地点", IsNullable = true)]
    public string? ClockLocation { get; set; }

    /// <summary>
    /// 打卡设备
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "clock_device", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "打卡设备", IsNullable = true)]
    public string? ClockDevice { get; set; }
    #endregion

    #region 考勤详情
    /// <summary>
    /// 是否迟到
    /// </summary>
    [SugarColumn(ColumnName = "is_late", ColumnDescription = "是否迟到", IsNullable = false, DefaultValue = "0")]
    public bool IsLate { get; set; }

    /// <summary>
    /// 迟到时长(分钟)
    /// </summary>
    [SugarColumn(ColumnName = "late_minutes", ColumnDescription = "迟到时长(分钟)", IsNullable = true)]
    public int? LateMinutes { get; set; }

    /// <summary>
    /// 是否早退
    /// </summary>
    [SugarColumn(ColumnName = "is_early_leave", ColumnDescription = "是否早退", IsNullable = false, DefaultValue = "0")]
    public bool IsEarlyLeave { get; set; }

    /// <summary>
    /// 早退时长(分钟)
    /// </summary>
    [SugarColumn(ColumnName = "early_leave_minutes", ColumnDescription = "早退时长(分钟)", IsNullable = true)]
    public int? EarlyLeaveMinutes { get; set; }

    /// <summary>
    /// 是否旷工
    /// </summary>
    [SugarColumn(ColumnName = "is_absent", ColumnDescription = "是否旷工", IsNullable = false, DefaultValue = "0")]
    public bool IsAbsent { get; set; }

    /// <summary>
    /// 是否加班
    /// </summary>
    [SugarColumn(ColumnName = "is_overtime", ColumnDescription = "是否加班", IsNullable = false, DefaultValue = "0")]
    public bool IsOvertime { get; set; }

    /// <summary>
    /// 加班时长(小时)
    /// </summary>
    [SugarColumn(ColumnName = "overtime_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "加班时长(小时)", IsNullable = true)]
    public decimal? OvertimeHours { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否异常
    /// </summary>
    [SugarColumn(ColumnName = "is_exception", ColumnDescription = "是否异常", IsNullable = false, DefaultValue = "0")]
    public bool IsException { get; set; }

    /// <summary>
    /// 异常原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "exception_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "异常原因", IsNullable = true)]
    public string? ExceptionReason { get; set; }

    /// <summary>
    /// 考勤备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "attendance_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "考勤备注", IsNullable = true)]
    public string? AttendanceRemarks { get; set; }
    #endregion
  }
}