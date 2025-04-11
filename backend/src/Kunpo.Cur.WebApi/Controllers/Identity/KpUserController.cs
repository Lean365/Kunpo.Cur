// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户控制器</summary>
// <remarks>处理用户的查询、创建、更新、删除和导出等操作</remarks>
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
  /// 用户控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/user")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpUserController : KpBaseController
  {
    private readonly IKpUserService _userService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="userService">用户服务</param>
    public KpUserController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpUserService userService) : base(logger, localizationService, securityContext)
    {
      _userService = userService;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:user:list", "查询用户")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpUserDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpUserDto>>>> GetListAsync([FromQuery] KpUserQueryDto query)
    {
      try
      {
        var result = await _userService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpUserDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>用户详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:user:detail", "查看用户")]
    [ProducesResponseType(typeof(KpApiResult<KpUserDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpUserDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _userService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpUserDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户信息</param>
    /// <returns>用户ID</returns>
    [HttpPost]
    [KpPermission("identity:user:create", "创建用户")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpUserCreateDto input)
    {
      try
      {
        var result = await _userService.CreateAsync(input);
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
    /// <param name="input">用户信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:user:update", "更新用户")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpUserUpdateDto input)
    {
      try
      {
        var result = await _userService.UpdateAsync(input);
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
    /// <param name="id">用户ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:user:delete", "删除用户")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _userService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改用户状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:user:status", "修改用户状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpUserChangeStatusDto input)
    {
      try
      {
        var result = await _userService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="input">密码信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("password")]
    [KpPermission("identity:user:password", "修改用户密码")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangePasswordAsync([FromBody] KpUserChangePasswordDto input)
    {
      try
      {
        var result = await _userService.ChangePasswordAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 重置用户密码
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>新密码</returns>
    [HttpPut("reset-password/{id}")]
    [KpPermission("identity:user:reset-password", "重置用户密码")]
    [ProducesResponseType(typeof(KpApiResult<string>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<string>>> ResetPasswordAsync(long id)
    {
      try
      {
        var dto = new KpUserResetPasswordDto { Id = id };
        var result = await _userService.ResetPasswordAsync(dto);
        return Success<string>(result);
      }
      catch (Exception ex)
      {
        return Error<string>(ex.Message);
      }
    }

    /// <summary>
    /// 导入用户
    /// </summary>
    /// <param name="users">用户导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:user:import", "导入用户")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpUserImportDto> users)
    {
      try
      {
        var result = await _userService.ImportAsync(users);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出用户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:user:export", "导出用户")]
    [ProducesResponseType(typeof(KpApiResult<List<KpUserExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpUserExportDto>>>> ExportAsync([FromQuery] KpUserQueryDto query)
    {
      try
      {
        var result = await _userService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpUserExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取用户导入模板
    /// </summary>
    /// <returns>用户导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:user:template", "获取用户导入模板")]
    [ProducesResponseType(typeof(KpApiResult<KpUserTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpUserTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _userService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpUserTemplateDto>(ex.Message);
      }
    }
  }
}