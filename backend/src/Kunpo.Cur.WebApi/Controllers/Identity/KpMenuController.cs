// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>菜单控制器</summary>
// <remarks>处理菜单的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 菜单控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/menu")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpMenuController : KpBaseController
  {
    private readonly IKpMenuService _menuService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="menuService">菜单服务</param>
    public KpMenuController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpMenuService menuService) : base(logger, localizationService, securityContext)
    {
      _menuService = menuService;
    }

    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:menu:list", "查询菜单")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpMenuDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpMenuDto>>>> GetListAsync([FromQuery] KpMenuQueryDto query)
    {
      try
      {
        var result = await _menuService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpMenuDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取菜单详情
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>菜单详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:menu:get", "获取菜单详情")]
    [ProducesResponseType(typeof(KpApiResult<KpMenuDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpMenuDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _menuService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpMenuDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="dto">创建菜单参数</param>
    /// <returns>菜单ID</returns>
    [HttpPost]
    [KpPermission("identity:menu:create", "创建菜单")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpMenuCreateDto dto)
    {
      try
      {
        var result = await _menuService.CreateAsync(dto);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto">更新菜单参数</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:menu:update", "更新菜单")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpMenuUpdateDto dto)
    {
      try
      {
        var result = await _menuService.UpdateAsync(dto);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:menu:delete", "删除菜单")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _menuService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 根据父ID获取菜单列表
    /// </summary>
    /// <param name="parentId">父菜单ID</param>
    /// <returns>菜单列表</returns>
    [HttpGet("parent/{parentId}")]
    [KpPermission("identity:menu:list", "查询菜单")]
    [ProducesResponseType(typeof(KpApiResult<List<KpMenuDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpMenuDto>>>> GetByParentIdAsync(long parentId)
    {
      try
      {
        var result = await _menuService.GetByParentIdAsync(parentId);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpMenuDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取菜单树
    /// </summary>
    /// <returns>菜单树</returns>
    [HttpGet("tree")]
    [KpPermission("identity:menu:list", "查询菜单")]
    [ProducesResponseType(typeof(KpApiResult<List<KpMenuDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpMenuDto>>>> GetTreeAsync()
    {
      try
      {
        var result = await _menuService.GetTreeAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpMenuDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入菜单
    /// </summary>
    /// <param name="dtos">菜单导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:menu:import", "导入菜单")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpMenuImportDto> dtos)
    {
      try
      {
        var result = await _menuService.ImportAsync(dtos);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出菜单
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:menu:export", "导出菜单")]
    [ProducesResponseType(typeof(KpApiResult<List<KpMenuExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpMenuExportDto>>>> ExportAsync([FromQuery] KpMenuQueryDto query)
    {
      try
      {
        var result = await _menuService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpMenuExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取菜单导入模板
    /// </summary>
    /// <returns>菜单导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:menu:import", "导入菜单")]
    [ProducesResponseType(typeof(KpApiResult<KpMenuTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpMenuTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _menuService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpMenuTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改菜单状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:menu:update", "更新菜单")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpMenuChangeStatusDto dto)
    {
      try
      {
        var result = await _menuService.ChangeStatusAsync(dto);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改菜单排序
    /// </summary>
    /// <param name="dto">排序参数</param>
    /// <returns>是否成功</returns>
    [HttpPut("sort")]
    [KpPermission("identity:menu:update", "更新菜单")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeSortAsync([FromBody] KpMenuSortDto dto)
    {
      try
      {
        var result = await _menuService.ChangeSortAsync(dto);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }
  }
}