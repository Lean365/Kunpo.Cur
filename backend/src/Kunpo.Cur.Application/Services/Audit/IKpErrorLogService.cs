// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>错误日志服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 错误日志服务接口
  /// </summary>
  public interface IKpErrorLogService
  {
    /// <summary>
    /// 获取错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    Task<KpPageResult<KpErrorLogDto>> GetListAsync(KpErrorLogQueryDto query);

    /// <summary>
    /// 获取错误日志详情
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>错误日志详情</returns>
    Task<KpErrorLogDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>错误日志ID</returns>
    Task<long> CreateAsync(KpErrorLogCreateDto input);

    /// <summary>
    /// 更新错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpErrorLogUpdateDto input);

    /// <summary>
    /// 删除错误日志
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    Task<List<KpErrorLogExportDto>> ExportListAsync(KpErrorLogQueryDto query);
  }
}