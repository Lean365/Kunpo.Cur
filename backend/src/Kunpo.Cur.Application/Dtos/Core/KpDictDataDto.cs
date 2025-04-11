// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典数据数据传输对象</summary>
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
  /// 字典数据数据传输对象
  /// </summary>
  public class KpDictDataDto
  {
    /// <summary>
    /// 字典数据ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 字典类型ID
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表样式
    /// </summary>
    public string? ListClass { get; set; }

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
  /// 字典数据查询数据传输对象
  /// </summary>
  public class KpDictDataQueryDto : KpPageRequest
  {
    public KpDictDataQueryDto()
    {
      DictTypeId = null;
      DictDataLabel = null;
      DictDataValue = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "DictDataLabel", "DictDataValue", "DictDataDesc" };
    }

    /// <summary>
    /// 字典类型ID
    /// </summary>
    public long? DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 字典数据创建数据传输对象
  /// </summary>
  public class KpDictDataCreateDto
  {
    public KpDictDataCreateDto()
    {
      DictDataLabel = string.Empty;
      DictDataValue = string.Empty;
      DictDataDesc = string.Empty;
      CssClass = string.Empty;
      ListClass = string.Empty;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 字典类型ID
    /// </summary>
    [Required(ErrorMessage = "字典类型ID不能为空")]
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    [Required(ErrorMessage = "字典数据标签不能为空")]
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    [Required(ErrorMessage = "字典数据值不能为空")]
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表样式
    /// </summary>
    public string? ListClass { get; set; }

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
  /// 字典数据更新数据传输对象
  /// </summary>
  public class KpDictDataUpdateDto : KpDictDataCreateDto
  {
    /// <summary>
    /// 字典数据ID
    /// </summary>
    [Required(ErrorMessage = "字典数据ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 字典数据导入数据传输对象
  /// </summary>
  public class KpDictDataImportDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [Required(ErrorMessage = "字典类型ID不能为空")]
    [KpExcelColumnName("字典类型ID")]
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    [Required(ErrorMessage = "字典数据标签不能为空")]
    [KpExcelColumnName("字典数据标签")]
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    [Required(ErrorMessage = "字典数据值不能为空")]
    [KpExcelColumnName("字典数据值")]
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    [KpExcelColumnName("字典数据描述")]
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    [KpExcelColumnName("CSS样式")]
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表样式
    /// </summary>
    [KpExcelColumnName("列表样式")]
    public string? ListClass { get; set; }

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
  /// 字典数据导入模板数据传输对象
  /// </summary>
  public class KpDictDataTemplateDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [KpExcelColumnName("字典类型ID")]
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    [KpExcelColumnName("字典数据标签")]
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    [KpExcelColumnName("字典数据值")]
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    [KpExcelColumnName("字典数据描述")]
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    [KpExcelColumnName("CSS样式")]
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表样式
    /// </summary>
    [KpExcelColumnName("列表样式")]
    public string? ListClass { get; set; }

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
  }

  /// <summary>
  /// 字典数据导出数据传输对象
  /// </summary>
  public class KpDictDataExportDto
  {
    /// <summary>
    /// 字典数据ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("字典数据ID")]
    public long Id { get; set; }

    /// <summary>
    /// 字典类型ID
    /// </summary>
    [KpExcelColumnName("字典类型ID")]
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    [KpExcelColumnName("字典数据标签")]
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    [KpExcelColumnName("字典数据值")]
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    [KpExcelColumnName("字典数据描述")]
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    [KpExcelColumnName("CSS样式")]
    public string? CssClass { get; set; }

    /// <summary>
    /// 列表样式
    /// </summary>
    [KpExcelColumnName("列表样式")]
    public string? ListClass { get; set; }

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
  /// 字典数据状态修改数据传输对象
  /// </summary>
  public class KpDictDataChangeStatusDto
  {
    /// <summary>
    /// 字典数据ID
    /// </summary>
    [Required(ErrorMessage = "字典数据ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 字典数据转置数据传输对象
  /// </summary>
  public class KpDictDataTransposeDto
  {
    /// <summary>
    /// 主键
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 字典类型ID
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典数据标签
    /// </summary>
    public string? DictDataLabel { get; set; }

    /// <summary>
    /// 字典数据值
    /// </summary>
    public string? DictDataValue { get; set; }

    /// <summary>
    /// 字典数据描述
    /// </summary>
    public string? DictDataDesc { get; set; }

    /// <summary>
    /// 扩展数据标签
    /// </summary>
    public string? ExtDataLabel { get; set; }

    /// <summary>
    /// 扩展数据值
    /// </summary>
    public string? ExtDataValue { get; set; }

    /// <summary>
    /// CSS样式
    /// </summary>
    public string? CssClass { get; set; }

    /// <summary>
    /// 表格回显样式
    /// </summary>
    public string? ListClass { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 多语言翻译
    /// </summary>
    public Dictionary<string, string> Translations { get; set; } = new Dictionary<string, string>();
  }

  /// <summary>
  /// 字典数据删除数据传输对象
  /// </summary>
  public class KpDictDataDeleteDto
  {
    /// <summary>
    /// 字典数据ID
    /// </summary>
    [Required(ErrorMessage = "字典数据ID不能为空")]
    public long Id { get; set; }
  }
}