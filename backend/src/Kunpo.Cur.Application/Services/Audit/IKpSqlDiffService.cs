// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL差异服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// SQL差异服务接口
  /// </summary>
  public interface IKpSqlDiffService
  {
    /// <summary>
    /// 获取SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    Task<KpPageResult<KpSqlDiffDto>> GetListAsync(KpSqlDiffQueryDto query);

    /// <summary>
    /// 获取SQL差异详情
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>SQL差异详情</returns>
    Task<KpSqlDiffDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>SQL差异ID</returns>
    Task<long> CreateAsync(KpSqlDiffCreateDto input);

    /// <summary>
    /// 更新SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpSqlDiffUpdateDto input);

    /// <summary>
    /// 删除SQL差异
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    Task<List<KpSqlDiffExportDto>> ExportListAsync(KpSqlDiffQueryDto query);
  }
}