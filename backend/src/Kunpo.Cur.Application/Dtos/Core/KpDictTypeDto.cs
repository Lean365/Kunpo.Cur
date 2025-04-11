// -----------------------------------------------------------------------
// <copyright file="KpDictTypeDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典类型数据传输对象</summary>
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
  /// 字典类型数据传输对象
  /// </summary>
  public class KpDictTypeDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 字典类型名称
    /// </summary>
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典类型来源（0：系统内置，1：用户自定义，2：SQL查询）
    /// </summary>
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    public string? DictSqlScript { get; set; }

    /// <summary>
    /// 是否内置
    /// </summary>
    public int IsBuiltin { get; set; }

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
  /// 字典类型查询数据传输对象
  /// </summary>
  public class KpDictTypeQueryDto : KpPageRequest
  {
    public KpDictTypeQueryDto()
    {
      DictTypeName = null;
      DictTypeCode = null;
      DictSource = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "DictTypeName", "DictTypeCode", "DictTypeDesc" };
    }

    /// <summary>
    /// 字典类型名称
    /// </summary>
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型来源
    /// </summary>
    public int? DictSource { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 字典类型创建数据传输对象
  /// </summary>
  public class KpDictTypeCreateDto
  {
    public KpDictTypeCreateDto()
    {
      DictTypeName = string.Empty;
      DictTypeCode = string.Empty;
      DictTypeDesc = string.Empty;
      DictSqlScript = string.Empty;
      DictSource = 1;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 字典类型名称
    /// </summary>
    [Required(ErrorMessage = "字典类型名称不能为空")]
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    [Required(ErrorMessage = "字典类型编码不能为空")]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典类型来源（0：系统内置，1：用户自定义，2：SQL查询）
    /// </summary>
    [Required(ErrorMessage = "字典类型来源不能为空")]
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    public string? DictSqlScript { get; set; }

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
  /// 字典类型更新数据传输对象
  /// </summary>
  public class KpDictTypeUpdateDto : KpDictTypeCreateDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [Required(ErrorMessage = "字典类型ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 字典类型导入数据传输对象
  /// </summary>
  public class KpDictTypeImportDto
  {
    /// <summary>
    /// 字典类型名称
    /// </summary>
    [Required(ErrorMessage = "字典类型名称不能为空")]
    [KpExcelColumnName("字典类型名称")]
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    [Required(ErrorMessage = "字典类型编码不能为空")]
    [KpExcelColumnName("字典类型编码")]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    [KpExcelColumnName("字典类型描述")]
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典类型来源
    /// </summary>
    [Required(ErrorMessage = "字典类型来源不能为空")]
    [KpExcelColumnName("字典类型来源")]
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    [KpExcelColumnName("SQL脚本")]
    public string? DictSqlScript { get; set; }

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
  /// 字典类型导入模板数据传输对象
  /// </summary>
  public class KpDictTypeTemplateDto
  {
    /// <summary>
    /// 字典类型名称
    /// </summary>
    [KpExcelColumnName("字典类型名称")]
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    [KpExcelColumnName("字典类型编码")]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    [KpExcelColumnName("字典类型描述")]
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典类型来源
    /// </summary>
    [KpExcelColumnName("字典类型来源")]
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    [KpExcelColumnName("SQL脚本")]
    public string? DictSqlScript { get; set; }

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
  /// 字典类型导出数据传输对象
  /// </summary>
  public class KpDictTypeExportDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("字典类型ID")]
    public long Id { get; set; }

    /// <summary>
    /// 字典类型名称
    /// </summary>
    [KpExcelColumnName("字典类型名称")]
    public string? DictTypeName { get; set; }

    /// <summary>
    /// 字典类型编码
    /// </summary>
    [KpExcelColumnName("字典类型编码")]
    public string? DictTypeCode { get; set; }

    /// <summary>
    /// 字典类型描述
    /// </summary>
    [KpExcelColumnName("字典类型描述")]
    public string? DictTypeDesc { get; set; }

    /// <summary>
    /// 字典类型来源
    /// </summary>
    [KpExcelColumnName("字典类型来源")]
    public int DictSource { get; set; }

    /// <summary>
    /// SQL脚本
    /// </summary>
    [KpExcelColumnName("SQL脚本")]
    public string? DictSqlScript { get; set; }

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
    /// 字典类型来源标签
    /// </summary>
    [KpExcelColumnName("字典类型来源")]
    public string? DictSourceLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 字典类型状态修改数据传输对象
  /// </summary>
  public class KpDictTypeChangeStatusDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [Required(ErrorMessage = "字典类型ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 字典类型删除数据传输对象
  /// </summary>
  public class KpDictTypeDeleteDto
  {
    /// <summary>
    /// 字典类型ID
    /// </summary>
    [Required(ErrorMessage = "字典类型ID不能为空")]
    public long Id { get; set; }
  }
}