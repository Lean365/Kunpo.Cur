// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>报表导出实体类</summary>
// <remarks>处理报表导出的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Report
{
  /// <summary>
  /// 报表导出实体类
  /// </summary>
  [SugarTable("kp_ro_report_export")]
  [SugarIndex("idx_report_export_code", nameof(ExportCode), OrderByType.Asc)]
  public class KpReportExport : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 导出编码
    /// </summary>
    [SugarColumn(ColumnName = "export_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "导出编码", IsNullable = false, IsPrimaryKey = true)]
    public string? ExportCode { get; set; }

    /// <summary>
    /// 报表编码
    /// </summary>
    [SugarColumn(ColumnName = "report_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "报表编码", IsNullable = false)]
    public string? ReportCode { get; set; }

    /// <summary>
    /// 实例编码
    /// </summary>
    [SugarColumn(ColumnName = "instance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "实例编码", IsNullable = false)]
    [Required(ErrorMessage = "实例编码不能为空")]
    public string? InstanceCode { get; set; }

    /// <summary>
    /// 导出类型
    /// </summary>
    [SugarColumn(ColumnName = "export_type", ColumnDataType = "int", ColumnDescription = "导出类型", IsNullable = false)]
    public int ExportType { get; set; }

    /// <summary>
    /// 导出状态
    /// </summary>
    [SugarColumn(ColumnName = "export_status", ColumnDataType = "int", ColumnDescription = "导出状态", IsNullable = false)]
    public int ExportStatus { get; set; }

    /// <summary>
    /// 导出标题
    /// </summary>
    [SugarColumn(ColumnName = "export_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "导出标题", IsNullable = false)]
    public string? ExportTitle { get; set; }

    /// <summary>
    /// 导出描述
    /// </summary>
    [SugarColumn(ColumnName = "export_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "导出描述", IsNullable = true)]
    public string? ExportDescription { get; set; }
    #endregion

    #region 导出信息
    /// <summary>
    /// 导出内容
    /// </summary>
    [SugarColumn(ColumnName = "export_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "导出内容", IsNullable = true)]
    public string? ExportContent { get; set; }

    /// <summary>
    /// 导出参数
    /// </summary>
    [SugarColumn(ColumnName = "export_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "导出参数", IsNullable = true)]
    public string? ExportParameters { get; set; }

    /// <summary>
    /// 导出附件
    /// </summary>
    [SugarColumn(ColumnName = "export_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "导出附件", IsNullable = true)]
    public string? ExportAttachments { get; set; }

    /// <summary>
    /// 导出格式
    /// </summary>
    [SugarColumn(ColumnName = "export_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "导出格式", IsNullable = false)]
    [Required(ErrorMessage = "导出格式不能为空")]
    public string? ExportFormat { get; set; }

    /// <summary>
    /// 导出大小
    /// </summary>
    [SugarColumn(ColumnName = "export_size", ColumnDataType = "bigint", ColumnDescription = "导出大小", IsNullable = false)]
    [Required(ErrorMessage = "导出大小不能为空")]
    public long ExportSize { get; set; }

    /// <summary>
    /// 导出路径
    /// </summary>
    [SugarColumn(ColumnName = "export_path", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "导出路径", IsNullable = false)]
    [Required(ErrorMessage = "导出路径不能为空")]
    public string? ExportPath { get; set; }

    /// <summary>
    /// 导出结果
    /// </summary>
    [SugarColumn(ColumnName = "export_result", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "导出结果", IsNullable = true)]
    public string? ExportResult { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 导出时间
    /// </summary>
    [SugarColumn(ColumnName = "export_time", ColumnDataType = "datetime", ColumnDescription = "导出时间", IsNullable = false)]
    public DateTime ExportTime { get; set; }

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