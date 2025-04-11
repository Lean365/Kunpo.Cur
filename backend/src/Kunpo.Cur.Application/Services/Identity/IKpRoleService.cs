// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 角色服务接口
  /// </summary>
  public interface IKpRoleService
  {
    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色列表</returns>
    Task<KpPageResult<KpRoleDto>> GetListAsync(KpRoleQueryDto query);

    /// <summary>
    /// 获取角色详情
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>角色详情</returns>
    Task<KpRoleDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="dto">创建角色参数</param>
    /// <returns>角色ID</returns>
    Task<long> CreateAsync(KpRoleCreateDto dto);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto">更新角色参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpRoleUpdateDto dto);

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导入角色
    /// </summary>
    /// <param name="dtos">角色导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpRoleImportDto> dtos);

    /// <summary>
    /// 导出角色
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色导出数据</returns>
    Task<List<KpRoleExportDto>> ExportAsync(KpRoleQueryDto query);

    /// <summary>
    /// 获取角色导入模板
    /// </summary>
    /// <returns>角色导入模板</returns>
    Task<KpRoleTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改角色状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpRoleChangeStatusDto dto);

    /// <summary>
    /// 分配角色菜单
    /// </summary>
    /// <param name="dto">角色菜单数据传输对象</param>
    /// <returns>是否成功</returns>
    Task<bool> AssignMenuAsync(KpRoleMenuDto dto);

    /// <summary>
    /// 获取角色菜单
    /// </summary>
    /// <param name="roleId">角色ID</param>
    /// <returns>菜单ID列表</returns>
    Task<List<long>> GetRoleMenuAsync(long roleId);
  }
}