// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>会议实体类</summary>
// <remarks>处理会议的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Meeting
{
  /// <summary>
  /// 会议实体类
  /// </summary>
  [SugarTable("kp_ro_meeting")]
  [SugarIndex("idx_meeting_code", nameof(MeetingCode), OrderByType.Asc)]
  public class KpMeeting : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 会议编码
    /// </summary>
    [SugarColumn(ColumnName = "meeting_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "会议编码", IsNullable = false, IsPrimaryKey = true)]
    public string? MeetingCode { get; set; }

    /// <summary>
    /// 会议类型
    /// </summary>
    [SugarColumn(ColumnName = "meeting_type", ColumnDataType = "int", ColumnDescription = "会议类型", IsNullable = false)]
    public int MeetingType { get; set; }

    /// <summary>
    /// 会议状态
    /// </summary>
    [SugarColumn(ColumnName = "meeting_status", ColumnDataType = "int", ColumnDescription = "会议状态", IsNullable = false)]
    public int MeetingStatus { get; set; }

    /// <summary>
    /// 会议标题
    /// </summary>
    [SugarColumn(ColumnName = "meeting_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "会议标题", IsNullable = false)]
    public string? MeetingTitle { get; set; }

    /// <summary>
    /// 会议描述
    /// </summary>
    [SugarColumn(ColumnName = "meeting_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "会议描述", IsNullable = true)]
    public string? MeetingDescription { get; set; }
    #endregion

    #region 会议信息
    /// <summary>
    /// 会议内容
    /// </summary>
    [SugarColumn(ColumnName = "meeting_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "会议内容", IsNullable = false)]
    public string? MeetingContent { get; set; }

    /// <summary>
    /// 会议参数
    /// </summary>
    [SugarColumn(ColumnName = "meeting_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "会议参数", IsNullable = true)]
    public string? MeetingParameters { get; set; }

    /// <summary>
    /// 会议附件
    /// </summary>
    [SugarColumn(ColumnName = "meeting_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "会议附件", IsNullable = true)]
    public string? MeetingAttachments { get; set; }

    /// <summary>
    /// 会议标签
    /// </summary>
    [SugarColumn(ColumnName = "meeting_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "会议标签", IsNullable = true)]
    public string? MeetingTags { get; set; }

    /// <summary>
    /// 会议格式
    /// </summary>
    [SugarColumn(ColumnName = "meeting_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "会议格式", IsNullable = false)]
    public string? MeetingFormat { get; set; }

    /// <summary>
    /// 会议大小
    /// </summary>
    [SugarColumn(ColumnName = "meeting_size", ColumnDataType = "bigint", ColumnDescription = "会议大小", IsNullable = false)]
    public long MeetingSize { get; set; }

    /// <summary>
    /// 会议版本
    /// </summary>
    [SugarColumn(ColumnName = "meeting_version", ColumnDataType = "int", ColumnDescription = "会议版本", IsNullable = false, DefaultValue = "1")]
    public int MeetingVersion { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 开始时间
    /// </summary>
    [SugarColumn(ColumnName = "start_time", ColumnDataType = "datetime", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [SugarColumn(ColumnName = "end_time", ColumnDataType = "datetime", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    [SugarColumn(ColumnName = "publish_time", ColumnDataType = "datetime", ColumnDescription = "发布时间", IsNullable = true)]
    public DateTime? PublishTime { get; set; }
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

    #region 导航属性
    /// <summary>
    /// 会议审批
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpMeetingApproval.MeetingCode))]
    public List<KpMeetingApproval>? Approvals { get; set; }


    #endregion
  }
}