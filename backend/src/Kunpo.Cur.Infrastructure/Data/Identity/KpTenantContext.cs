// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户上下文</summary>
// <remarks>处理租户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;

namespace Kunpo.Cur.Infrastructure.Data.Identity
{
  /// <summary>
  /// 租户上下文
  /// </summary>
  public class KpTenantContext
  {
    private readonly KpSqlSugarDbContext _dbContext;

    public KpTenantContext(KpSqlSugarDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// 租户表
    /// </summary>
    public ISugarQueryable<KpTenant> Tenants => _dbContext.Db.Queryable<KpTenant>();
  }
}