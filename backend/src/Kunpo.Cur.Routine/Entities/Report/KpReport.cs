// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>报表实体类</summary>
// <remarks>处理报表的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Report
{
  /// <summary>
  /// 报告实体类
  /// </summary>
  [SugarTable("kp_ro_report")]
  [SugarIndex("idx_report_code", nameof(ReportCode), OrderByType.Asc)]
  public class KpReport : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 报告编码
    /// </summary>
    [SugarColumn(ColumnName = "report_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "报告编码", IsNullable = false, IsPrimaryKey = true)]
    public string? ReportCode { get; set; }

    /// <summary>
    /// 报告类型
    /// </summary>
    [SugarColumn(ColumnName = "report_type", ColumnDataType = "int", ColumnDescription = "报告类型", IsNullable = false)]
    public int ReportType { get; set; }

    /// <summary>
    /// 报告状态
    /// </summary>
    [SugarColumn(ColumnName = "report_status", ColumnDataType = "int", ColumnDescription = "报告状态", IsNullable = false)]
    public int ReportStatus { get; set; }

    /// <summary>
    /// 报告标题
    /// </summary>
    [SugarColumn(ColumnName = "report_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "报告标题", IsNullable = false)]
    public string? ReportTitle { get; set; }

    /// <summary>
    /// 报告内容
    /// </summary>
    [SugarColumn(ColumnName = "report_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "报告内容", IsNullable = true)]
    public string? ReportContent { get; set; }

    /// <summary>
    /// 报告描述
    /// </summary>
    [SugarColumn(ColumnName = "report_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "报告描述", IsNullable = true)]
    public string? ReportDescription { get; set; }
    #endregion

    #region 报告人信息
    /// <summary>
    /// 报告人编码
    /// </summary>
    [SugarColumn(ColumnName = "reporter_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "报告人编码", IsNullable = false)]
    public string? ReporterCode { get; set; }

    /// <summary>
    /// 报告人名称
    /// </summary>
    [SugarColumn(ColumnName = "reporter_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "报告人名称", IsNullable = false)]
    public string? ReporterName { get; set; }

    /// <summary>
    /// 报告部门编码
    /// </summary>
    [SugarColumn(ColumnName = "reporter_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "报告部门编码", IsNullable = true)]
    public string? ReporterDeptCode { get; set; }

    /// <summary>
    /// 报告部门名称
    /// </summary>
    [SugarColumn(ColumnName = "reporter_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "报告部门名称", IsNullable = true)]
    public string? ReporterDeptName { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 报告时间
    /// </summary>
    [SugarColumn(ColumnName = "report_time", ColumnDataType = "datetime", ColumnDescription = "报告时间", IsNullable = false)]
    public DateTime ReportTime { get; set; }

    /// <summary>
    /// 提交时间
    /// </summary>
    [SugarColumn(ColumnName = "submit_time", ColumnDataType = "datetime", ColumnDescription = "提交时间", IsNullable = true)]
    public DateTime? SubmitTime { get; set; }

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