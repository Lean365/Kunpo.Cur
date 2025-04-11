// -----------------------------------------------------------------------
// <copyright file="KpConfigDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>系统配置数据传输对象</summary>
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
  /// 系统配置数据传输对象
  /// </summary>
  public class KpConfigDto
  {
    /// <summary>
    /// 配置键
    /// </summary>
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）
    /// </summary>
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    public string? ConfigGroup { get; set; }

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
  /// 系统配置查询数据传输对象
  /// </summary>
  public class KpConfigQueryDto : KpPageRequest
  {
    public KpConfigQueryDto()
    {
      ConfigKey = null;
      ConfigGroup = null;
      ConfigType = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "ConfigKey", "ConfigValue", "ConfigDesc" };
    }

    /// <summary>
    /// 配置键
    /// </summary>
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    public string? ConfigGroup { get; set; }

    /// <summary>
    /// 配置类型
    /// </summary>
    public int? ConfigType { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 系统配置创建数据传输对象
  /// </summary>
  public class KpConfigCreateDto
  {
    public KpConfigCreateDto()
    {
      ConfigKey = string.Empty;
      ConfigValue = string.Empty;
      ConfigDesc = string.Empty;
      ConfigGroup = string.Empty;
      ConfigType = 0;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 配置键
    /// </summary>
    [Required(ErrorMessage = "配置键不能为空")]
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [Required(ErrorMessage = "配置值不能为空")]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）
    /// </summary>
    [Required(ErrorMessage = "配置类型不能为空")]
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    public string? ConfigGroup { get; set; }

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
  /// 系统配置更新数据传输对象
  /// </summary>
  public class KpConfigUpdateDto : KpConfigCreateDto
  {
    /// <summary>
    /// 配置ID
    /// </summary>
    [Required(ErrorMessage = "配置ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 系统配置导入数据传输对象
  /// </summary>
  public class KpConfigImportDto
  {
    /// <summary>
    /// 配置键
    /// </summary>
    [Required(ErrorMessage = "配置键不能为空")]
    [KpExcelColumnName("配置键")]
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [Required(ErrorMessage = "配置值不能为空")]
    [KpExcelColumnName("配置值")]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    [KpExcelColumnName("配置描述")]
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）
    /// </summary>
    [Required(ErrorMessage = "配置类型不能为空")]
    [KpExcelColumnName("配置类型")]
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    [KpExcelColumnName("配置分组")]
    public string? ConfigGroup { get; set; }

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
  /// 系统配置导出数据传输对象
  /// </summary>
  public class KpConfigExportDto
  {
    /// <summary>
    /// 配置ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("配置ID")]
    public long Id { get; set; }

    /// <summary>
    /// 配置键
    /// </summary>
    [KpExcelColumnName("配置键")]
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [KpExcelColumnName("配置值")]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    [KpExcelColumnName("配置描述")]
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型
    /// </summary>
    [KpExcelColumnName("配置类型")]
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    [KpExcelColumnName("配置分组")]
    public string? ConfigGroup { get; set; }

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
    /// 配置类型标签
    /// </summary>
    [KpExcelColumnName("配置类型")]
    public string? ConfigTypeLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 系统配置模板数据传输对象
  /// </summary>
  public class KpConfigTemplateDto
  {
    /// <summary>
    /// 配置键
    /// </summary>
    [Required(ErrorMessage = "配置键不能为空")]
    [KpExcelColumnName("配置键")]
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [Required(ErrorMessage = "配置值不能为空")]
    [KpExcelColumnName("配置值")]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    [KpExcelColumnName("配置描述")]
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）
    /// </summary>
    [Required(ErrorMessage = "配置类型不能为空")]
    [KpExcelColumnName("配置类型")]
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    [KpExcelColumnName("配置分组")]
    public string? ConfigGroup { get; set; }

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
    /// 配置类型标签
    /// </summary>
    [KpExcelColumnName("配置类型")]
    public string? ConfigTypeLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 修改配置状态数据传输对象
  /// </summary>
  public class KpConfigChangeStatusDto
  {
    /// <summary>
    /// 配置ID
    /// </summary>
    [Required(ErrorMessage = "配置ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 系统配置删除数据传输对象
  /// </summary>
  public class KpConfigDeleteDto
  {
    /// <summary>
    /// 配置ID
    /// </summary>
    [Required(ErrorMessage = "配置ID不能为空")]
    public long Id { get; set; }
  }
}