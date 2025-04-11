// -----------------------------------------------------------------------
// <copyright file="KpDictData.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典数据实体</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Core
{
  /// <summary>
  /// 字典数据实体
  /// </summary>
  [SugarTable("kp_co_dict_data", "字典数据")]
  [SugarIndex("idx_dict_data_type_code", nameof(DictTypeCode), OrderByType.Asc)]
  [SugarIndex("idx_dict_data_code", nameof(DictDataCode), OrderByType.Asc)]
  public class KpDictData : KpBaseEntity
  {
    /// <summary>
    /// 字典类型编码
    /// </summary>
    [SugarColumn(ColumnName = "dict_type_code", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典类型编码", IsNullable = false)]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典数据编码
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_code", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典数据编码", IsNullable = false)]
    public string? DictDataCode { get; set; }

    /// <summary>
    /// 字典数据名称
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典数据名称", IsNullable = false)]
    public string? DictDataName { get; set; }

    /// <summary>
    /// 字典数据翻译键
    /// </summary>
    [SugarColumn(ColumnName = "translate_key", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "字典数据翻译键", IsNullable = true)]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_value", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "字典数据值", IsNullable = false)]
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "字典数据描述", IsNullable = true)]
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// 扩展数据标签
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_ext_label", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "扩展数据标签", IsNullable = true)]
    public string? ExtDataLabel { get; set; }

    /// <summary>
    /// 扩展数据值
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_ext_value", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "扩展数据值", IsNullable = true)]
    public string? ExtDataValue { get; set; }

    /// <summary>
    /// CSS类名
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_css_class", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "CSS类名", IsNullable = true)]
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表类名
    /// </summary>
    [SugarColumn(ColumnName = "dict_data_list_class", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "列表类名", IsNullable = true)]
    public string? ListClass { get; set; }

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
    /// 字典类型
    /// </summary>
    [Navigate(NavigateType.ManyToOne, nameof(DictTypeCode), nameof(KpDictType.DictTypeCode))]
    public KpDictType? DictType { get; set; }
  }
}