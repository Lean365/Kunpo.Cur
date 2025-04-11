/******************************************************************************
 * 文件名称：KpBenefitClaim.cs
 * 文件描述：福利申请实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Benefit
{
  /// <summary>
  /// 福利申请实体类
  /// </summary>
  [SugarTable("kp_hr_benefit_claim", "福利申请")]
  [SugarIndex("idx_benefit_claim_code", nameof(BenefitClaimCode), OrderByType.Asc)]
  public class KpBenefitClaim : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 福利申请编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_claim_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利申请编码", IsNullable = false)]
    public string? BenefitClaimCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 福利项目编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利项目编码", IsNullable = false)]
    public string? BenefitCode { get; set; }

    /// <summary>
    /// 福利计划编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_plan_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利计划编码", IsNullable = false)]
    public string? BenefitPlanCode { get; set; }

    /// <summary>
    /// 申请状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "claim_status", ColumnDescription = "申请状态", IsNullable = false)]
    public int ClaimStatus { get; set; }

    /// <summary>
    /// 申请原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "claim_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "申请原因", IsNullable = true)]
    public string? ClaimReason { get; set; }
    #endregion

    #region 申请信息
    /// <summary>
    /// 申请日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "claim_date", ColumnDescription = "申请日期", IsNullable = false)]
    public DateTime ClaimDate { get; set; }

    /// <summary>
    /// 申请金额
    /// </summary>
    [SugarColumn(ColumnName = "claim_amount", ColumnDescription = "申请金额", IsNullable = true)]
    public decimal? ClaimAmount { get; set; }

    /// <summary>
    /// 申请数量
    /// </summary>
    [SugarColumn(ColumnName = "claim_quantity", ColumnDescription = "申请数量", IsNullable = true)]
    public int? ClaimQuantity { get; set; }

    /// <summary>
    /// 申请说明
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "claim_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "申请说明", IsNullable = true)]
    public string? ClaimDescription { get; set; }
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
    /// 福利申请备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_claim_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利申请备注", IsNullable = true)]
    public string? BenefitClaimRemarks { get; set; }
    #endregion
  }
}