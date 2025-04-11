// -----------------------------------------------------------------------
// <copyright file="IKpLanguageService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>语言服务接口</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 语言服务接口
  /// </summary>
  public interface IKpLanguageService
  {
    /// <summary>
    /// 获取语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    Task<KpPageResult<KpLanguageDto>> GetListAsync(KpLanguageQueryDto query);

    /// <summary>
    /// 获取语言详情
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>语言详情</returns>
    Task<KpLanguageDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>语言ID</returns>
    Task<long> CreateAsync(KpLanguageCreateDto input);

    /// <summary>
    /// 更新语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpLanguageUpdateDto input);

    /// <summary>
    /// 删除语言
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导入语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(KpLanguageImportDto input);

    /// <summary>
    /// 导出语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    Task<List<KpLanguageExportDto>> ExportListAsync(KpLanguageQueryDto query);

    /// <summary>
    /// 获取语言导入模板
    /// </summary>
    /// <returns>语言导入模板</returns>
    Task<KpLanguageTemplateDto> GetTemplateAsync();

    /// <summary>
    /// 修改语言状态
    /// </summary>
    /// <param name="input">语言状态信息</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpLanguageChangeStatusDto input);

    /// <summary>
    /// 设置默认语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    Task<bool> SetDefaultAsync(KpLanguageSetDefaultDto input);
  }
}