// -----------------------------------------------------------------------
// <copyright file="KpLanguage.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>语言实体</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Core
{
  /// <summary>
  /// 语言实体
  /// </summary>
  [SugarTable("kp_co_language", "系统语言")]
  [SugarIndex("idx_language_code", nameof(LanguageCode), OrderByType.Asc)]
  public class KpLanguage : KpBaseEntity
  {
    /// <summary>
    /// 语言代码
    /// </summary>
    [SugarColumn(ColumnName = "language_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "语言代码", IsNullable = false)]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [SugarColumn(ColumnName = "language_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "语言名称", IsNullable = false)]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [SugarColumn(ColumnName = "is_default", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否默认", IsNullable = false)]
    public int IsDefault { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
    public int IsEnabled { get; set; } = 1;

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnName = "language_sort", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "排序", IsNullable = false)]
    public int OrderNum { get; set; }

    /// <summary>
    /// 翻译集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(KpTranslate.LanguageCode), nameof(LanguageCode))]
    public List<KpTranslate>? Translates { get; set; }
  }
}