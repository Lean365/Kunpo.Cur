// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>错误日志控制器</summary>
// <remarks>处理错误日志的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 错误日志控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/error")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpErrorLogController : KpBaseController
  {
    private readonly IKpErrorLogService _errorLogService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="errorLogService">错误日志服务</param>
    public KpErrorLogController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpErrorLogService errorLogService) : base(logger, localizationService, securityContext)
    {
      _errorLogService = errorLogService;
    }

    /// <summary>
    /// 获取错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    [HttpGet("list")]
    [KpPermission("audit:error:list", "查询错误日志")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpErrorLogDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpErrorLogDto>>>> GetListAsync([FromQuery] KpErrorLogQueryDto query)
    {
      try
      {
        var result = await _errorLogService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpErrorLogDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取错误日志详情
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>错误日志详情</returns>
    [HttpGet("{id}")]
    [KpPermission("audit:error:detail", "查看错误日志")]
    [ProducesResponseType(typeof(KpApiResult<KpErrorLogDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpErrorLogDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _errorLogService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpErrorLogDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>错误日志ID</returns>
    [HttpPost]
    [KpPermission("audit:error:create", "创建错误日志")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpErrorLogCreateDto input)
    {
      try
      {
        var result = await _errorLogService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("audit:error:update", "更新错误日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpErrorLogUpdateDto input)
    {
      try
      {
        var result = await _errorLogService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除错误日志
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("audit:error:delete", "删除错误日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _errorLogService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    [HttpGet("export")]
    [KpPermission("audit:error:export", "导出错误日志")]
    [ProducesResponseType(typeof(KpApiResult<List<KpErrorLogExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpErrorLogExportDto>>>> ExportListAsync([FromQuery] KpErrorLogQueryDto query)
    {
      try
      {
        var result = await _errorLogService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpErrorLogExportDto>>(ex.Message);
      }
    }
  }
}