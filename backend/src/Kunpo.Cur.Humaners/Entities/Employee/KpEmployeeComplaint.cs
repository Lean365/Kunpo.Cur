/******************************************************************************
 * 文件名称：KpEmployeeComplaint.cs
 * 文件描述：员工投诉实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Employee
{
  /// <summary>
  /// 员工投诉实体类
  /// </summary>
  [SugarTable("kp_hr_employee_complaint", "员工投诉")]
  [SugarIndex("idx_employee_complaint_code", nameof(ComplaintCode), OrderByType.Asc)]
  public class KpEmployeeComplaint : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 投诉编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "complaint_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "投诉编码", IsNullable = false)]
    public string? ComplaintCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 投诉类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "complaint_type", ColumnDescription = "投诉类型", IsNullable = false)]
    public int ComplaintType { get; set; }

    /// <summary>
    /// 投诉状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "complaint_status", ColumnDescription = "投诉状态", IsNullable = false)]
    public int ComplaintStatus { get; set; }

    /// <summary>
    /// 投诉标题
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "complaint_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "投诉标题", IsNullable = false)]
    public string? ComplaintTitle { get; set; }

    /// <summary>
    /// 投诉内容
    /// </summary>
    [Required]
    [StringLength(2000)]
    [SugarColumn(ColumnName = "complaint_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "投诉内容", IsNullable = false)]
    public string? ComplaintContent { get; set; }
    #endregion

    #region 处理信息
    /// <summary>
    /// 处理人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "handler_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "处理人编码", IsNullable = true)]
    public string? HandlerCode { get; set; }

    /// <summary>
    /// 处理时间
    /// </summary>
    [SugarColumn(ColumnName = "handle_time", ColumnDescription = "处理时间", IsNullable = true)]
    public DateTime? HandleTime { get; set; }

    /// <summary>
    /// 处理结果
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "handle_result", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "处理结果", IsNullable = true)]
    public string? HandleResult { get; set; }

    /// <summary>
    /// 处理意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "handle_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "处理意见", IsNullable = true)]
    public string? HandleComment { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 投诉时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "complaint_time", ColumnDescription = "投诉时间", IsNullable = false)]
    public DateTime ComplaintTime { get; set; }

    /// <summary>
    /// 期望处理时间
    /// </summary>
    [SugarColumn(ColumnName = "expected_handle_time", ColumnDescription = "期望处理时间", IsNullable = true)]
    public DateTime? ExpectedHandleTime { get; set; }

    /// <summary>
    /// 实际处理时间
    /// </summary>
    [SugarColumn(ColumnName = "actual_handle_time", ColumnDescription = "实际处理时间", IsNullable = true)]
    public DateTime? ActualHandleTime { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否匿名
    /// </summary>
    [SugarColumn(ColumnName = "is_anonymous", ColumnDescription = "是否匿名", IsNullable = false, DefaultValue = "0")]
    public bool IsAnonymous { get; set; }

    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public bool IsEnabled { get; set; }

    /// <summary>
    /// 投诉备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "complaint_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "投诉备注", IsNullable = true)]
    public string? ComplaintRemarks { get; set; }
    #endregion
  }
}