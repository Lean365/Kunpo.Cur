// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>菜单数据传输对象</summary>
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
  /// 菜单数据传输对象
  /// </summary>
  public class KpMenuDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public int MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    public string? MenuDesc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 子菜单列表
    /// </summary>
    public List<KpMenuDto>? Children { get; set; }

    /// <summary>
    /// 父菜单名称
    /// </summary>
    public string? ParentName { get; set; }

    /// <summary>
    /// 菜单层级
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    public string? MenuPathFull { get; set; }
  }

  /// <summary>
  /// 菜单查询数据传输对象
  /// </summary>
  public class KpMenuQueryDto : KpPageRequest
  {
    public KpMenuQueryDto()
    {
      ParentId = null;
      MenuName = null;
      MenuCode = null;
      MenuType = null;
      Status = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "MenuName", "MenuCode" };
    }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public int? MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 菜单创建数据传输对象
  /// </summary>
  public class KpMenuCreateDto
  {
    public KpMenuCreateDto()
    {
      ParentId = 0;
      MenuName = string.Empty;
      MenuCode = string.Empty;
      MenuIcon = string.Empty;
      MenuPath = string.Empty;
      MenuComponent = string.Empty;
      MenuPerms = string.Empty;
      MenuType = 0;
      Status = 0;
      MenuDesc = string.Empty;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    [Required(ErrorMessage = "菜单名称不能为空")]
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    [Required(ErrorMessage = "菜单编码不能为空")]
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    [Required(ErrorMessage = "菜单类型不能为空")]
    public int MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    [Required(ErrorMessage = "菜单状态不能为空")]
    public int Status { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    public string? MenuDesc { get; set; }

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
  /// 菜单更新数据传输对象
  /// </summary>
  public class KpMenuUpdateDto : KpMenuCreateDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    [Required(ErrorMessage = "菜单ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 菜单导入数据传输对象
  /// </summary>
  public class KpMenuImportDto
  {
    /// <summary>
    /// 父菜单ID
    /// </summary>
    [Required(ErrorMessage = "父菜单ID不能为空")]
    [KpExcelColumnName("父菜单ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    [Required(ErrorMessage = "菜单名称不能为空")]
    [KpExcelColumnName("菜单名称")]
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    [Required(ErrorMessage = "菜单编码不能为空")]
    [KpExcelColumnName("菜单编码")]
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    [KpExcelColumnName("菜单图标")]
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    [KpExcelColumnName("菜单路径")]
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    [KpExcelColumnName("菜单组件")]
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    [KpExcelColumnName("菜单权限")]
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    [Required(ErrorMessage = "菜单类型不能为空")]
    [KpExcelColumnName("菜单类型")]
    public int MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    [Required(ErrorMessage = "菜单状态不能为空")]
    [KpExcelColumnName("菜单状态")]
    public int Status { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    [KpExcelColumnName("菜单描述")]
    public string? MenuDesc { get; set; }

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
  /// 菜单导出数据传输对象
  /// </summary>
  public class KpMenuExportDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("菜单ID")]
    public long Id { get; set; }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    [KpExcelColumnName("父菜单ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 父菜单名称
    /// </summary>
    [KpExcelColumnName("父菜单名称")]
    public string? ParentName { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    [KpExcelColumnName("菜单名称")]
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    [KpExcelColumnName("菜单编码")]
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    [KpExcelColumnName("菜单图标")]
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    [KpExcelColumnName("菜单路径")]
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    [KpExcelColumnName("菜单组件")]
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    [KpExcelColumnName("菜单权限")]
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    [KpExcelColumnName("菜单类型")]
    public int MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    [KpExcelColumnName("菜单状态")]
    public int Status { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    [KpExcelColumnName("菜单描述")]
    public string? MenuDesc { get; set; }

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
    /// 菜单类型标签
    /// </summary>
    [KpExcelColumnName("菜单类型")]
    public string? MenuTypeLabel { get; set; }

    /// <summary>
    /// 菜单状态标签
    /// </summary>
    [KpExcelColumnName("菜单状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 菜单模板数据传输对象
  /// </summary>
  public class KpMenuTemplateDto
  {
    /// <summary>
    /// 父菜单ID
    /// </summary>
    [Required(ErrorMessage = "父菜单ID不能为空")]
    [KpExcelColumnName("父菜单ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 父菜单名称
    /// </summary>
    [KpExcelColumnName("父菜单名称")]
    public string? ParentName { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    [Required(ErrorMessage = "菜单名称不能为空")]
    [KpExcelColumnName("菜单名称")]
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    [Required(ErrorMessage = "菜单编码不能为空")]
    [KpExcelColumnName("菜单编码")]
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    [KpExcelColumnName("菜单图标")]
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    [KpExcelColumnName("菜单路径")]
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    [KpExcelColumnName("菜单组件")]
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    [KpExcelColumnName("菜单权限")]
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    [Required(ErrorMessage = "菜单类型不能为空")]
    [KpExcelColumnName("菜单类型")]
    public int MenuType { get; set; }

    /// <summary>
    /// 菜单状态
    /// </summary>
    [Required(ErrorMessage = "菜单状态不能为空")]
    [KpExcelColumnName("菜单状态")]
    public int Status { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    [KpExcelColumnName("菜单描述")]
    public string? MenuDesc { get; set; }

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
    /// 菜单类型标签
    /// </summary>
    [KpExcelColumnName("菜单类型")]
    public string? MenuTypeLabel { get; set; }

    /// <summary>
    /// 菜单状态标签
    /// </summary>
    [KpExcelColumnName("菜单状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 是否启用标签
    /// </summary>
    [KpExcelColumnName("是否启用")]
    public string? IsEnabledLabel { get; set; }
  }

  /// <summary>
  /// 修改菜单状态数据传输对象
  /// </summary>
  public class KpMenuChangeStatusDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    [Required(ErrorMessage = "菜单ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 菜单删除数据传输对象
  /// </summary>
  public class KpMenuDeleteDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    [Required(ErrorMessage = "菜单ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 菜单排序数据传输对象
  /// </summary>
  public class KpMenuSortDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    [Required(ErrorMessage = "菜单ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    [Required(ErrorMessage = "排序号不能为空")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    [Required(ErrorMessage = "父菜单ID不能为空")]
    public long ParentId { get; set; }
  }

  /// <summary>
  /// 当前用户菜单数据传输对象
  /// </summary>
  public class KpUserMenuDto
  {
    /// <summary>
    /// 菜单ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 父菜单ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string? MenuName { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    public string? MenuCode { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string? MenuIcon { get; set; }

    /// <summary>
    /// 菜单路径
    /// </summary>
    public string? MenuPath { get; set; }

    /// <summary>
    /// 菜单组件
    /// </summary>
    public string? MenuComponent { get; set; }

    /// <summary>
    /// 菜单权限
    /// </summary>
    public string? MenuPerms { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public int MenuType { get; set; }

    /// <summary>
    /// 是否缓存
    /// </summary>
    public int IsCache { get; set; }

    /// <summary>
    /// 是否可见
    /// </summary>
    public int IsVisible { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 子菜单列表
    /// </summary>
    public List<KpUserMenuDto>? Children { get; set; }
  }
}