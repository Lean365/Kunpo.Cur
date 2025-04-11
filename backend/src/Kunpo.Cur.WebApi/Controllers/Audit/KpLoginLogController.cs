// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录日志控制器</summary>
// <remarks>处理登录日志的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 登录日志控制器
  /// </summary>
  [ApiController]
  [Route("api/audit/login")]
  [ApiExplorerSettings(GroupName = "audit")]
  public class KpLoginLogController : KpBaseController
  {
    private readonly IKpLoginLogService _loginLogService;
    private readonly IKpLoginDevService _loginDevService;
    private readonly IKpLoginEnvService _loginEnvService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="loginLogService">登录日志服务</param>
    /// <param name="loginDevService">登录设备服务</param>
    /// <param name="loginEnvService">登录环境服务</param>
    public KpLoginLogController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpLoginLogService loginLogService,
      IKpLoginDevService loginDevService,
      IKpLoginEnvService loginEnvService) : base(logger, localizationService, securityContext)
    {
      _loginLogService = loginLogService;
      _loginDevService = loginDevService;
      _loginEnvService = loginEnvService;
    }

    #region 登录日志

    /// <summary>
    /// 获取登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    [HttpGet("log/list")]
    [KpPermission("audit:login:log:list", "查询登录日志")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpLoginLogDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpLoginLogDto>>>> GetLogListAsync([FromQuery] KpLoginLogQueryDto query)
    {
      try
      {
        var result = await _loginLogService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpLoginLogDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取登录日志详情
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>登录日志详情</returns>
    [HttpGet("log/{id}")]
    [KpPermission("audit:login:log:detail", "查看登录日志")]
    [ProducesResponseType(typeof(KpApiResult<KpLoginLogDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpLoginLogDto>>> GetLogByIdAsync(long id)
    {
      try
      {
        var result = await _loginLogService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpLoginLogDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>登录日志ID</returns>
    [HttpPost("log")]
    [KpPermission("audit:login:log:create", "创建登录日志")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateLogAsync([FromBody] KpLoginLogCreateDto input)
    {
      try
      {
        var result = await _loginLogService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("log")]
    [KpPermission("audit:login:log:update", "更新登录日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateLogAsync([FromBody] KpLoginLogUpdateDto input)
    {
      try
      {
        var result = await _loginLogService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除登录日志
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("log/{id}")]
    [KpPermission("audit:login:log:delete", "删除登录日志")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteLogAsync(long id)
    {
      try
      {
        var result = await _loginLogService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    [HttpGet("log/export")]
    [KpPermission("audit:login:log:export", "导出登录日志")]
    [ProducesResponseType(typeof(KpApiResult<List<KpLoginLogExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpLoginLogExportDto>>>> ExportLogListAsync([FromQuery] KpLoginLogQueryDto query)
    {
      try
      {
        var result = await _loginLogService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpLoginLogExportDto>>(ex.Message);
      }
    }

    #endregion

    #region 登录设备

    /// <summary>
    /// 获取登录设备列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录设备列表</returns>
    [HttpGet("dev/list")]
    [KpPermission("audit:login:dev:list", "查询登录设备")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpLoginDevDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpLoginDevDto>>>> GetDevListAsync([FromQuery] KpLoginDeviceQueryDto query)
    {
      try
      {
        var result = await _loginDevService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpLoginDevDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取登录设备详情
    /// </summary>
    /// <param name="id">登录设备ID</param>
    /// <returns>登录设备详情</returns>
    [HttpGet("dev/{id}")]
    [KpPermission("audit:login:dev:detail", "查看登录设备")]
    [ProducesResponseType(typeof(KpApiResult<KpLoginDevDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpLoginDevDto>>> GetDevByIdAsync(long id)
    {
      try
      {
        var result = await _loginDevService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpLoginDevDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建登录设备
    /// </summary>
    /// <param name="input">登录设备信息</param>
    /// <returns>登录设备ID</returns>
    [HttpPost("dev")]
    [KpPermission("audit:login:dev:create", "创建登录设备")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateDevAsync([FromBody] KpLoginDeviceCreateDto input)
    {
      try
      {
        var result = await _loginDevService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新登录设备
    /// </summary>
    /// <param name="input">登录设备信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("dev")]
    [KpPermission("audit:login:dev:update", "更新登录设备")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateDevAsync([FromBody] KpLoginDeviceUpdateDto input)
    {
      try
      {
        var result = await _loginDevService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除登录设备
    /// </summary>
    /// <param name="id">登录设备ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("dev/{id}")]
    [KpPermission("audit:login:dev:delete", "删除登录设备")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteDevAsync(long id)
    {
      try
      {
        var result = await _loginDevService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出登录设备列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录设备列表</returns>
    [HttpGet("dev/export")]
    [KpPermission("audit:login:dev:export", "导出登录设备")]
    [ProducesResponseType(typeof(KpApiResult<List<KpLoginDeviceExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpLoginDeviceExportDto>>>> ExportDevListAsync([FromQuery] KpLoginDeviceQueryDto query)
    {
      try
      {
        var result = await _loginDevService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpLoginDeviceExportDto>>(ex.Message);
      }
    }

    #endregion

    #region 登录环境

    /// <summary>
    /// 获取登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    [HttpGet("env/list")]
    [KpPermission("audit:login:env:list", "查询登录环境")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpLoginEnvDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpLoginEnvDto>>>> GetEnvListAsync([FromQuery] KpLoginEnvQueryDto query)
    {
      try
      {
        var result = await _loginEnvService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpLoginEnvDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取登录环境详情
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>登录环境详情</returns>
    [HttpGet("env/{id}")]
    [KpPermission("audit:login:env:detail", "查看登录环境")]
    [ProducesResponseType(typeof(KpApiResult<KpLoginEnvDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpLoginEnvDto>>> GetEnvByIdAsync(long id)
    {
      try
      {
        var result = await _loginEnvService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpLoginEnvDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>登录环境ID</returns>
    [HttpPost("env")]
    [KpPermission("audit:login:env:create", "创建登录环境")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateEnvAsync([FromBody] KpLoginEnvCreateDto input)
    {
      try
      {
        var result = await _loginEnvService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("env")]
    [KpPermission("audit:login:env:update", "更新登录环境")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateEnvAsync([FromBody] KpLoginEnvUpdateDto input)
    {
      try
      {
        var result = await _loginEnvService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除登录环境
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("env/{id}")]
    [KpPermission("audit:login:env:delete", "删除登录环境")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteEnvAsync(long id)
    {
      try
      {
        var result = await _loginEnvService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    [HttpGet("env/export")]
    [KpPermission("audit:login:env:export", "导出登录环境")]
    [ProducesResponseType(typeof(KpApiResult<List<KpLoginEnvExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpLoginEnvExportDto>>>> ExportEnvListAsync([FromQuery] KpLoginEnvQueryDto query)
    {
      try
      {
        var result = await _loginEnvService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpLoginEnvExportDto>>(ex.Message);
      }
    }

    #endregion
  }
}