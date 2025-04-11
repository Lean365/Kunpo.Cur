// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日历提醒实体类</summary>
// <remarks>处理日历提醒的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Calendar
{
  /// <summary>
  /// 日历提醒实体
  /// </summary>
  [SugarTable("kp_ro_calendar_reminder", "日历提醒")]
  [SugarIndex("idx_calendar_reminder_calendar_id", nameof(CalendarId), OrderByType.Asc)]
  public class KpCalendarReminder : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 日历ID
    /// </summary>
    [SugarColumn(ColumnName = "calendar_id", ColumnDescription = "日历ID", IsNullable = false)]
    public long CalendarId { get; set; }

    /// <summary>
    /// 提醒编码
    /// </summary>
    [SugarColumn(ColumnName = "reminder_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "提醒编码", IsNullable = false)]
    public string? ReminderCode { get; set; }

    /// <summary>
    /// 提醒类型
    /// </summary>
    /// <remarks>
    /// 0：系统提醒，1：自定义提醒，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "reminder_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "提醒类型", IsNullable = false)]
    public int ReminderType { get; set; }

    /// <summary>
    /// 提醒状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：已过期，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "reminder_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "提醒状态", IsNullable = false)]
    public int ReminderStatus { get; set; }

    /// <summary>
    /// 提醒标题
    /// </summary>
    [SugarColumn(ColumnName = "reminder_title", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "提醒标题", IsNullable = false)]
    public string? ReminderTitle { get; set; }

    /// <summary>
    /// 提醒内容
    /// </summary>
    [SugarColumn(ColumnName = "reminder_content", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "提醒内容", IsNullable = true)]
    public string? ReminderContent { get; set; }
    #endregion
  }
}