// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日历实体类</summary>
// <remarks>处理日历的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Calendar
{
  /// <summary>
  /// 日历实体
  /// </summary>
  [SugarTable("kp_ro_calendar", "日历")]
  [SugarIndex("idx_calendar_code", nameof(CalendarCode), OrderByType.Asc)]
  public class KpCalendar : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 日历编码
    /// </summary>
    [SugarColumn(ColumnName = "calendar_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "日历编码", IsNullable = false)]
    public string? CalendarCode { get; set; }

    /// <summary>
    /// 日历类型
    /// </summary>
    /// <remarks>
    /// 0：个人日历，1：团队日历，2：项目日历，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "calendar_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "日历类型", IsNullable = false)]
    public int CalendarType { get; set; }

    /// <summary>
    /// 日历状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "calendar_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "日历状态", IsNullable = false)]
    public int CalendarStatus { get; set; }

    /// <summary>
    /// 日历标题
    /// </summary>
    [SugarColumn(ColumnName = "calendar_title", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "日历标题", IsNullable = false)]
    public string? CalendarTitle { get; set; }

    /// <summary>
    /// 日历描述
    /// </summary>
    [SugarColumn(ColumnName = "calendar_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "日历描述", IsNullable = true)]
    public string? CalendarDescription { get; set; }
    #endregion

    #region 日历信息
    /// <summary>
    /// 日历内容
    /// </summary>
    [SugarColumn(ColumnName = "calendar_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "日历内容", IsNullable = false)]
    public string? CalendarContent { get; set; }

    /// <summary>
    /// 日历附件
    /// </summary>
    [SugarColumn(ColumnName = "calendar_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "日历附件", IsNullable = true)]
    public string? CalendarAttachments { get; set; }

    /// <summary>
    /// 日历标签
    /// </summary>
    [SugarColumn(ColumnName = "calendar_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "日历标签", IsNullable = true)]
    public string? CalendarTags { get; set; }

    /// <summary>
    /// 日历颜色
    /// </summary>
    [SugarColumn(ColumnName = "calendar_color", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "日历颜色", IsNullable = true)]
    public string? CalendarColor { get; set; }

    /// <summary>
    /// 日历图标
    /// </summary>
    [SugarColumn(ColumnName = "calendar_icon", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "日历图标", IsNullable = true)]
    public string? CalendarIcon { get; set; }

    /// <summary>
    /// 日历背景
    /// </summary>
    [SugarColumn(ColumnName = "calendar_background", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "日历背景", IsNullable = true)]
    public string? CalendarBackground { get; set; }

    /// <summary>
    /// 日历语言
    /// </summary>
    [SugarColumn(ColumnName = "calendar_language", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "日历语言", IsNullable = false)]
    public string? CalendarLanguage { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    /// <remarks>
    /// 0：否，1：是，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否系统预设", IsNullable = false)]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
    public int IsEnabled { get; set; }
    #endregion

    #region 导航属性
    /// <summary>
    /// 日历事件列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpCalendarEvent.CalendarId))]
    public List<KpCalendarEvent>? CalendarEvents { get; set; }

    /// <summary>
    /// 日历提醒列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpCalendarReminder.CalendarId))]
    public List<KpCalendarReminder>? CalendarReminders { get; set; }

    /// <summary>
    /// 日历共享列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpCalendarSharing.CalendarId))]
    public List<KpCalendarSharing>? CalendarSharings { get; set; }

    /// <summary>
    /// 日历同步列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpCalendarSync.CalendarId))]
    public List<KpCalendarSync>? CalendarSyncs { get; set; }
    #endregion
  }
}