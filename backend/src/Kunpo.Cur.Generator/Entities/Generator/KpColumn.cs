// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>数据表列实体类</summary>
// <remarks>处理数据表列的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Generator.Entities.Generator
{
  /// <summary>
  /// 数据表列实体
  /// </summary>
  [SugarTable("kp_gen_column", "数据表列")]
  [SugarIndex("idx_column_table_id", nameof(TableId), OrderByType.Asc)]
  [SugarIndex("idx_column_name", nameof(ColumnName), OrderByType.Asc)]
  public class KpColumn : KpBaseEntity
  {
    /// <summary>
    /// 表ID
    /// </summary>
    [SugarColumn(ColumnName = "table_id", ColumnDataType = "bigint", ColumnDescription = "表ID", IsNullable = false)]
    public long TableId { get; set; }

    /// <summary>
    /// 列名
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "column_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "列名", IsNullable = false)]
    public string? ColumnName { get; set; }

    /// <summary>
    /// 列描述
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "column_description", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "列描述", IsNullable = true)]
    public string? ColumnDescription { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "data_type", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "数据类型", IsNullable = true)]
    public string? DataType { get; set; }

    /// <summary>
    /// 数据长度
    /// </summary>
    [SugarColumn(ColumnName = "data_length", ColumnDataType = "int", ColumnDescription = "数据长度", IsNullable = true)]
    public int? DataLength { get; set; }

    /// <summary>
    /// 小数位数
    /// </summary>
    [SugarColumn(ColumnName = "decimal_digits", ColumnDataType = "int", ColumnDescription = "小数位数", IsNullable = true)]
    public int? DecimalDigits { get; set; }

    /// <summary>
    /// 是否可空
    /// </summary>
    [SugarColumn(ColumnName = "is_nullable", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否可空", IsNullable = false)]
    public int IsNullable { get; set; }

    /// <summary>
    /// 是否主键
    /// </summary>
    [SugarColumn(ColumnName = "is_primary_key", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否主键", IsNullable = false)]
    public int IsPrimaryKey { get; set; }

    /// <summary>
    /// 是否自增
    /// </summary>
    [SugarColumn(ColumnName = "is_identity", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否自增", IsNullable = false)]
    public int IsIdentity { get; set; }

    /// <summary>
    /// 默认值
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "default_value", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "默认值", IsNullable = true)]
    public string? DefaultValue { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnName = "sort_order", ColumnDataType = "int", ColumnDescription = "排序", IsNullable = true)]
    public int? SortOrder { get; set; }


  }
}