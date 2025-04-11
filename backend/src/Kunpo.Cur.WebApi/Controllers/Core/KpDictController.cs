// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典控制器</summary>
// <remarks>处理字典的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 字典控制器
  /// </summary>
  [ApiController]
  [Route("api/core/dict")]
  [ApiExplorerSettings(GroupName = "core")]
  public class KpDictController : KpBaseController
  {
    private readonly IKpDictTypeService _dictTypeService;
    private readonly IKpDictDataService _dictDataService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="dictTypeService">字典类型服务</param>
    /// <param name="dictDataService">字典数据服务</param>
    public KpDictController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpDictTypeService dictTypeService,
      IKpDictDataService dictDataService) : base(logger, localizationService, securityContext)
    {
      _dictTypeService = dictTypeService;
      _dictDataService = dictDataService;
    }

    #region 字典类型

    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    [HttpGet("type/list")]
    [KpPermission("core:dict:type:list", "查询字典类型")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpDictTypeDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpDictTypeDto>>>> GetTypeListAsync([FromQuery] KpDictTypeQueryDto query)
    {
      try
      {
        var result = await _dictTypeService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpDictTypeDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取字典类型详情
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>字典类型详情</returns>
    [HttpGet("type/{id}")]
    [KpPermission("core:dict:type:detail", "查看字典类型")]
    [ProducesResponseType(typeof(KpApiResult<KpDictTypeDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDictTypeDto>>> GetTypeByIdAsync(long id)
    {
      try
      {
        var result = await _dictTypeService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDictTypeDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>字典类型ID</returns>
    [HttpPost("type")]
    [KpPermission("core:dict:type:create", "创建字典类型")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateTypeAsync([FromBody] KpDictTypeCreateDto input)
    {
      try
      {
        var result = await _dictTypeService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("type")]
    [KpPermission("core:dict:type:update", "更新字典类型")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateTypeAsync([FromBody] KpDictTypeUpdateDto input)
    {
      try
      {
        var result = await _dictTypeService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("type/{id}")]
    [KpPermission("core:dict:type:delete", "删除字典类型")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteTypeAsync(long id)
    {
      try
      {
        var result = await _dictTypeService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    [HttpGet("type/export")]
    [KpPermission("core:dict:type:export", "导出字典类型")]
    [ProducesResponseType(typeof(KpApiResult<List<KpDictTypeExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpDictTypeExportDto>>>> ExportTypeListAsync([FromQuery] KpDictTypeQueryDto query)
    {
      try
      {
        var result = await _dictTypeService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpDictTypeExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>导入结果</returns>
    [HttpPost("type/import")]
    [KpPermission("core:dict:type:import", "导入字典类型")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportTypeAsync([FromBody] KpDictTypeImportDto input)
    {
      try
      {
        var result = await _dictTypeService.ImportAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 获取字典类型模板
    /// </summary>
    /// <returns>字典类型模板</returns>
    [HttpGet("type/template")]
    [KpPermission("core:dict:type:template", "获取字典类型模板")]
    [ProducesResponseType(typeof(KpApiResult<KpDictTypeTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDictTypeTemplateDto>>> GetTypeTemplateAsync()
    {
      try
      {
        var result = await _dictTypeService.GetTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDictTypeTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改字典类型状态
    /// </summary>
    /// <param name="input">字典类型状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("type/status")]
    [KpPermission("core:dict:type:status", "修改字典类型状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeTypeStatusAsync([FromBody] KpDictTypeChangeStatusDto input)
    {
      try
      {
        var result = await _dictTypeService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    #endregion

    #region 字典数据

    /// <summary>
    /// 获取字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    [HttpGet("data/list")]
    [KpPermission("core:dict:data:list", "查询字典数据")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpDictDataDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpDictDataDto>>>> GetDataListAsync([FromQuery] KpDictDataQueryDto query)
    {
      try
      {
        var result = await _dictDataService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpDictDataDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取字典数据详情
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>字典数据详情</returns>
    [HttpGet("data/{id}")]
    [KpPermission("core:dict:data:detail", "查看字典数据")]
    [ProducesResponseType(typeof(KpApiResult<KpDictDataDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDictDataDto>>> GetDataByIdAsync(long id)
    {
      try
      {
        var result = await _dictDataService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDictDataDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>字典数据ID</returns>
    [HttpPost("data")]
    [KpPermission("core:dict:data:create", "创建字典数据")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateDataAsync([FromBody] KpDictDataCreateDto input)
    {
      try
      {
        var result = await _dictDataService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("data")]
    [KpPermission("core:dict:data:update", "更新字典数据")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateDataAsync([FromBody] KpDictDataUpdateDto input)
    {
      try
      {
        var result = await _dictDataService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除字典数据
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("data/{id}")]
    [KpPermission("core:dict:data:delete", "删除字典数据")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteDataAsync(long id)
    {
      try
      {
        var result = await _dictDataService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    [HttpGet("data/export")]
    [KpPermission("core:dict:data:export", "导出字典数据")]
    [ProducesResponseType(typeof(KpApiResult<List<KpDictDataExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpDictDataExportDto>>>> ExportDataListAsync([FromQuery] KpDictDataQueryDto query)
    {
      try
      {
        var result = await _dictDataService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpDictDataExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 导入字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>导入结果</returns>
    [HttpPost("data/import")]
    [KpPermission("core:dict:data:import", "导入字典数据")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportDataAsync([FromBody] KpDictDataImportDto input)
    {
      try
      {
        var result = await _dictDataService.ImportAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 获取字典数据模板
    /// </summary>
    /// <returns>字典数据模板</returns>
    [HttpGet("data/template")]
    [KpPermission("core:dict:data:template", "获取字典数据模板")]
    [ProducesResponseType(typeof(KpApiResult<KpDictDataTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpDictDataTemplateDto>>> GetDataTemplateAsync()
    {
      try
      {
        var result = await _dictDataService.GetTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpDictDataTemplateDto>(ex.Message);
      }
    }

    /// <summary>
    /// 修改字典数据状态
    /// </summary>
    /// <param name="input">字典数据状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("data/status")]
    [KpPermission("core:dict:data:status", "修改字典数据状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeDataStatusAsync([FromBody] KpDictDataChangeStatusDto input)
    {
      try
      {
        var result = await _dictDataService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 转置字典数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的字典数据</returns>
    [HttpGet("data/transpose")]
    [KpPermission("core:dict:data:transpose", "转置字典数据")]
    [ProducesResponseType(typeof(KpApiResult<List<KpDictDataTransposeDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpDictDataTransposeDto>>>> TransposeDataAsync([FromQuery] KpDictDataQueryDto query)
    {
      try
      {
        var result = await _dictDataService.TransposeAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpDictDataTransposeDto>>(ex.Message);
      }
    }

    #endregion
  }
}