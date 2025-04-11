// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>JWT服务接口</summary>
// <remarks>处理JWT服务的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System.Security.Claims;
using Kunpo.Cur.Domain.Entities.Identity;

namespace Kunpo.Cur.Domain.Interfaces
{
  /// <summary>
  /// JWT服务接口
  /// </summary>
  public interface IKpJwtService
  {
    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="userName">用户名</param>
    /// <param name="permissions">权限列表</param>
    /// <returns>访问令牌</returns>
    string GenerateAccessToken(long userId, string userName, IEnumerable<string> permissions);

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>刷新令牌</returns>
    string GenerateRefreshToken(long userId);

    /// <summary>
    /// 验证令牌
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否有效</returns>
    bool ValidateToken(string token);

    /// <summary>
    /// 将令牌加入黑名单
    /// </summary>
    /// <param name="token">令牌</param>
    /// <param name="expiration">过期时间</param>
    void AddToBlacklist(string token, DateTime expiration);

    /// <summary>
    /// 检查令牌是否在黑名单中
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否在黑名单中</returns>
    bool IsTokenBlacklisted(string token);

    /// <summary>
    /// 生成访问令牌和刷新令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>访问令牌和刷新令牌</returns>
    Task<(string AccessToken, string RefreshToken)> GenerateTokensAsync(KpUser user);

    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>访问令牌</returns>
    Task<string> GenerateTokenAsync(KpUser user);

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>刷新令牌</returns>
    Task<string> GenerateRefreshTokenAsync(KpUser user);

    /// <summary>
    /// 刷新令牌
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>新的访问令牌和刷新令牌</returns>
    Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken);

    /// <summary>
    /// 验证令牌
    /// </summary>
    /// <param name="token">令牌</param>
    /// <param name="isRefreshToken">是否是刷新令牌</param>
    /// <returns>令牌主体</returns>
    ClaimsPrincipal? ValidateToken(string token, bool isRefreshToken = false);

    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="userName">用户名</param>
    /// <param name="roles">角色列表</param>
    /// <returns>访问令牌</returns>
    string? GenerateAccessToken(long userId, string? userName, string[] roles);

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <returns>刷新令牌</returns>
    string? GenerateRefreshToken();

    /// <summary>
    /// 验证访问令牌
    /// </summary>
    /// <param name="token">访问令牌</param>
    /// <returns>是否有效</returns>
    bool ValidateAccessToken(string? token);

    /// <summary>
    /// 从令牌中获取用户ID
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>用户ID</returns>
    long GetUserIdFromToken(string? token);

    /// <summary>
    /// 从令牌中获取用户名
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>用户名</returns>
    string? GetUserNameFromToken(string? token);

    /// <summary>
    /// 从令牌中获取角色列表
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>角色列表</returns>
    string[] GetRolesFromToken(string? token);

    /// <summary>
    /// 登出
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>是否成功</returns>
    Task<bool> LogoutAsync(string accessToken, string refreshToken);
  }
}