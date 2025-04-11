// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>部门服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 部门服务接口
  /// </summary>
  public interface IKpDeptService
  {
    /// <summary>
    /// 获取部门列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门列表</returns>
    Task<KpPageResult<KpDeptDto>> GetListAsync(KpDeptQueryDto query);

    /// <summary>
    /// 获取部门详情
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>部门详情</returns>
    Task<KpDeptDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建部门
    /// </summary>
    /// <param name="dto">创建部门参数</param>
    /// <returns>部门ID</returns>
    Task<long> CreateAsync(KpDeptCreateDto dto);

    /// <summary>
    /// 更新部门
    /// </summary>
    /// <param name="dto">更新部门参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpDeptUpdateDto dto);

    /// <summary>
    /// 删除部门
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 根据父ID获取部门列表
    /// </summary>
    /// <param name="parentId">父部门ID</param>
    /// <returns>部门列表</returns>
    Task<List<KpDeptDto>> GetByParentIdAsync(long parentId);

    /// <summary>
    /// 获取部门树
    /// </summary>
    /// <returns>部门树</returns>
    Task<List<KpDeptDto>> GetTreeAsync();

    /// <summary>
    /// 导入部门
    /// </summary>
    /// <param name="dtos">部门导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpDeptImportDto> dtos);

    /// <summary>
    /// 导出部门
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门导出数据</returns>
    Task<List<KpDeptExportDto>> ExportAsync(KpDeptQueryDto query);

    /// <summary>
    /// 获取部门导入模板
    /// </summary>
    /// <returns>部门导入模板</returns>
    Task<KpDeptTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改部门状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpDeptChangeStatusDto dto);
  }
}