// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL差异控制器</summary>
// <remarks>处理SQL差异的查询、创建、更新、删除和导出等操作</remarks>
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
  /// SQL差异控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/sql-diff")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpSqlDiffController : KpBaseController
  {
    private readonly IKpSqlDiffService _sqlDiffService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="sqlDiffService">SQL差异服务</param>
    public KpSqlDiffController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpSqlDiffService sqlDiffService) : base(logger, localizationService, securityContext)
    {
      _sqlDiffService = sqlDiffService;
    }

    /// <summary>
    /// 获取SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    [HttpGet("list")]
    [KpPermission("audit:sql-diff:list", "查询SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpSqlDiffDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpSqlDiffDto>>>> GetListAsync([FromQuery] KpSqlDiffQueryDto query)
    {
      try
      {
        var result = await _sqlDiffService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpSqlDiffDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取SQL差异详情
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>SQL差异详情</returns>
    [HttpGet("{id}")]
    [KpPermission("audit:sql-diff:detail", "查看SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<KpSqlDiffDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpSqlDiffDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _sqlDiffService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpSqlDiffDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>SQL差异ID</returns>
    [HttpPost]
    [KpPermission("audit:sql-diff:create", "创建SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpSqlDiffCreateDto input)
    {
      try
      {
        var result = await _sqlDiffService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("audit:sql-diff:update", "更新SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpSqlDiffUpdateDto input)
    {
      try
      {
        var result = await _sqlDiffService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除SQL差异
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("audit:sql-diff:delete", "删除SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _sqlDiffService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    [HttpGet("export")]
    [KpPermission("audit:sql-diff:export", "导出SQL差异")]
    [ProducesResponseType(typeof(KpApiResult<List<KpSqlDiffExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpSqlDiffExportDto>>>> ExportListAsync([FromQuery] KpSqlDiffQueryDto query)
    {
      try
      {
        var result = await _sqlDiffService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpSqlDiffExportDto>>(ex.Message);
      }
    }
  }
}