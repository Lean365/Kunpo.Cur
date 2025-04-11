// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>基础仓储实现类</summary>
// <remarks>处理基础仓储的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kunpo.Cur.Domain.Entities;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Interfaces;
using SqlSugar;
using Kunpo.Cur.Common.Apps;
using Kunpo.Cur.Infrastructure.Data;
using Kunpo.Cur.Common.Exceptions;
using AutoMapper;

namespace Kunpo.Cur.Infrastructure.Repositories
{
  /// <summary>
  /// 基础仓储实现类
  /// </summary>
  /// <remarks>
  /// 该实现类基于SqlSugar实现了基础仓储接口的所有功能，包括：
  /// 1. 查询操作：根据ID查询、获取所有记录、条件查询等
  /// 2. 新增操作：创建单个实体、批量创建实体
  /// 3. 修改操作：更新实体、批量更新、条件更新
  /// 4. 删除操作：删除实体、批量删除、根据ID删除、条件删除
  /// 5. 分页查询：支持条件查询、排序、分页
  /// 
  /// 自动处理：
  /// 1. 新增时：
  ///    - 设置创建时间CreatedTime
  ///    - 设置更新时间UpdatedTime
  ///    - 设置创建人CreatedBy（用户名）
  ///    - 设置更新人UpdatedBy（用户名）
  ///    - 设置是否删除IsDeleted（默认false）
  /// 2. 修改时：
  ///    - 设置更新时间UpdatedTime
  ///    - 设置更新人UpdatedBy（用户名）
  /// 3. 删除时：
  ///    - 设置是否删除IsDeleted（设置为true）
  ///    - 设置更新时间UpdatedTime
  ///    - 设置更新人UpdatedBy（用户名）
  /// </remarks>
  /// <typeparam name="TEntity">实体类型，必须继承自KpBaseEntity</typeparam>
  public class KpBaseRepository<TEntity> : IKpBaseRepository<TEntity> where TEntity : KpBaseEntity, new()
  {
    /// <summary>
    /// SqlSugar数据库上下文
    /// </summary>
    protected readonly KpSqlSugarDbContext _dbContext;

    /// <summary>
    /// SqlSugar数据库实例
    /// </summary>
    protected readonly ISqlSugarClient _db;

    /// <summary>
    /// 用户上下文服务
    /// </summary>
    protected readonly IKpUserContext _userContext;

    /// <summary>
    /// AutoMapper实例
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="dbContext">SqlSugar数据库上下文</param>
    /// <param name="userContext">用户上下文服务</param>
    /// <param name="mapper">AutoMapper实例</param>
    public KpBaseRepository(KpSqlSugarDbContext dbContext, IKpUserContext userContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _db = dbContext.Db;
      _userContext = userContext;
      _mapper = mapper;
    }

    #region 查询
    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>实体</returns>
    public async Task<TEntity?> GetByIdAsync(long id)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      return await _db.Queryable<TEntity>().FirstAsync(x => x.Id == id);
    }

    /// <summary>
    /// 获取实体列表
    /// </summary>
    /// <param name="predicate">条件</param>
    /// <returns>实体列表</returns>
    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      var query = _db.Queryable<TEntity>();
      if (predicate != null)
      {
        query = query.Where(predicate);
      }
      return await query.ToListAsync();
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="request">分页请求</param>
    /// <param name="predicate">条件</param>
    /// <returns>分页结果</returns>
    public async Task<(List<TEntity> Items, int Total)> GetPageAsync(KpPageRequest request, Expression<Func<TEntity, bool>>? predicate = null)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      var query = _db.Queryable<TEntity>();

      // 添加条件
      if (predicate != null)
      {
        query = query.Where(predicate);
      }

      // 添加排序
      if (!string.IsNullOrEmpty(request.OrderBy))
      {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, request.OrderBy);
        var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

        query = request.OrderType == "asc"
            ? query.OrderBy(lambda)
            : query.OrderBy(lambda, OrderByType.Desc);
      }

      // 获取总数
      var total = await query.CountAsync();

      // 分页查询
      var items = await query.ToPageListAsync(request.PageNum, request.PageSize);

      return (items, total);
    }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>是否成功</returns>
    public async Task<bool> CreateAsync(TEntity entity)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置创建相关字段
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();
      entity.CreatedTime = now;
      entity.UpdatedTime = now;
      entity.CreatedBy = userName;
      entity.UpdatedBy = userName;
      entity.IsDeleted = 0;

      return await _db.Insertable(entity).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(TEntity entity)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置更新相关字段
      entity.UpdatedTime = DateTime.Now;
      entity.UpdatedBy = _userContext.GetCurrentUserName();

      return await _db.Updateable(entity).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 删除实体
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(TEntity entity)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置删除相关字段
      entity.IsDeleted = 1;
      entity.UpdatedTime = DateTime.Now;
      entity.UpdatedBy = _userContext.GetCurrentUserName();

      return await _db.Updateable(entity).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 获取第一个或默认实体
    /// </summary>
    /// <param name="predicate">条件</param>
    /// <returns>实体</returns>
    public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
      return await _db.Queryable<TEntity>().WhereIF(predicate != null, predicate).FirstAsync();
    }
    #endregion

    #region 扩展方法
    /// <summary>
    /// 检查是否存在重复记录
    /// </summary>
    /// <param name="predicate">条件表达式</param>
    /// <param name="excludeId">排除的ID（用于更新时排除自身）</param>
    /// <returns>是否存在重复记录</returns>
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, long? excludeId = null)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      var query = _db.Queryable<TEntity>().Where(predicate);

      if (excludeId.HasValue)
      {
        query = query.Where(x => x.Id != excludeId.Value);
      }

      return await query.AnyAsync();
    }

    /// <summary>
    /// 分页查询（DTO）
    /// </summary>
    /// <typeparam name="TDto">DTO类型</typeparam>
    /// <param name="request">分页请求</param>
    /// <param name="predicate">条件表达式</param>
    /// <returns>分页结果</returns>
    public async Task<(List<TDto> Items, int Total)> GetPageAsync<TDto>(KpPageRequest request, Expression<Func<TEntity, bool>>? predicate = null)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      var query = _db.Queryable<TEntity>();

      // 添加条件
      if (predicate != null)
      {
        query = query.Where(predicate);
      }

      // 添加排序
      if (!string.IsNullOrEmpty(request.OrderBy))
      {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, request.OrderBy);
        var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

        query = request.OrderType == "asc"
            ? query.OrderBy(lambda)
            : query.OrderBy(lambda, OrderByType.Desc);
      }

      // 获取总数
      var total = await query.CountAsync();

      // 分页查询
      var items = await query.Select<TDto>().ToPageListAsync(request.PageNum, request.PageSize);

      return (items, total);
    }

    /// <summary>
    /// 批量创建实体
    /// </summary>
    /// <param name="entities">实体列表</param>
    /// <returns>是否成功</returns>
    public async Task<bool> CreateRangeAsync(List<TEntity> entities)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置创建相关字段
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();
      foreach (var entity in entities)
      {
        entity.CreatedTime = now;
        entity.UpdatedTime = now;
        entity.CreatedBy = userName;
        entity.UpdatedBy = userName;
        entity.IsDeleted = 0;
      }

      return await _db.Insertable(entities).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 批量更新实体
    /// </summary>
    /// <param name="entities">实体列表</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateRangeAsync(List<TEntity> entities)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置更新相关字段
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();
      foreach (var entity in entities)
      {
        entity.UpdatedTime = now;
        entity.UpdatedBy = userName;
      }

      return await _db.Updateable(entities).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 根据条件更新实体
    /// </summary>
    /// <param name="predicate">条件</param>
    /// <param name="updateExpression">更新表达式</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 获取当前用户信息
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();

      // 创建新的更新表达式，包含自动更新的字段
      var parameter = Expression.Parameter(typeof(TEntity), "x");
      var updatedTimeProperty = Expression.Property(parameter, "UpdatedTime");
      var updatedByProperty = Expression.Property(parameter, "UpdatedBy");
      var updatedTimeAssignment = Expression.Assign(updatedTimeProperty, Expression.Constant(now));
      var updatedByAssignment = Expression.Assign(updatedByProperty, Expression.Constant(userName));

      // 合并更新表达式
      var body = Expression.Block(
          updateExpression.Body,
          updatedTimeAssignment,
          updatedByAssignment
      );

      var newUpdateExpression = Expression.Lambda<Func<TEntity, TEntity>>(body, parameter);

      return await _db.Updateable<TEntity>()
          .SetColumns(newUpdateExpression)
          .Where(predicate)
          .ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 批量删除实体
    /// </summary>
    /// <param name="entities">实体列表</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteRangeAsync(List<TEntity> entities)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 设置删除相关字段
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();
      foreach (var entity in entities)
      {
        entity.IsDeleted = 1;
        entity.UpdatedTime = now;
        entity.UpdatedBy = userName;
      }

      return await _db.Updateable(entities).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 根据ID删除实体
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteByIdAsync(long id)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 获取当前用户信息
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();

      return await _db.Updateable<TEntity>()
          .SetColumns(x => new TEntity
          {
            IsDeleted = 1,
            UpdatedTime = now,
            UpdatedBy = userName
          })
          .Where(x => x.Id == id)
          .ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 根据条件删除实体
    /// </summary>
    /// <param name="predicate">条件</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 获取当前用户信息
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();

      return await _db.Updateable<TEntity>()
          .SetColumns(x => new TEntity
          {
            IsDeleted = 1,
            UpdatedTime = now,
            UpdatedBy = userName
          })
          .Where(predicate)
          .ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 根据ID列表删除实体
    /// </summary>
    /// <param name="ids">ID列表</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteByIdsAsync(List<long> ids)
    {
      if (_db == null)
      {
        throw new KpBusinessException("数据库连接未初始化");
      }

      // 获取当前用户信息
      var now = DateTime.Now;
      var userName = _userContext.GetCurrentUserName();

      return await _db.Updateable<TEntity>()
          .SetColumns(x => new TEntity
          {
            IsDeleted = 1,
            UpdatedTime = now,
            UpdatedBy = userName
          })
          .Where(x => ids.Contains(x.Id))
          .ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 根据ID删除实体
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      return await DeleteByIdAsync(id);
    }
    #endregion
  }
}
