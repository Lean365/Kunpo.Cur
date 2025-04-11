// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>翻译控制器</summary>
// <remarks>处理翻译的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Application.Services.Core;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.WebApi.Controllers.Core
{
  /// <summary>
  /// 翻译控制器
  /// </summary>
  [ApiController]
  [Route("api/core/translate")]
  [ApiExplorerSettings(GroupName = "core")]
  public class KpTranslateController : KpBaseController
  {
    private readonly IKpLanguageService _languageService;
    private readonly IKpTranslateService _translateService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="languageService">语言服务</param>
    /// <param name="translateService">翻译服务</param>
    public KpTranslateController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpLanguageService languageService,
      IKpTranslateService translateService) : base(logger, localizationService, securityContext)
    {
      _languageService = languageService;
      _translateService = translateService;
    }

    #region 语言

    /// <summary>
    /// 获取语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    [HttpGet("language/list")]
    [KpPermission("core:translate:language:list", "查询语言")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpLanguageDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpLanguageDto>>>> GetLanguageListAsync([FromQuery] KpLanguageQueryDto query)
    {
      try
      {
        var result = await _languageService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpLanguageDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取语言详情
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>语言详情</returns>
    [HttpGet("language/{id}")]
    [KpPermission("core:translate:language:detail", "查看语言")]
    [ProducesResponseType(typeof(KpApiResult<KpLanguageDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpLanguageDto>>> GetLanguageByIdAsync(long id)
    {
      try
      {
        var result = await _languageService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpLanguageDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>语言ID</returns>
    [HttpPost("language")]
    [KpPermission("core:translate:language:create", "创建语言")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateLanguageAsync([FromBody] KpLanguageCreateDto input)
    {
      try
      {
        var result = await _languageService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("language")]
    [KpPermission("core:translate:language:update", "更新语言")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateLanguageAsync([FromBody] KpLanguageUpdateDto input)
    {
      try
      {
        var result = await _languageService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除语言
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("language/{id}")]
    [KpPermission("core:translate:language:delete", "删除语言")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteLanguageAsync(long id)
    {
      try
      {
        var result = await _languageService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    [HttpGet("language/export")]
    [KpPermission("core:translate:language:export", "导出语言")]
    [ProducesResponseType(typeof(KpApiResult<List<KpLanguageExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpLanguageExportDto>>>> ExportLanguageListAsync([FromQuery] KpLanguageQueryDto query)
    {
      try
      {
        var result = await _languageService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpLanguageExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>导入结果</returns>
    [HttpPost("language/import")]
    [KpPermission("core:translate:language:import", "导入语言")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportLanguageAsync([FromBody] KpLanguageImportDto input)
    {
      try
      {
        var result = await _languageService.ImportAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 获取语言模板
    /// </summary>
    /// <returns>语言模板</returns>
    [HttpGet("language/template")]
    [KpPermission("core:translate:language:template", "获取语言模板")]
    [ProducesResponseType(typeof(KpApiResult<KpLanguageTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpLanguageTemplateDto>>> GetLanguageTemplateAsync()
    {
      try
      {
        var result = await _languageService.GetTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpLanguageTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改语言状态
    /// </summary>
    /// <param name="input">语言状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("language/status")]
    [KpPermission("core:translate:language:status", "修改语言状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeLanguageStatusAsync([FromBody] KpLanguageChangeStatusDto input)
    {
      try
      {
        var result = await _languageService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 设置默认语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("language/default")]
    [KpPermission("core:translate:language:default", "设置默认语言")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> SetLanguageDefaultAsync([FromBody] KpLanguageSetDefaultDto input)
    {
      try
      {
        var result = await _languageService.SetDefaultAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    #endregion

    #region 翻译

    /// <summary>
    /// 获取翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    [HttpGet("list")]
    [KpPermission("core:translate:list", "查询翻译")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpTranslateDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpTranslateDto>>>> GetListAsync([FromQuery] KpTranslateQueryDto query)
    {
      try
      {
        var result = await _translateService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpTranslateDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取翻译详情
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>翻译详情</returns>
    [HttpGet("{id}")]
    [KpPermission("core:translate:detail", "查看翻译")]
    [ProducesResponseType(typeof(KpApiResult<KpTranslateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpTranslateDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _translateService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpTranslateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>翻译ID</returns>
    [HttpPost]
    [KpPermission("core:translate:create", "创建翻译")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpTranslateCreateDto input)
    {
      try
      {
        var result = await _translateService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("core:translate:update", "更新翻译")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpTranslateUpdateDto input)
    {
      try
      {
        var result = await _translateService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除翻译
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("core:translate:delete", "删除翻译")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _translateService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    [HttpGet("export")]
    [KpPermission("core:translate:export", "导出翻译")]
    [ProducesResponseType(typeof(KpApiResult<List<KpTranslateExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpTranslateExportDto>>>> ExportListAsync([FromQuery] KpTranslateQueryDto query)
    {
      try
      {
        var result = await _translateService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpTranslateExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("core:translate:import", "导入翻译")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] KpTranslateImportDto input)
    {
      try
      {
        var result = await _translateService.ImportAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 获取翻译模板
    /// </summary>
    /// <returns>翻译模板</returns>
    [HttpGet("template")]
    [KpPermission("core:translate:template", "获取翻译模板")]
    [ProducesResponseType(typeof(KpApiResult<KpTranslateTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpTranslateTemplateDto>>> GetTemplateAsync()
    {
      try
      {
        var result = await _translateService.GetTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpTranslateTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改翻译状态
    /// </summary>
    /// <param name="input">翻译状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("core:translate:status", "修改翻译状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpTranslateChangeStatusDto input)
    {
      try
      {
        var result = await _translateService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 转置翻译数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的翻译数据</returns>
    [HttpGet("transpose")]
    [KpPermission("core:translate:transpose", "转置翻译数据")]
    [ProducesResponseType(typeof(KpApiResult<List<KpTranslateTransposeDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpTranslateTransposeDto>>>> TransposeAsync([FromQuery] KpTranslateQueryDto query)
    {
      try
      {
        var result = await _translateService.TransposeAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpTranslateTransposeDto>>(ex.Message);
      }
    }

    #endregion
  }
}