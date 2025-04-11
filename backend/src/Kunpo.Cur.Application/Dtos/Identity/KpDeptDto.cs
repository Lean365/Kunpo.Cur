// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>部门数据传输对象</summary>
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
  /// 部门数据传输对象
  /// </summary>
  public class KpDeptDto
  {
    /// <summary>
    /// 部门ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 父部门ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    public string? DeptDesc { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 部门电话
    /// </summary>
    public string? DeptPhone { get; set; }

    /// <summary>
    /// 部门邮箱
    /// </summary>
    public string? DeptEmail { get; set; }

    /// <summary>
    /// 部门地址
    /// </summary>
    public string? DeptAddress { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnabled { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 子部门列表
    /// </summary>
    public List<KpDeptDto>? Children { get; set; }

    /// <summary>
    /// 父部门名称
    /// </summary>
    public string? ParentName { get; set; }

    /// <summary>
    /// 部门层级
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 部门路径
    /// </summary>
    public string? DeptPath { get; set; }
  }

  /// <summary>
  /// 部门查询数据传输对象
  /// </summary>
  public class KpDeptQueryDto : KpPageRequest
  {
    public KpDeptQueryDto()
    {
      ParentId = null;
      DeptName = null;
      DeptCode = null;
      DeptLeader = null;
      IsEnabled = null;
      OrderBy = "OrderNum";
      OrderType = "asc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "DeptName", "DeptCode", "DeptLeader" };
    }

    /// <summary>
    /// 父部门ID
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public int? IsEnabled { get; set; }
  }

  /// <summary>
  /// 部门创建数据传输对象
  /// </summary>
  public class KpDeptCreateDto
  {
    public KpDeptCreateDto()
    {
      ParentId = 0;
      DeptName = string.Empty;
      DeptCode = string.Empty;
      DeptDesc = string.Empty;
      DeptLeader = string.Empty;
      DeptPhone = string.Empty;
      DeptEmail = string.Empty;
      DeptAddress = string.Empty;
      IsEnabled = 1;
      OrderNum = 0;
    }

    /// <summary>
    /// 父部门ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [Required(ErrorMessage = "部门名称不能为空")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [Required(ErrorMessage = "部门编码不能为空")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    public string? DeptDesc { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 部门电话
    /// </summary>
    public string? DeptPhone { get; set; }

    /// <summary>
    /// 部门邮箱
    /// </summary>
    public string? DeptEmail { get; set; }

    /// <summary>
    /// 部门地址
    /// </summary>
    public string? DeptAddress { get; set; }

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
  /// 部门更新数据传输对象
  /// </summary>
  public class KpDeptUpdateDto : KpDeptCreateDto
  {
    /// <summary>
    /// 部门ID
    /// </summary>
    [Required(ErrorMessage = "部门ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 部门导入数据传输对象
  /// </summary>
  public class KpDeptImportDto
  {
    /// <summary>
    /// 父部门ID
    /// </summary>
    [Required(ErrorMessage = "父部门ID不能为空")]
    [KpExcelColumnName("父部门ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [Required(ErrorMessage = "部门名称不能为空")]
    [KpExcelColumnName("部门名称")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [Required(ErrorMessage = "部门编码不能为空")]
    [KpExcelColumnName("部门编码")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    [KpExcelColumnName("部门描述")]
    public string? DeptDesc { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    [KpExcelColumnName("部门负责人")]
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 部门电话
    /// </summary>
    [KpExcelColumnName("部门电话")]
    public string? DeptPhone { get; set; }

    /// <summary>
    /// 部门邮箱
    /// </summary>
    [KpExcelColumnName("部门邮箱")]
    public string? DeptEmail { get; set; }

    /// <summary>
    /// 部门地址
    /// </summary>
    [KpExcelColumnName("部门地址")]
    public string? DeptAddress { get; set; }

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
  /// 部门导出数据传输对象
  /// </summary>
  public class KpDeptExportDto
  {
    /// <summary>
    /// 部门ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("部门ID")]
    public long Id { get; set; }

    /// <summary>
    /// 父部门ID
    /// </summary>
    [KpExcelColumnName("父部门ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 父部门名称
    /// </summary>
    [KpExcelColumnName("父部门名称")]
    public string? ParentName { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [KpExcelColumnName("部门名称")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [KpExcelColumnName("部门编码")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    [KpExcelColumnName("部门描述")]
    public string? DeptDesc { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    [KpExcelColumnName("部门负责人")]
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 部门电话
    /// </summary>
    [KpExcelColumnName("部门电话")]
    public string? DeptPhone { get; set; }

    /// <summary>
    /// 部门邮箱
    /// </summary>
    [KpExcelColumnName("部门邮箱")]
    public string? DeptEmail { get; set; }

    /// <summary>
    /// 部门地址
    /// </summary>
    [KpExcelColumnName("部门地址")]
    public string? DeptAddress { get; set; }

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
  /// 部门模板数据传输对象
  /// </summary>
  public class KpDeptTemplateDto
  {
    /// <summary>
    /// 父部门ID
    /// </summary>
    [Required(ErrorMessage = "父部门ID不能为空")]
    [KpExcelColumnName("父部门ID")]
    public long ParentId { get; set; }

    /// <summary>
    /// 父部门名称
    /// </summary>
    [KpExcelColumnName("父部门名称")]
    public string? ParentName { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [Required(ErrorMessage = "部门名称不能为空")]
    [KpExcelColumnName("部门名称")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [Required(ErrorMessage = "部门编码不能为空")]
    [KpExcelColumnName("部门编码")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    [KpExcelColumnName("部门描述")]
    public string? DeptDesc { get; set; }

    /// <summary>
    /// 部门负责人
    /// </summary>
    [KpExcelColumnName("部门负责人")]
    public string? DeptLeader { get; set; }

    /// <summary>
    /// 部门电话
    /// </summary>
    [KpExcelColumnName("部门电话")]
    public string? DeptPhone { get; set; }

    /// <summary>
    /// 部门邮箱
    /// </summary>
    [KpExcelColumnName("部门邮箱")]
    public string? DeptEmail { get; set; }

    /// <summary>
    /// 部门地址
    /// </summary>
    [KpExcelColumnName("部门地址")]
    public string? DeptAddress { get; set; }

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
  /// 修改部门状态数据传输对象
  /// </summary>
  public class KpDeptChangeStatusDto
  {
    /// <summary>
    /// 部门ID
    /// </summary>
    [Required(ErrorMessage = "部门ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [Required(ErrorMessage = "是否启用不能为空")]
    public int IsEnabled { get; set; }
  }

  /// <summary>
  /// 部门删除数据传输对象
  /// </summary>
  public class KpDeptDeleteDto
  {
    /// <summary>
    /// 部门ID
    /// </summary>
    [Required(ErrorMessage = "部门ID不能为空")]
    public long Id { get; set; }
  }
}