// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户上下文</summary>
// <remarks>处理用户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.Infrastructure.Data.Identity
{
  /// <summary>
  /// 用户上下文
  /// </summary>
  public class KpUserContext : IKpUserContext
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly IKpSecurityContext _securityContext;

    public KpUserContext(KpSqlSugarDbContext dbContext, IKpSecurityContext securityContext)
    {
      _dbContext = dbContext;
      _securityContext = securityContext;
    }

    /// <summary>
    /// 用户表
    /// </summary>
    public ISugarQueryable<KpUser> Users => _dbContext.Db.Queryable<KpUser>();

    /// <summary>
    /// 用户角色关联表
    /// </summary>
    public ISugarQueryable<KpUserRole> UserRoles => _dbContext.Db.Queryable<KpUserRole>();

    /// <summary>
    /// 用户部门关联表
    /// </summary>
    public ISugarQueryable<KpUserDept> UserDepts => _dbContext.Db.Queryable<KpUserDept>();

    /// <summary>
    /// 用户岗位关联表
    /// </summary>
    public ISugarQueryable<KpUserPost> UserPosts => _dbContext.Db.Queryable<KpUserPost>();

    /// <summary>
    /// 获取当前用户名
    /// </summary>
    public string GetCurrentUserName()
    {
      return _securityContext.GetCurrentUserName() ?? string.Empty;
    }
  }
}