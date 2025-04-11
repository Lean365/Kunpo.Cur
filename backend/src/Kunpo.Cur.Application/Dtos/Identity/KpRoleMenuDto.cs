// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色菜单数据传输对象</summary>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 角色菜单数据传输对象
  /// </summary>
  public class KpRoleMenuDto
  {
    /// <summary>
    /// 角色ID
    /// </summary>
    [Required(ErrorMessage = "角色ID不能为空")]
    [SugarColumn(IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long RoleId { get; set; }

    /// <summary>
    /// 菜单ID列表
    /// </summary>
    [Required(ErrorMessage = "菜单ID列表不能为空")]
    public List<long> MenuIds { get; set; } = new List<long>();
  }
}