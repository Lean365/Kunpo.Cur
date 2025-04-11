// -----------------------------------------------------------------------
// <copyright file="KpLanguageDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>语言数据传输对象</summary>
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
  /// 语言数据传输对象
  /// </summary>
  public class KpLanguageDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 语言编码
    /// </summary>
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    public int IsDefault { get; set; }

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
  /// 语言查询数据传输对象
  /// </summary>
  public class KpLanguageQueryDto : KpPageRequest
  {
    public KpLanguageQueryDto()
    {
      LanguageCode = null;
      LanguageName = null;
      IsDefault = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "LanguageCode", "LanguageName" };
    }

    /// <summary>
    /// 语言编码
    /// </summary>
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    public int? IsDefault { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 语言创建数据传输对象
  /// </summary>
  public class KpLanguageCreateDto
  {
    public KpLanguageCreateDto()
    {
      LanguageCode = string.Empty;
      LanguageName = string.Empty;
      IsDefault = 0;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 语言编码
    /// </summary>
    [Required(ErrorMessage = "语言编码不能为空")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [Required(ErrorMessage = "语言名称不能为空")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    public int IsDefault { get; set; }

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
  /// 语言更新数据传输对象
  /// </summary>
  public class KpLanguageUpdateDto : KpLanguageCreateDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 语言删除数据传输对象
  /// </summary>
  public class KpLanguageDeleteDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 语言导入数据传输对象
  /// </summary>
  public class KpLanguageImportDto
  {
    /// <summary>
    /// 语言编码
    /// </summary>
    [Required(ErrorMessage = "语言编码不能为空")]
    [KpExcelColumnName("语言编码")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [Required(ErrorMessage = "语言名称不能为空")]
    [KpExcelColumnName("语言名称")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [Required(ErrorMessage = "是否默认不能为空")]
    [KpExcelColumnName("是否默认")]
    public int IsDefault { get; set; }

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
  /// 语言导出数据传输对象
  /// </summary>
  public class KpLanguageExportDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("语言ID")]
    public long Id { get; set; }

    /// <summary>
    /// 语言编码
    /// </summary>
    [KpExcelColumnName("语言编码")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [KpExcelColumnName("语言名称")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [KpExcelColumnName("是否默认")]
    public int IsDefault { get; set; }

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
    /// 是否默认标签
    /// </summary>
    [KpExcelColumnName("是否默认")]
    public string? IsDefaultLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 语言模板数据传输对象
  /// </summary>
  public class KpLanguageTemplateDto
  {
    /// <summary>
    /// 语言编码
    /// </summary>
    [Required(ErrorMessage = "语言编码不能为空")]
    [KpExcelColumnName("语言编码")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// 语言名称
    /// </summary>
    [Required(ErrorMessage = "语言名称不能为空")]
    [KpExcelColumnName("语言名称")]
    public string? LanguageName { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [Required(ErrorMessage = "是否默认不能为空")]
    [KpExcelColumnName("是否默认")]
    public int IsDefault { get; set; }

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
    /// 是否默认标签
    /// </summary>
    [KpExcelColumnName("是否默认")]
    public string? IsDefaultLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 修改语言状态数据传输对象
  /// </summary>
  public class KpLanguageChangeStatusDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 设置默认语言数据传输对象
  /// </summary>
  public class KpLanguageSetDefaultDto
  {
    /// <summary>
    /// 语言ID
    /// </summary>
    [Required(ErrorMessage = "语言ID不能为空")]
    public long Id { get; set; }
  }
}