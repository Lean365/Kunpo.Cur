/******************************************************************************
 * 文件名称：KpTrainingPlan.cs
 * 文件描述：培训计划实体类
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
  /// 培训计划实体类
  /// </summary>
  [SugarTable("kp_hr_training_plan", "培训计划")]
  [SugarIndex("idx_training_plan_code", nameof(PlanCode), OrderByType.Asc)]
  public class KpTrainingPlan : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 计划编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "plan_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "计划编码", IsNullable = false)]
    public string? PlanCode { get; set; }

    /// <summary>
    /// 计划名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "plan_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "计划名称", IsNullable = false)]
    public string? PlanName { get; set; }

    /// <summary>
    /// 计划类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "plan_type", ColumnDescription = "计划类型", IsNullable = false)]
    public int PlanType { get; set; }

    /// <summary>
    /// 计划状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "plan_status", ColumnDescription = "计划状态", IsNullable = false)]
    public int PlanStatus { get; set; }

    /// <summary>
    /// 计划描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "plan_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "计划描述", IsNullable = true)]
    public string? PlanDescription { get; set; }
    #endregion

    #region 培训信息
    /// <summary>
    /// 开始日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "start_date", ColumnDataType = "date", ColumnDescription = "开始日期", IsNullable = false)]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 结束日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "end_date", ColumnDataType = "date", ColumnDescription = "结束日期", IsNullable = false)]
    public DateTime EndDate { get; set; }

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

    /// <summary>
    /// 培训目标
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "training_objective", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "培训目标", IsNullable = false)]
    public string? TrainingObjective { get; set; }

    /// <summary>
    /// 培训内容
    /// </summary>
    [Required]
    [StringLength(2000)]
    [SugarColumn(ColumnName = "training_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "培训内容", IsNullable = false)]
    public string? TrainingContent { get; set; }
    #endregion

    #region 费用信息
    /// <summary>
    /// 预算金额
    /// </summary>
    [SugarColumn(ColumnName = "budget_amount", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "预算金额", IsNullable = true)]
    public decimal? BudgetAmount { get; set; }

    /// <summary>
    /// 实际金额
    /// </summary>
    [SugarColumn(ColumnName = "actual_amount", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "实际金额", IsNullable = true)]
    public decimal? ActualAmount { get; set; }

    /// <summary>
    /// 费用币种
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "cost_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "费用币种", IsNullable = true)]
    public string? CostCurrency { get; set; }
    #endregion

    #region 参与信息
    /// <summary>
    /// 计划人数
    /// </summary>
    [SugarColumn(ColumnName = "planned_participants", ColumnDescription = "计划人数", IsNullable = true)]
    public int? PlannedParticipants { get; set; }

    /// <summary>
    /// 实际人数
    /// </summary>
    [SugarColumn(ColumnName = "actual_participants", ColumnDescription = "实际人数", IsNullable = true)]
    public int? ActualParticipants { get; set; }

    /// <summary>
    /// 参与部门
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "participant_departments", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "参与部门", IsNullable = true)]
    public string? ParticipantDepartments { get; set; }

    /// <summary>
    /// 参与职位
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "participant_positions", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "参与职位", IsNullable = true)]
    public string? ParticipantPositions { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否必修
    /// </summary>
    [SugarColumn(ColumnName = "is_required", ColumnDescription = "是否必修", IsNullable = false, DefaultValue = "0")]
    public bool IsRequired { get; set; }

    /// <summary>
    /// 是否考核
    /// </summary>
    [SugarColumn(ColumnName = "is_assessment", ColumnDescription = "是否考核", IsNullable = false, DefaultValue = "0")]
    public bool IsAssessment { get; set; }

    /// <summary>
    /// 计划备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "plan_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "计划备注", IsNullable = true)]
    public string? PlanRemarks { get; set; }
    #endregion
  }
}