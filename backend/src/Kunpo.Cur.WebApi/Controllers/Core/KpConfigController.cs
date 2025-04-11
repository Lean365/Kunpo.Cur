// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>配置控制器</summary>
// <remarks>处理配置的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 配置控制器
  /// </summary>
  [ApiController]
  [Route("api/core/config")]
  [ApiExplorerSettings(GroupName = "core")]
  public class KpConfigController : KpBaseController
  {
    private readonly IKpConfigService _configService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="configService">配置服务</param>
    public KpConfigController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpConfigService configService) : base(logger, localizationService, securityContext)
    {
      _configService = configService;
    }

    /// <summary>
    /// 获取配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    [HttpGet("list")]
    [KpPermission("core:config:list", "查询配置")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpConfigDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpConfigDto>>>> GetListAsync([FromQuery] KpConfigQueryDto query)
    {
      try
      {
        var result = await _configService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpConfigDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取配置详情
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>配置详情</returns>
    [HttpGet("{id}")]
    [KpPermission("core:config:detail", "查看配置")]
    [ProducesResponseType(typeof(KpApiResult<KpConfigDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpConfigDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _configService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpConfigDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>配置ID</returns>
    [HttpPost]
    [KpPermission("core:config:create", "创建配置")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpConfigCreateDto input)
    {
      try
      {
        var result = await _configService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("core:config:update", "更新配置")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpConfigUpdateDto input)
    {
      try
      {
        var result = await _configService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除配置
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("core:config:delete", "删除配置")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _configService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    [HttpGet("export")]
    [KpPermission("core:config:export", "导出配置")]
    [ProducesResponseType(typeof(KpApiResult<List<KpConfigExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpConfigExportDto>>>> ExportListAsync([FromQuery] KpConfigQueryDto query)
    {
      try
      {
        var result = await _configService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpConfigExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("core:config:import", "导入配置")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] KpConfigImportDto input)
    {
      try
      {
        var result = await _configService.ImportAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 获取配置模板
    /// </summary>
    /// <returns>配置模板</returns>
    [HttpGet("template")]
    [KpPermission("core:config:template", "获取配置模板")]
    [ProducesResponseType(typeof(KpApiResult<KpConfigTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpConfigTemplateDto>>> GetTemplateAsync()
    {
      try
      {
        var result = await _configService.GetTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpConfigTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改配置状态
    /// </summary>
    /// <param name="input">配置状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("core:config:status", "修改配置状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpConfigChangeStatusDto input)
    {
      try
      {
        var result = await _configService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }
  }
}