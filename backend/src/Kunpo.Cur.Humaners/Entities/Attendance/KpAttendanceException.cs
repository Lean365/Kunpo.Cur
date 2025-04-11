/******************************************************************************
 * 文件名称：KpAttendanceException.cs
 * 文件描述：考勤异常记录实体类
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
  /// 考勤异常记录实体类
  /// </summary>
  [SugarTable("kp_hr_attendance_exception", "考勤异常记录")]
  [SugarIndex("idx_attendance_exception_employee_date", nameof(EmployeeCode), nameof(ExceptionDate), OrderByType.Asc)]
  public class KpAttendanceException : KpBaseEntity
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
    /// 异常日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "exception_date", ColumnDataType = "date", ColumnDescription = "异常日期", IsNullable = false)]
    public DateTime ExceptionDate { get; set; }

    /// <summary>
    /// 异常类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "exception_type", ColumnDescription = "异常类型", IsNullable = false)]
    public int ExceptionType { get; set; }

    /// <summary>
    /// 异常状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "exception_status", ColumnDescription = "异常状态", IsNullable = false)]
    public int ExceptionStatus { get; set; }
    #endregion

    #region 异常详情
    /// <summary>
    /// 异常时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "exception_time", ColumnDataType = "time", ColumnDescription = "异常时间", IsNullable = false)]
    public TimeSpan ExceptionTime { get; set; }

    /// <summary>
    /// 异常时长(分钟)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "exception_minutes", ColumnDescription = "异常时长(分钟)", IsNullable = false)]
    public int ExceptionMinutes { get; set; }

    /// <summary>
    /// 异常原因
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "exception_reason", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "异常原因", IsNullable = true)]
    public string? ExceptionReason { get; set; }

    /// <summary>
    /// 异常地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "exception_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "异常地点", IsNullable = true)]
    public string? ExceptionLocation { get; set; }
    #endregion

    #region 处理信息
    /// <summary>
    /// 处理方式
    /// </summary>
    [SugarColumn(ColumnName = "handle_type", ColumnDescription = "处理方式", IsNullable = true)]
    public int? HandleType { get; set; }

    /// <summary>
    /// 处理人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "handle_by", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "处理人", IsNullable = true)]
    public string? HandleBy { get; set; }

    /// <summary>
    /// 处理时间
    /// </summary>
    [SugarColumn(ColumnName = "handle_time", ColumnDataType = "datetime", ColumnDescription = "处理时间", IsNullable = true)]
    public DateTime? HandleTime { get; set; }

    /// <summary>
    /// 处理意见
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "handle_comment", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "处理意见", IsNullable = true)]
    public string? HandleComment { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否影响考勤
    /// </summary>
    [SugarColumn(ColumnName = "is_affect_attendance", ColumnDescription = "是否影响考勤", IsNullable = false, DefaultValue = "0")]
    public bool IsAffectAttendance { get; set; }

    /// <summary>
    /// 是否影响工资
    /// </summary>
    [SugarColumn(ColumnName = "is_affect_salary", ColumnDescription = "是否影响工资", IsNullable = false, DefaultValue = "0")]
    public bool IsAffectSalary { get; set; }

    /// <summary>
    /// 异常备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "exception_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "异常备注", IsNullable = true)]
    public string? ExceptionRemarks { get; set; }
    #endregion
  }
}