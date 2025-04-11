/******************************************************************************
 * 文件名称：KpBenefitPlan.cs
 * 文件描述：福利计划实体类
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
  /// 福利计划实体类
  /// </summary>
  [SugarTable("kp_hr_benefit_plan", "福利计划")]
  [SugarIndex("idx_benefit_plan_code", nameof(BenefitPlanCode), OrderByType.Asc)]
  public class KpBenefitPlan : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 福利计划编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_plan_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利计划编码", IsNullable = false)]
    public string? BenefitPlanCode { get; set; }

    /// <summary>
    /// 福利计划名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "benefit_plan_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "福利计划名称", IsNullable = false)]
    public string? BenefitPlanName { get; set; }

    /// <summary>
    /// 福利计划类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "benefit_plan_type", ColumnDescription = "福利计划类型", IsNullable = false)]
    public int BenefitPlanType { get; set; }

    /// <summary>
    /// 福利计划状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "benefit_plan_status", ColumnDescription = "福利计划状态", IsNullable = false)]
    public int BenefitPlanStatus { get; set; }

    /// <summary>
    /// 福利计划描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_plan_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利计划描述", IsNullable = true)]
    public string? BenefitPlanDescription { get; set; }
    #endregion

    #region 计划信息
    /// <summary>
    /// 福利项目编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利项目编码", IsNullable = false)]
    public string? BenefitCode { get; set; }

    /// <summary>
    /// 计划开始日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "plan_start_date", ColumnDescription = "计划开始日期", IsNullable = false)]
    public DateTime PlanStartDate { get; set; }

    /// <summary>
    /// 计划结束日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "plan_end_date", ColumnDescription = "计划结束日期", IsNullable = false)]
    public DateTime PlanEndDate { get; set; }

    /// <summary>
    /// 计划预算
    /// </summary>
    [SugarColumn(ColumnName = "plan_budget", ColumnDescription = "计划预算", IsNullable = true)]
    public decimal? PlanBudget { get; set; }

    /// <summary>
    /// 计划人数
    /// </summary>
    [SugarColumn(ColumnName = "plan_employee_count", ColumnDescription = "计划人数", IsNullable = true)]
    public int? PlanEmployeeCount { get; set; }
    #endregion

    #region 适用信息
    /// <summary>
    /// 适用部门
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "applicable_departments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "适用部门", IsNullable = true)]
    public string? ApplicableDepartments { get; set; }

    /// <summary>
    /// 适用岗位
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "applicable_jobs", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "适用岗位", IsNullable = true)]
    public string? ApplicableJobs { get; set; }

    /// <summary>
    /// 适用职级
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "applicable_job_levels", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "适用职级", IsNullable = true)]
    public string? ApplicableJobLevels { get; set; }
    #endregion

    #region 其他信息
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
    /// 福利计划备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_plan_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利计划备注", IsNullable = true)]
    public string? BenefitPlanRemarks { get; set; }
    #endregion
  }
}