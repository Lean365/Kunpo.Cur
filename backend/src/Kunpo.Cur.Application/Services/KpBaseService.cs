// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>服务基类</summary>
// -----------------------------------------------------------------------


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using Kunpo.Cur.Common.Utils;
using Kunpo.Cur.Domain.Interfaces;

namespace Kunpo.Cur.Application.Services
{
  /// <summary>
  /// 服务基类
  /// </summary>
  public abstract class KpBaseService : IKpBaseService
  {
    protected readonly ILogger _logger;
    protected readonly IConfiguration _configuration;
    protected readonly IKpSecurityContext _securityContext;
    protected readonly IKpLocalizationService _localizationService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="configuration">配置</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    protected KpBaseService(
      ILogger logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService)
    {
      _logger = logger;
      _configuration = configuration;
      _securityContext = securityContext;
      _localizationService = localizationService;
    }

    /// <summary>
    /// 记录信息日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    public void LogInformation(string message, params object[] args)
    {
      _logger.LogInformation(message, args);
    }

    /// <summary>
    /// 记录警告日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    public void LogWarning(string message, params object[] args)
    {
      _logger.LogWarning(message, args);
    }

    /// <summary>
    /// 记录错误日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    public void LogError(string message, params object[] args)
    {
      _logger.LogError(message, args);
    }

    /// <summary>
    /// 记录异常日志
    /// </summary>
    /// <param name="ex">异常</param>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    public void LogException(Exception ex, string message, params object[] args)
    {
      _logger.LogError(ex, message, args);
    }

    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    /// <returns>用户ID</returns>
    public long GetCurrentUserId()
    {
      return _securityContext.GetCurrentUserId();
    }

    /// <summary>
    /// 获取当前用户名
    /// </summary>
    /// <returns>用户名</returns>
    public string? GetCurrentUserName()
    {
      return _securityContext.GetCurrentUserName();
    }

    /// <summary>
    /// 获取当前用户权限
    /// </summary>
    /// <returns>权限列表</returns>
    public IEnumerable<string>? GetCurrentUserPermissions()
    {
      return _securityContext.GetCurrentUserPermissions();
    }

    /// <summary>
    /// 检查当前用户是否有指定权限
    /// </summary>
    /// <param name="permission">权限</param>
    /// <returns>是否有权限</returns>
    public bool HasPermission(string permission)
    {
      return _securityContext.HasPermission(permission);
    }

    /// <summary>
    /// 检查当前用户是否有所有指定权限
    /// </summary>
    /// <param name="permissions">权限列表</param>
    /// <returns>是否有所有权限</returns>
    protected bool HasAllPermissions(params string[] permissions)
    {
      return _securityContext.HasAllPermissions(permissions);
    }

    /// <summary>
    /// 检查当前用户是否有任一指定权限
    /// </summary>
    /// <param name="permissions">权限列表</param>
    /// <returns>是否有任一权限</returns>
    protected bool HasAnyPermission(params string[] permissions)
    {
      return _securityContext.HasAnyPermission(permissions);
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
  }
}