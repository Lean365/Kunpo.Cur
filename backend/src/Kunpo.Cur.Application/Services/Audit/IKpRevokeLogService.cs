// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>撤销日志服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 撤销日志服务接口
  /// </summary>
  public interface IKpRevokeLogService
  {
    /// <summary>
    /// 获取撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    Task<KpPageResult<KpRevokeLogDto>> GetListAsync(KpRevokeLogQueryDto query);

    /// <summary>
    /// 获取撤销日志详情
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>撤销日志详情</returns>
    Task<KpRevokeLogDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>撤销日志ID</returns>
    Task<long> CreateAsync(KpRevokeLogCreateDto input);

    /// <summary>
    /// 更新撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpRevokeLogUpdateDto input);

    /// <summary>
    /// 删除撤销日志
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    Task<List<KpRevokeLogExportDto>> ExportListAsync(KpRevokeLogQueryDto query);
  }
}