// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>审计日志服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 审计日志服务接口
  /// </summary>
  public interface IKpAuditLogService
  {
    /// <summary>
    /// 获取审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    Task<KpPageResult<KpAuditLogDto>> GetListAsync(KpAuditLogQueryDto query);

    /// <summary>
    /// 获取审计日志详情
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>审计日志详情</returns>
    Task<KpAuditLogDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>审计日志ID</returns>
    Task<long> CreateAsync(KpAuditLogCreateDto input);

    /// <summary>
    /// 更新审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpAuditLogUpdateDto input);

    /// <summary>
    /// 删除审计日志
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    Task<List<KpAuditLogExportDto>> ExportListAsync(KpAuditLogQueryDto query);
  }
}