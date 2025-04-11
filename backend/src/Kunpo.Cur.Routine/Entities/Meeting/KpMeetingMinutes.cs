// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>会议纪要实体类</summary>
// <remarks>处理会议纪要的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Meeting
{
  /// <summary>
  /// 会议纪要实体类
  /// </summary>
  [SugarTable("kp_ro_meeting_minutes")]
  [SugarIndex("idx_meeting_minutes_code", nameof(MinutesCode), OrderByType.Asc)]
  public class KpMeetingMinutes : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 纪要编码
    /// </summary>
    [SugarColumn(ColumnName = "minutes_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "纪要编码", IsNullable = false, IsPrimaryKey = true)]
    public string? MinutesCode { get; set; }

    /// <summary>
    /// 会议编码
    /// </summary>
    [SugarColumn(ColumnName = "meeting_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "会议编码", IsNullable = false)]
    public string? MeetingCode { get; set; }

    /// <summary>
    /// 纪要类型
    /// </summary>
    [SugarColumn(ColumnName = "minutes_type", ColumnDataType = "int", ColumnDescription = "纪要类型", IsNullable = false)]
    public int MinutesType { get; set; }

    /// <summary>
    /// 纪要状态
    /// </summary>
    [SugarColumn(ColumnName = "minutes_status", ColumnDataType = "int", ColumnDescription = "纪要状态", IsNullable = false)]
    public int MinutesStatus { get; set; }

    /// <summary>
    /// 纪要标题
    /// </summary>
    [SugarColumn(ColumnName = "minutes_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "纪要标题", IsNullable = false)]
    public string? MinutesTitle { get; set; }

    /// <summary>
    /// 纪要内容
    /// </summary>
    [SugarColumn(ColumnName = "minutes_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "纪要内容", IsNullable = true)]
    public string? MinutesContent { get; set; }

    /// <summary>
    /// 纪要描述
    /// </summary>
    [SugarColumn(ColumnName = "minutes_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "纪要描述", IsNullable = true)]
    public string? MinutesDescription { get; set; }
    #endregion

    #region 纪要人信息
    /// <summary>
    /// 纪要人编码
    /// </summary>
    [SugarColumn(ColumnName = "minutes_taker_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "纪要人编码", IsNullable = false)]
    public string? MinutesTakerCode { get; set; }

    /// <summary>
    /// 纪要人名称
    /// </summary>
    [SugarColumn(ColumnName = "minutes_taker_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "纪要人名称", IsNullable = false)]
    public string? MinutesTakerName { get; set; }

    /// <summary>
    /// 纪要部门编码
    /// </summary>
    [SugarColumn(ColumnName = "minutes_taker_dept_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "纪要部门编码", IsNullable = true)]
    public string? MinutesTakerDeptCode { get; set; }

    /// <summary>
    /// 纪要部门名称
    /// </summary>
    [SugarColumn(ColumnName = "minutes_taker_dept_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "纪要部门名称", IsNullable = true)]
    public string? MinutesTakerDeptName { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 纪要时间
    /// </summary>
    [SugarColumn(ColumnName = "minutes_time", ColumnDataType = "datetime", ColumnDescription = "纪要时间", IsNullable = false)]
    public DateTime MinutesTime { get; set; }
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