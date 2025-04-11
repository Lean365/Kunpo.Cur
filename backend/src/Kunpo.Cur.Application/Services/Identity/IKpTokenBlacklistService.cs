// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>令牌黑名单服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 令牌黑名单服务接口
  /// </summary>
  public interface IKpTokenBlacklistService
  {
    /// <summary>
    /// 获取令牌黑名单列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>令牌黑名单列表</returns>
    Task<KpPageResult<KpTokenBlacklistDto>> GetListAsync(KpTokenBlacklistQueryDto query);

    /// <summary>
    /// 获取令牌黑名单详情
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>令牌黑名单详情</returns>
    Task<KpTokenBlacklistDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建令牌黑名单
    /// </summary>
    /// <param name="dto">创建数据传输对象</param>
    /// <returns>主键ID</returns>
    Task<long> CreateAsync(KpTokenBlacklistCreateDto dto);

    /// <summary>
    /// 删除令牌黑名单
    /// </summary>
    /// <param name="dto">删除数据传输对象</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(KpTokenBlacklistDeleteDto dto);

    /// <summary>
    /// 导出令牌黑名单
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>导出数据</returns>
    Task<List<KpTokenBlacklistExportDto>> ExportAsync(KpTokenBlacklistQueryDto query);

    /// <summary>
    /// 检查令牌是否在黑名单中
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否在黑名单中</returns>
    Task<bool> IsTokenBlacklistedAsync(string token);

    /// <summary>
    /// 清理过期的黑名单记录
    /// </summary>
    /// <returns>是否成功</returns>
    Task<bool> CleanExpiredAsync();
  }
}