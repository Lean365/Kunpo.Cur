// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>安全上下文实现</summary>
// <remarks>处理安全上下文的实现</remarks>
// -----------------------------------------------------------------------

using System.Security.Claims;
using Kunpo.Cur.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Kunpo.Cur.Infrastructure.Services
{
  /// <summary>
  /// 安全上下文实现
  /// </summary>
  public class KpSecurityContext : IKpSecurityContext
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="httpContextAccessor">HTTP上下文访问器</param>
    public KpSecurityContext(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    public long GetCurrentUserId()
    {
      var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      return !string.IsNullOrEmpty(userId) && long.TryParse(userId, out var id) ? id : 0;
    }

    /// <summary>
    /// 获取当前用户名称
    /// </summary>
    public string? GetCurrentUserName()
    {
      return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
    }

    /// <summary>
    /// 获取当前用户权限列表
    /// </summary>
    public List<string> GetCurrentUserPermissions()
    {
      return _httpContextAccessor.HttpContext?.User.Claims
          .Where(c => c.Type == "permission")
          .Select(c => c.Value)
          .ToList() ?? new List<string>();
    }

    /// <summary>
    /// 检查当前用户是否拥有指定权限
    /// </summary>
    public bool HasPermission(string permissionCode)
    {
      return GetCurrentUserPermissions().Contains(permissionCode);
    }

    /// <summary>
    /// 检查当前用户是否拥有所有指定权限
    /// </summary>
    public bool HasAllPermissions(params string[] permissionCodes)
    {
      var userPermissions = GetCurrentUserPermissions();
      return permissionCodes.All(permissionCode => userPermissions.Contains(permissionCode));
    }

    /// <summary>
    /// 检查当前用户是否拥有任意指定权限
    /// </summary>
    public bool HasAnyPermission(params string[] permissionCodes)
    {
      var userPermissions = GetCurrentUserPermissions();
      return permissionCodes.Any(permissionCode => userPermissions.Contains(permissionCode));
    }
  }
}