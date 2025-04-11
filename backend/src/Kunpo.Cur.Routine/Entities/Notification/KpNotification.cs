// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>通知实体类</summary>
// <remarks>处理通知的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Notification
{
  /// <summary>
  /// 通知实体类
  /// </summary>
  [SugarTable("kp_ro_notification")]
  [SugarIndex("idx_notification_code", nameof(NotificationCode), OrderByType.Asc)]
  public class KpNotification : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 通知编码
    /// </summary>
    [SugarColumn(ColumnName = "notification_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "通知编码", IsNullable = false, IsPrimaryKey = true)]
    public string? NotificationCode { get; set; }

    /// <summary>
    /// 通知类型
    /// </summary>
    [SugarColumn(ColumnName = "notification_type", ColumnDataType = "int", ColumnDescription = "通知类型", IsNullable = false)]
    public int NotificationType { get; set; }

    /// <summary>
    /// 通知状态
    /// </summary>
    [SugarColumn(ColumnName = "notification_status", ColumnDataType = "int", ColumnDescription = "通知状态", IsNullable = false)]
    public int NotificationStatus { get; set; }

    /// <summary>
    /// 通知标题
    /// </summary>
    [SugarColumn(ColumnName = "notification_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "通知标题", IsNullable = false)]
    public string? NotificationTitle { get; set; }

    /// <summary>
    /// 通知描述
    /// </summary>
    [SugarColumn(ColumnName = "notification_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "通知描述", IsNullable = true)]
    public string? NotificationDescription { get; set; }
    #endregion

    #region 通知信息
    /// <summary>
    /// 通知内容
    /// </summary>
    [SugarColumn(ColumnName = "notification_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "通知内容", IsNullable = true)]
    public string? NotificationContent { get; set; }

    /// <summary>
    /// 通知参数
    /// </summary>
    [SugarColumn(ColumnName = "notification_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "通知参数", IsNullable = true)]
    public string? NotificationParameters { get; set; }

    /// <summary>
    /// 通知附件
    /// </summary>
    [SugarColumn(ColumnName = "notification_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "通知附件", IsNullable = true)]
    public string? NotificationAttachments { get; set; }

    /// <summary>
    /// 通知标签
    /// </summary>
    [SugarColumn(ColumnName = "notification_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "通知标签", IsNullable = true)]
    public string? NotificationTags { get; set; }

    /// <summary>
    /// 通知格式
    /// </summary>
    [SugarColumn(ColumnName = "notification_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "通知格式", IsNullable = false)]
    public string? NotificationFormat { get; set; }

    /// <summary>
    /// 通知大小
    /// </summary>
    [SugarColumn(ColumnName = "notification_size", ColumnDataType = "bigint", ColumnDescription = "通知大小", IsNullable = false)]
    public long? NotificationSize { get; set; }

    /// <summary>
    /// 通知版本
    /// </summary>
    [SugarColumn(ColumnName = "notification_version", ColumnDataType = "int", ColumnDescription = "通知版本", IsNullable = false, DefaultValue = "1")]
    public int NotificationVersion { get; set; } = 1;
    #endregion

    #region 实例信息
    /// <summary>
    /// 实例编码
    /// </summary>
    [SugarColumn(ColumnName = "instance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "实例编码", IsNullable = true)]
    public string? InstanceCode { get; set; }

    /// <summary>
    /// 实例类型
    /// </summary>
    [SugarColumn(ColumnName = "instance_type", ColumnDataType = "int", ColumnDescription = "实例类型", IsNullable = true)]
    public int? InstanceType { get; set; }

    /// <summary>
    /// 实例状态
    /// </summary>
    [SugarColumn(ColumnName = "instance_status", ColumnDataType = "int", ColumnDescription = "实例状态", IsNullable = true)]
    public int? InstanceStatus { get; set; }

    /// <summary>
    /// 实例描述
    /// </summary>
    [SugarColumn(ColumnName = "instance_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "实例描述", IsNullable = true)]
    public string? InstanceDescription { get; set; }

    /// <summary>
    /// 实例标题
    /// </summary>
    [SugarColumn(ColumnName = "instance_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "实例标题", IsNullable = true)]
    public string? InstanceTitle { get; set; }

    /// <summary>
    /// 实例内容
    /// </summary>
    [SugarColumn(ColumnName = "instance_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "实例内容", IsNullable = true)]
    public string? InstanceContent { get; set; }

    /// <summary>
    /// 实例参数
    /// </summary>
    [SugarColumn(ColumnName = "instance_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "实例参数", IsNullable = true)]
    public string? InstanceParameters { get; set; }

    /// <summary>
    /// 实例附件
    /// </summary>
    [SugarColumn(ColumnName = "instance_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "实例附件", IsNullable = true)]
    public string? InstanceAttachments { get; set; }

    /// <summary>
    /// 实例标签
    /// </summary>
    [SugarColumn(ColumnName = "instance_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "实例标签", IsNullable = true)]
    public string? InstanceTags { get; set; }

    /// <summary>
    /// 实例格式
    /// </summary>
    [SugarColumn(ColumnName = "instance_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "实例格式", IsNullable = true)]
    public string? InstanceFormat { get; set; }

    /// <summary>
    /// 实例大小
    /// </summary>
    [SugarColumn(ColumnName = "instance_size", ColumnDataType = "bigint", ColumnDescription = "实例大小", IsNullable = true)]
    public long? InstanceSize { get; set; }

    /// <summary>
    /// 实例版本
    /// </summary>
    [SugarColumn(ColumnName = "instance_version", ColumnDataType = "int", ColumnDescription = "实例版本", IsNullable = true, DefaultValue = "1")]
    public int? InstanceVersion { get; set; } = 1;
    #endregion

    #region 时间信息

    /// <summary>
    /// 发布时间
    /// </summary>
    [SugarColumn(ColumnName = "publish_time", ColumnDataType = "datetime", ColumnDescription = "发布时间", IsNullable = true)]
    public DateTime? PublishTime { get; set; }

    /// <summary>
    /// 实例时间
    /// </summary>
    [SugarColumn(ColumnName = "instance_time", ColumnDataType = "datetime", ColumnDescription = "实例时间", IsNullable = true)]
    public DateTime? InstanceTime { get; set; }
    #endregion


    #region 其他信息
    /// <summary>
    /// 是否系统通知
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", ColumnDescription = "是否系统通知", IsNullable = false, DefaultValue = "0")]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public int IsEnabled { get; set; }


    #endregion
  }
}