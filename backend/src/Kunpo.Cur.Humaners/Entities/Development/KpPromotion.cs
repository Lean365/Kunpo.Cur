/******************************************************************************
 * 文件名称：KpPromotion.cs
 * 文件描述：晋升记录实体类
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
  /// 晋升记录实体类
  /// </summary>
  [SugarTable("kp_hr_promotion", "晋升记录")]
  [SugarIndex("idx_promotion_code", nameof(PromotionCode), OrderByType.Asc)]
  public class KpPromotion : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 晋升记录编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "promotion_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "晋升记录编码", IsNullable = false)]
    public string? PromotionCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 晋升类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "promotion_type", ColumnDescription = "晋升类型", IsNullable = false)]
    public int PromotionType { get; set; }

    /// <summary>
    /// 晋升状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "promotion_status", ColumnDescription = "晋升状态", IsNullable = false)]
    public int PromotionStatus { get; set; }

    /// <summary>
    /// 晋升原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "promotion_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "晋升原因", IsNullable = true)]
    public string? PromotionReason { get; set; }
    #endregion

    #region 晋升信息
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
    /// 原职级编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "original_job_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "原职级编码", IsNullable = false)]
    public string? OriginalJobLevelCode { get; set; }

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
    /// 新职级编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "new_job_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "新职级编码", IsNullable = false)]
    public string? NewJobLevelCode { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 晋升日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "promotion_date", ColumnDescription = "晋升日期", IsNullable = false)]
    public DateTime PromotionDate { get; set; }

    /// <summary>
    /// 生效日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "effective_date", ColumnDescription = "生效日期", IsNullable = false)]
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// 试用期结束日期
    /// </summary>
    [SugarColumn(ColumnName = "probation_end_date", ColumnDescription = "试用期结束日期", IsNullable = true)]
    public DateTime? ProbationEndDate { get; set; }
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
    /// 晋升记录备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "promotion_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "晋升记录备注", IsNullable = true)]
    public string? PromotionRemarks { get; set; }
    #endregion
  }
}