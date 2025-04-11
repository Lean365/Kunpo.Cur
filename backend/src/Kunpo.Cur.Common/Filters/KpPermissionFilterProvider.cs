// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>权限过滤器提供程序</summary>
// <remarks>处理权限过滤器的提供</remarks>
// -----------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Kunpo.Cur.Common.Attributes;

namespace Kunpo.Cur.Common.Filters
{
  /// <summary>
  /// 权限过滤器提供程序
  /// </summary>
  public class KpPermissionFilterProvider : IFilterProvider
  {
    /// <summary>
    /// 过滤器顺序
    /// </summary>
    public int Order => 0;

    /// <summary>
    /// 获取过滤器
    /// </summary>
    public void OnProvidersExecuting(FilterProviderContext context)
    {
      if (context.ActionContext.ActionDescriptor.EndpointMetadata.Any(x => x is KpPermissionAttribute))
      {
        context.Results.Add(new FilterItem(new FilterDescriptor(new KpPermissionFilter(), FilterScope.Action), new KpPermissionFilter()));
      }
    }

    /// <summary>
    /// 获取过滤器后
    /// </summary>
    public void OnProvidersExecuted(FilterProviderContext context)
    {
    }
  }
}