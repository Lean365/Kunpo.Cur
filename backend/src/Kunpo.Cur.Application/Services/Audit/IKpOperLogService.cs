// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>操作日志服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 操作日志服务接口
  /// </summary>
  public interface IKpOperLogService
  {
    /// <summary>
    /// 获取操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    Task<KpPageResult<KpOperLogDto>> GetListAsync(KpOperLogQueryDto query);

    /// <summary>
    /// 获取操作日志详情
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>操作日志详情</returns>
    Task<KpOperLogDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>操作日志ID</returns>
    Task<long> CreateAsync(KpOperLogCreateDto input);

    /// <summary>
    /// 更新操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpOperLogUpdateDto input);

    /// <summary>
    /// 删除操作日志
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    Task<List<KpOperLogExportDto>> ExportListAsync(KpOperLogQueryDto query);
  }
}