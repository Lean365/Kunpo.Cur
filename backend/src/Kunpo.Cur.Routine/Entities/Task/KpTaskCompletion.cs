// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>任务完成实体类</summary>
// <remarks>处理任务完成的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Task
{
  /// <summary>
  /// 任务完成实体类
  /// </summary>
  [SugarTable("kp_ro_task_completion")]
  [SugarIndex("idx_task_completion_code", nameof(CompletionCode), OrderByType.Asc)]
  public class KpTaskCompletion : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 完成编码
    /// </summary>
    [SugarColumn(ColumnName = "completion_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "完成编码", IsNullable = false, IsPrimaryKey = true)]
    public string? CompletionCode { get; set; }

    /// <summary>
    /// 任务编码
    /// </summary>
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 完成类型
    /// </summary>
    [SugarColumn(ColumnName = "completion_type", ColumnDataType = "int", ColumnDescription = "完成类型", IsNullable = false)]
    public int CompletionType { get; set; }

    /// <summary>
    /// 完成状态
    /// </summary>
    [SugarColumn(ColumnName = "completion_status", ColumnDataType = "int", ColumnDescription = "完成状态", IsNullable = false)]
    public int CompletionStatus { get; set; }

    /// <summary>
    /// 完成描述
    /// </summary>
    [SugarColumn(ColumnName = "completion_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "完成描述", IsNullable = true)]
    public string? CompletionDescription { get; set; }
    #endregion

    #region 完成信息
    /// <summary>
    /// 完成标题
    /// </summary>
    [SugarColumn(ColumnName = "completion_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "完成标题", IsNullable = false)]
    public string? CompletionTitle { get; set; }

    /// <summary>
    /// 完成内容
    /// </summary>
    [SugarColumn(ColumnName = "completion_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "完成内容", IsNullable = true)]
    public string? CompletionContent { get; set; }

    /// <summary>
    /// 完成参数
    /// </summary>
    [SugarColumn(ColumnName = "completion_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "完成参数", IsNullable = true)]
    public string? CompletionParameters { get; set; }

    /// <summary>
    /// 完成附件
    /// </summary>
    [SugarColumn(ColumnName = "completion_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "完成附件", IsNullable = true)]
    public string? CompletionAttachments { get; set; }

    /// <summary>
    /// 完成评分
    /// </summary>
    [SugarColumn(ColumnName = "completion_score", ColumnDataType = "int", ColumnDescription = "完成评分", IsNullable = true)]
    public int? CompletionScore { get; set; }

    /// <summary>
    /// 完成评价
    /// </summary>
    [SugarColumn(ColumnName = "completion_evaluation", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "完成评价", IsNullable = true)]
    public string? CompletionEvaluation { get; set; }
    #endregion

    #region 完成人信息
    /// <summary>
    /// 完成人编码
    /// </summary>
    [SugarColumn(ColumnName = "completer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "完成人编码", IsNullable = false)]
    public string? CompleterCode { get; set; }

    /// <summary>
    /// 完成人名称
    /// </summary>
    [SugarColumn(ColumnName = "completer_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "完成人名称", IsNullable = false)]
    public string? CompleterName { get; set; }

    /// <summary>
    /// 完成人部门编码
    /// </summary>
    [SugarColumn(ColumnName = "completer_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "完成人部门编码", IsNullable = true)]
    public string? CompleterDeptCode { get; set; }

    /// <summary>
    /// 完成人部门名称
    /// </summary>
    [SugarColumn(ColumnName = "completer_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "完成人部门名称", IsNullable = true)]
    public string? CompleterDeptName { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    [SugarColumn(ColumnName = "completion_time", ColumnDataType = "datetime", ColumnDescription = "完成时间", IsNullable = false)]
    public DateTime CompletionTime { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    [SugarColumn(ColumnName = "review_time", ColumnDataType = "datetime", ColumnDescription = "审核时间", IsNullable = true)]
    public DateTime? ReviewTime { get; set; }
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