// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户控制器</summary>
// <remarks>处理租户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Application.Services.Identity;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.WebApi.Controllers.Identity
{
  /// <summary>
  /// 租户控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/tenant")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpTenantController : KpBaseController
  {
    private readonly IKpTenantService _tenantService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="tenantService">租户服务</param>
    public KpTenantController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpTenantService tenantService) : base(logger, localizationService, securityContext)
    {
      _tenantService = tenantService;
    }

    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:tenant:list", "查询租户")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpTenantDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpTenantDto>>>> GetListAsync([FromQuery] KpTenantQueryDto query)
    {
      try
      {
        var result = await _tenantService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpTenantDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取租户详情
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>租户详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:tenant:detail", "查看租户")]
    [ProducesResponseType(typeof(KpApiResult<KpTenantDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpTenantDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _tenantService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpTenantDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="input">租户信息</param>
    /// <returns>租户ID</returns>
    [HttpPost]
    [KpPermission("identity:tenant:create", "创建租户")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpTenantCreateDto input)
    {
      try
      {
        var result = await _tenantService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="input">租户信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:tenant:update", "更新租户")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpTenantUpdateDto input)
    {
      try
      {
        var result = await _tenantService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:tenant:delete", "删除租户")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _tenantService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改租户状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:tenant:status", "修改租户状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpTenantChangeStatusDto input)
    {
      try
      {
        var result = await _tenantService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导入租户
    /// </summary>
    /// <param name="tenants">租户导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:tenant:import", "导入租户")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpTenantImportDto> tenants)
    {
      try
      {
        var result = await _tenantService.ImportAsync(tenants);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出租户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:tenant:export", "导出租户")]
    [ProducesResponseType(typeof(KpApiResult<List<KpTenantExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpTenantExportDto>>>> ExportAsync([FromQuery] KpTenantQueryDto query)
    {
      try
      {
        var result = await _tenantService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpTenantExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取租户导入模板
    /// </summary>
    /// <returns>租户导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:tenant:template", "获取租户导入模板")]
    [ProducesResponseType(typeof(KpApiResult<KpTenantTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpTenantTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _tenantService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpTenantTemplateDto>(ex.Message);
      }
    }
  }
}