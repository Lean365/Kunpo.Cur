// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>会议提醒实体类</summary>
// <remarks>处理会议提醒的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Meeting
{
  /// <summary>
  /// 会议提醒实体类
  /// </summary>
  [SugarTable("kp_ro_meeting_reminder")]
  [SugarIndex("idx_meeting_reminder_code", nameof(ReminderCode), OrderByType.Asc)]
  public class KpMeetingReminder : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 提醒编码
    /// </summary>
    [SugarColumn(ColumnName = "reminder_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "提醒编码", IsNullable = false, IsPrimaryKey = true)]
    public string? ReminderCode { get; set; }

    /// <summary>
    /// 会议编码
    /// </summary>
    [SugarColumn(ColumnName = "meeting_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "会议编码", IsNullable = false)]
    public string? MeetingCode { get; set; }

    /// <summary>
    /// 提醒类型
    /// </summary>
    [SugarColumn(ColumnName = "reminder_type", ColumnDataType = "int", ColumnDescription = "提醒类型", IsNullable = false)]
    public int ReminderType { get; set; }

    /// <summary>
    /// 提醒状态
    /// </summary>
    [SugarColumn(ColumnName = "reminder_status", ColumnDataType = "int", ColumnDescription = "提醒状态", IsNullable = false)]
    public int ReminderStatus { get; set; }

    /// <summary>
    /// 提醒标题
    /// </summary>
    [SugarColumn(ColumnName = "reminder_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "提醒标题", IsNullable = false)]
    public string? ReminderTitle { get; set; }

    /// <summary>
    /// 提醒内容
    /// </summary>
    [SugarColumn(ColumnName = "reminder_content", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "提醒内容", IsNullable = true)]
    public string? ReminderContent { get; set; }
    #endregion

    #region 提醒人信息
    /// <summary>
    /// 提醒人编码
    /// </summary>
    [SugarColumn(ColumnName = "reminder_to_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "提醒人编码", IsNullable = false)]
    public string? ReminderToCode { get; set; }

    /// <summary>
    /// 提醒人名称
    /// </summary>
    [SugarColumn(ColumnName = "reminder_to_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "提醒人名称", IsNullable = false)]
    public string? ReminderToName { get; set; }

    /// <summary>
    /// 提醒部门编码
    /// </summary>
    [SugarColumn(ColumnName = "reminder_to_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "提醒部门编码", IsNullable = true)]
    public string? ReminderToDeptCode { get; set; }

    /// <summary>
    /// 提醒部门名称
    /// </summary>
    [SugarColumn(ColumnName = "reminder_to_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "提醒部门名称", IsNullable = true)]
    public string? ReminderToDeptName { get; set; }
    #endregion

    #region 提醒时间
    /// <summary>
    /// 提醒时间
    /// </summary>
    [SugarColumn(ColumnName = "reminder_time", ColumnDataType = "datetime", ColumnDescription = "提醒时间", IsNullable = false)]
    public DateTime ReminderTime { get; set; }

    /// <summary>
    /// 提醒间隔
    /// </summary>
    [SugarColumn(ColumnName = "reminder_interval", ColumnDataType = "int", ColumnDescription = "提醒间隔(分钟)", IsNullable = false)]
    public int ReminderInterval { get; set; }

    /// <summary>
    /// 提醒次数
    /// </summary>
    [SugarColumn(ColumnName = "reminder_count", ColumnDataType = "int", ColumnDescription = "提醒次数", IsNullable = false)]
    public int ReminderCount { get; set; }

    /// <summary>
    /// 已提醒次数
    /// </summary>
    [SugarColumn(ColumnName = "reminded_count", ColumnDataType = "int", ColumnDescription = "已提醒次数", IsNullable = false)]
    public int RemindedCount { get; set; }
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