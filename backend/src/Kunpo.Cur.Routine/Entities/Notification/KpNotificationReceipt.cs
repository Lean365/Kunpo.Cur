// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>通知回执实体类</summary>
// <remarks>处理通知回执的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Notification
{
  /// <summary>
  /// 通知回执实体类
  /// </summary>
  [SugarTable("kp_ro_notification_receipt")]
  [SugarIndex("idx_notification_receipt_code", nameof(ReceiptCode), OrderByType.Asc)]
  public class KpNotificationReceipt : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 回执编码
    /// </summary>
    [SugarColumn(ColumnName = "receipt_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "回执编码", IsNullable = false, IsPrimaryKey = true)]
    public string? ReceiptCode { get; set; }

    /// <summary>
    /// 通知编码
    /// </summary>
    [SugarColumn(ColumnName = "notification_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "通知编码", IsNullable = false)]
    public string? NotificationCode { get; set; }

    /// <summary>
    /// 回执类型
    /// </summary>
    [SugarColumn(ColumnName = "receipt_type", ColumnDescription = "回执类型", IsNullable = false)]
    public int ReceiptType { get; set; }

    /// <summary>
    /// 回执状态
    /// </summary>
    [SugarColumn(ColumnName = "receipt_status", ColumnDescription = "回执状态", IsNullable = false)]
    public int ReceiptStatus { get; set; }

    /// <summary>
    /// 回执描述
    /// </summary>
    [SugarColumn(ColumnName = "receipt_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "回执描述", IsNullable = true)]
    public string? ReceiptDescription { get; set; }
    #endregion

    #region 回执信息
    /// <summary>
    /// 回执标题
    /// </summary>
    [SugarColumn(ColumnName = "receipt_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "回执标题", IsNullable = false)]
    public string? ReceiptTitle { get; set; }

    /// <summary>
    /// 回执内容
    /// </summary>
    [SugarColumn(ColumnName = "receipt_content", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "回执内容", IsNullable = true)]
    public string? ReceiptContent { get; set; }

    /// <summary>
    /// 回执参数
    /// </summary>
    [SugarColumn(ColumnName = "receipt_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "回执参数", IsNullable = true)]
    public string? ReceiptParameters { get; set; }

    /// <summary>
    /// 回执附件
    /// </summary>
    [SugarColumn(ColumnName = "receipt_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "回执附件", IsNullable = true)]
    public string? ReceiptAttachments { get; set; }

    /// <summary>
    /// 回执标签
    /// </summary>
    [SugarColumn(ColumnName = "receipt_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "回执标签", IsNullable = true)]
    public string? ReceiptTags { get; set; }

    /// <summary>
    /// 回执格式
    /// </summary>
    [SugarColumn(ColumnName = "receipt_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "回执格式", IsNullable = false)]
    public string? ReceiptFormat { get; set; }

    /// <summary>
    /// 回执大小
    /// </summary>
    [SugarColumn(ColumnName = "receipt_size", ColumnDataType = "bigint", ColumnDescription = "回执大小", IsNullable = false)]
    public long ReceiptSize { get; set; }

    /// <summary>
    /// 回执版本
    /// </summary>
    [SugarColumn(ColumnName = "receipt_version", ColumnDataType = "int", ColumnDescription = "回执版本", IsNullable = false, DefaultValue = "1")]
    public int ReceiptVersion { get; set; } = 1;
    #endregion

    #region 时间信息


    /// <summary>
    /// 回执时间
    /// </summary>
    [SugarColumn(ColumnName = "receipt_time", ColumnDataType = "datetime", ColumnDescription = "回执时间", IsNullable = false)]
    public DateTime ReceiptTime { get; set; }
    #endregion


    #region 其他信息
    /// <summary>
    /// 是否系统回执
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDataType = "int", ColumnDescription = "是否系统回执", IsNullable = false, DefaultValue = "0")]
    public int IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public int IsEnabled { get; set; }


    #endregion
  }
}