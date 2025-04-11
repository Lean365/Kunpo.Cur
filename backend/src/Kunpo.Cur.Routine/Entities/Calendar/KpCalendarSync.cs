// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日历同步实体类</summary>
// <remarks>处理日历同步的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Calendar
{
  /// <summary>
  /// 日历同步实体
  /// </summary>
  [SugarTable("kp_ro_calendar_sync", "日历同步")]
  [SugarIndex("idx_calendar_sync_calendar_id", nameof(CalendarId), OrderByType.Asc)]
  public class KpCalendarSync : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 日历ID
    /// </summary>
    [SugarColumn(ColumnName = "calendar_id", ColumnDataType = "bigint", ColumnDescription = "日历ID", IsNullable = false)]
    public long CalendarId { get; set; }

    /// <summary>
    /// 同步编码
    /// </summary>
    [SugarColumn(ColumnName = "sync_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "同步编码", IsNullable = false)]
    public string? SyncCode { get; set; }

    /// <summary>
    /// 同步类型
    /// </summary>
    /// <remarks>
    /// 0：系统同步，1：自定义同步，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "sync_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "同步类型", IsNullable = false)]
    public int SyncType { get; set; }

    /// <summary>
    /// 同步状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：已过期，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "sync_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "同步状态", IsNullable = false)]
    public int SyncStatus { get; set; }

    /// <summary>
    /// 同步标题
    /// </summary>
    [SugarColumn(ColumnName = "sync_title", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "同步标题", IsNullable = false)]
    public string? SyncTitle { get; set; }

    /// <summary>
    /// 同步描述
    /// </summary>
    [SugarColumn(ColumnName = "sync_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "同步描述", IsNullable = true)]
    public string? SyncDescription { get; set; }
    #endregion

    #region 同步信息
    /// <summary>
    /// 同步源
    /// </summary>
    [SugarColumn(ColumnName = "sync_source", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "同步源", IsNullable = false)]
    public string? SyncSource { get; set; }

    /// <summary>
    /// 同步目标
    /// </summary>
    [SugarColumn(ColumnName = "sync_target", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "同步目标", IsNullable = false)]
    public string? SyncTarget { get; set; }

    /// <summary>
    /// 同步参数
    /// </summary>
    [SugarColumn(ColumnName = "sync_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "同步参数", IsNullable = true)]
    public string? SyncParameters { get; set; }

    /// <summary>
    /// 同步频率
    /// </summary>
    [SugarColumn(ColumnName = "sync_frequency", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "同步频率(分钟)", IsNullable = false)]
    public int SyncFrequency { get; set; }

    /// <summary>
    /// 上次同步时间
    /// </summary>
    [SugarColumn(ColumnName = "last_sync_time", ColumnDataType = "datetime", ColumnDescription = "上次同步时间", IsNullable = true)]
    public DateTime? LastSyncTime { get; set; }

    /// <summary>
    /// 下次同步时间
    /// </summary>
    [SugarColumn(ColumnName = "next_sync_time", ColumnDataType = "datetime", ColumnDescription = "下次同步时间", IsNullable = true)]
    public DateTime? NextSyncTime { get; set; }
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
  }
}