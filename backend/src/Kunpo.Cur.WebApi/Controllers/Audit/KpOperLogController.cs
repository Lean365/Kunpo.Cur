// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>操作日志控制器</summary>
// <remarks>处理操作日志的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 操作日志控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/oper")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpOperLogController : KpBaseController
  {
    private readonly IKpOperLogService _operLogService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="operLogService">操作日志服务</param>
    public KpOperLogController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpOperLogService operLogService) : base(logger, localizationService, securityContext)
    {
      _operLogService = operLogService;
    }

    /// <summary>
    /// 获取操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    [HttpGet("list")]
    [KpPermission("audit:oper:list", "查询操作日志")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpOperLogDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpOperLogDto>>>> GetListAsync([FromQuery] KpOperLogQueryDto query)
    {
      try
      {
        var result = await _operLogService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpOperLogDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取操作日志详情
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>操作日志详情</returns>
    [HttpGet("{id}")]
    [KpPermission("audit:oper:detail", "查看操作日志")]
    [ProducesResponseType(typeof(KpApiResult<KpOperLogDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpOperLogDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _operLogService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpOperLogDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>操作日志ID</returns>
    [HttpPost]
    [KpPermission("audit:oper:create", "创建操作日志")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpOperLogCreateDto input)
    {
      try
      {
        var result = await _operLogService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("audit:oper:update", "更新操作日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpOperLogUpdateDto input)
    {
      try
      {
        var result = await _operLogService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除操作日志
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("audit:oper:delete", "删除操作日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _operLogService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    [HttpGet("export")]
    [KpPermission("audit:oper:export", "导出操作日志")]
    [ProducesResponseType(typeof(KpApiResult<List<KpOperLogExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpOperLogExportDto>>>> ExportListAsync([FromQuery] KpOperLogQueryDto query)
    {
      try
      {
        var result = await _operLogService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpOperLogExportDto>>(ex.Message);
      }
    }
  }
}