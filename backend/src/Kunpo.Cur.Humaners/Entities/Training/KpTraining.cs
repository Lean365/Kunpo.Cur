/******************************************************************************
 * 文件名称：KpTraining.cs
 * 文件描述：培训记录实体类
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
  /// 培训记录实体类
  /// </summary>
  [SugarTable("kp_hr_training", "培训记录")]
  [SugarIndex("idx_training_employee", nameof(EmployeeCode), OrderByType.Asc)]
  public class KpTraining : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 培训计划编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "plan_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "培训计划编码", IsNullable = false)]
    public string? PlanCode { get; set; }

    /// <summary>
    /// 培训状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_status", ColumnDescription = "培训状态", IsNullable = false)]
    public int TrainingStatus { get; set; }

    /// <summary>
    /// 培训日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_date", ColumnDataType = "date", ColumnDescription = "培训日期", IsNullable = false)]
    public DateTime TrainingDate { get; set; }
    #endregion

    #region 培训信息
    /// <summary>
    /// 开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "start_time", ColumnDataType = "time", ColumnDescription = "开始时间", IsNullable = false)]
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "end_time", ColumnDataType = "time", ColumnDescription = "结束时间", IsNullable = false)]
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// 培训时长(小时)
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_hours", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "培训时长(小时)", IsNullable = false)]
    public decimal TrainingHours { get; set; }

    /// <summary>
    /// 培训地点
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "training_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "培训地点", IsNullable = false)]
    public string? TrainingLocation { get; set; }

    /// <summary>
    /// 培训方式
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_method", ColumnDescription = "培训方式", IsNullable = false)]
    public int TrainingMethod { get; set; }

    /// <summary>
    /// 培训讲师
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "trainer", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "培训讲师", IsNullable = false)]
    public string? Trainer { get; set; }
    #endregion

    #region 评估信息
    /// <summary>
    /// 评估分数
    /// </summary>
    [SugarColumn(ColumnName = "assessment_score", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "评估分数", IsNullable = true)]
    public decimal? AssessmentScore { get; set; }

    /// <summary>
    /// 评估等级
    /// </summary>
    [SugarColumn(ColumnName = "assessment_level", ColumnDescription = "评估等级", IsNullable = true)]
    public int? AssessmentLevel { get; set; }

    /// <summary>
    /// 评估评语
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "assessment_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "评估评语", IsNullable = true)]
    public string? AssessmentComment { get; set; }

    /// <summary>
    /// 评估人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "assessor", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "评估人", IsNullable = true)]
    public string? Assessor { get; set; }

    /// <summary>
    /// 评估时间
    /// </summary>
    [SugarColumn(ColumnName = "assessment_time", ColumnDataType = "datetime", ColumnDescription = "评估时间", IsNullable = true)]
    public DateTime? AssessmentTime { get; set; }
    #endregion

    #region 反馈信息
    /// <summary>
    /// 培训反馈
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_feedback", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训反馈", IsNullable = true)]
    public string? TrainingFeedback { get; set; }

    /// <summary>
    /// 改进建议
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "improvement_suggestions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "改进建议", IsNullable = true)]
    public string? ImprovementSuggestions { get; set; }

    /// <summary>
    /// 培训收获
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_gains", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训收获", IsNullable = true)]
    public string? TrainingGains { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否完成
    /// </summary>
    [SugarColumn(ColumnName = "is_completed", ColumnDescription = "是否完成", IsNullable = false, DefaultValue = "0")]
    public bool IsCompleted { get; set; }

    /// <summary>
    /// 是否通过
    /// </summary>
    [SugarColumn(ColumnName = "is_passed", ColumnDescription = "是否通过", IsNullable = false, DefaultValue = "0")]
    public bool IsPassed { get; set; }

    /// <summary>
    /// 培训备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训备注", IsNullable = true)]
    public string? TrainingRemarks { get; set; }
    #endregion
  }
}