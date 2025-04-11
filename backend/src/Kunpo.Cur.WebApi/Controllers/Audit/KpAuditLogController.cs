// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>审计日志控制器</summary>
// <remarks>处理审计日志的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Application.Services.Audit;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.WebApi.Controllers.Audit
{
  /// <summary>
  /// 审计日志控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/log")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpAuditLogController : KpBaseController
  {
    private readonly IKpAuditLogService _auditLogService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="auditLogService">审计日志服务</param>
    public KpAuditLogController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpAuditLogService auditLogService) : base(logger, localizationService, securityContext)
    {
      _auditLogService = auditLogService;
    }

    /// <summary>
    /// 获取审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    [HttpGet("list")]
    [KpPermission("audit:log:list", "查询审计日志")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpAuditLogDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpAuditLogDto>>>> GetListAsync([FromQuery] KpAuditLogQueryDto query)
    {
      try
      {
        var result = await _auditLogService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpAuditLogDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取审计日志详情
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>审计日志详情</returns>
    [HttpGet("{id}")]
    [KpPermission("audit:log:detail", "查看审计日志")]
    [ProducesResponseType(typeof(KpApiResult<KpAuditLogDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpAuditLogDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _auditLogService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpAuditLogDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>审计日志ID</returns>
    [HttpPost]
    [KpPermission("audit:log:create", "创建审计日志")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpAuditLogCreateDto input)
    {
      try
      {
        var result = await _auditLogService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("audit:log:update", "更新审计日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpAuditLogUpdateDto input)
    {
      try
      {
        var result = await _auditLogService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除审计日志
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("audit:log:delete", "删除审计日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _auditLogService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    [HttpGet("export")]
    [KpPermission("audit:log:export", "导出审计日志")]
    [ProducesResponseType(typeof(KpApiResult<List<KpAuditLogExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpAuditLogExportDto>>>> ExportListAsync([FromQuery] KpAuditLogQueryDto query)
    {
      try
      {
        var result = await _auditLogService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpAuditLogExportDto>>(ex.Message);
      }
    }
  }
}