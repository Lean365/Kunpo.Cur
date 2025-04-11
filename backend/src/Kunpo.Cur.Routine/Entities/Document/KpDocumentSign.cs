// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>文档签收实体类</summary>
// <remarks>处理文档签收的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------using System;
using System.ComponentModel.DataAnnotations;
using SqlSugar;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Routine.Entities.Document
{
  /// <summary>
  /// 文档签收实体类
  /// </summary>
  [SugarTable("kp_ro_document_sign")]
  [SugarIndex("idx_document_sign_code", nameof(SignCode), OrderByType.Asc)]
  public class KpDocumentSign : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 签收编码
    /// </summary>
    [SugarColumn(ColumnName = "sign_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "签收编码", IsNullable = false, IsPrimaryKey = true)]
    public string? SignCode { get; set; }

    /// <summary>
    /// 文档编码
    /// </summary>
    [SugarColumn(ColumnName = "document_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "文档编码", IsNullable = false)]
    public string? DocumentCode { get; set; }

    /// <summary>
    /// 签收类型
    /// </summary>
    [SugarColumn(ColumnName = "sign_type", ColumnDataType = "int", ColumnDescription = "签收类型", IsNullable = false)]
    public int SignType { get; set; }

    /// <summary>
    /// 签收状态
    /// </summary>
    [SugarColumn(ColumnName = "sign_status", ColumnDataType = "int", ColumnDescription = "签收状态", IsNullable = false)]
    public int SignStatus { get; set; }

    /// <summary>
    /// 签收描述
    /// </summary>
    [SugarColumn(ColumnName = "sign_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "签收描述", IsNullable = true)]
    public string? SignDescription { get; set; }
    #endregion


    #region 签收内容
    /// <summary>
    /// 签收意见
    /// </summary>
    [SugarColumn(ColumnName = "sign_opinion", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "签收意见", IsNullable = true)]
    public string? SignOpinion { get; set; }

    /// <summary>
    /// 签收结果
    /// </summary>
    [SugarColumn(ColumnName = "sign_result", ColumnDataType = "int", ColumnDescription = "签收结果", IsNullable = false)]
    public int SignResult { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 签收时间
    /// </summary>
    [SugarColumn(ColumnName = "sign_time", ColumnDataType = "datetime", ColumnDescription = "签收时间", IsNullable = false)]
    public DateTime SignTime { get; set; }
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