// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录设备服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 登录设备服务接口
  /// </summary>
  public interface IKpLoginDevService
  {
    /// <summary>
    /// 获取登录设备列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录设备列表</returns>
    Task<KpPageResult<KpLoginDevDto>> GetListAsync(KpLoginDeviceQueryDto query);

    /// <summary>
    /// 获取登录设备详情
    /// </summary>
    /// <param name="id">登录设备ID</param>
    /// <returns>登录设备详情</returns>
    Task<KpLoginDevDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建登录设备
    /// </summary>
    /// <param name="input">登录设备信息</param>
    /// <returns>登录设备ID</returns>
    Task<long> CreateAsync(KpLoginDeviceCreateDto input);

    /// <summary>
    /// 更新登录设备
    /// </summary>
    /// <param name="input">登录设备信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpLoginDeviceUpdateDto input);

    /// <summary>
    /// 删除登录设备
    /// </summary>
    /// <param name="id">登录设备ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出登录设备列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录设备列表</returns>
    Task<List<KpLoginDeviceExportDto>> ExportListAsync(KpLoginDeviceQueryDto query);
  }
}