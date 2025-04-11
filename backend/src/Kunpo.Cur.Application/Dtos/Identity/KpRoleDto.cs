// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色数据传输对象</summary>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Newtonsoft.Json;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 角色 DTO
  /// </summary>
  public class KpRoleDto
  {
    /// <summary>
    /// 构造函数
    /// </summary>
    public KpRoleDto()
    {
      RoleCode = string.Empty;
      RoleName = string.Empty;
      RoleDesc = string.Empty;
      RoleDataDeptIds = string.Empty;
    }

    /// <summary>
    /// 角色ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// 角色编码
    /// </summary>
    [Required(ErrorMessage = "角色编码不能为空")]
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    [Required(ErrorMessage = "角色名称不能为空")]
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    public string? RoleDesc { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    public int Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    /// <remarks>
    /// 0：全部数据，1：本部门数据，2：本部门及下级部门数据，3：自定义数据，4：仅本人数据，默认为0
    /// </remarks>
    public int DataScope { get; set; }

    /// <summary>
    /// 数据权限部门ID列表
    /// </summary>
    /// <remarks>
    /// 当数据权限类型为3(自定义数据)时使用，多个部门ID用逗号分隔
    /// </remarks>
    public string? RoleDataDeptIds { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// 创建人ID
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// 更新人ID
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool IsDeleted { get; set; }
  }

  /// <summary>
  /// 角色查询 DTO
  /// </summary>
  public class KpRoleQueryDto : KpPageRequest
  {
    public KpRoleQueryDto()
    {
      RoleCode = null;
      RoleName = null;
      Status = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "RoleCode", "RoleName", "RoleDesc" };
    }

    /// <summary>
    /// 角色编码
    /// </summary>
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    public int? DataScope { get; set; }
  }

  /// <summary>
  /// 创建角色 DTO
  /// </summary>
  public class KpRoleCreateDto
  {
    public KpRoleCreateDto()
    {
      RoleCode = string.Empty;
      RoleName = string.Empty;
      RoleDesc = string.Empty;
      RoleDataDeptIds = string.Empty;
      OrderNum = 0;
      Status = 1;
      DataScope = 0;
    }

    /// <summary>
    /// 角色编码
    /// </summary>
    [Required(ErrorMessage = "角色编码不能为空")]
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    [Required(ErrorMessage = "角色名称不能为空")]
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    public string? RoleDesc { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    public int DataScope { get; set; }

    /// <summary>
    /// 数据权限部门ID列表
    /// </summary>
    public string? RoleDataDeptIds { get; set; }
  }

  /// <summary>
  /// 更新角色 DTO
  /// </summary>
  public class KpRoleUpdateDto : KpRoleCreateDto
  {
    /// <summary>
    /// 角色ID
    /// </summary>
    [Required(ErrorMessage = "角色ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 角色导入 DTO
  /// </summary>
  public class KpRoleImportDto
  {
    /// <summary>
    /// 角色编码
    /// </summary>
    [Required(ErrorMessage = "角色编码不能为空")]
    [KpExcelColumnName("角色编码")]
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    [Required(ErrorMessage = "角色名称不能为空")]
    [KpExcelColumnName("角色名称")]
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    [KpExcelColumnName("角色描述")]
    public string? RoleDesc { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    [KpExcelColumnName("角色排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    [Required(ErrorMessage = "角色状态不能为空")]
    [KpExcelColumnName("角色状态")]
    public int Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    /// <remarks>
    /// 0：全部数据，1：本部门数据，2：本部门及下级部门数据，3：自定义数据，4：仅本人数据，默认为0
    /// </remarks>
    [Required(ErrorMessage = "数据权限类型不能为空")]
    [KpExcelColumnName("数据权限类型")]
    public int DataScope { get; set; }

    /// <summary>
    /// 数据权限部门ID列表
    /// </summary>
    [KpExcelColumnName("数据权限部门ID列表")]
    public string? RoleDataDeptIds { get; set; }
  }

  /// <summary>
  /// 角色导出 DTO
  /// </summary>
  public class KpRoleExportDto
  {
    /// <summary>
    /// 角色ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("角色ID")]
    public long Id { get; set; }

    /// <summary>
    /// 角色编码
    /// </summary>
    [KpExcelColumnName("角色编码")]
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    [KpExcelColumnName("角色名称")]
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    [KpExcelColumnName("角色描述")]
    public string? RoleDesc { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    [KpExcelColumnName("角色排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    [KpExcelColumnName("角色状态")]
    public int Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    [KpExcelColumnName("数据权限类型")]
    public int DataScope { get; set; }

    /// <summary>
    /// 数据权限部门ID列表
    /// </summary>
    [KpExcelColumnName("数据权限部门ID列表")]
    public string? RoleDataDeptIds { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 角色状态标签
    /// </summary>
    [KpExcelColumnName("角色状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 数据权限类型标签
    /// </summary>
    [KpExcelColumnName("数据权限类型")]
    public string? DataScopeLabel { get; set; }
  }

  /// <summary>
  /// 角色模板 DTO
  /// </summary>
  public class KpRoleTemplateDto
  {
    /// <summary>
    /// 角色编码
    /// </summary>
    [Required(ErrorMessage = "角色编码不能为空")]
    [KpExcelColumnName("角色编码")]
    public string? RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    [Required(ErrorMessage = "角色名称不能为空")]
    [KpExcelColumnName("角色名称")]
    public string? RoleName { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    [KpExcelColumnName("角色描述")]
    public string? RoleDesc { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    [KpExcelColumnName("角色排序")]
    public int OrderNum { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    [Required(ErrorMessage = "角色状态不能为空")]
    [KpExcelColumnName("角色状态")]
    public int Status { get; set; }

    /// <summary>
    /// 数据权限类型
    /// </summary>
    /// <remarks>
    /// 0：全部数据，1：本部门数据，2：本部门及下级部门数据，3：自定义数据，4：仅本人数据，默认为0
    /// </remarks>
    [Required(ErrorMessage = "数据权限类型不能为空")]
    [KpExcelColumnName("数据权限类型")]
    public int DataScope { get; set; }

    /// <summary>
    /// 数据权限部门ID列表
    /// </summary>
    [KpExcelColumnName("数据权限部门ID列表")]
    public string? RoleDataDeptIds { get; set; }

    /// <summary>
    /// 角色状态标签
    /// </summary>
    [KpExcelColumnName("角色状态")]
    public string? StatusLabel { get; set; }

    /// <summary>
    /// 数据权限类型标签
    /// </summary>
    [KpExcelColumnName("数据权限类型")]
    public string? DataScopeLabel { get; set; }
  }

  /// <summary>
  /// 修改角色状态 DTO
  /// </summary>
  public class KpRoleChangeStatusDto
  {
    /// <summary>
    /// 角色ID
    /// </summary>
    [Required(ErrorMessage = "角色ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 角色状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    [Required(ErrorMessage = "角色状态不能为空")]
    public int Status { get; set; }
  }

  /// <summary>
  /// 角色删除数据传输对象
  /// </summary>
  public class KpRoleDeleteDto
  {
    /// <summary>
    /// 角色ID
    /// </summary>
    [Required(ErrorMessage = "角色ID不能为空")]
    public long Id { get; set; }
  }
}