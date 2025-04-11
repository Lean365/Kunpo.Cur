/******************************************************************************
 * 文件名称：KpBenefit.cs
 * 文件描述：福利项目实体类
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
  /// 福利项目实体类
  /// </summary>
  [SugarTable("kp_hr_benefit", "福利项目")]
  [SugarIndex("idx_benefit_code", nameof(BenefitCode), OrderByType.Asc)]
  public class KpBenefit : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 福利项目编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利项目编码", IsNullable = false)]
    public string? BenefitCode { get; set; }

    /// <summary>
    /// 福利项目名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "benefit_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "福利项目名称", IsNullable = false)]
    public string? BenefitName { get; set; }

    /// <summary>
    /// 福利项目类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "benefit_type", ColumnDescription = "福利项目类型", IsNullable = false)]
    public int BenefitType { get; set; }

    /// <summary>
    /// 福利项目状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "benefit_status", ColumnDescription = "福利项目状态", IsNullable = false)]
    public int BenefitStatus { get; set; }

    /// <summary>
    /// 福利项目描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利项目描述", IsNullable = true)]
    public string? BenefitDescription { get; set; }
    #endregion

    #region 福利信息
    /// <summary>
    /// 福利金额
    /// </summary>
    [SugarColumn(ColumnName = "benefit_amount", ColumnDescription = "福利金额", IsNullable = true)]
    public decimal? BenefitAmount { get; set; }

    /// <summary>
    /// 福利单位
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "benefit_unit", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "福利单位", IsNullable = true)]
    public string? BenefitUnit { get; set; }

    /// <summary>
    /// 福利周期
    /// </summary>
    [SugarColumn(ColumnName = "benefit_period", ColumnDescription = "福利周期", IsNullable = true)]
    public int? BenefitPeriod { get; set; }

    /// <summary>
    /// 福利标准
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_standard", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利标准", IsNullable = true)]
    public string? BenefitStandard { get; set; }
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
    /// 福利项目备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "benefit_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "福利项目备注", IsNullable = true)]
    public string? BenefitRemarks { get; set; }
    #endregion
  }
}