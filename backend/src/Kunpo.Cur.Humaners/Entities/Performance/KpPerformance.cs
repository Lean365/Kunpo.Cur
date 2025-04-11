/******************************************************************************
 * 文件名称：KpPerformance.cs
 * 文件描述：绩效记录实体类
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
  /// 绩效记录实体类
  /// </summary>
  [SugarTable("kp_hr_performance", "绩效记录")]
  [SugarIndex("idx_performance_code", nameof(PerformanceCode), OrderByType.Asc)]
  public class KpPerformance : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 绩效编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "performance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "绩效编码", IsNullable = false)]
    public string? PerformanceCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 绩效周期
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "performance_period", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "绩效周期", IsNullable = false)]
    public string? PerformancePeriod { get; set; }

    /// <summary>
    /// 绩效类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "performance_type", ColumnDescription = "绩效类型", IsNullable = false)]
    public int PerformanceType { get; set; }

    /// <summary>
    /// 绩效状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "performance_status", ColumnDescription = "绩效状态", IsNullable = false)]
    public int PerformanceStatus { get; set; }
    #endregion

    #region 绩效信息
    /// <summary>
    /// 绩效得分
    /// </summary>
    [SugarColumn(ColumnName = "performance_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "绩效得分", IsNullable = true)]
    public decimal? PerformanceScore { get; set; }

    /// <summary>
    /// 绩效等级
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "performance_level", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "绩效等级", IsNullable = true)]
    public string? PerformanceLevel { get; set; }

    /// <summary>
    /// 绩效评语
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "performance_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "绩效评语", IsNullable = true)]
    public string? PerformanceComment { get; set; }

    /// <summary>
    /// 绩效目标
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "performance_goal", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "绩效目标", IsNullable = true)]
    public string? PerformanceGoal { get; set; }

    /// <summary>
    /// 绩效结果
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "performance_result", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "绩效结果", IsNullable = true)]
    public string? PerformanceResult { get; set; }
    #endregion

    #region 评估信息
    /// <summary>
    /// 评估人
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "evaluator_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估人", IsNullable = false)]
    public string? EvaluatorCode { get; set; }

    /// <summary>
    /// 评估时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "evaluation_time", ColumnDataType = "datetime", ColumnDescription = "评估时间", IsNullable = false)]
    public DateTime EvaluationTime { get; set; }

    /// <summary>
    /// 评估意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "evaluation_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估意见", IsNullable = true)]
    public string? EvaluationComment { get; set; }

    /// <summary>
    /// 确认人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "confirmer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "确认人", IsNullable = true)]
    public string? ConfirmerCode { get; set; }

    /// <summary>
    /// 确认时间
    /// </summary>
    [SugarColumn(ColumnName = "confirmation_time", ColumnDataType = "datetime", ColumnDescription = "确认时间", IsNullable = true)]
    public DateTime? ConfirmationTime { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否申诉
    /// </summary>
    [SugarColumn(ColumnName = "is_appealed", ColumnDescription = "是否申诉", IsNullable = false, DefaultValue = "0")]
    public bool IsAppealed { get; set; }

    /// <summary>
    /// 申诉原因
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "appeal_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "申诉原因", IsNullable = true)]
    public string? AppealReason { get; set; }

    /// <summary>
    /// 申诉结果
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "appeal_result", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "申诉结果", IsNullable = true)]
    public string? AppealResult { get; set; }

    /// <summary>
    /// 绩效备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "performance_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "绩效备注", IsNullable = true)]
    public string? PerformanceRemarks { get; set; }
    #endregion
  }
}