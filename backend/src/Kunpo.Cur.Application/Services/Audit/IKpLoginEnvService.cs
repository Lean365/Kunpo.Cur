// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录环境服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 登录环境服务接口
  /// </summary>
  public interface IKpLoginEnvService
  {
    /// <summary>
    /// 获取登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    Task<KpPageResult<KpLoginEnvDto>> GetListAsync(KpLoginEnvQueryDto query);

    /// <summary>
    /// 获取登录环境详情
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>登录环境详情</returns>
    Task<KpLoginEnvDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>登录环境ID</returns>
    Task<long> CreateAsync(KpLoginEnvCreateDto input);

    /// <summary>
    /// 更新登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpLoginEnvUpdateDto input);

    /// <summary>
    /// 删除登录环境
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    Task<List<KpLoginEnvExportDto>> ExportListAsync(KpLoginEnvQueryDto query);
  }
}