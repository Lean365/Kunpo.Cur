// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>会议模板实体类</summary>
// <remarks>处理会议模板的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Meeting
{
  /// <summary>
  /// 会议模板实体类
  /// </summary>
  [SugarTable("kp_ro_meeting_template")]
  [SugarIndex("idx_meeting_template_code", nameof(TemplateCode), OrderByType.Asc)]
  public class KpMeetingTemplate : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 模板编码
    /// </summary>
    [SugarColumn(ColumnName = "template_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "模板编码", IsNullable = false, IsPrimaryKey = true)]
    public string? TemplateCode { get; set; }

    /// <summary>
    /// 模板类型
    /// </summary>
    [SugarColumn(ColumnName = "template_type", ColumnDataType = "int", ColumnDescription = "模板类型", IsNullable = false)]
    public int TemplateType { get; set; }

    /// <summary>
    /// 模板状态
    /// </summary>
    [SugarColumn(ColumnName = "template_status", ColumnDataType = "int", ColumnDescription = "模板状态", IsNullable = false)]
    public int TemplateStatus { get; set; }

    /// <summary>
    /// 模板标题
    /// </summary>
    [SugarColumn(ColumnName = "template_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "模板标题", IsNullable = false)]
    public string? TemplateTitle { get; set; }

    /// <summary>
    /// 模板内容
    /// </summary>
    [SugarColumn(ColumnName = "template_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "模板内容", IsNullable = false)]
    public string? TemplateContent { get; set; }

    /// <summary>
    /// 模板描述
    /// </summary>
    [SugarColumn(ColumnName = "template_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板描述", IsNullable = true)]
    public string? TemplateDescription { get; set; }
    #endregion

    #region 模板信息
    /// <summary>
    /// 模板参数
    /// </summary>
    [SugarColumn(ColumnName = "template_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "模板参数", IsNullable = true)]
    public string? TemplateParameters { get; set; }

    /// <summary>
    /// 模板附件
    /// </summary>
    [SugarColumn(ColumnName = "template_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "模板附件", IsNullable = true)]
    public string? TemplateAttachments { get; set; }

    /// <summary>
    /// 模板标签
    /// </summary>
    [SugarColumn(ColumnName = "template_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "模板标签", IsNullable = true)]
    public string? TemplateTags { get; set; }

    /// <summary>
    /// 模板格式
    /// </summary>
    [SugarColumn(ColumnName = "template_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "模板格式", IsNullable = false)]
    public string? TemplateFormat { get; set; }

    /// <summary>
    /// 模板大小
    /// </summary>
    [SugarColumn(ColumnName = "template_size", ColumnDataType = "bigint", ColumnDescription = "模板大小", IsNullable = false)]
    public long TemplateSize { get; set; }

    /// <summary>
    /// 模板版本
    /// </summary>
    [SugarColumn(ColumnName = "template_version", ColumnDataType = "int", ColumnDescription = "模板版本", IsNullable = false, DefaultValue = "1")]
    public int TemplateVersion { get; set; } = 1;
    #endregion

    #region 时间信息
    /// <summary>
    /// 模板时间
    /// </summary>
    [SugarColumn(ColumnName = "template_time", ColumnDataType = "datetime", ColumnDescription = "模板时间", IsNullable = false)]
    public DateTime TemplateTime { get; set; }
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

    #region 模板设置
    /// <summary>
    /// 默认会议类型
    /// </summary>
    [SugarColumn(ColumnName = "default_meeting_type", ColumnDataType = "int", ColumnDescription = "默认会议类型", IsNullable = false)]
    public int DefaultMeetingType { get; set; }

    /// <summary>
    /// 默认会议时长
    /// </summary>
    [SugarColumn(ColumnName = "default_meeting_duration", ColumnDataType = "int", ColumnDescription = "默认会议时长(分钟)", IsNullable = false)]
    public int DefaultMeetingDuration { get; set; }

    /// <summary>
    /// 默认提醒时间
    /// </summary>
    [SugarColumn(ColumnName = "default_reminder_time", ColumnDataType = "int", ColumnDescription = "默认提醒时间(分钟)", IsNullable = false)]
    public int DefaultReminderTime { get; set; }

    /// <summary>
    /// 默认提醒间隔
    /// </summary>
    [SugarColumn(ColumnName = "default_reminder_interval", ColumnDataType = "int", ColumnDescription = "默认提醒间隔(分钟)", IsNullable = false)]
    public int DefaultReminderInterval { get; set; }

    /// <summary>
    /// 默认提醒次数
    /// </summary>
    [SugarColumn(ColumnName = "default_reminder_count", ColumnDataType = "int", ColumnDescription = "默认提醒次数", IsNullable = false)]
    public int DefaultReminderCount { get; set; }
    #endregion
  }
}