/******************************************************************************
 * 文件名称：KpPerformanceIndicator.cs
 * 文件描述：绩效指标实体类
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
  /// 绩效指标实体类
  /// </summary>
  [SugarTable("kp_hr_performance_indicator", "绩效指标")]
  [SugarIndex("idx_performance_indicator_code", nameof(IndicatorCode), OrderByType.Asc)]
  public class KpPerformanceIndicator : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 指标编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "indicator_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "指标编码", IsNullable = false)]
    public string? IndicatorCode { get; set; }

    /// <summary>
    /// 指标名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "indicator_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "指标名称", IsNullable = false)]
    public string? IndicatorName { get; set; }

    /// <summary>
    /// 指标类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "indicator_type", ColumnDescription = "指标类型", IsNullable = false)]
    public int IndicatorType { get; set; }

    /// <summary>
    /// 指标状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "indicator_status", ColumnDescription = "指标状态", IsNullable = false)]
    public int IndicatorStatus { get; set; }

    /// <summary>
    /// 指标描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "indicator_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "指标描述", IsNullable = true)]
    public string? IndicatorDescription { get; set; }
    #endregion

    #region 指标信息
    /// <summary>
    /// 指标权重
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "indicator_weight", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "指标权重", IsNullable = false)]
    public decimal IndicatorWeight { get; set; }

    /// <summary>
    /// 指标单位
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "indicator_unit", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "指标单位", IsNullable = true)]
    public string? IndicatorUnit { get; set; }

    /// <summary>
    /// 指标公式
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "indicator_formula", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "指标公式", IsNullable = true)]
    public string? IndicatorFormula { get; set; }

    /// <summary>
    /// 指标来源
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "indicator_source", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "指标来源", IsNullable = true)]
    public string? IndicatorSource { get; set; }

    /// <summary>
    /// 指标周期
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "indicator_period", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "指标周期", IsNullable = true)]
    public string? IndicatorPeriod { get; set; }
    #endregion

    #region 评分标准
    /// <summary>
    /// 评分方式
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "scoring_method", ColumnDescription = "评分方式", IsNullable = false)]
    public int ScoringMethod { get; set; }

    /// <summary>
    /// 评分标准
    /// </summary>
    [Required]
    [StringLength(1000)]
    [SugarColumn(ColumnName = "scoring_standard", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "评分标准", IsNullable = false)]
    public string? ScoringStandard { get; set; }

    /// <summary>
    /// 评分范围
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "scoring_range", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "评分范围", IsNullable = true)]
    public string? ScoringRange { get; set; }

    /// <summary>
    /// 评分说明
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "scoring_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评分说明", IsNullable = true)]
    public string? ScoringDescription { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system_preset", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystemPreset { get; set; }

    /// <summary>
    /// 是否必填
    /// </summary>
    [SugarColumn(ColumnName = "is_required", ColumnDescription = "是否必填", IsNullable = false, DefaultValue = "0")]
    public bool IsRequired { get; set; }

    /// <summary>
    /// 指标备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "indicator_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "指标备注", IsNullable = true)]
    public string? IndicatorRemarks { get; set; }
    #endregion
  }
}