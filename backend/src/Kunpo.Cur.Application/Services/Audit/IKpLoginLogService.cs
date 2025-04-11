// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录日志服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 登录日志服务接口
  /// </summary>
  public interface IKpLoginLogService
  {
    /// <summary>
    /// 获取登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    Task<KpPageResult<KpLoginLogDto>> GetListAsync(KpLoginLogQueryDto query);

    /// <summary>
    /// 获取登录日志详情
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>登录日志详情</returns>
    Task<KpLoginLogDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>登录日志ID</returns>
    Task<long> CreateAsync(KpLoginLogCreateDto input);

    /// <summary>
    /// 更新登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpLoginLogUpdateDto input);

    /// <summary>
    /// 删除登录日志
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    Task<List<KpLoginLogExportDto>> ExportListAsync(KpLoginLogQueryDto query);
  }
}