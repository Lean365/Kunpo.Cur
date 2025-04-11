// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线消息控制器</summary>
// <remarks>处理在线消息的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 在线消息控制器
  /// </summary>
  [ApiController]
  [Route("api/[controller]")]
  [ApiExplorerSettings(GroupName = "signalr")]
  public class KpOnlineMessageController : KpBaseController
  {
    private readonly IKpOnlineMessageService _onlineMessageService;

    /// <summary>
    /// 构造函数
    /// </summary>
    public KpOnlineMessageController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpOnlineMessageService onlineMessageService) : base(logger, localizationService, securityContext)
    {
      _onlineMessageService = onlineMessageService;
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    [HttpGet("{messageId}")]
    [ProducesResponseType(typeof(KpApiResult<KpOnlineMessageDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpOnlineMessageDto>>> GetAsync(long messageId)
    {
      try
      {
        var result = await _onlineMessageService.GetAsync(messageId);
        if (result == null)
        {
          return Error<KpOnlineMessageDto>("消息不存在");
        }
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpOnlineMessageDto>(ex.Message);
      }
    }

    /// <summary>
    /// 获取消息列表
    /// </summary>
    [HttpGet("list")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpOnlineMessageDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpOnlineMessageDto>>>> GetListAsync([FromQuery] KpOnlineMessageQueryDto query)
    {
      try
      {
        var result = await _onlineMessageService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpOnlineMessageDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 创建消息
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpOnlineMessageCreateDto input)
    {
      try
      {
        var result = await _onlineMessageService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新消息
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpOnlineMessageUpdateDto input)
    {
      try
      {
        var result = await _onlineMessageService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除消息
    /// </summary>
    [HttpDelete("{messageId}")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long messageId)
    {
      try
      {
        var result = await _onlineMessageService.DeleteAsync(new KpOnlineMessageDeleteDto { MessageId = messageId });
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导出消息列表
    /// </summary>
    [HttpGet("export")]
    [ProducesResponseType(typeof(KpApiResult<List<KpOnlineMessageExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpOnlineMessageExportDto>>>> ExportListAsync([FromQuery] KpOnlineMessageQueryDto query)
    {
      try
      {
        var result = await _onlineMessageService.ExportListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpOnlineMessageExportDto>>(ex.Message);
      }
    }
  }
}