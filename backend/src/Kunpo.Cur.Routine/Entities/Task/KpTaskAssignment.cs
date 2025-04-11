// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>任务分配实体类</summary>
// <remarks>处理任务分配的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Task
{
  /// <summary>
  /// 任务分配实体类
  /// </summary>
  [SugarTable("kp_ro_task_assignment")]
  [SugarIndex("idx_task_assignment_code", nameof(AssignmentCode), OrderByType.Asc)]
  public class KpTaskAssignment : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 分配编码
    /// </summary>
    [SugarColumn(ColumnName = "assignment_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "分配编码", IsNullable = false, IsPrimaryKey = true)]
    public string? AssignmentCode { get; set; }

    /// <summary>
    /// 任务编码
    /// </summary>
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 分配类型
    /// </summary>
    [SugarColumn(ColumnName = "assignment_type", ColumnDataType = "int", ColumnDescription = "分配类型", IsNullable = false)]
    public int AssignmentType { get; set; }

    /// <summary>
    /// 分配状态
    /// </summary>
    [SugarColumn(ColumnName = "assignment_status", ColumnDescription = "分配状态", IsNullable = false)]
    public int AssignmentStatus { get; set; }

    /// <summary>
    /// 分配描述
    /// </summary>
    [SugarColumn(ColumnName = "assignment_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "分配描述", IsNullable = true)]
    public string? AssignmentDescription { get; set; }
    #endregion

    #region 分配信息
    /// <summary>
    /// 分配标题
    /// </summary>
    [SugarColumn(ColumnName = "assignment_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "分配标题", IsNullable = false)]
    public string? AssignmentTitle { get; set; }

    /// <summary>
    /// 分配内容
    /// </summary>
    [SugarColumn(ColumnName = "assignment_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "分配内容", IsNullable = true)]
    public string? AssignmentContent { get; set; }

    /// <summary>
    /// 分配参数
    /// </summary>
    [SugarColumn(ColumnName = "assignment_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "分配参数", IsNullable = true)]
    public string? AssignmentParameters { get; set; }

    /// <summary>
    /// 分配附件
    /// </summary>
    [SugarColumn(ColumnName = "assignment_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "分配附件", IsNullable = true)]
    public string? AssignmentAttachments { get; set; }

    /// <summary>
    /// 分配标签
    /// </summary>
    [SugarColumn(ColumnName = "assignment_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "分配标签", IsNullable = true)]
    public string? AssignmentTags { get; set; }
    #endregion

    #region 分配人信息
    /// <summary>
    /// 分配人编码
    /// </summary>
    [SugarColumn(ColumnName = "assigner_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "分配人编码", IsNullable = false)]
    public string? AssignerCode { get; set; }

    /// <summary>
    /// 分配人名称
    /// </summary>
    [SugarColumn(ColumnName = "assigner_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "分配人名称", IsNullable = false)]
    public string? AssignerName { get; set; }

    /// <summary>
    /// 分配人部门编码
    /// </summary>
    [SugarColumn(ColumnName = "assigner_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "分配人部门编码", IsNullable = true)]
    public string? AssignerDeptCode { get; set; }

    /// <summary>
    /// 分配人部门名称
    /// </summary>
    [SugarColumn(ColumnName = "assigner_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "分配人部门名称", IsNullable = true)]
    public string? AssignerDeptName { get; set; }

    /// <summary>
    /// 分配时间
    /// </summary>
    [SugarColumn(ColumnName = "assignment_time", ColumnDataType = "datetime", ColumnDescription = "分配时间", IsNullable = false)]
    public DateTime AssignmentTime { get; set; }
    #endregion

    #region 接收人信息
    /// <summary>
    /// 接收人编码
    /// </summary>
    [SugarColumn(ColumnName = "assignee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "被分配人编码", IsNullable = false)]
    public string? AssigneeCode { get; set; }

    /// <summary>
    /// 接收人名称
    /// </summary>
    [SugarColumn(ColumnName = "assignee_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "被分配人名称", IsNullable = false)]
    public string? AssigneeName { get; set; }

    /// <summary>
    /// 接收人部门编码
    /// </summary>
    [SugarColumn(ColumnName = "assignee_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "被分配部门编码", IsNullable = true)]
    public string? AssigneeDeptCode { get; set; }

    /// <summary>
    /// 接收人部门名称
    /// </summary>
    [SugarColumn(ColumnName = "assignee_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "被分配部门名称", IsNullable = true)]
    public string? AssigneeDeptName { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    [SugarColumn(ColumnName = "complete_time", ColumnDataType = "datetime", ColumnDescription = "完成时间", IsNullable = true)]
    public DateTime? CompleteTime { get; set; }

    /// <summary>
    /// 接收状态
    /// </summary>
    [SugarColumn(ColumnName = "receive_status", ColumnDataType = "int", ColumnDescription = "接收状态", IsNullable = false, DefaultValue = "0")]
    public int ReceiveStatus { get; set; }

    /// <summary>
    /// 接收结果
    /// </summary>
    [SugarColumn(ColumnName = "receive_result", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "接收结果", IsNullable = true)]
    public string? ReceiveResult { get; set; }

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