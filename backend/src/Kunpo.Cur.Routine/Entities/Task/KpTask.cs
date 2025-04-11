// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>任务实体类</summary>
// <remarks>处理任务的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Task
{
  /// <summary>
  /// 任务实体类
  /// </summary>
  [SugarTable("kp_ro_task")]
  [SugarIndex("idx_task_code", nameof(TaskCode), OrderByType.Asc)]
  public class KpTask : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 任务编码
    /// </summary>
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false, IsPrimaryKey = true)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 任务类型
    /// </summary>
    [SugarColumn(ColumnName = "task_type", ColumnDataType = "int", ColumnDescription = "任务类型", IsNullable = false)]
    public int TaskType { get; set; }

    /// <summary>
    /// 任务状态
    /// </summary>
    [SugarColumn(ColumnName = "task_status", ColumnDataType = "int", ColumnDescription = "任务状态", IsNullable = false)]
    public int TaskStatus { get; set; }

    /// <summary>
    /// 任务标题
    /// </summary>
    [SugarColumn(ColumnName = "task_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "任务标题", IsNullable = false)]
    public string? TaskTitle { get; set; }

    /// <summary>
    /// 任务描述
    /// </summary>
    [SugarColumn(ColumnName = "task_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "任务描述", IsNullable = true)]
    public string? TaskDescription { get; set; }

    /// <summary>
    /// 任务内容
    /// </summary>
    [SugarColumn(ColumnName = "task_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "任务内容", IsNullable = true)]
    public string? TaskContent { get; set; }

    /// <summary>
    /// 任务参数
    /// </summary>
    [SugarColumn(ColumnName = "task_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "任务参数", IsNullable = true)]
    public string? TaskParameters { get; set; }

    /// <summary>
    /// 任务附件
    /// </summary>
    [SugarColumn(ColumnName = "task_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "任务附件", IsNullable = true)]
    public string? TaskAttachments { get; set; }

    /// <summary>
    /// 任务标签
    /// </summary>
    [SugarColumn(ColumnName = "task_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "任务标签", IsNullable = true)]
    public string? TaskTags { get; set; }
    #endregion

    #region 任务人信息
    /// <summary>
    /// 负责人编码
    /// </summary>
    [SugarColumn(ColumnName = "assignee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "负责人编码", IsNullable = false)]
    public string? AssigneeCode { get; set; }

    /// <summary>
    /// 负责人名称
    /// </summary>
    [SugarColumn(ColumnName = "assignee_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "负责人名称", IsNullable = false)]
    public string? AssigneeName { get; set; }

    /// <summary>
    /// 负责部门编码
    /// </summary>
    [SugarColumn(ColumnName = "assignee_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "负责部门编码", IsNullable = true)]
    public string? AssigneeDeptCode { get; set; }

    /// <summary>
    /// 负责部门名称
    /// </summary>
    [SugarColumn(ColumnName = "assignee_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "负责部门名称", IsNullable = true)]
    public string? AssigneeDeptName { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 开始时间
    /// </summary>
    [SugarColumn(ColumnName = "start_time", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [SugarColumn(ColumnName = "end_time", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 计划开始时间
    /// </summary>
    [SugarColumn(ColumnName = "plan_start_time", ColumnDataType = "datetime", ColumnDescription = "计划开始时间", IsNullable = true)]
    public DateTime? PlanStartTime { get; set; }

    /// <summary>
    /// 计划结束时间
    /// </summary>
    [SugarColumn(ColumnName = "plan_end_time", ColumnDataType = "datetime", ColumnDescription = "计划结束时间", IsNullable = true)]
    public DateTime? PlanEndTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    [SugarColumn(ColumnName = "complete_time", ColumnDescription = "完成时间", IsNullable = true)]
    public DateTime? CompleteTime { get; set; }
    #endregion

    #region 任务信息
    /// <summary>
    /// 任务优先级
    /// </summary>
    [SugarColumn(ColumnName = "task_priority", ColumnDataType = "int", ColumnDescription = "任务优先级", IsNullable = false, DefaultValue = "0")]
    public int TaskPriority { get; set; }

    /// <summary>
    /// 任务难度
    /// </summary>
    [SugarColumn(ColumnName = "task_difficulty", ColumnDataType = "int", ColumnDescription = "任务难度", IsNullable = true)]
    public int? TaskDifficulty { get; set; }

    /// <summary>
    /// 任务进度
    /// </summary>
    [SugarColumn(ColumnName = "task_progress", ColumnDataType = "int", ColumnDescription = "任务进度", IsNullable = false, DefaultValue = "0")]
    public int TaskProgress { get; set; }

    /// <summary>
    /// 任务评分
    /// </summary>
    [SugarColumn(ColumnName = "task_score", ColumnDataType = "int", ColumnDescription = "任务评分", IsNullable = true)]
    public int? TaskScore { get; set; }

    /// <summary>
    /// 任务评价
    /// </summary>
    [SugarColumn(ColumnName = "task_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "任务评价", IsNullable = true)]
    public string? TaskEvaluation { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public int IsEnabled { get; set; }
    #endregion
  }
}