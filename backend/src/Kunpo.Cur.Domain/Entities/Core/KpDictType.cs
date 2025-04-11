// -----------------------------------------------------------------------
// <copyright file="KpDictType.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典类型实体</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Core
{
  /// <summary>
  /// 字典类型实体
  /// </summary>
  [SugarTable("kp_co_dict_type", "字典类型")]
  [SugarIndex("idx_dict_type_code", nameof(DictTypeCode), OrderByType.Asc)]
  public class KpDictType : KpBaseEntity
  {
    /// <summary>
    /// 字典类型编码
    /// </summary>
    [SugarColumn(ColumnName = "dict_type_code", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典类型编码", IsNullable = false)]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型名称
    /// </summary>
    [SugarColumn(ColumnName = "dict_type_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典类型名称", IsNullable = false)]
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    [SugarColumn(ColumnName = "dict_type_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "字典类型描述", IsNullable = true)]
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典数据来源（0：传统，1：SQL）
    /// </summary>
    [SugarColumn(ColumnName = "dict_source", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "字典数据来源（0：传统，1：SQL）", IsNullable = false)]
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    [SugarColumn(ColumnName = "dict_sql_script", ColumnDataType = "nvarchar(max)", ColumnDescription = "SQL脚本", IsNullable = true)]
    public string? DictSqlScript { get; set; }

    /// <summary>
    /// 是否内置
    /// </summary>
    [SugarColumn(ColumnName = "is_builtin", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否内置", IsNullable = false)]
    public int IsBuiltin { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
    public int IsEnabled { get; set; } = 1;

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "排序", IsNullable = false)]
    public int OrderNum { get; set; }

    /// <summary>
    /// 字典数据列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpDictData.DictTypeCode), nameof(DictTypeCode))]
    public List<KpDictData>? DictDatas { get; set; }
  }
}