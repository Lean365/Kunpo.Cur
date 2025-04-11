// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>岗位服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 岗位服务接口
  /// </summary>
  public interface IKpPostService
  {
    /// <summary>
    /// 获取岗位列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位列表</returns>
    Task<KpPageResult<KpPostDto>> GetListAsync(KpPostQueryDto query);

    /// <summary>
    /// 获取岗位详情
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>岗位详情</returns>
    Task<KpPostDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建岗位
    /// </summary>
    /// <param name="dto">创建岗位参数</param>
    /// <returns>岗位ID</returns>
    Task<long> CreateAsync(KpPostCreateDto dto);

    /// <summary>
    /// 更新岗位
    /// </summary>
    /// <param name="dto">更新岗位参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpPostUpdateDto dto);

    /// <summary>
    /// 删除岗位
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导入岗位
    /// </summary>
    /// <param name="dtos">岗位导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpPostImportDto> dtos);

    /// <summary>
    /// 导出岗位
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位导出数据</returns>
    Task<List<KpPostExportDto>> ExportAsync(KpPostQueryDto query);

    /// <summary>
    /// 获取岗位导入模板
    /// </summary>
    /// <returns>岗位导入模板</returns>
    Task<KpPostTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改岗位状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpPostChangeStatusDto dto);
  }
}