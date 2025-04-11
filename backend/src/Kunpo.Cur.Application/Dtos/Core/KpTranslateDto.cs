// -----------------------------------------------------------------------
// <copyright file="KpTranslateDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>翻译数据传输对象</summary>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Newtonsoft.Json;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Core
{
  /// <summary>
  /// 翻译数据传输对象
  /// </summary>
  public class KpTranslateDto
  {
    /// <summary>
    /// 翻译ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 翻译键
    /// </summary>
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    public long LanguageId { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }
  }

  /// <summary>
  /// 翻译查询数据传输对象
  /// </summary>
  public class KpTranslateQueryDto : KpPageRequest
  {
    public KpTranslateQueryDto()
    {
      TranslateKey = null;
      TranslateValue = null;
      LanguageId = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "TranslateKey", "TranslateValue" };
    }

    /// <summary>
    /// 翻译键
    /// </summary>
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    public long? LanguageId { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 翻译创建数据传输对象
  /// </summary>
  public class KpTranslateCreateDto
  {
    public KpTranslateCreateDto()
    {
      TranslateKey = string.Empty;
      TranslateValue = string.Empty;
      TranslateDesc = string.Empty;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 翻译键
    /// </summary>
    [Required(ErrorMessage = "翻译键不能为空")]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    [Required(ErrorMessage = "翻译值不能为空")]
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    public long LanguageId { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }
  }

  /// <summary>
  /// 翻译更新数据传输对象
  /// </summary>
  public class KpTranslateUpdateDto : KpTranslateCreateDto
  {
    /// <summary>
    /// 翻译ID
    /// </summary>
    [Required(ErrorMessage = "翻译ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 翻译删除数据传输对象
  /// </summary>
  public class KpTranslateDeleteDto
  {
    /// <summary>
    /// 翻译ID
    /// </summary>
    [Required(ErrorMessage = "翻译ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 翻译导入数据传输对象
  /// </summary>
  public class KpTranslateImportDto
  {
    /// <summary>
    /// 翻译键
    /// </summary>
    [Required(ErrorMessage = "翻译键不能为空")]
    [KpExcelColumnName("翻译键")]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    [Required(ErrorMessage = "翻译值不能为空")]
    [KpExcelColumnName("翻译值")]
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    [KpExcelColumnName("语言ID")]
    public long LanguageId { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    [KpExcelColumnName("翻译描述")]
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    [KpExcelColumnName("是否启用")]
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [Required(ErrorMessage = "排序不能为空")]
    [KpExcelColumnName("排序")]
    public int OrderNum { get; set; }
  }

  /// <summary>
  /// 翻译导出数据传输对象
  /// </summary>
  public class KpTranslateExportDto
  {
    /// <summary>
    /// 翻译ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("翻译ID")]
    public long Id { get; set; }

    /// <summary>
    /// 翻译键
    /// </summary>
    [KpExcelColumnName("翻译键")]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    [KpExcelColumnName("翻译值")]
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    [KpExcelColumnName("语言ID")]
    public long LanguageId { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [KpExcelColumnName("语言名称")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    [KpExcelColumnName("翻译描述")]
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [KpExcelColumnName("排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 翻译模板数据传输对象
  /// </summary>
  public class KpTranslateTemplateDto
  {
    /// <summary>
    /// 翻译键
    /// </summary>
    [Required(ErrorMessage = "翻译键不能为空")]
    [KpExcelColumnName("翻译键")]
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译值
    /// </summary>
    [Required(ErrorMessage = "翻译值不能为空")]
    [KpExcelColumnName("翻译值")]
    public string? TranslateValue { get; set; }

    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    [KpExcelColumnName("语言ID")]
    public long LanguageId { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [KpExcelColumnName("语言名称")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    [KpExcelColumnName("翻译描述")]
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    [KpExcelColumnName("是否启用")]
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [Required(ErrorMessage = "排序不能为空")]
    [KpExcelColumnName("排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 修改翻译状态数据传输对象
  /// </summary>
  public class KpTranslateChangeStatusDto
  {
    /// <summary>
    /// 翻译ID
    /// </summary>
    [Required(ErrorMessage = "翻译ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 翻译转置数据传输对象
  /// </summary>
  public class KpTranslateTransposeDto
  {
    /// <summary>
    /// 翻译键
    /// </summary>
    public string? TranslateKey { get; set; }

    /// <summary>
    /// 翻译描述
    /// </summary>
    public string? TranslateDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 翻译值字典，键为语言代码，值为翻译值
    /// </summary>
    public Dictionary<string, string> Translations { get; set; } = new Dictionary<string, string>();
  }
}