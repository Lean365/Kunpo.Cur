// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>岗位数据传输对象</summary>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Newtonsoft.Json;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 岗位数据传输对象
  /// </summary>
  public class KpPostDto
  {
    /// <summary>
    /// 岗位ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位编码
    /// </summary>
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位描述
    /// </summary>
    public string? PostDesc { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    public int PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    public int PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsActive { get; set; }
  }

  /// <summary>
  /// 岗位查询数据传输对象
  /// </summary>
  public class KpPostQueryDto : KpPageRequest
  {
    public KpPostQueryDto()
    {
      PostCode = null;
      PostName = null;
      Status = null;
      PostLevel = null;
      PostSequence = null;
      IsActive = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "PostCode", "PostName" };
    }

    /// <summary>
    /// 岗位编码
    /// </summary>
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    public int? PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    public int? PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsActive { get; set; }
  }

  /// <summary>
  /// 岗位创建数据传输对象
  /// </summary>
  public class KpPostCreateDto
  {
    public KpPostCreateDto()
    {
      PostCode = string.Empty;
      PostName = string.Empty;
      PostDesc = string.Empty;
      OrderNum = 0;
      Status = 1;
      PostLevel = 0;
      PostSequence = 4;
      IsActive = 1;
    }

    /// <summary>
    /// 岗位编码
    /// </summary>
    [Required(ErrorMessage = "岗位编码不能为空")]
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    [Required(ErrorMessage = "岗位名称不能为空")]
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位描述
    /// </summary>
    public string? PostDesc { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    public int PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    public int PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsActive { get; set; }
  }

  /// <summary>
  /// 岗位更新数据传输对象
  /// </summary>
  public class KpPostUpdateDto : KpPostCreateDto
  {
    /// <summary>
    /// 岗位ID
    /// </summary>
    [Required(ErrorMessage = "岗位ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 岗位删除数据传输对象
  /// </summary>
  public class KpPostDeleteDto
  {
    /// <summary>
    /// 岗位ID
    /// </summary>
    [Required(ErrorMessage = "岗位ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 岗位导入数据传输对象
  /// </summary>
  public class KpPostImportDto
  {
    /// <summary>
    /// 岗位编码
    /// </summary>
    [Required(ErrorMessage = "岗位编码不能为空")]
    [KpExcelColumnName("岗位编码")]
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    [Required(ErrorMessage = "岗位名称不能为空")]
    [KpExcelColumnName("岗位名称")]
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位描述
    /// </summary>
    [KpExcelColumnName("岗位描述")]
    public string? PostDesc { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    [Required(ErrorMessage = "岗位排序不能为空")]
    [KpExcelColumnName("岗位排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    [Required(ErrorMessage = "岗位状态不能为空")]
    [KpExcelColumnName("岗位状态")]
    public int Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    [Required(ErrorMessage = "岗位等级不能为空")]
    [KpExcelColumnName("岗位等级")]
    public int PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    [Required(ErrorMessage = "岗位序列不能为空")]
    [KpExcelColumnName("岗位序列")]
    public int PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    [KpExcelColumnName("是否启用")]
    public int IsActive { get; set; }
  }

  /// <summary>
  /// 岗位导出数据传输对象
  /// </summary>
  public class KpPostExportDto
  {
    /// <summary>
    /// 岗位ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("岗位ID")]
    public long Id { get; set; }

    /// <summary>
    /// 岗位编码
    /// </summary>
    [KpExcelColumnName("岗位编码")]
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    [KpExcelColumnName("岗位名称")]
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位描述
    /// </summary>
    [KpExcelColumnName("岗位描述")]
    public string? PostDesc { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    [KpExcelColumnName("岗位排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    [KpExcelColumnName("岗位状态")]
    public int Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    [KpExcelColumnName("岗位等级")]
    public int PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    [KpExcelColumnName("岗位序列")]
    public int PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public int IsActive { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 岗位状态标签
    /// </summary>
    [KpExcelColumnName("岗位状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 岗位等级标签
    /// </summary>
    [KpExcelColumnName("岗位等级")]
    public string? PostLevelLabel { get; set; }

    /// <summary>
    /// 岗位序列标签
    /// </summary>
    [KpExcelColumnName("岗位序列")]
    public string? PostSequenceLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsActiveLabel { get; set; }
  }

  /// <summary>
  /// 岗位模板数据传输对象
  /// </summary>
  public class KpPostTemplateDto
  {
    /// <summary>
    /// 岗位编码
    /// </summary>
    [Required(ErrorMessage = "岗位编码不能为空")]
    [KpExcelColumnName("岗位编码")]
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    [Required(ErrorMessage = "岗位名称不能为空")]
    [KpExcelColumnName("岗位名称")]
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位描述
    /// </summary>
    [KpExcelColumnName("岗位描述")]
    public string? PostDesc { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    [Required(ErrorMessage = "岗位排序不能为空")]
    [KpExcelColumnName("岗位排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 岗位状态
    /// </summary>
    [Required(ErrorMessage = "岗位状态不能为空")]
    [KpExcelColumnName("岗位状态")]
    public int Status { get; set; }

    /// <summary>
    /// 岗位等级
    /// </summary>
    [Required(ErrorMessage = "岗位等级不能为空")]
    [KpExcelColumnName("岗位等级")]
    public int PostLevel { get; set; }

    /// <summary>
    /// 岗位序列
    /// </summary>
    [Required(ErrorMessage = "岗位序列不能为空")]
    [KpExcelColumnName("岗位序列")]
    public int PostSequence { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    [KpExcelColumnName("是否启用")]
    public int IsActive { get; set; }

    /// <summary>
    /// 岗位状态标签
    /// </summary>
    [KpExcelColumnName("岗位状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 岗位等级标签
    /// </summary>
    [KpExcelColumnName("岗位等级")]
    public string? PostLevelLabel { get; set; }

    /// <summary>
    /// 岗位序列标签
    /// </summary>
    [KpExcelColumnName("岗位序列")]
    public string? PostSequenceLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsActiveLabel { get; set; }
  }

  /// <summary>
  /// 修改岗位状态数据传输对象
  /// </summary>
  public class KpPostChangeStatusDto
  {
    /// <summary>
    /// 岗位ID
    /// </summary>
    [Required(ErrorMessage = "岗位ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsActive { get; set; }
  }
}