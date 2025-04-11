// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>认证控制器</summary>
// <remarks>处理认证的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Application.Services.Identity;
using Kunpo.Cur.Application.Services.Localization;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Interfaces;

namespace Kunpo.Cur.WebApi.Controllers.Identity
{
  /// <summary>
  /// 认证控制器
  /// </summary>
  [ApiController]
  [Route("api/[controller]")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpAuthController : KpBaseController
  {
    /// <summary>
    /// 认证服务
    /// </summary>
    private readonly IKpAuthService _authService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="authService">认证服务</param>
    public KpAuthController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpAuthService authService) : base(logger, localizationService, securityContext)
    {
      _authService = authService;
    }

    /// <summary>
    /// 用户认证
    /// </summary>
    /// <param name="authRequest">认证请求</param>
    /// <returns>认证响应</returns>
    [HttpPost("authenticate")]
    [KpPermission("identity:auth:authenticate", "用户认证")]
    [ProducesResponseType(typeof(KpApiResult<KpAuthResponseDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpAuthResponseDto>>> Authenticate([FromBody] KpAuthRequestDto authRequest)
    {
      try
      {
        var result = await _authService.AuthenticateAsync(authRequest);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpAuthResponseDto>(ex.Message);
      }
    }

    /// <summary>
    /// 用户登出
    /// </summary>
    /// <returns>登出结果</returns>
    [HttpPost("logout")]
    [KpPermission("identity:auth:logout", "用户登出")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> Logout()
    {
      try
      {
        var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var refreshToken = HttpContext.Request.Headers["X-Refresh-Token"].ToString();

        var result = await _authService.LogoutAsync(accessToken, refreshToken);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>新的访问令牌</returns>
    [HttpPost("refresh-token")]
    [KpPermission("identity:auth:refresh", "刷新令牌")]
    [ProducesResponseType(typeof(KpApiResult<KpAuthResponseDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpAuthResponseDto>>> RefreshToken([FromBody] string refreshToken)
    {
      try
      {
        var result = await _authService.RefreshTokenAsync(refreshToken);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpAuthResponseDto>(ex.Message);
      }
    }
  }
}