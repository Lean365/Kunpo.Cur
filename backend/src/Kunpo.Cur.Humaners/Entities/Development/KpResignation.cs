/******************************************************************************
 * 文件名称：KpResignation.cs
 * 文件描述：离职记录实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Development
{
  /// <summary>
  /// 离职记录实体类
  /// </summary>
  [SugarTable("kp_hr_resignation", "离职记录")]
  [SugarIndex("idx_resignation_code", nameof(ResignationCode), OrderByType.Asc)]
  public class KpResignation : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 离职记录编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "resignation_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "离职记录编码", IsNullable = false)]
    public string? ResignationCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 离职类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "resignation_type", ColumnDescription = "离职类型", IsNullable = false)]
    public int ResignationType { get; set; }

    /// <summary>
    /// 离职状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "resignation_status", ColumnDescription = "离职状态", IsNullable = false)]
    public int ResignationStatus { get; set; }

    /// <summary>
    /// 离职原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "resignation_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "离职原因", IsNullable = true)]
    public string? ResignationReason { get; set; }
    #endregion

    #region 离职信息
    /// <summary>
    /// 部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "部门编码", IsNullable = false)]
    public string? DepartmentCode { get; set; }

    /// <summary>
    /// 岗位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "岗位编码", IsNullable = false)]
    public string? JobCode { get; set; }

    /// <summary>
    /// 职级编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职级编码", IsNullable = false)]
    public string? JobLevelCode { get; set; }

    /// <summary>
    /// 工作地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "work_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "工作地点", IsNullable = true)]
    public string? WorkLocation { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 申请日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "apply_date", ColumnDescription = "申请日期", IsNullable = false)]
    public DateTime ApplyDate { get; set; }

    /// <summary>
    /// 离职日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "resignation_date", ColumnDescription = "离职日期", IsNullable = false)]
    public DateTime ResignationDate { get; set; }

    /// <summary>
    /// 交接完成日期
    /// </summary>
    [SugarColumn(ColumnName = "handover_complete_date", ColumnDescription = "交接完成日期", IsNullable = true)]
    public DateTime? HandoverCompleteDate { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人编码", IsNullable = true)]
    public string? ApproverCode { get; set; }

    /// <summary>
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDescription = "审批时间", IsNullable = true)]
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
    /// 离职记录备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "resignation_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "离职记录备注", IsNullable = true)]
    public string? ResignationRemarks { get; set; }
    #endregion
  }
}