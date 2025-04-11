// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户上下文接口</summary>
// <remarks>处理用户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;

namespace Kunpo.Cur.Domain.Interfaces
{
  /// <summary>
  /// 用户上下文接口
  /// </summary>
  public interface IKpUserContext
  {
    /// <summary>
    /// 用户表
    /// </summary>
    ISugarQueryable<KpUser> Users { get; }

    /// <summary>
    /// 用户角色关联表
    /// </summary>
    ISugarQueryable<KpUserRole> UserRoles { get; }

    /// <summary>
    /// 用户部门关联表
    /// </summary>
    ISugarQueryable<KpUserDept> UserDepts { get; }

    /// <summary>
    /// 用户岗位关联表
    /// </summary>
    ISugarQueryable<KpUserPost> UserPosts { get; }

    /// <summary>
    /// 获取当前用户名
    /// </summary>
    /// <returns>当前用户名</returns>
    string GetCurrentUserName();
  }
}