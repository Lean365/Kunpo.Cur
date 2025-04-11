// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>数据表实体类</summary>
// <remarks>处理数据表的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Generator.Entities.Generator
{
  /// <summary>
  /// 数据表实体
  /// </summary>
  [SugarTable("kp_gen_table", "数据表")]
  [SugarIndex("idx_table_name", nameof(TableName), OrderByType.Asc)]
  public class KpTable : KpBaseEntity
  {
    /// <summary>
    /// 表名
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "table_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "表名", IsNullable = false)]
    public string? TableName { get; set; }

    /// <summary>
    /// 表描述
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "table_description", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "表描述", IsNullable = true)]
    public string? TableDescription { get; set; }

    /// <summary>
    /// 数据库类型
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "db_type", ColumnDataType = "int", ColumnDescription = "数据库类型", IsNullable = true)]
    public int DbType { get; set; }

    /// <summary>
    /// 数据库名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "db_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "数据库名称", IsNullable = true)]
    public string? DbName { get; set; }

    /// <summary>
    /// 架构名称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "schema_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "架构名称", IsNullable = true)]
    public string? SchemaName { get; set; }

    /// <summary>
    /// 是否生成代码
    /// </summary>
    [SugarColumn(ColumnName = "is_generate", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否生成代码", IsNullable = false)]
    public int IsGenerate { get; set; }

    /// <summary>
    /// 生成时间
    /// </summary>
    [SugarColumn(ColumnName = "generate_time", ColumnDataType = "datetime", ColumnDescription = "生成时间", IsNullable = true)]
    public DateTime? GenerateTime { get; set; }


  }
}