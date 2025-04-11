// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>菜单服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 菜单服务接口
  /// </summary>
  public interface IKpMenuService
  {
    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单列表</returns>
    Task<KpPageResult<KpMenuDto>> GetListAsync(KpMenuQueryDto query);

    /// <summary>
    /// 获取菜单详情
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>菜单详情</returns>
    Task<KpMenuDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="dto">创建菜单参数</param>
    /// <returns>菜单ID</returns>
    Task<long> CreateAsync(KpMenuCreateDto dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto">更新菜单参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpMenuUpdateDto dto);

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 根据父ID获取菜单列表
    /// </summary>
    /// <param name="parentId">父菜单ID</param>
    /// <returns>菜单列表</returns>
    Task<List<KpMenuDto>> GetByParentIdAsync(long parentId);

    /// <summary>
    /// 获取菜单树
    /// </summary>
    /// <returns>菜单树</returns>
    Task<List<KpMenuDto>> GetTreeAsync();

    /// <summary>
    /// 导入菜单
    /// </summary>
    /// <param name="dtos">菜单导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpMenuImportDto> dtos);

    /// <summary>
    /// 导出菜单
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单导出数据</returns>
    Task<List<KpMenuExportDto>> ExportAsync(KpMenuQueryDto query);

    /// <summary>
    /// 获取菜单导入模板
    /// </summary>
    /// <returns>菜单导入模板</returns>
    Task<KpMenuTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改菜单状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpMenuChangeStatusDto dto);

    /// <summary>
    /// 修改菜单排序
    /// </summary>
    /// <param name="dto">排序参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeSortAsync(KpMenuSortDto dto);
  }
}