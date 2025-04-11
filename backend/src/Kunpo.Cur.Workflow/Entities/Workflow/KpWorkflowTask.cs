// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>工作流任务实体类</summary>
// <remarks>处理工作流任务的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Workflow
{
  /// <summary>
  /// 工作流任务实体类
  /// </summary>
  [SugarTable("kp_wf_workflow_task", "工作流任务")]
  [SugarIndex("idx_workflow_task_code", nameof(TaskCode), OrderByType.Asc)]
  public class KpWorkflowTask : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 任务编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 实例编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "instance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "实例编码", IsNullable = false)]
    public string? InstanceCode { get; set; }

    /// <summary>
    /// 节点编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "node_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "节点编码", IsNullable = false)]
    public string? NodeCode { get; set; }

    /// <summary>
    /// 任务名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "task_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "任务名称", IsNullable = false)]
    public string? TaskName { get; set; }

    /// <summary>
    /// 任务类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "task_type", ColumnDataType = "int", ColumnDescription = "任务类型", IsNullable = false)]
    public int TaskType { get; set; }

    /// <summary>
    /// 任务状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "task_status", ColumnDataType = "int", ColumnDescription = "任务状态", IsNullable = false)]
    public int TaskStatus { get; set; }

    /// <summary>
    /// 任务描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "task_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "任务描述", IsNullable = true)]
    public string? TaskDescription { get; set; }
    #endregion

    #region 处理信息
    /// <summary>
    /// 处理人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "handler_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "处理人编码", IsNullable = false)]
    public string? HandlerCode { get; set; }

    /// <summary>
    /// 处理人名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "handler_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "处理人名称", IsNullable = false)]
    public string? HandlerName { get; set; }

    /// <summary>
    /// 处理部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "handler_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "处理部门编码", IsNullable = false)]
    public string? HandlerDeptCode { get; set; }

    /// <summary>
    /// 处理部门名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "handler_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "处理部门名称", IsNullable = false)]
    public string? HandlerDeptName { get; set; }

    /// <summary>
    /// 处理意见
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "handler_opinion", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "处理意见", IsNullable = true)]
    public string? HandlerOpinion { get; set; }

    /// <summary>
    /// 处理结果
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "handler_result", ColumnDataType = "int", ColumnDescription = "处理结果", IsNullable = false)]
    public int HandlerResult { get; set; }

    /// <summary>
    /// 转办人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "transfer_to_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "转办人编码", IsNullable = true)]
    public string? TransferToCode { get; set; }

    /// <summary>
    /// 转办人名称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "transfer_to_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "转办人名称", IsNullable = true)]
    public string? TransferToName { get; set; }

    /// <summary>
    /// 退回节点编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "return_to_node_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "退回节点编码", IsNullable = true)]
    public string? ReturnToNodeCode { get; set; }

    /// <summary>
    /// 退回节点名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "return_to_node_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "退回节点名称", IsNullable = true)]
    public string? ReturnToNodeName { get; set; }
    #endregion

    #region 时间信息

    /// <summary>
    /// 处理时间
    /// </summary>
    [SugarColumn(ColumnName = "process_time", ColumnDataType = "datetime", ColumnDescription = "处理时间", IsNullable = true)]
    public DateTime? ProcessTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    [SugarColumn(ColumnName = "complete_time", ColumnDataType = "datetime", ColumnDescription = "完成时间", IsNullable = true)]
    public DateTime? CompleteTime { get; set; }
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