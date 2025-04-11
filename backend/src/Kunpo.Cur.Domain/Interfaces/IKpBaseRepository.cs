// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>仓储基类接口</summary>
// <remarks>处理仓储基类的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System.Linq.Expressions;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Entities;

namespace Kunpo.Cur.Domain.Interfaces
{
  /// <summary>
  /// 仓储基类接口
  /// </summary>
  /// <typeparam name="TEntity">实体类型</typeparam>
  public interface IKpBaseRepository<TEntity> where TEntity : KpBaseEntity
  {
    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>实体</returns>
    Task<TEntity?> GetByIdAsync(long id);

    /// <summary>
    /// 获取实体列表
    /// </summary>
    /// <param name="predicate">查询条件</param>
    /// <returns>实体列表</returns>
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null);

    /// <summary>
    /// 分页获取实体列表
    /// </summary>
    /// <typeparam name="TDto">DTO类型</typeparam>
    /// <param name="request">分页请求</param>
    /// <param name="predicate">查询条件</param>
    /// <returns>分页结果</returns>
    Task<(List<TDto> Items, int Total)> GetPageAsync<TDto>(KpPageRequest request, Expression<Func<TEntity, bool>>? predicate = null);

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>是否成功</returns>
    Task<bool> CreateAsync(TEntity entity);

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(TEntity entity);

    /// <summary>
    /// 删除实体
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 批量删除实体
    /// </summary>
    /// <param name="ids">实体ID列表</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteByIdsAsync(List<long> ids);

    /// <summary>
    /// 根据条件获取第一个实体
    /// </summary>
    /// <param name="predicate">查询条件</param>
    /// <returns>实体</returns>
    Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null);

    /// <summary>
    /// 检查是否存在重复记录
    /// </summary>
    /// <param name="predicate">条件表达式</param>
    /// <param name="excludeId">排除的ID（用于更新时排除自身）</param>
    /// <returns>是否存在重复记录</returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, long? excludeId = null);
  }
}