// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户部门关联数据传输对象</summary>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Kunpo.Cur.Common.Models;
using SqlSugar;
namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 用户部门关联数据传输对象
  /// </summary>
  public class KpUserDeptDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long UserId { get; set; }

    /// <summary>
    /// 部门ID列表
    /// </summary>
    [Required(ErrorMessage = "部门ID列表不能为空")]
    public List<long> DeptIds { get; set; } = new();
  }
}