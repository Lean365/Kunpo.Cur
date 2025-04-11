// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线用户控制器</summary>
// <remarks>处理在线用户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Application.Services.SignalR;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Application.Services.Localization;

namespace Kunpo.Cur.WebApi.Controllers.SignalR
{
  /// <summary>
  /// 在线用户控制器
  /// </summary>
  [ApiController]
  [Route("api/[controller]")]
  [ApiExplorerSettings(GroupName = "signalr")]
  public class KpOnlineUserController : KpBaseController
  {
    private readonly IKpOnlineUserService _onlineUserService;

    /// <summary>
    /// 构造函数
    /// </summary>
    public KpOnlineUserController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpOnlineUserService onlineUserService) : base(logger, localizationService, securityContext)
    {
      _onlineUserService = onlineUserService;
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(KpApiResult<KpOnlineUserDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpOnlineUserDto>>> GetAsync(long userId)
    {
      try
      {
        var result = await _onlineUserService.GetAsync(userId);
        if (result == null)
        {
          return Error<KpOnlineUserDto>("用户不存在");
        }
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpOnlineUserDto>(ex.Message);
      }
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    [HttpGet("list")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpOnlineUserDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpOnlineUserDto>>>> GetListAsync([FromQuery] KpOnlineUserQueryDto query)
    {
      try
      {
        var result = await _onlineUserService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpOnlineUserDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpOnlineUserCreateDto input)
    {
      try
      {
        var result = await _onlineUserService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpOnlineUserUpdateDto input)
    {
      try
      {
        var result = await _onlineUserService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    [HttpDelete("{userId}")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long userId)
    {
      try
      {
        var result = await _onlineUserService.DeleteAsync(new KpOnlineUserDeleteDto { UserId = userId });
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出用户列表
    /// </summary>
    [HttpGet("export")]
    [ProducesResponseType(typeof(KpApiResult<List<KpOnlineUserExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpOnlineUserExportDto>>>> ExportListAsync([FromQuery] KpOnlineUserQueryDto query)
    {
      try
      {
        var result = await _onlineUserService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpOnlineUserExportDto>>(ex.Message);
      }
    }
  }
}