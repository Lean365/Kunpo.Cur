// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>报表参数实体类</summary>
// <remarks>处理报表参数的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Report
{
  /// <summary>
  /// 报表参数实体类
  /// </summary>
  [SugarTable("kp_ro_report_parameter")]
  [SugarIndex("idx_report_parameter_code", nameof(ParameterCode), OrderByType.Asc)]
  public class KpReportParameter : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 参数编码
    /// </summary>
    [SugarColumn(ColumnName = "parameter_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "参数编码", IsNullable = false, IsPrimaryKey = true)]
    [Required(ErrorMessage = "参数编码不能为空")]
    public string? ParameterCode { get; set; }

    /// <summary>
    /// 报表编码
    /// </summary>
    [SugarColumn(ColumnName = "report_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "报表编码", IsNullable = false)]
    [Required(ErrorMessage = "报表编码不能为空")]
    public string? ReportCode { get; set; }

    /// <summary>
    /// 参数类型
    /// </summary>
    [SugarColumn(ColumnName = "parameter_type", ColumnDataType = "int", ColumnDescription = "参数类型", IsNullable = false)]
    [Required(ErrorMessage = "参数类型不能为空")]
    public int ParameterType { get; set; }

    /// <summary>
    /// 参数状态
    /// </summary>
    [SugarColumn(ColumnName = "parameter_status", ColumnDataType = "int", ColumnDescription = "参数状态", IsNullable = false)]
    [Required(ErrorMessage = "参数状态不能为空")]
    public int ParameterStatus { get; set; }

    /// <summary>
    /// 参数标题
    /// </summary>
    [SugarColumn(ColumnName = "parameter_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "参数标题", IsNullable = false)]
    [Required(ErrorMessage = "参数标题不能为空")]
    public string? ParameterTitle { get; set; }

    /// <summary>
    /// 参数描述
    /// </summary>
    [SugarColumn(ColumnName = "parameter_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "参数描述", IsNullable = true)]
    public string? ParameterDescription { get; set; }
    #endregion

    #region 参数信息
    /// <summary>
    /// 参数值
    /// </summary>
    [SugarColumn(ColumnName = "parameter_value", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参数值", IsNullable = true)]
    public string? ParameterValue { get; set; }

    /// <summary>
    /// 参数默认值
    /// </summary>
    [SugarColumn(ColumnName = "parameter_default", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参数默认值", IsNullable = true)]
    public string? ParameterDefault { get; set; }

    /// <summary>
    /// 参数选项
    /// </summary>
    [SugarColumn(ColumnName = "parameter_options", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参数选项", IsNullable = true)]
    public string? ParameterOptions { get; set; }

    /// <summary>
    /// 参数验证
    /// </summary>
    [SugarColumn(ColumnName = "parameter_validation", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参数验证", IsNullable = true)]
    public string? ParameterValidation { get; set; }

    /// <summary>
    /// 参数顺序
    /// </summary>
    [SugarColumn(ColumnName = "parameter_order", ColumnDataType = "int", ColumnDescription = "参数顺序", IsNullable = false)]
    [Required(ErrorMessage = "参数顺序不能为空")]
    public int ParameterOrder { get; set; }

    /// <summary>
    /// 参数分组
    /// </summary>
    [SugarColumn(ColumnName = "parameter_group", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "参数分组", IsNullable = true)]
    public string? ParameterGroup { get; set; }

    /// <summary>
    /// 参数分类
    /// </summary>
    [SugarColumn(ColumnName = "parameter_category", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "参数分类", IsNullable = true)]
    public string? ParameterCategory { get; set; }

    /// <summary>
    /// 参数标签
    /// </summary>
    [SugarColumn(ColumnName = "parameter_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "参数标签", IsNullable = true)]
    public string? ParameterTags { get; set; }

    /// <summary>
    /// 参数格式
    /// </summary>
    [SugarColumn(ColumnName = "parameter_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "参数格式", IsNullable = true)]
    public string? ParameterFormat { get; set; }

    /// <summary>
    /// 参数大小
    /// </summary>
    [SugarColumn(ColumnName = "parameter_size", ColumnDataType = "bigint", ColumnDescription = "参数大小", IsNullable = false)]
    public long ParameterSize { get; set; }

    /// <summary>
    /// 参数版本
    /// </summary>
    [SugarColumn(ColumnName = "parameter_version", ColumnDataType = "int", ColumnDescription = "参数版本", IsNullable = false, DefaultValue = "1")]
    public int ParameterVersion { get; set; } = 1;
    #endregion

    #region 时间信息
    /// <summary>
    /// 发布时间
    /// </summary>
    [SugarColumn(ColumnName = "publish_time", ColumnDataType = "datetime", ColumnDescription = "发布时间", IsNullable = true)]
    public DateTime? PublishTime { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    [Required(ErrorMessage = "是否系统预设不能为空")]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }


    #endregion
  }
}