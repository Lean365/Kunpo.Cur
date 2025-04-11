// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>文档实体类</summary>
// <remarks>处理文档的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Routine.Entities.Document
{
  /// <summary>
  /// 文档实体类
  /// </summary>
  [SugarTable("kp_ro_document")]
  [SugarIndex("idx_document_code", nameof(DocumentCode), OrderByType.Asc)]
  public class KpDocument : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 文档编码
    /// </summary>
    [SugarColumn(ColumnName = "document_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "文档编码", IsNullable = false, IsPrimaryKey = true)]
    public string? DocumentCode { get; set; }

    /// <summary>
    /// 文档类型
    /// </summary>
    [SugarColumn(ColumnName = "document_type", ColumnDataType = "int", ColumnDescription = "文档类型", IsNullable = false)]
    public int DocumentType { get; set; }

    /// <summary>
    /// 文档状态
    /// </summary>
    [SugarColumn(ColumnName = "document_status", ColumnDataType = "int", ColumnDescription = "文档状态", IsNullable = false)]
    public int DocumentStatus { get; set; }

    /// <summary>
    /// 文档标题
    /// </summary>
    [SugarColumn(ColumnName = "document_title", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "文档标题", IsNullable = false)]
    public string? DocumentTitle { get; set; }

    /// <summary>
    /// 文档描述
    /// </summary>
    [SugarColumn(ColumnName = "document_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "文档描述", IsNullable = true)]
    public string? DocumentDescription { get; set; }
    #endregion

    #region 文档信息
    /// <summary>
    /// 文档内容
    /// </summary>
    [SugarColumn(ColumnName = "document_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "文档内容", IsNullable = false)]
    public string? DocumentContent { get; set; }

    /// <summary>
    /// 文档参数
    /// </summary>
    [SugarColumn(ColumnName = "document_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "文档参数", IsNullable = true)]
    public string? DocumentParameters { get; set; }

    /// <summary>
    /// 文档附件
    /// </summary>
    [SugarColumn(ColumnName = "document_attachments", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "文档附件", IsNullable = true)]
    public string? DocumentAttachments { get; set; }

    /// <summary>
    /// 文档标签
    /// </summary>
    [SugarColumn(ColumnName = "document_tags", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "文档标签", IsNullable = true)]
    public string? DocumentTags { get; set; }

    /// <summary>
    /// 文档格式
    /// </summary>
    [SugarColumn(ColumnName = "document_format", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "文档格式", IsNullable = false)]
    public string? DocumentFormat { get; set; }

    /// <summary>
    /// 文档大小
    /// </summary>
    [SugarColumn(ColumnName = "document_size", ColumnDataType = "bigint", ColumnDescription = "文档大小", IsNullable = false)]
    public long DocumentSize { get; set; }

    /// <summary>
    /// 文档版本
    /// </summary>
    [SugarColumn(ColumnName = "document_version", ColumnDataType = "int", ColumnDescription = "文档版本", IsNullable = false, DefaultValue = "1")]
    public int DocumentVersion { get; set; }
    #endregion

    #region 时间信息
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
    /// 文档审批
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpDocumentApproval.DocumentCode))]
    public List<KpDocumentApproval>? Approvals { get; set; }

    /// <summary>
    /// 文档签收
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpDocumentSign.DocumentCode))]
    public List<KpDocumentSign>? Signs { get; set; }

    /// <summary>
    /// 文档归档
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpDocumentArchiving.DocumentCode))]
    public List<KpDocumentArchiving>? Archivings { get; set; }
    #endregion
  }
}