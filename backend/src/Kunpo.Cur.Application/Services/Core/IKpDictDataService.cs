// -----------------------------------------------------------------------
// <copyright file="IKpDictDataService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>字典数据服务接口</summary>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 字典数据服务接口
  /// </summary>
  public interface IKpDictDataService
  {
    /// <summary>
    /// 获取字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    Task<KpPageResult<KpDictDataDto>> GetListAsync(KpDictDataQueryDto query);

    /// <summary>
    /// 获取字典数据详情
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>字典数据详情</returns>
    Task<KpDictDataDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>字典数据ID</returns>
    Task<long> CreateAsync(KpDictDataCreateDto input);

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpDictDataUpdateDto input);

    /// <summary>
    /// 导入字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(KpDictDataImportDto input);

    /// <summary>
    /// 获取字典数据导入模板
    /// </summary>
    /// <returns>字典数据导入模板</returns>
    Task<KpDictDataTemplateDto> GetTemplateAsync();

    /// <summary>
    /// 导出字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    Task<List<KpDictDataExportDto>> ExportListAsync(KpDictDataQueryDto query);

    /// <summary>
    /// 修改字典数据状态
    /// </summary>
    /// <param name="input">字典数据状态信息</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpDictDataChangeStatusDto input);

    /// <summary>
    /// 转置字典数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的字典数据</returns>
    Task<List<KpDictDataTransposeDto>> TransposeAsync(KpDictDataQueryDto query);

    /// <summary>
    /// 删除字典数据
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);
  }
}