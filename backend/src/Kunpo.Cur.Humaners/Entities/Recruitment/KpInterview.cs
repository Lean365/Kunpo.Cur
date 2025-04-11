/******************************************************************************
 * 文件名称：KpInterview.cs
 * 文件描述：面试记录实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Recruitment
{
  /// <summary>
  /// 面试记录实体类
  /// </summary>
  [SugarTable("kp_hr_interview", "面试记录")]
  [SugarIndex("idx_interview_code", nameof(InterviewCode), OrderByType.Asc)]
  public class KpInterview : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 面试编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "interview_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "面试编码", IsNullable = false)]
    public string? InterviewCode { get; set; }

    /// <summary>
    /// 候选人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "candidate_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "候选人编码", IsNullable = false)]
    public string? CandidateCode { get; set; }

    /// <summary>
    /// 面试类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "interview_type", ColumnDescription = "面试类型", IsNullable = false)]
    public int InterviewType { get; set; }

    /// <summary>
    /// 面试状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "interview_status", ColumnDescription = "面试状态", IsNullable = false)]
    public int InterviewStatus { get; set; }
    #endregion

    #region 面试信息
    /// <summary>
    /// 面试时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "interview_time", ColumnDataType = "datetime", ColumnDescription = "面试时间", IsNullable = false)]
    public DateTime InterviewTime { get; set; }

    /// <summary>
    /// 面试地点
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "interview_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "面试地点", IsNullable = false)]
    public string? InterviewLocation { get; set; }

    /// <summary>
    /// 面试方式
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "interview_method", ColumnDescription = "面试方式", IsNullable = false)]
    public int InterviewMethod { get; set; }

    /// <summary>
    /// 面试时长
    /// </summary>
    [SugarColumn(ColumnName = "interview_duration", ColumnDescription = "面试时长", IsNullable = true)]
    public int? InterviewDuration { get; set; }
    #endregion

    #region 面试官信息
    /// <summary>
    /// 面试官编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "interviewer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "面试官编码", IsNullable = false)]
    public string? InterviewerCode { get; set; }

    /// <summary>
    /// 面试官姓名
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "interviewer_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "面试官姓名", IsNullable = false)]
    public string? InterviewerName { get; set; }

    /// <summary>
    /// 面试官职位
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "interviewer_position", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "面试官职位", IsNullable = false)]
    public string? InterviewerPosition { get; set; }
    #endregion

    #region 评估信息
    /// <summary>
    /// 面试评分
    /// </summary>
    [SugarColumn(ColumnName = "interview_score", ColumnDescription = "面试评分", IsNullable = true)]
    public decimal? InterviewScore { get; set; }

    /// <summary>
    /// 面试评价
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "interview_evaluation", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "面试评价", IsNullable = true)]
    public string? InterviewEvaluation { get; set; }

    /// <summary>
    /// 面试结果
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "interview_result", ColumnDescription = "面试结果", IsNullable = false)]
    public int InterviewResult { get; set; }

    /// <summary>
    /// 面试建议
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "interview_suggestion", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "面试建议", IsNullable = true)]
    public string? InterviewSuggestion { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否通过
    /// </summary>
    [SugarColumn(ColumnName = "is_passed", ColumnDescription = "是否通过", IsNullable = false, DefaultValue = "0")]
    public bool IsPassed { get; set; }

    /// <summary>
    /// 面试备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "interview_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "面试备注", IsNullable = true)]
    public string? InterviewRemarks { get; set; }
    #endregion
  }
}