// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>部门控制器</summary>
// <remarks>处理部门的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 部门控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/dept")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpDeptController : KpBaseController
  {
    private readonly IKpDeptService _deptService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="deptService">部门服务</param>
    public KpDeptController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpDeptService deptService) : base(logger, localizationService, securityContext)
    {
      _deptService = deptService;
    }

    /// <summary>
    /// 获取部门列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:dept:list", "查询部门")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpDeptDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpDeptDto>>>> GetListAsync([FromQuery] KpDeptQueryDto query)
    {
      try
      {
        var result = await _deptService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpDeptDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取部门树形结构
    /// </summary>
    /// <returns>部门树形结构</returns>
    [HttpGet("tree")]
    [KpPermission("identity:dept:tree", "查询部门树")]
    [ProducesResponseType(typeof(KpApiResult<List<KpDeptDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpDeptDto>>>> GetTreeAsync()
    {
      try
      {
        var result = await _deptService.GetTreeAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpDeptDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取部门详情
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>部门详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:dept:detail", "查看部门")]
    [ProducesResponseType(typeof(KpApiResult<KpDeptDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDeptDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _deptService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDeptDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建部门
    /// </summary>
    /// <param name="input">部门信息</param>
    /// <returns>部门ID</returns>
    [HttpPost]
    [KpPermission("identity:dept:create", "创建部门")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpDeptCreateDto input)
    {
      try
      {
        var result = await _deptService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新部门
    /// </summary>
    /// <param name="input">部门信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:dept:update", "更新部门")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpDeptUpdateDto input)
    {
      try
      {
        var result = await _deptService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除部门
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:dept:delete", "删除部门")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _deptService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改部门状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:dept:status", "修改部门状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpDeptChangeStatusDto input)
    {
      try
      {
        var result = await _deptService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导入部门
    /// </summary>
    /// <param name="depts">部门导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:dept:import", "导入部门")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpDeptImportDto> depts)
    {
      try
      {
        var result = await _deptService.ImportAsync(depts);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出部门
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:dept:export", "导出部门")]
    [ProducesResponseType(typeof(KpApiResult<List<KpDeptExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpDeptExportDto>>>> ExportAsync([FromQuery] KpDeptQueryDto query)
    {
      try
      {
        var result = await _deptService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpDeptExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取部门导入模板
    /// </summary>
    /// <returns>部门导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:dept:template", "获取部门导入模板")]
    [ProducesResponseType(typeof(KpApiResult<KpDeptTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDeptTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _deptService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDeptTemplateDto>(ex.Message);
      }
    }
  }
}