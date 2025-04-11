// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>安全上下文接口</summary>
// <remarks>处理安全的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Interfaces
{
  /// <summary>
  /// 安全上下文接口
  /// </summary>
  public interface IKpSecurityContext
  {
    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    long GetCurrentUserId();

    /// <summary>
    /// 获取当前用户名称
    /// </summary>
    string? GetCurrentUserName();

    /// <summary>
    /// 获取当前用户权限列表
    /// </summary>
    List<string> GetCurrentUserPermissions();

    /// <summary>
    /// 检查当前用户是否拥有指定权限
    /// </summary>
    bool HasPermission(string permissionCode);

    /// <summary>
    /// 检查当前用户是否拥有所有指定权限
    /// </summary>
    bool HasAllPermissions(params string[] permissionCodes);

    /// <summary>
    /// 检查当前用户是否拥有任意指定权限
    /// </summary>
    bool HasAnyPermission(params string[] permissionCodes);
  }
}