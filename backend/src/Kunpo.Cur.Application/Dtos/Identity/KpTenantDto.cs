// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户数据传输对象</summary>
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
  /// 租户数据传输对象
  /// </summary>
  public class KpTenantDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 租户名称
    /// </summary>
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户描述
    /// </summary>
    public string? TenantDesc { get; set; }

    /// <summary>
    /// 租户联系人
    /// </summary>
    public string? TenantContact { get; set; }

    /// <summary>
    /// 租户电话
    /// </summary>
    public string? TenantPhone { get; set; }

    /// <summary>
    /// 租户邮箱
    /// </summary>
    public string? TenantEmail { get; set; }

    /// <summary>
    /// 租户地址
    /// </summary>
    public string? TenantAddress { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 租户过期时间
    /// </summary>
    public DateTime? TenantExpireTime { get; set; }

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
  /// 租户查询数据传输对象
  /// </summary>
  public class KpTenantQueryDto : KpPageRequest
  {
    public KpTenantQueryDto()
    {
      TenantName = null;
      TenantCode = null;
      Status = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "TenantName", "TenantCode" };
    }

    /// <summary>
    /// 租户名称
    /// </summary>
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 租户创建数据传输对象
  /// </summary>
  public class KpTenantCreateDto
  {
    public KpTenantCreateDto()
    {
      TenantName = string.Empty;
      TenantCode = string.Empty;
      TenantShortName = string.Empty;
      TenantDesc = string.Empty;
      TenantContact = string.Empty;
      TenantPhone = string.Empty;
      TenantEmail = string.Empty;
      TenantAddress = string.Empty;
      Status = 0;
      TenantExpireTime = null;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 租户名称
    /// </summary>
    [Required(ErrorMessage = "租户名称不能为空")]
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    [Required(ErrorMessage = "租户编码不能为空")]
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户简称
    /// </summary>
    public string? TenantShortName { get; set; }

    /// <summary>
    /// 租户描述
    /// </summary>
    public string? TenantDesc { get; set; }

    /// <summary>
    /// 租户联系人
    /// </summary>
    public string? TenantContact { get; set; }

    /// <summary>
    /// 租户电话
    /// </summary>
    public string? TenantPhone { get; set; }

    /// <summary>
    /// 租户邮箱
    /// </summary>
    public string? TenantEmail { get; set; }

    /// <summary>
    /// 租户地址
    /// </summary>
    public string? TenantAddress { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    [Required(ErrorMessage = "租户状态不能为空")]
    public int Status { get; set; }

    /// <summary>
    /// 租户过期时间
    /// </summary>
    public DateTime? TenantExpireTime { get; set; }

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
  /// 租户更新数据传输对象
  /// </summary>
  public class KpTenantUpdateDto : KpTenantCreateDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }
  }

  /// <summary>
  /// 租户删除数据传输对象
  /// </summary>
  public class KpTenantDeleteDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }
  }

  /// <summary>
  /// 租户导入数据传输对象
  /// </summary>
  public class KpTenantImportDto
  {
    /// <summary>
    /// 租户名称
    /// </summary>
    [Required(ErrorMessage = "租户名称不能为空")]
    [KpExcelColumnName("租户名称")]
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    [Required(ErrorMessage = "租户编码不能为空")]
    [KpExcelColumnName("租户编码")]
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户简称
    /// </summary>
    [KpExcelColumnName("租户简称")]
    public string? TenantShortName { get; set; }

    /// <summary>
    /// 租户描述
    /// </summary>
    [KpExcelColumnName("租户描述")]
    public string? TenantDesc { get; set; }

    /// <summary>
    /// 租户联系人
    /// </summary>
    [KpExcelColumnName("租户联系人")]
    public string? TenantContact { get; set; }

    /// <summary>
    /// 租户电话
    /// </summary>
    [KpExcelColumnName("租户电话")]
    public string? TenantPhone { get; set; }

    /// <summary>
    /// 租户邮箱
    /// </summary>
    [KpExcelColumnName("租户邮箱")]
    public string? TenantEmail { get; set; }

    /// <summary>
    /// 租户地址
    /// </summary>
    [KpExcelColumnName("租户地址")]
    public string? TenantAddress { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    [Required(ErrorMessage = "租户状态不能为空")]
    [KpExcelColumnName("租户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 租户过期时间
    /// </summary>
    [KpExcelColumnName("租户过期时间")]
    public DateTime? TenantExpireTime { get; set; }

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
  /// 租户导出数据传输对象
  /// </summary>
  public class KpTenantExportDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("租户ID")]
    public long Id { get; set; }

    /// <summary>
    /// 租户名称
    /// </summary>
    [KpExcelColumnName("租户名称")]
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    [KpExcelColumnName("租户编码")]
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户描述
    /// </summary>
    [KpExcelColumnName("租户描述")]
    public string? TenantDesc { get; set; }

    /// <summary>
    /// 租户联系人
    /// </summary>
    [KpExcelColumnName("租户联系人")]
    public string? TenantContact { get; set; }

    /// <summary>
    /// 租户电话
    /// </summary>
    [KpExcelColumnName("租户电话")]
    public string? TenantPhone { get; set; }

    /// <summary>
    /// 租户邮箱
    /// </summary>
    [KpExcelColumnName("租户邮箱")]
    public string? TenantEmail { get; set; }

    /// <summary>
    /// 租户地址
    /// </summary>
    [KpExcelColumnName("租户地址")]
    public string? TenantAddress { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    [KpExcelColumnName("租户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 租户过期时间
    /// </summary>
    [KpExcelColumnName("租户过期时间")]
    public DateTime? TenantExpireTime { get; set; }

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
    /// 租户状态标签
    /// </summary>
    [KpExcelColumnName("租户状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 租户模板数据传输对象
  /// </summary>
  public class KpTenantTemplateDto
  {
    /// <summary>
    /// 租户名称
    /// </summary>
    [Required(ErrorMessage = "租户名称不能为空")]
    [KpExcelColumnName("租户名称")]
    public string? TenantName { get; set; }

    /// <summary>
    /// 租户编码
    /// </summary>
    [Required(ErrorMessage = "租户编码不能为空")]
    [KpExcelColumnName("租户编码")]
    public string? TenantCode { get; set; }

    /// <summary>
    /// 租户描述
    /// </summary>
    [KpExcelColumnName("租户描述")]
    public string? TenantDesc { get; set; }

    /// <summary>
    /// 租户联系人
    /// </summary>
    [KpExcelColumnName("租户联系人")]
    public string? TenantContact { get; set; }

    /// <summary>
    /// 租户电话
    /// </summary>
    [KpExcelColumnName("租户电话")]
    public string? TenantPhone { get; set; }

    /// <summary>
    /// 租户邮箱
    /// </summary>
    [KpExcelColumnName("租户邮箱")]
    public string? TenantEmail { get; set; }

    /// <summary>
    /// 租户地址
    /// </summary>
    [KpExcelColumnName("租户地址")]
    public string? TenantAddress { get; set; }

    /// <summary>
    /// 租户状态
    /// </summary>
    [Required(ErrorMessage = "租户状态不能为空")]
    [KpExcelColumnName("租户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 租户过期时间
    /// </summary>
    [KpExcelColumnName("租户过期时间")]
    public DateTime? TenantExpireTime { get; set; }

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
    /// 租户状态标签
    /// </summary>
    [KpExcelColumnName("租户状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 修改租户状态数据传输对象
  /// </summary>
  public class KpTenantChangeStatusDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }
}