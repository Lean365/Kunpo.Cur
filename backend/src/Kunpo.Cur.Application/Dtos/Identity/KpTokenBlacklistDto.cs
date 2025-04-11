// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>令牌黑名单数据传输对象</summary>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Kunpo.Cur.Common.Models;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 令牌黑名单数据传输对象
  /// </summary>
  public class KpTokenBlacklistDto
  {
    /// <summary>
    /// 主键ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long UserId { get; set; }

    /// <summary>
    /// 令牌
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// 令牌类型（0：访问令牌，1：刷新令牌）
    /// </summary>
    public int TokenType { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// 加入黑名单时间
    /// </summary>
    public DateTime? BlacklistTime { get; set; }

    /// <summary>
    /// 加入黑名单原因
    /// </summary>
    public string? BlacklistReason { get; set; }
  }

  /// <summary>
  /// 令牌黑名单查询数据传输对象
  /// </summary>
  public class KpTokenBlacklistQueryDto : KpPageRequest
  {
    public KpTokenBlacklistQueryDto()
    {
      UserId = null;
      TokenType = null;
      OrderBy = "BlacklistTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "Token", "BlacklistReason" };
    }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long? UserId { get; set; }

    /// <summary>
    /// 令牌类型
    /// </summary>
    public int? TokenType { get; set; }
  }

  /// <summary>
  /// 令牌黑名单创建数据传输对象
  /// </summary>
  public class KpTokenBlacklistCreateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long UserId { get; set; }

    /// <summary>
    /// 令牌
    /// </summary>
    [Required(ErrorMessage = "令牌不能为空")]
    public string? Token { get; set; }

    /// <summary>
    /// 令牌类型（0：访问令牌，1：刷新令牌）
    /// </summary>
    [Required(ErrorMessage = "令牌类型不能为空")]
    public int TokenType { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    [Required(ErrorMessage = "过期时间不能为空")]
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// 加入黑名单原因
    /// </summary>
    public string? BlacklistReason { get; set; }
  }

  /// <summary>
  /// 令牌黑名单导出数据传输对象
  /// </summary>
  public class KpTokenBlacklistExportDto
  {
    /// <summary>
    /// 主键ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long UserId { get; set; }

    /// <summary>
    /// 令牌
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// 令牌类型（0：访问令牌，1：刷新令牌）
    /// </summary>
    public int TokenType { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// 加入黑名单时间
    /// </summary>
    public DateTime? BlacklistTime { get; set; }

    /// <summary>
    /// 加入黑名单原因
    /// </summary>
    public string? BlacklistReason { get; set; }

    /// <summary>
    /// 令牌类型标签
    /// </summary>
    public string? TokenTypeLabel { get; set; }
  }

  /// <summary>
  /// 令牌黑名单删除数据传输对象
  /// </summary>
  public class KpTokenBlacklistDeleteDto
  {
    /// <summary>
    /// 主键ID
    /// </summary>
    [Required(ErrorMessage = "主键ID不能为空")]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }
  }
}