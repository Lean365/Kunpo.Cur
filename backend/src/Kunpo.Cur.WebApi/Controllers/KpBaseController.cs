// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>基础控制器</summary>
// <remarks>处理基础的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Enums;
using Kunpo.Cur.Common.Attributes;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Core;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class KpBaseController : ControllerBase
  {
    /// <summary>
    /// 日志记录器
    /// </summary>
    protected readonly Serilog.ILogger _logger;

    /// <summary>
    /// 本地化服务
    /// </summary>
    protected readonly IKpLocalizationService _localizationService;

    private readonly IKpSecurityContext _securityContext;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    protected KpBaseController(Serilog.ILogger logger, IKpLocalizationService localizationService, IKpSecurityContext securityContext)
    {
      _logger = logger;
      _localizationService = localizationService;
      _securityContext = securityContext;
    }

    /// <summary>
    /// 获取本地化文本
    /// </summary>
    /// <param name="resourceType">资源类型</param>
    /// <param name="resourceKey">资源键</param>
    /// <param name="args">参数</param>
    /// <returns>本地化文本</returns>
    protected string L(string resourceType, string resourceKey, params object[] args)
    {
      return _localizationService.GetString(resourceType, resourceKey, args);
    }

    /// <summary>
    /// 获取本地化文本（带默认值）
    /// </summary>
    /// <param name="resourceType">资源类型</param>
    /// <param name="resourceKey">资源键</param>
    /// <param name="defaultValue">默认值</param>
    /// <param name="args">参数</param>
    /// <returns>本地化文本</returns>
    protected string L(string resourceType, string resourceKey, string defaultValue, params object[] args)
    {
      return _localizationService.GetString(resourceType, resourceKey, defaultValue, args);
    }

    /// <summary>
    /// 获取当前语言
    /// </summary>
    /// <returns>当前语言</returns>
    protected KpLanguage? GetCurrentLanguage()
    {
      return _localizationService.GetCurrentLanguage();
    }

    /// <summary>
    /// 设置当前语言
    /// </summary>
    /// <param name="languageId">语言ID</param>
    protected void SetCurrentLanguage(string languageId)
    {
      _localizationService.SetCurrentLanguage(languageId);
    }

    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    protected long GetCurrentUserId()
    {
      return _securityContext.GetCurrentUserId();
    }

    /// <summary>
    /// 获取当前用户名称
    /// </summary>
    protected string? GetCurrentUserName()
    {
      return _securityContext.GetCurrentUserName();
    }

    /// <summary>
    /// 获取当前用户权限列表
    /// </summary>
    protected List<string> GetCurrentUserPermissions()
    {
      return _securityContext.GetCurrentUserPermissions();
    }

    /// <summary>
    /// 检查当前用户是否拥有指定权限
    /// </summary>
    protected bool HasPermission(string permissionCode)
    {
      return _securityContext.HasPermission(permissionCode);
    }

    /// <summary>
    /// 检查当前用户是否拥有所有指定权限
    /// </summary>
    protected bool HasAllPermissions(params string[] permissionCodes)
    {
      return _securityContext.HasAllPermissions(permissionCodes);
    }

    /// <summary>
    /// 检查当前用户是否拥有任意指定权限
    /// </summary>
    protected bool HasAnyPermission(params string[] permissionCodes)
    {
      return _securityContext.HasAnyPermission(permissionCodes);
    }

    /// <summary>
    /// 成功响应
    /// </summary>
    protected KpApiResult<T> Success<T>(T? data = default, string? message = null)
    {
      return KpApiResult<T>.Ok(data, message ?? L("Common", "Success"));
    }

    /// <summary>
    /// 成功响应（无数据）
    /// </summary>
    protected KpApiResult Success(string? message = null)
    {
      return KpApiResult.Ok(null, message ?? L("Common", "Success"));
    }

    /// <summary>
    /// 错误响应
    /// </summary>
    protected KpApiResult<T> Error<T>(string? message = null, KpErrorCode errorCode = KpErrorCode.ServerError, T? data = default)
    {
      return KpApiResult<T>.Fail(message ?? L("Common", "Error"), errorCode, data);
    }

    /// <summary>
    /// 错误响应（无数据）
    /// </summary>
    protected KpApiResult Error(string? message = null, KpErrorCode errorCode = KpErrorCode.ServerError)
    {
      return KpApiResult.Fail(message ?? L("Common", "Error"), errorCode);
    }

    /// <summary>
    /// 未授权响应
    /// </summary>
    protected KpApiResult Unauthorized(string? message = null)
    {
      return KpApiResult.Unauthorized(message ?? L("Common", "Unauthorized"));
    }

    /// <summary>
    /// 禁止访问响应
    /// </summary>
    protected KpApiResult Forbidden(string? message = null)
    {
      return KpApiResult.Forbidden(message ?? L("Common", "Forbidden"));
    }

    /// <summary>
    /// 未找到响应
    /// </summary>
    protected KpApiResult NotFound(string? message = null)
    {
      return KpApiResult.NotFound(message ?? L("Common", "NotFound"));
    }

    /// <summary>
    /// 服务器错误响应
    /// </summary>
    protected KpApiResult ServerError(string? message = null)
    {
      return KpApiResult.ServerError(message ?? L("Common", "ServerError"));
    }
  }
}