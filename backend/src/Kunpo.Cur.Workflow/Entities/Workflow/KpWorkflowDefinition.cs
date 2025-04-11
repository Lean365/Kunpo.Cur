// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>工作流定义实体类</summary>
// <remarks>处理工作流定义的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Workflow
{
  /// <summary>
  /// 工作流定义实体类
  /// </summary>
  [SugarTable("kp_wf_workflow_definition", "工作流定义")]
  [SugarIndex("idx_workflow_definition_code", nameof(DefinitionCode), OrderByType.Asc)]
  public class KpWorkflowDefinition : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 定义编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "definition_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "定义编码", IsNullable = false)]
    public string? DefinitionCode { get; set; }

    /// <summary>
    /// 定义名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "definition_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "定义名称", IsNullable = false)]
    public string? DefinitionName { get; set; }

    /// <summary>
    /// 定义类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "definition_type", ColumnDataType = "int", ColumnDescription = "定义类型", IsNullable = false)]
    public int DefinitionType { get; set; }

    /// <summary>
    /// 定义状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "definition_status", ColumnDataType = "int", ColumnDescription = "定义状态", IsNullable = false)]
    public int DefinitionStatus { get; set; }

    /// <summary>
    /// 定义描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "definition_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "定义描述", IsNullable = true)]
    public string? DefinitionDescription { get; set; }
    #endregion

    #region 定义信息
    /// <summary>
    /// 定义内容
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "definition_content", ColumnDataType = "text", ColumnDescription = "定义内容", IsNullable = false)]
    public string? DefinitionContent { get; set; }

    /// <summary>
    /// 定义参数
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "definition_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "定义参数", IsNullable = true)]
    public string? DefinitionParameters { get; set; }

    /// <summary>
    /// 定义版本
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "definition_version", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "定义版本", IsNullable = false)]
    public string? DefinitionVersion { get; set; }
    #endregion

    #region 管理信息
    /// <summary>
    /// 创建人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "creator_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "创建人编码", IsNullable = false)]
    public string? CreatorCode { get; set; }

    /// <summary>
    /// 创建人名称
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "creator_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "创建人名称", IsNullable = false)]
    public string? CreatorName { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "create_time", ColumnDataType = "datetime", ColumnDescription = "创建时间", IsNullable = false)]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 最后修改人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "last_modifier_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "最后修改人编码", IsNullable = true)]
    public string? LastModifierCode { get; set; }

    /// <summary>
    /// 最后修改人名称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "last_modifier_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "最后修改人名称", IsNullable = true)]
    public string? LastModifierName { get; set; }

    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnName = "last_modify_time", ColumnDataType = "datetime", ColumnDescription = "最后修改时间", IsNullable = true)]
    public DateTime? LastModifyTime { get; set; }
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