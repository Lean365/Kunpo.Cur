/******************************************************************************
 * 文件名称：KpSafetyTraining.cs
 * 文件描述：安全培训实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Employee
{
  /// <summary>
  /// 安全培训实体类
  /// </summary>
  [SugarTable("kp_hr_safety_training", "安全培训")]
  [SugarIndex("idx_safety_training_code", nameof(TrainingCode), OrderByType.Asc)]
  public class KpSafetyTraining : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 培训编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "training_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "培训编码", IsNullable = false)]
    public string? TrainingCode { get; set; }

    /// <summary>
    /// 培训名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "training_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "培训名称", IsNullable = false)]
    public string? TrainingName { get; set; }

    /// <summary>
    /// 培训类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_type", ColumnDescription = "培训类型", IsNullable = false)]
    public int TrainingType { get; set; }

    /// <summary>
    /// 培训状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_status", ColumnDescription = "培训状态", IsNullable = false)]
    public int TrainingStatus { get; set; }

    /// <summary>
    /// 培训描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训描述", IsNullable = true)]
    public string? TrainingDescription { get; set; }
    #endregion

    #region 培训信息
    /// <summary>
    /// 培训讲师
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "trainer", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "培训讲师", IsNullable = true)]
    public string? Trainer { get; set; }

    /// <summary>
    /// 培训地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "training_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "培训地点", IsNullable = true)]
    public string? TrainingLocation { get; set; }

    /// <summary>
    /// 培训内容
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "training_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "培训内容", IsNullable = true)]
    public string? TrainingContent { get; set; }

    /// <summary>
    /// 培训时长
    /// </summary>
    [SugarColumn(ColumnName = "training_duration", ColumnDescription = "培训时长", IsNullable = true)]
    public int? TrainingDuration { get; set; }

    /// <summary>
    /// 培训人数
    /// </summary>
    [SugarColumn(ColumnName = "training_count", ColumnDescription = "培训人数", IsNullable = true)]
    public int? TrainingCount { get; set; }

    /// <summary>
    /// 培训费用
    /// </summary>
    [SugarColumn(ColumnName = "training_cost", ColumnDescription = "培训费用", IsNullable = true)]
    public decimal? TrainingCost { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 培训开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_start_time", ColumnDescription = "培训开始时间", IsNullable = false)]
    public DateTime TrainingStartTime { get; set; }

    /// <summary>
    /// 培训结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "training_end_time", ColumnDescription = "培训结束时间", IsNullable = false)]
    public DateTime TrainingEndTime { get; set; }

    /// <summary>
    /// 报名截止时间
    /// </summary>
    [SugarColumn(ColumnName = "registration_deadline", ColumnDescription = "报名截止时间", IsNullable = true)]
    public DateTime? RegistrationDeadline { get; set; }
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
    /// 培训备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训备注", IsNullable = true)]
    public string? TrainingRemarks { get; set; }
    #endregion
  }
}