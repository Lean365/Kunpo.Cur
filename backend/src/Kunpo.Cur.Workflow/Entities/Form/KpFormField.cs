// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>表单字段实体类</summary>
// <remarks>处理表单字段的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Workflow.Entities.Form
{
  /// <summary>
  /// 表单字段实体类
  /// </summary>
  [SugarTable("kp_wf_form_field", "表单字段")]
  [SugarIndex("idx_form_field_code", nameof(FieldCode), OrderByType.Asc)]
  public class KpFormField : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 字段编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "field_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "字段编码", IsNullable = false)]
    public string? FieldCode { get; set; }

    /// <summary>
    /// 模板编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "template_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "模板编码", IsNullable = false)]
    public string? TemplateCode { get; set; }

    /// <summary>
    /// 字段名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "field_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字段名称", IsNullable = false)]
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "field_type", ColumnDescription = "字段类型", IsNullable = false)]
    public int FieldType { get; set; }

    /// <summary>
    /// 字段状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "field_status", ColumnDescription = "字段状态", IsNullable = false)]
    public int FieldStatus { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "field_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "字段描述", IsNullable = true)]
    public string? FieldDescription { get; set; }
    #endregion

    #region 字段信息
    /// <summary>
    /// 字段默认值
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "field_default_value", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "字段默认值", IsNullable = true)]
    public string? FieldDefaultValue { get; set; }

    /// <summary>
    /// 字段验证规则
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "field_validation_rule", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "字段验证规则", IsNullable = true)]
    public string? FieldValidationRule { get; set; }

    /// <summary>
    /// 字段验证提示
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "field_validation_message", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "字段验证提示", IsNullable = true)]
    public string? FieldValidationMessage { get; set; }

    /// <summary>
    /// 字段排序
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "field_sort", ColumnDescription = "字段排序", IsNullable = false)]
    public int FieldSort { get; set; }

    /// <summary>
    /// 字段宽度
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "field_width", ColumnDescription = "字段宽度", IsNullable = false)]
    public int FieldWidth { get; set; }

    /// <summary>
    /// 字段高度
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "field_height", ColumnDescription = "字段高度", IsNullable = false)]
    public int FieldHeight { get; set; }

    /// <summary>
    /// 字段样式
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "field_style", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "字段样式", IsNullable = true)]
    public string? FieldStyle { get; set; }

    /// <summary>
    /// 字段属性
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "field_properties", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "字段属性", IsNullable = true)]
    public string? FieldProperties { get; set; }
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
    /// 字段备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "field_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "字段备注", IsNullable = true)]
    public string? FieldRemarks { get; set; }
    #endregion
  }
}