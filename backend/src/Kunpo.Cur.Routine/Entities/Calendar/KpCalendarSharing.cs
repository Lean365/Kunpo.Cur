// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日历共享实体类</summary>
// <remarks>处理日历共享的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Calendar
{
  /// <summary>
  /// 日历共享实体
  /// </summary>
  [SugarTable("kp_ro_calendar_sharing", "日历共享")]
  [SugarIndex("idx_calendar_sharing_calendar_id", nameof(CalendarId), OrderByType.Asc)]
  public class KpCalendarSharing : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 日历ID
    /// </summary>
    [SugarColumn(ColumnName = "calendar_id", ColumnDataType = "bigint", ColumnDescription = "日历ID", IsNullable = false)]
    public long CalendarId { get; set; }

    /// <summary>
    /// 共享编码
    /// </summary>
    [SugarColumn(ColumnName = "sharing_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "共享编码", IsNullable = false)]
    public string? SharingCode { get; set; }

    /// <summary>
    /// 共享类型
    /// </summary>
    /// <remarks>
    /// 0：个人共享，1：部门共享，2：角色共享，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "sharing_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "共享类型", IsNullable = false)]
    public int SharingType { get; set; }

    /// <summary>
    /// 共享状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：已过期，默认为1
    /// </remarks>
    [SugarColumn(ColumnName = "sharing_status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "共享状态", IsNullable = false)]
    public int SharingStatus { get; set; }

    /// <summary>
    /// 共享标题
    /// </summary>
    [SugarColumn(ColumnName = "sharing_title", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "共享标题", IsNullable = false)]
    public string? SharingTitle { get; set; }

    /// <summary>
    /// 共享描述
    /// </summary>
    [SugarColumn(ColumnName = "sharing_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "共享描述", IsNullable = true)]
    public string? SharingDescription { get; set; }
    #endregion

    #region 共享信息
    /// <summary>
    /// 共享对象ID
    /// </summary>
    [SugarColumn(ColumnName = "sharing_object_id", ColumnDataType = "bigint", ColumnDescription = "共享对象ID", IsNullable = false)]
    public long SharingObjectId { get; set; }

    /// <summary>
    /// 共享对象名称
    /// </summary>
    [SugarColumn(ColumnName = "sharing_object_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "共享对象名称", IsNullable = false)]
    public string? SharingObjectName { get; set; }

    /// <summary>
    /// 共享权限
    /// </summary>
    /// <remarks>
    /// 0：只读，1：读写，2：管理，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "sharing_permission", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "共享权限", IsNullable = false)]
    public int SharingPermission { get; set; }

    /// <summary>
    /// 共享开始时间
    /// </summary>
    [SugarColumn(ColumnName = "sharing_start_time", ColumnDataType = "datetime", ColumnDescription = "共享开始时间", IsNullable = false)]
    public DateTime SharingStartTime { get; set; }

    /// <summary>
    /// 共享结束时间
    /// </summary>
    [SugarColumn(ColumnName = "sharing_end_time", ColumnDataType = "datetime", ColumnDescription = "共享结束时间", IsNullable = true)]
    public DateTime? SharingEndTime { get; set; }
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