/******************************************************************************
 * 文件名称：KpPerformanceTemplate.cs
 * 文件描述：绩效模板实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Performance
{
  /// <summary>
  /// 绩效模板实体类
  /// </summary>
  [SugarTable("kp_hr_performance_template", "绩效模板")]
  [SugarIndex("idx_performance_template_code", nameof(TemplateCode), OrderByType.Asc)]
  public class KpPerformanceTemplate : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 模板编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "template_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "模板编码", IsNullable = false)]
    public string? TemplateCode { get; set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "template_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "模板名称", IsNullable = false)]
    public string? TemplateName { get; set; }

    /// <summary>
    /// 模板类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "template_type", ColumnDescription = "模板类型", IsNullable = false)]
    public int TemplateType { get; set; }

    /// <summary>
    /// 模板状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "template_status", ColumnDescription = "模板状态", IsNullable = false)]
    public int TemplateStatus { get; set; }

    /// <summary>
    /// 模板描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "template_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板描述", IsNullable = true)]
    public string? TemplateDescription { get; set; }
    #endregion

    #region 模板信息
    /// <summary>
    /// 评估周期
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "evaluation_period", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估周期", IsNullable = false)]
    public string? EvaluationPeriod { get; set; }

    /// <summary>
    /// 评估方式
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "evaluation_method", ColumnDescription = "评估方式", IsNullable = false)]
    public int EvaluationMethod { get; set; }

    /// <summary>
    /// 评分标准
    /// </summary>
    [Required]
    [StringLength(1000)]
    [SugarColumn(ColumnName = "scoring_standard", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "评分标准", IsNullable = false)]
    public string? ScoringStandard { get; set; }

    /// <summary>
    /// 等级标准
    /// </summary>
    [Required]
    [StringLength(1000)]
    [SugarColumn(ColumnName = "level_standard", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "等级标准", IsNullable = false)]
    public string? LevelStandard { get; set; }

    /// <summary>
    /// 权重设置
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "weight_settings", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "权重设置", IsNullable = true)]
    public string? WeightSettings { get; set; }
    #endregion

    #region 适用范围
    /// <summary>
    /// 适用部门
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "applicable_departments", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "适用部门", IsNullable = true)]
    public string? ApplicableDepartments { get; set; }

    /// <summary>
    /// 适用职位
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "applicable_positions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "适用职位", IsNullable = true)]
    public string? ApplicablePositions { get; set; }

    /// <summary>
    /// 适用职级
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "applicable_levels", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "适用职级", IsNullable = true)]
    public string? ApplicableLevels { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system_preset", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystemPreset { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [SugarColumn(ColumnName = "is_default", ColumnDescription = "是否默认", IsNullable = false, DefaultValue = "0")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// 模板备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "template_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板备注", IsNullable = true)]
    public string? TemplateRemarks { get; set; }
    #endregion
  }
}