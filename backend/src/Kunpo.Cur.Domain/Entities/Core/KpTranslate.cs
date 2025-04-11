// -----------------------------------------------------------------------
// <copyright file="KpTranslate.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>翻译实体</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Core
{
  /// <summary>
  /// 翻译实体
  /// </summary>
  [SugarTable("kp_co_translate", "系统翻译")]
  [SugarIndex("idx_translate_key", nameof(TranslateKey), OrderByType.Asc)]
  [SugarIndex("idx_translate_language", nameof(LanguageCode), OrderByType.Asc)]
  public class KpTranslate : KpBaseEntity
  {
    /// <summary>
    /// 语言代码
    /// </summary>
    [SugarColumn(ColumnName = "language_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "语言代码", IsNullable = false)]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 翻译键
    /// </summary>
    [SugarColumn(ColumnName = "translate_key", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "翻译键", IsNullable = false)]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    [SugarColumn(ColumnName = "translate_value", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "翻译值", IsNullable = false)]
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    [SugarColumn(ColumnName = "translate_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "翻译描述", IsNullable = true)]
    public string? TranslateDesc { get; set; }

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
    /// 语言
    /// </summary>
    [Navigate(NavigateType.ManyToOne, nameof(LanguageCode), nameof(KpLanguage.LanguageCode))]
    public KpLanguage? Language { get; set; }
  }
}