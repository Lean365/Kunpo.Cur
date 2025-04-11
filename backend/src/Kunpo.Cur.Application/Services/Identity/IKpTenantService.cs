// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 租户服务接口
  /// </summary>
  public interface IKpTenantService
  {
    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户列表</returns>
    Task<KpPageResult<KpTenantDto>> GetListAsync(KpTenantQueryDto query);

    /// <summary>
    /// 获取租户详情
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>租户详情</returns>
    Task<KpTenantDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="dto">创建租户参数</param>
    /// <returns>租户ID</returns>
    Task<long> CreateAsync(KpTenantCreateDto dto);

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto">更新租户参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpTenantUpdateDto dto);

    /// <summary>
    /// 导入租户
    /// </summary>
    /// <param name="dtos">租户导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpTenantImportDto> dtos);

    /// <summary>
    /// 导出租户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户导出数据</returns>
    Task<List<KpTenantExportDto>> ExportAsync(KpTenantQueryDto query);

    /// <summary>
    /// 获取租户导入模板
    /// </summary>
    /// <returns>租户导入模板</returns>
    Task<KpTenantTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改租户状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpTenantChangeStatusDto dto);

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);
  }
}