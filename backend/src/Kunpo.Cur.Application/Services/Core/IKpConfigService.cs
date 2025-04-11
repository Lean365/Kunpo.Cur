// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>配置服务接口</summary>
// -----------------------------------------------------------------------


using System.Threading.Tasks;
using System.Collections.Generic;
using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 配置服务接口
  /// </summary>
  public interface IKpConfigService
  {
    /// <summary>
    /// 获取配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    Task<KpPageResult<KpConfigDto>> GetListAsync(KpConfigQueryDto query);

    /// <summary>
    /// 获取配置详情
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>配置详情</returns>
    Task<KpConfigDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>配置ID</returns>
    Task<long> CreateAsync(KpConfigCreateDto input);

    /// <summary>
    /// 更新配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpConfigUpdateDto input);

    /// <summary>
    /// 删除配置
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导出配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    Task<List<KpConfigExportDto>> ExportListAsync(KpConfigQueryDto query);

    /// <summary>
    /// 导入配置数据
    /// </summary>
    /// <param name="input">导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(KpConfigImportDto input);

    /// <summary>
    /// 获取配置模板
    /// </summary>
    /// <returns>配置模板</returns>
    Task<KpConfigTemplateDto> GetTemplateAsync();

    /// <summary>
    /// 更改配置状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpConfigChangeStatusDto input);
  }
}