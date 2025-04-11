// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>权限过滤器</summary>
// <remarks>处理权限的验证</remarks>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Kunpo.Cur.Common.Attributes;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Enums;

namespace Kunpo.Cur.Common.Filters
{
  /// <summary>
  /// 权限过滤器
  /// </summary>
  public class KpPermissionFilter : IAsyncActionFilter
  {
    /// <summary>
    /// 执行权限验证
    /// </summary>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      // 获取控制器和方法上的权限特性
      var controllerAttributes = context.Controller.GetType().GetCustomAttributes(typeof(KpPermissionAttribute), true)
          .Cast<KpPermissionAttribute>();
      var actionAttributes = context.ActionDescriptor.EndpointMetadata.OfType<KpPermissionAttribute>();

      // 合并所有权限特性
      var permissionAttributes = controllerAttributes.Concat(actionAttributes).ToList();

      // 如果没有权限特性，直接执行下一步
      if (!permissionAttributes.Any())
      {
        await next();
        return;
      }

      // 获取当前用户
      var user = context.HttpContext.User;
      if (user == null || !user.Identity.IsAuthenticated)
      {
        context.Result = new JsonResult(KpApiResult.Unauthorized("用户未登录"));
        return;
      }

      // 获取用户权限列表
      var userPermissions = user.Claims
          .Where(c => c.Type == "permission")
          .Select(c => c.Value)
          .ToList();

      // 验证权限
      var requiredPermissions = permissionAttributes.Select(p => p.Code).ToList();
      var hasPermission = requiredPermissions.All(p => userPermissions.Contains(p));

      if (!hasPermission)
      {
        context.Result = new JsonResult(KpApiResult.Fail("权限不足", KpErrorCode.Forbidden));
        return;
      }

      // 权限验证通过，执行下一步
      await next();
    }
  }
}