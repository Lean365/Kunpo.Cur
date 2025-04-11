// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线用户服务接口</summary>
// -----------------------------------------------------------------------
using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kunpo.Cur.Application.Services.SignalR
{
  /// <summary>
  /// 在线用户服务接口
  /// </summary>
  public interface IKpOnlineUserService
  {
    /// <summary>
    /// 获取在线用户
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>在线用户信息</returns>
    Task<KpOnlineUserDto?> GetAsync(long userId);

    /// <summary>
    /// 获取在线用户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>在线用户列表</returns>
    Task<KpPageResult<KpOnlineUserDto>> GetListAsync(KpOnlineUserQueryDto query);

    /// <summary>
    /// 获取所有在线用户
    /// </summary>
    /// <returns>在线用户列表</returns>
    Task<List<KpOnlineUserDto>> GetAllAsync();

    /// <summary>
    /// 创建在线用户
    /// </summary>
    /// <param name="input">在线用户信息</param>
    /// <returns>用户ID</returns>
    Task<long> CreateAsync(KpOnlineUserCreateDto input);

    /// <summary>
    /// 更新在线用户
    /// </summary>
    /// <param name="input">在线用户信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpOnlineUserUpdateDto input);

    /// <summary>
    /// 更新用户最后活动时间
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateLastActivityTimeAsync(long userId);

    /// <summary>
    /// 强制用户下线
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>是否成功</returns>
    Task<bool> ForceLogoutAsync(long userId);

    /// <summary>
    /// 检查用户是否在线
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>是否在线</returns>
    Task<bool> IsOnlineAsync(long userId);

    /// <summary>
    /// 删除在线用户
    /// </summary>
    /// <param name="input">在线用户信息</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(KpOnlineUserDeleteDto input);

    /// <summary>
    /// 导出在线用户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>在线用户列表</returns>
    Task<List<KpOnlineUserExportDto>> ExportListAsync(KpOnlineUserQueryDto query);
  }
}