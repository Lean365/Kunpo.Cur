// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>翻译服务接口</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 翻译服务接口
  /// </summary>
  public interface IKpTranslateService
  {
    /// <summary>
    /// 获取翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    Task<KpPageResult<KpTranslateDto>> GetListAsync(KpTranslateQueryDto query);

    /// <summary>
    /// 获取翻译详情
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>翻译详情</returns>
    Task<KpTranslateDto> GetByIdAsync(long id);

    /// <summary>
    /// 创建翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>翻译ID</returns>
    Task<long> CreateAsync(KpTranslateCreateDto input);

    /// <summary>
    /// 更新翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpTranslateUpdateDto input);

    /// <summary>
    /// 删除翻译
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 导入翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(KpTranslateImportDto input);

    /// <summary>
    /// 导出翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    Task<List<KpTranslateExportDto>> ExportListAsync(KpTranslateQueryDto query);

    /// <summary>
    /// 获取翻译导入模板
    /// </summary>
    /// <returns>翻译导入模板</returns>
    Task<KpTranslateTemplateDto> GetTemplateAsync();

    /// <summary>
    /// 修改翻译状态
    /// </summary>
    /// <param name="input">翻译状态信息</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpTranslateChangeStatusDto input);

    /// <summary>
    /// 转置翻译数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的翻译数据</returns>
    Task<List<KpTranslateTransposeDto>> TransposeAsync(KpTranslateQueryDto query);
  }
}