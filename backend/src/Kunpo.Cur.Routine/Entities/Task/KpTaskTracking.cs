// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>任务跟踪实体类</summary>
// <remarks>处理任务跟踪的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Task
{
  /// <summary>
  /// 任务跟踪实体类
  /// </summary>
  [SugarTable("kp_ro_task_tracking")]
  [SugarIndex("idx_task_tracking_code", nameof(TrackingCode), OrderByType.Asc)]
  public class KpTaskTracking : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 跟踪编码
    /// </summary>
    [SugarColumn(ColumnName = "tracking_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "跟踪编码", IsNullable = false, IsPrimaryKey = true)]
    public string? TrackingCode { get; set; }

    /// <summary>
    /// 任务编码
    /// </summary>
    [SugarColumn(ColumnName = "task_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "任务编码", IsNullable = false)]
    public string? TaskCode { get; set; }

    /// <summary>
    /// 跟踪类型
    /// </summary>
    [SugarColumn(ColumnName = "tracking_type", ColumnDataType = "int", ColumnDescription = "跟踪类型", IsNullable = false)]
    public int TrackingType { get; set; }

    /// <summary>
    /// 跟踪状态
    /// </summary>
    [SugarColumn(ColumnName = "tracking_status", ColumnDataType = "int", ColumnDescription = "跟踪状态", IsNullable = false)]
    public int TrackingStatus { get; set; }

    /// <summary>
    /// 跟踪标题
    /// </summary>
    [SugarColumn(ColumnName = "tracking_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "跟踪标题", IsNullable = false)]
    public string? TrackingTitle { get; set; }

    /// <summary>
    /// 跟踪内容
    /// </summary>
    [SugarColumn(ColumnName = "tracking_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "跟踪内容", IsNullable = true)]
    public string? TrackingContent { get; set; }

    /// <summary>
    /// 跟踪描述
    /// </summary>
    [SugarColumn(ColumnName = "tracking_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "跟踪描述", IsNullable = true)]
    public string? TrackingDescription { get; set; }
    #endregion

    #region 跟踪人信息
    /// <summary>
    /// 跟踪人编码
    /// </summary>
    [SugarColumn(ColumnName = "tracker_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "跟踪人编码", IsNullable = false)]
    public string? TrackerCode { get; set; }

    /// <summary>
    /// 跟踪人名称
    /// </summary>
    [SugarColumn(ColumnName = "tracker_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "跟踪人名称", IsNullable = false)]
    public string? TrackerName { get; set; }

    /// <summary>
    /// 跟踪部门编码
    /// </summary>
    [SugarColumn(ColumnName = "tracker_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "跟踪部门编码", IsNullable = true)]
    public string? TrackerDeptCode { get; set; }

    /// <summary>
    /// 跟踪部门名称
    /// </summary>
    [SugarColumn(ColumnName = "tracker_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "跟踪部门名称", IsNullable = true)]
    public string? TrackerDeptName { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 跟踪时间
    /// </summary>
    [SugarColumn(ColumnName = "tracking_time", ColumnDataType = "datetime", ColumnDescription = "跟踪时间", IsNullable = false)]
    public DateTime TrackingTime { get; set; }

    /// <summary>
    /// 跟踪间隔
    /// </summary>
    [SugarColumn(ColumnName = "tracking_interval", ColumnDataType = "int", ColumnDescription = "跟踪间隔(分钟)", IsNullable = false)]
    public int TrackingInterval { get; set; }

    /// <summary>
    /// 跟踪次数
    /// </summary>
    [SugarColumn(ColumnName = "tracking_count", ColumnDataType = "int", ColumnDescription = "跟踪次数", IsNullable = false)]
    public int TrackingCount { get; set; }

    /// <summary>
    /// 已跟踪次数
    /// </summary>
    [SugarColumn(ColumnName = "tracked_count", ColumnDataType = "int", ColumnDescription = "已跟踪次数", IsNullable = false)]
    public int TrackedCount { get; set; }
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