// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>权限特性</summary>
// <remarks>处理权限的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;

namespace Kunpo.Cur.Common.Attributes
{
  /// <summary>
  /// 权限特性
  /// </summary>
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
  public class KpPermissionAttribute : Attribute
  {
    /// <summary>
    /// 权限编码
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// 权限名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 权限描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 初始化权限特性
    /// </summary>
    /// <param name="code">权限编码</param>
    /// <param name="name">权限名称</param>
    public KpPermissionAttribute(string code, string name)
    {
      Code = code;
      Name = name;
    }
  }
}