// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典类型服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 字典类型服务接口
  /// </summary>
  public interface IKpDictTypeService
  {
    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    Task<KpPageResult<KpDictTypeDto>> GetListAsync(KpDictTypeQueryDto query);

    /// <summary>
    /// 获取字典类型详情
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>字典类型详情</returns>
    Task<KpDictTypeDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>字典类型ID</returns>
    Task<long> CreateAsync(KpDictTypeCreateDto input);

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpDictTypeUpdateDto input);

    /// <summary>
    /// 导入字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(KpDictTypeImportDto input);

    /// <summary>
    /// 获取字典类型导入模板
    /// </summary>
    /// <returns>字典类型导入模板</returns>
    Task<KpDictTypeTemplateDto> GetTemplateAsync();

    /// <summary>
    /// 导出字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    Task<List<KpDictTypeExportDto>> ExportListAsync(KpDictTypeQueryDto query);

    /// <summary>
    /// 修改字典类型状态
    /// </summary>
    /// <param name="input">字典类型状态信息</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpDictTypeChangeStatusDto input);

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);
  }
}