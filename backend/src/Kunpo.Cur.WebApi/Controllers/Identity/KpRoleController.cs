// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色控制器</summary>
// <remarks>处理角色的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 角色控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/role")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpRoleController : KpBaseController
  {
    private readonly IKpRoleService _roleService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="roleService">角色服务</param>
    public KpRoleController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpRoleService roleService) : base(logger, localizationService, securityContext)
    {
      _roleService = roleService;
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:role:list", "查询角色")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpRoleDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpRoleDto>>>> GetListAsync([FromQuery] KpRoleQueryDto query)
    {
      try
      {
        var result = await _roleService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpRoleDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取角色详情
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>角色详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:role:detail", "查看角色")]
    [ProducesResponseType(typeof(KpApiResult<KpRoleDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpRoleDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _roleService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpRoleDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="input">角色信息</param>
    /// <returns>角色ID</returns>
    [HttpPost]
    [KpPermission("identity:role:create", "创建角色")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpRoleCreateDto input)
    {
      try
      {
        var result = await _roleService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="input">角色信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:role:update", "更新角色")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpRoleUpdateDto input)
    {
      try
      {
        var result = await _roleService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:role:delete", "删除角色")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _roleService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改角色状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:role:status", "修改角色状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpRoleChangeStatusDto input)
    {
      try
      {
        var result = await _roleService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 分配角色菜单
    /// </summary>
    /// <param name="input">角色菜单信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("menu")]
    [KpPermission("identity:role:menu", "分配角色菜单")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> AssignMenuAsync([FromBody] KpRoleMenuDto input)
    {
      try
      {
        var result = await _roleService.AssignMenuAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 获取角色菜单
    /// </summary>
    /// <param name="roleId">角色ID</param>
    /// <returns>角色菜单列表</returns>
    [HttpGet("menu/{roleId}")]
    [KpPermission("identity:role:menu", "查看角色菜单")]
    [ProducesResponseType(typeof(KpApiResult<List<long>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<long>>>> GetRoleMenuAsync(long roleId)
    {
      try
      {
        var result = await _roleService.GetRoleMenuAsync(roleId);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<long>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入角色
    /// </summary>
    /// <param name="roles">角色导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:role:import", "导入角色")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpRoleImportDto> roles)
    {
      try
      {
        var result = await _roleService.ImportAsync(roles);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出角色
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:role:export", "导出角色")]
    [ProducesResponseType(typeof(KpApiResult<List<KpRoleExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpRoleExportDto>>>> ExportAsync([FromQuery] KpRoleQueryDto query)
    {
      try
      {
        var result = await _roleService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpRoleExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取角色导入模板
    /// </summary>
    /// <returns>角色导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:role:template", "获取角色导入模板")]
    [ProducesResponseType(typeof(KpApiResult<KpRoleTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpRoleTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _roleService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpRoleTemplateDto>(ex.Message);
      }
    }
  }
}