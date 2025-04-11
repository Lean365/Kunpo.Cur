// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>本地化服务接口</summary>
// <remarks>处理本地化的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities.Core;

namespace Kunpo.Cur.Domain.Interfaces
{
  /// <summary>
  /// 本地化服务接口
  /// </summary>
  public interface IKpLocalizationService
  {
    /// <summary>
    /// 获取本地化文本
    /// </summary>
    /// <param name="resourceType">资源类型</param>
    /// <param name="resourceKey">资源键</param>
    /// <param name="args">参数</param>
    /// <returns>本地化文本</returns>
    string GetString(string resourceType, string resourceKey, params object[] args);

    /// <summary>
    /// 获取本地化文本（带默认值）
    /// </summary>
    /// <param name="resourceType">资源类型</param>
    /// <param name="resourceKey">资源键</param>
    /// <param name="defaultValue">默认值</param>
    /// <param name="args">参数</param>
    /// <returns>本地化文本</returns>
    string GetString(string resourceType, string resourceKey, string defaultValue, params object[] args);

    /// <summary>
    /// 获取当前语言
    /// </summary>
    /// <returns>当前语言</returns>
    KpLanguage? GetCurrentLanguage();

    /// <summary>
    /// 设置当前语言
    /// </summary>
    /// <param name="languageId">语言ID</param>
    void SetCurrentLanguage(string languageId);
  }
}