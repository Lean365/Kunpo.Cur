/******************************************************************************
 * 文件名称：KpTrainingEvaluation.cs
 * 文件描述：培训评估实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Training
{
  /// <summary>
  /// 培训评估实体类
  /// </summary>
  [SugarTable("kp_hr_training_evaluation", "培训评估")]
  [SugarIndex("idx_training_evaluation_code", nameof(EvaluationCode), OrderByType.Asc)]
  public class KpTrainingEvaluation : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 评估编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "evaluation_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估编码", IsNullable = false)]
    public string? EvaluationCode { get; set; }

    /// <summary>
    /// 培训编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "training_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "培训编码", IsNullable = false)]
    public string? TrainingCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 评估类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "evaluation_type", ColumnDescription = "评估类型", IsNullable = false)]
    public int EvaluationType { get; set; }

    /// <summary>
    /// 评估状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "evaluation_status", ColumnDescription = "评估状态", IsNullable = false)]
    public int EvaluationStatus { get; set; }
    #endregion

    #region 评估内容
    /// <summary>
    /// 培训内容评分
    /// </summary>
    [SugarColumn(ColumnName = "content_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "培训内容评分", IsNullable = true)]
    public decimal? ContentScore { get; set; }

    /// <summary>
    /// 培训内容评价
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "content_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训内容评价", IsNullable = true)]
    public string? ContentEvaluation { get; set; }

    /// <summary>
    /// 讲师评分
    /// </summary>
    [SugarColumn(ColumnName = "trainer_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "讲师评分", IsNullable = true)]
    public decimal? TrainerScore { get; set; }

    /// <summary>
    /// 讲师评价
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "trainer_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "讲师评价", IsNullable = true)]
    public string? TrainerEvaluation { get; set; }

    /// <summary>
    /// 组织评分
    /// </summary>
    [SugarColumn(ColumnName = "organization_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "组织评分", IsNullable = true)]
    public decimal? OrganizationScore { get; set; }

    /// <summary>
    /// 组织评价
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "organization_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "组织评价", IsNullable = true)]
    public string? OrganizationEvaluation { get; set; }

    /// <summary>
    /// 环境评分
    /// </summary>
    [SugarColumn(ColumnName = "environment_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "环境评分", IsNullable = true)]
    public decimal? EnvironmentScore { get; set; }

    /// <summary>
    /// 环境评价
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "environment_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "环境评价", IsNullable = true)]
    public string? EnvironmentEvaluation { get; set; }

    /// <summary>
    /// 时间评分
    /// </summary>
    [SugarColumn(ColumnName = "time_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "时间评分", IsNullable = true)]
    public decimal? TimeScore { get; set; }

    /// <summary>
    /// 时间评价
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "time_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "时间评价", IsNullable = true)]
    public string? TimeEvaluation { get; set; }
    #endregion

    #region 改进建议
    /// <summary>
    /// 内容改进建议
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "content_suggestions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "内容改进建议", IsNullable = true)]
    public string? ContentSuggestions { get; set; }

    /// <summary>
    /// 讲师改进建议
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "trainer_suggestions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "讲师改进建议", IsNullable = true)]
    public string? TrainerSuggestions { get; set; }

    /// <summary>
    /// 组织改进建议
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "organization_suggestions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "组织改进建议", IsNullable = true)]
    public string? OrganizationSuggestions { get; set; }

    /// <summary>
    /// 其他建议
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "other_suggestions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "其他建议", IsNullable = true)]
    public string? OtherSuggestions { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否匿名
    /// </summary>
    [SugarColumn(ColumnName = "is_anonymous", ColumnDescription = "是否匿名", IsNullable = false, DefaultValue = "0")]
    public bool IsAnonymous { get; set; }

    /// <summary>
    /// 是否采纳
    /// </summary>
    [SugarColumn(ColumnName = "is_adopted", ColumnDescription = "是否采纳", IsNullable = false, DefaultValue = "0")]
    public bool IsAdopted { get; set; }

    /// <summary>
    /// 采纳说明
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "adoption_notes", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "采纳说明", IsNullable = true)]
    public string? AdoptionNotes { get; set; }

    /// <summary>
    /// 评估备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "evaluation_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估备注", IsNullable = true)]
    public string? EvaluationRemarks { get; set; }
    #endregion
  }
}