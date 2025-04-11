/******************************************************************************
 * 文件名称：KpPerformanceReview.cs
 * 文件描述：绩效评估实体类
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
  /// 绩效评估实体类
  /// </summary>
  [SugarTable("kp_hr_performance_review", "绩效评估")]
  [SugarIndex("idx_performance_review_code", nameof(ReviewCode), OrderByType.Asc)]
  public class KpPerformanceReview : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 评估编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "review_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估编码", IsNullable = false)]
    public string? ReviewCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 评估周期
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "review_period", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估周期", IsNullable = false)]
    public string? ReviewPeriod { get; set; }

    /// <summary>
    /// 评估类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "review_type", ColumnDescription = "评估类型", IsNullable = false)]
    public int ReviewType { get; set; }

    /// <summary>
    /// 评估状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "review_status", ColumnDescription = "评估状态", IsNullable = false)]
    public int ReviewStatus { get; set; }
    #endregion

    #region 评估信息
    /// <summary>
    /// 评估得分
    /// </summary>
    [SugarColumn(ColumnName = "review_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "评估得分", IsNullable = true)]
    public decimal? ReviewScore { get; set; }

    /// <summary>
    /// 评估等级
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "review_level", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估等级", IsNullable = true)]
    public string? ReviewLevel { get; set; }

    /// <summary>
    /// 评估评语
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "review_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估评语", IsNullable = true)]
    public string? ReviewComment { get; set; }

    /// <summary>
    /// 评估结果
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "review_result", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "评估结果", IsNullable = true)]
    public string? ReviewResult { get; set; }

    /// <summary>
    /// 评估建议
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "review_suggestion", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "评估建议", IsNullable = true)]
    public string? ReviewSuggestion { get; set; }
    #endregion

    #region 评估人信息
    /// <summary>
    /// 评估人
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "reviewer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估人", IsNullable = false)]
    public string? ReviewerCode { get; set; }

    /// <summary>
    /// 评估时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "review_time", ColumnDataType = "datetime", ColumnDescription = "评估时间", IsNullable = false)]
    public DateTime ReviewTime { get; set; }

    /// <summary>
    /// 评估意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "reviewer_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估意见", IsNullable = true)]
    public string? ReviewerComment { get; set; }

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
    /// 评估备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "review_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估备注", IsNullable = true)]
    public string? ReviewRemarks { get; set; }
    #endregion
  }
}