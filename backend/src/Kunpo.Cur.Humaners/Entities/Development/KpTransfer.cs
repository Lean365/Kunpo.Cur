/******************************************************************************
 * 文件名称：KpTransfer.cs
 * 文件描述：调动记录实体类
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
  /// 调动记录实体类
  /// </summary>
  [SugarTable("kp_hr_transfer", "调动记录")]
  [SugarIndex("idx_transfer_code", nameof(TransferCode), OrderByType.Asc)]
  public class KpTransfer : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 调动记录编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "transfer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "调动记录编码", IsNullable = false)]
    public string? TransferCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 调动类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "transfer_type", ColumnDescription = "调动类型", IsNullable = false)]
    public int TransferType { get; set; }

    /// <summary>
    /// 调动状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "transfer_status", ColumnDescription = "调动状态", IsNullable = false)]
    public int TransferStatus { get; set; }

    /// <summary>
    /// 调动原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "transfer_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "调动原因", IsNullable = true)]
    public string? TransferReason { get; set; }
    #endregion

    #region 调动信息
    /// <summary>
    /// 原部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "original_department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "原部门编码", IsNullable = false)]
    public string? OriginalDepartmentCode { get; set; }

    /// <summary>
    /// 原岗位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "original_job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "原岗位编码", IsNullable = false)]
    public string? OriginalJobCode { get; set; }

    /// <summary>
    /// 原工作地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "original_work_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "原工作地点", IsNullable = true)]
    public string? OriginalWorkLocation { get; set; }

    /// <summary>
    /// 新部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "new_department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "新部门编码", IsNullable = false)]
    public string? NewDepartmentCode { get; set; }

    /// <summary>
    /// 新岗位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "new_job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "新岗位编码", IsNullable = false)]
    public string? NewJobCode { get; set; }

    /// <summary>
    /// 新工作地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "new_work_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "新工作地点", IsNullable = true)]
    public string? NewWorkLocation { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 调动日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "transfer_date", ColumnDescription = "调动日期", IsNullable = false)]
    public DateTime TransferDate { get; set; }

    /// <summary>
    /// 生效日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "effective_date", ColumnDescription = "生效日期", IsNullable = false)]
    public DateTime EffectiveDate { get; set; }

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
    /// 调动记录备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "transfer_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "调动记录备注", IsNullable = true)]
    public string? TransferRemarks { get; set; }
    #endregion
  }
}