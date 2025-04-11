// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>撤销日志控制器</summary>
// <remarks>处理撤销日志的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 撤销日志控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/revoke")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpRevokeLogController : KpBaseController
  {
    private readonly IKpRevokeLogService _revokeLogService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="revokeLogService">撤销日志服务</param>
    public KpRevokeLogController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpRevokeLogService revokeLogService) : base(logger, localizationService, securityContext)
    {
      _revokeLogService = revokeLogService;
    }

    /// <summary>
    /// 获取撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    [HttpGet("list")]
    [KpPermission("audit:revoke:list", "查询撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpRevokeLogDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpRevokeLogDto>>>> GetListAsync([FromQuery] KpRevokeLogQueryDto query)
    {
      try
      {
        var result = await _revokeLogService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpRevokeLogDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取撤销日志详情
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>撤销日志详情</returns>
    [HttpGet("{id}")]
    [KpPermission("audit:revoke:detail", "查看撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<KpRevokeLogDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpRevokeLogDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _revokeLogService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpRevokeLogDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>撤销日志ID</returns>
    [HttpPost]
    [KpPermission("audit:revoke:create", "创建撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpRevokeLogCreateDto input)
    {
      try
      {
        var result = await _revokeLogService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("audit:revoke:update", "更新撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpRevokeLogUpdateDto input)
    {
      try
      {
        var result = await _revokeLogService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除撤销日志
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("audit:revoke:delete", "删除撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _revokeLogService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    [HttpGet("export")]
    [KpPermission("audit:revoke:export", "导出撤销日志")]
    [ProducesResponseType(typeof(KpApiResult<List<KpRevokeLogExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpRevokeLogExportDto>>>> ExportListAsync([FromQuery] KpRevokeLogQueryDto query)
    {
      try
      {
        var result = await _revokeLogService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpRevokeLogExportDto>>(ex.Message);
      }
    }
  }
}