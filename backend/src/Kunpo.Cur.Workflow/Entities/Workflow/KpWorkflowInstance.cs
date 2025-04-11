// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>工作流实例实体类</summary>
// <remarks>处理工作流实例的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Workflow
{
  /// <summary>
  /// 工作流实例实体类
  /// </summary>
  [SugarTable("kp_wf_workflow_instance", "工作流实例")]
  [SugarIndex("idx_workflow_instance_code", nameof(InstanceCode), OrderByType.Asc)]
  public class KpWorkflowInstance : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 实例编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "instance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "实例编码", IsNullable = false)]
    public string? InstanceCode { get; set; }

    /// <summary>
    /// 定义编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "definition_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "定义编码", IsNullable = false)]
    public string? DefinitionCode { get; set; }

    /// <summary>
    /// 实例名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "instance_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "实例名称", IsNullable = false)]
    public string? InstanceName { get; set; }

    /// <summary>
    /// 实例状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "instance_status", ColumnDataType = "int", ColumnDescription = "实例状态", IsNullable = false)]
    public int InstanceStatus { get; set; }

    /// <summary>
    /// 实例描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "instance_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "实例描述", IsNullable = true)]
    public string? InstanceDescription { get; set; }
    #endregion

    #region 流程信息
    /// <summary>
    /// 发起人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "initiator_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "发起人编码", IsNullable = false)]
    public string? InitiatorCode { get; set; }

    /// <summary>
    /// 发起人名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "initiator_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "发起人名称", IsNullable = false)]
    public string? InitiatorName { get; set; }

    /// <summary>
    /// 发起部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "initiator_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "发起部门编码", IsNullable = false)]
    public string? InitiatorDeptCode { get; set; }

    /// <summary>
    /// 发起部门名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "initiator_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "发起部门名称", IsNullable = false)]
    public string? InitiatorDeptName { get; set; }

    /// <summary>
    /// 当前处理人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "current_handler_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "当前处理人编码", IsNullable = true)]
    public string? CurrentHandlerCode { get; set; }

    /// <summary>
    /// 当前处理人名称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "current_handler_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "当前处理人名称", IsNullable = true)]
    public string? CurrentHandlerName { get; set; }

    /// <summary>
    /// 当前处理部门编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "current_handler_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "当前处理部门编码", IsNullable = true)]
    public string? CurrentHandlerDeptCode { get; set; }

    /// <summary>
    /// 当前处理部门名称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "current_handler_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "当前处理部门名称", IsNullable = true)]
    public string? CurrentHandlerDeptName { get; set; }

    /// <summary>
    /// 当前节点编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "current_node_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "当前节点编码", IsNullable = true)]
    public string? CurrentNodeCode { get; set; }

    /// <summary>
    /// 当前节点名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "current_node_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "当前节点名称", IsNullable = true)]
    public string? CurrentNodeName { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 发起时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "initiate_time", ColumnDataType = "datetime", ColumnDescription = "发起时间", IsNullable = false)]
    public DateTime InitiateTime { get; set; }

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
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public bool IsEnabled { get; set; }

    #endregion
  }
}