// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户岗位关联数据传输对象</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 用户岗位关联数据传输对象
  /// </summary>
  public class KpUserPostDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long UserId { get; set; }

    /// <summary>
    /// 岗位ID
    /// </summary>
    [Required(ErrorMessage = "岗位ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long PostId { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，默认为1
    /// </remarks>
    public int IsActive { get; set; } = 1;
  }
}