// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>JWT配置</summary>
// <remarks>处理JWT的配置</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// JWT配置
  /// </summary>
  public class KpJwtOption
  {
    /// <summary>
    /// 密钥
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// 签发者
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// 接收者
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// 访问令牌过期时间（分钟）
    /// </summary>
    public int ExpireMinutes { get; set; } = 60;

    /// <summary>
    /// 刷新令牌过期时间（天）
    /// </summary>
    public int RefreshTokenExpireDays { get; set; } = 7;
  }
}