// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日历事件实体类</summary>
// <remarks>处理日历事件的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Calendar
{
  /// <summary>
  /// 日历事件实体
  /// </summary>
  [SugarTable("kp_ro_calendar_event", "日历事件")]
  [SugarIndex("idx_calendar_event_calendar_id", nameof(CalendarId), OrderByType.Asc)]
  public class KpCalendarEvent : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 事件编码
    /// </summary>
    [SugarColumn(ColumnName = "event_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "事件编码", IsNullable = false)]
    public string? EventCode { get; set; }

    /// <summary>
    /// 日历ID
    /// </summary>
    [SugarColumn(ColumnName = "calendar_id", ColumnDataType = "bigint", ColumnDescription = "日历ID", IsNullable = false)]
    public long CalendarId { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [SugarColumn(ColumnName = "event_type", ColumnDataType = "nvarchar", DefaultValue = "0", ColumnDescription = "事件类型", IsNullable = false)]
    public int EventType { get; set; }

    /// <summary>
    /// 事件状态
    /// </summary>
    [SugarColumn(ColumnName = "event_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "事件状态", IsNullable = false)]
    public int EventStatus { get; set; }

    /// <summary>
    /// 事件名称
    /// </summary>
    [SugarColumn(ColumnName = "event_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "事件名称", IsNullable = false)]
    public string? EventName { get; set; }

    /// <summary>
    /// 事件描述
    /// </summary>
    [SugarColumn(ColumnName = "event_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "事件描述", IsNullable = true)]
    public string? EventDescription { get; set; }
    #endregion

    #region 事件信息
    /// <summary>
    /// 事件地点
    /// </summary>
    [SugarColumn(ColumnName = "event_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "事件地点", IsNullable = true)]
    public string? EventLocation { get; set; }

    /// <summary>
    /// 事件坐标
    /// </summary>
    [SugarColumn(ColumnName = "event_coordinates", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "事件坐标", IsNullable = true)]
    public string? EventCoordinates { get; set; }

    /// <summary>
    /// 事件地图
    /// </summary>
    [SugarColumn(ColumnName = "event_map", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "事件地图", IsNullable = true)]
    public string? EventMap { get; set; }

    /// <summary>
    /// 参与人列表
    /// </summary>
    [SugarColumn(ColumnName = "event_participants", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参与人列表", IsNullable = true)]
    public string? EventParticipants { get; set; }

    /// <summary>
    /// 参与部门列表
    /// </summary>
    [SugarColumn(ColumnName = "event_participant_depts", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "参与部门列表", IsNullable = true)]
    public string? EventParticipantDepts { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 开始时间
    /// </summary>
    [SugarColumn(ColumnName = "event_start_time", ColumnDataType = "datetime", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime EventStartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [SugarColumn(ColumnName = "event_end_time", ColumnDataType = "datetime", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EventEndTime { get; set; }

    /// <summary>
    /// 是否全天
    /// </summary>
    [SugarColumn(ColumnName = "is_all_day", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否全天", IsNullable = false)]
    public int IsAllDay { get; set; }

    /// <summary>
    /// 重复类型
    /// </summary>
    [SugarColumn(ColumnName = "repeat_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "重复类型", IsNullable = false)]
    public int RepeatType { get; set; }

    /// <summary>
    /// 重复参数
    /// </summary>
    [SugarColumn(ColumnName = "repeat_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "重复参数", IsNullable = true)]
    public string? RepeatParameters { get; set; }

    /// <summary>
    /// 重复结束时间
    /// </summary>
    [SugarColumn(ColumnName = "repeat_end_time", ColumnDataType = "datetime", ColumnDescription = "重复结束时间", IsNullable = true)]
    public DateTime? RepeatEndTime { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否系统预设", IsNullable = false)]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
    public int IsEnabled { get; set; }

    #endregion
  }
}