// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>文档归档实体类</summary>
// <remarks>处理文档归档的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Document
{
  /// <summary>
  /// 文档归档实体类
  /// </summary>
  [SugarTable("kp_ro_document_archiving")]
  [SugarIndex("idx_document_archiving_code", nameof(ArchivingCode), OrderByType.Asc)]
  public class KpDocumentArchiving : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 归档编码
    /// </summary>
    [SugarColumn(ColumnName = "archiving_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "归档编码", IsNullable = false, IsPrimaryKey = true)]
    public string? ArchivingCode { get; set; }

    /// <summary>
    /// 文档编码
    /// </summary>
    [SugarColumn(ColumnName = "document_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "文档编码", IsNullable = false)]
    public string? DocumentCode { get; set; }

    /// <summary>
    /// 归档类型
    /// </summary>
    [SugarColumn(ColumnName = "archiving_type", ColumnDataType = "int", ColumnDescription = "归档类型", IsNullable = false)]
    public int ArchivingType { get; set; }

    /// <summary>
    /// 归档状态
    /// </summary>
    [SugarColumn(ColumnName = "archiving_status", ColumnDataType = "int", ColumnDescription = "归档状态", IsNullable = false)]
    public int ArchivingStatus { get; set; }

    /// <summary>
    /// 归档描述
    /// </summary>
    [SugarColumn(ColumnName = "archiving_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "归档描述", IsNullable = true)]
    public string? ArchivingDescription { get; set; }
    #endregion



    #region 归档内容
    /// <summary>
    /// 归档位置
    /// </summary>
    [SugarColumn(ColumnName = "archiving_location", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "归档位置", IsNullable = true)]
    public string? ArchivingLocation { get; set; }

    /// <summary>
    /// 归档路径
    /// </summary>
    [SugarColumn(ColumnName = "archiving_path", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "归档路径", IsNullable = true)]
    public string? ArchivingPath { get; set; }

    /// <summary>
    /// 归档大小
    /// </summary>
    [SugarColumn(ColumnName = "archiving_size", ColumnDataType = "bigint", ColumnDescription = "归档大小", IsNullable = true)]
    public long? ArchivingSize { get; set; }

    /// <summary>
    /// 归档格式
    /// </summary>
    [SugarColumn(ColumnName = "archiving_format", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "归档格式", IsNullable = true)]
    public string? ArchivingFormat { get; set; }

    /// <summary>
    /// 归档参数
    /// </summary>
    [SugarColumn(ColumnName = "archiving_parameters", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "归档参数", IsNullable = true)]
    public string? ArchivingParameters { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 归档时间
    /// </summary>
    [SugarColumn(ColumnName = "archiving_time", ColumnDataType = "datetime", ColumnDescription = "归档时间", IsNullable = false)]
    public DateTime ArchivingTime { get; set; }
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