// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>工作流审批实体类</summary>
// <remarks>处理工作流审批的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Workflow
{
  /// <summary>
  /// 工作流审批实体类
  /// </summary>
  [SugarTable("kp_wf_workflow_approval", "工作流审批")]
  [SugarIndex("idx_workflow_approval_code", nameof(ApprovalCode), OrderByType.Asc)]
  public class KpWorkflowApproval : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 审批编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "approval_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批编码", IsNullable = false)]
    public string? ApprovalCode { get; set; }

    /// <summary>
    /// 任务编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 审批类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "approval_type", ColumnDataType = "int", ColumnDescription = "审批类型", IsNullable = false)]
    public int ApprovalType { get; set; }

    /// <summary>
    /// 审批状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "approval_status", ColumnDataType = "int", ColumnDescription = "审批状态", IsNullable = false)]
    public int ApprovalStatus { get; set; }

    /// <summary>
    /// 审批描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "approval_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "审批描述", IsNullable = true)]
    public string? ApprovalDescription { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人编码", IsNullable = false)]
    public string? ApproverCode { get; set; }

    /// <summary>
    /// 审批人名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "approver_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "审批人名称", IsNullable = false)]
    public string? ApproverName { get; set; }

    /// <summary>
    /// 审批部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批部门编码", IsNullable = false)]
    public string? ApproverDeptCode { get; set; }

    /// <summary>
    /// 审批部门名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "approver_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "审批部门名称", IsNullable = false)]
    public string? ApproverDeptName { get; set; }

    /// <summary>
    /// 审批意见
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "approval_opinion", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "审批意见", IsNullable = true)]
    public string? ApprovalOpinion { get; set; }

    /// <summary>
    /// 审批结果
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "approval_result", ColumnDataType = "int", ColumnDescription = "审批结果", IsNullable = false)]
    public int ApprovalResult { get; set; }

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
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDataType = "datetime", ColumnDescription = "审批时间", IsNullable = true)]
    public DateTime? ApprovalTime { get; set; }

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