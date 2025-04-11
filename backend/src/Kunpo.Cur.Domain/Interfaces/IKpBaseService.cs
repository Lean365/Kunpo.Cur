// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>服务基类接口</summary>
// <remarks>处理服务基类的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.Domain.Interfaces
{
  /// <summary>
  /// 服务基类接口
  /// </summary>
  public interface IKpBaseService
  {
    /// <summary>
    /// 记录信息日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    void LogInformation(string message, params object[] args);

    /// <summary>
    /// 记录警告日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    void LogWarning(string message, params object[] args);

    /// <summary>
    /// 记录错误日志
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    void LogError(string message, params object[] args);

    /// <summary>
    /// 记录异常日志
    /// </summary>
    /// <param name="ex">异常</param>
    /// <param name="message">消息</param>
    /// <param name="args">参数</param>
    void LogException(Exception ex, string message, params object[] args);

    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    /// <returns>用户ID</returns>
    long GetCurrentUserId();

    /// <summary>
    /// 获取当前用户名
    /// </summary>
    /// <returns>用户名</returns>
    string? GetCurrentUserName();

    /// <summary>
    /// 获取当前用户权限
    /// </summary>
    /// <returns>权限列表</returns>
    IEnumerable<string>? GetCurrentUserPermissions();

    /// <summary>
    /// 检查当前用户是否有指定权限
    /// </summary>
    /// <param name="permission">权限</param>
    /// <returns>是否有权限</returns>
    bool HasPermission(string permission);
  }
}