// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>认证服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 认证服务接口
  /// </summary>
  public interface IKpAuthService
  {
    /// <summary>
    /// 用户认证
    /// </summary>
    /// <param name="authRequest">认证请求</param>
    /// <returns>认证响应</returns>
    Task<KpAuthResponseDto> AuthenticateAsync(KpAuthRequestDto authRequest);

    /// <summary>
    /// 用户登出
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>是否成功</returns>
    Task<bool> LogoutAsync(string accessToken, string refreshToken);

    /// <summary>
    /// 刷新令牌
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>新的访问令牌</returns>
    Task<KpAuthResponseDto> RefreshTokenAsync(string refreshToken);
  }
}