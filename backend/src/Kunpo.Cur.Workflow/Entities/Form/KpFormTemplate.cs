// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>表单模板实体类</summary>
// <remarks>处理表单模板的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Form
{
  /// <summary>
  /// 表单模板实体类
  /// </summary>
  [SugarTable("kp_wf_form_template", "表单模板")]
  [SugarIndex("idx_form_template_code", nameof(TemplateCode), OrderByType.Asc)]
  public class KpFormTemplate : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 模板编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "template_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "模板编码", IsNullable = false)]
    public string? TemplateCode { get; set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "template_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "模板名称", IsNullable = false)]
    public string? TemplateName { get; set; }

    /// <summary>
    /// 模板类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "template_type", ColumnDescription = "模板类型", IsNullable = false)]
    public int TemplateType { get; set; }

    /// <summary>
    /// 模板状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "template_status", ColumnDescription = "模板状态", IsNullable = false)]
    public int TemplateStatus { get; set; }

    /// <summary>
    /// 模板描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "template_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板描述", IsNullable = true)]
    public string? TemplateDescription { get; set; }
    #endregion

    #region 模板信息
    /// <summary>
    /// 模板内容
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "template_content", ColumnDataType = "text", ColumnDescription = "模板内容", IsNullable = false)]
    public string? TemplateContent { get; set; }

    /// <summary>
    /// 模板参数
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "template_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "模板参数", IsNullable = true)]
    public string? TemplateParameters { get; set; }

    /// <summary>
    /// 模板版本
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "template_version", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "模板版本", IsNullable = false)]
    public string? TemplateVersion { get; set; }
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
    [SugarColumn(ColumnName = "create_time", ColumnDescription = "创建时间", IsNullable = false)]
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
    [SugarColumn(ColumnName = "last_modify_time", ColumnDescription = "最后修改时间", IsNullable = true)]
    public DateTime? LastModifyTime { get; set; }
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
    /// 模板备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "template_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板备注", IsNullable = true)]
    public string? TemplateRemarks { get; set; }
    #endregion
  }
}