// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>菜单种子数据初始化器</summary>
// <remarks>处理菜单种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  /// <summary>
  /// 菜单种子数据
  /// </summary>
  public class KpMenuSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly ILogger<KpMenuSeed> _logger;

    public KpMenuSeed(KpSqlSugarDbContext dbContext, ILogger<KpMenuSeed> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }

    /// <summary>
    /// 初始化菜单数据
    /// </summary>
    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化菜单数据...");

        int createdCount = 0;
        int updatedCount = 0;
        int skippedCount = 0;

        _dbContext.Db.BeginTran();

        try
        {
          // 1. 创建顶级菜单
          var rootMenus = new List<KpMenu>
          {
            new KpMenu
            {
              MenuCode = "system",
              MenuName = "系统管理",
              MenuDescription = "系统管理模块",
              MenuIcon = "Setting",
              OrderNum = 1,
              Status = 1,
              MenuType = 0, // 目录
              MenuLevel = 1,
              IsActive = 1,
              MenuParentId = 0, // 顶级菜单
              MenuAncestors = "0", // 无上级菜单
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            },
            new KpMenu
            {
              MenuCode = "monitor",
              MenuName = "监控中心",
              MenuDescription = "系统监控模块",
              MenuIcon = "Monitor",
              OrderNum = 2,
              Status = 1,
              MenuType = 0, // 目录
              MenuLevel = 1,
              IsActive = 1,
              MenuParentId = 0, // 顶级菜单
              MenuAncestors = "0", // 无上级菜单
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            },
            new KpMenu
            {
              MenuCode = "tool",
              MenuName = "系统工具",
              MenuDescription = "系统工具模块",
              MenuIcon = "Tool",
              OrderNum = 3,
              Status = 1,
              MenuType = 0, // 目录
              MenuLevel = 1,
              IsActive = 1,
              MenuParentId = 0, // 顶级菜单
              MenuAncestors = "0", // 无上级菜单
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            }
          };

          // 处理顶级菜单
          foreach (var menu in rootMenus)
          {
            try
            {
              // 检查菜单是否存在
              var existingMenu = _dbContext.Db.Queryable<KpMenu>()
                .First(m => m.MenuCode == menu.MenuCode);

              if (existingMenu == null)
              {
                // 菜单不存在，创建新菜单
                _dbContext.Db.Insertable(menu).ExecuteCommand();
                _logger.LogInformation("创建菜单: {MenuName} ({MenuCode})", menu.MenuName, menu.MenuCode);
                createdCount++;
              }
              else
              {
                // 菜单已存在，更新菜单信息
                menu.Id = existingMenu.Id;
                _dbContext.Db.Updateable(menu).ExecuteCommand();
                _logger.LogInformation("更新菜单: {MenuName} ({MenuCode})", menu.MenuName, menu.MenuCode);
                updatedCount++;
              }
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "处理菜单 {MenuName} ({MenuCode}) 失败", menu.MenuName, menu.MenuCode);
              skippedCount++;
            }
          }

          // 获取已保存的顶级菜单
          var savedRootMenus = _dbContext.Db.Queryable<KpMenu>()
            .Where(m => m.MenuParentId == 0)
            .ToList();

          // 2. 创建子菜单和按钮权限
          foreach (var rootMenu in savedRootMenus)
          {
            var subMenus = new List<KpMenu>();

            if (rootMenu.MenuCode == "system")
            {
              // 用户管理菜单
              var userMenu = new KpMenu
              {
                MenuCode = "system:user",
                MenuName = "用户管理",
                MenuDescription = "用户管理功能",
                MenuIcon = "User",
                OrderNum = 1,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 用户管理按钮权限
              var userButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "system:user:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:create",
                  MenuName = "新增",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:create",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:update",
                  MenuName = "修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:update",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 3,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:delete",
                  MenuName = "删除",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:delete",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 4,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:import",
                  MenuName = "导入",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:import",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 5,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:export",
                  MenuName = "导出",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:export",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 6,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:reset",
                  MenuName = "重置密码",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:reset",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 7,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:user:status",
                  MenuName = "状态修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:user:status",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 8,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(userMenu);
              subMenus.AddRange(userButtons);

              // 角色管理菜单
              var roleMenu = new KpMenu
              {
                MenuCode = "system:role",
                MenuName = "角色管理",
                MenuDescription = "角色管理功能",
                MenuIcon = "UserGroup",
                OrderNum = 2,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 角色管理按钮权限
              var roleButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "system:role:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:role:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:role:create",
                  MenuName = "新增",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:role:create",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:role:update",
                  MenuName = "修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:role:update",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 3,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:role:delete",
                  MenuName = "删除",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:role:delete",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 4,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:role:export",
                  MenuName = "导出",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:role:export",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 5,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(roleMenu);
              subMenus.AddRange(roleButtons);

              // 菜单管理菜单
              var menuMenu = new KpMenu
              {
                MenuCode = "system:menu",
                MenuName = "菜单管理",
                MenuDescription = "菜单管理功能",
                MenuIcon = "Menu",
                OrderNum = 3,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 菜单管理按钮权限
              var menuButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "system:menu:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:menu:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:menu:create",
                  MenuName = "新增",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:menu:create",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:menu:update",
                  MenuName = "修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:menu:update",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 3,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "system:menu:delete",
                  MenuName = "删除",
                  MenuType = 2, // 按钮
                  MenuPerms = "system:menu:delete",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 4,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(menuMenu);
              subMenus.AddRange(menuButtons);
            }
            else if (rootMenu.MenuCode == "monitor")
            {
              // 在线用户菜单
              var onlineMenu = new KpMenu
              {
                MenuCode = "monitor:online",
                MenuName = "在线用户",
                MenuDescription = "在线用户监控",
                MenuIcon = "Online",
                OrderNum = 1,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 在线用户按钮权限
              var onlineButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "monitor:online:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:online:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:online:forceLogout",
                  MenuName = "强退",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:online:forceLogout",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(onlineMenu);
              subMenus.AddRange(onlineButtons);

              // 定时任务菜单
              var jobMenu = new KpMenu
              {
                MenuCode = "monitor:job",
                MenuName = "定时任务",
                MenuDescription = "定时任务监控",
                MenuIcon = "Job",
                OrderNum = 2,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 定时任务按钮权限
              var jobButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "monitor:job:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:create",
                  MenuName = "新增",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:create",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:update",
                  MenuName = "修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:update",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 3,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:delete",
                  MenuName = "删除",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:delete",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 4,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:export",
                  MenuName = "导出",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:export",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 5,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:start",
                  MenuName = "启动",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:start",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 6,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "monitor:job:stop",
                  MenuName = "停止",
                  MenuType = 2, // 按钮
                  MenuPerms = "monitor:job:stop",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 7,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(jobMenu);
              subMenus.AddRange(jobButtons);
            }
            else if (rootMenu.MenuCode == "tool")
            {
              // 表单构建菜单
              var buildMenu = new KpMenu
              {
                MenuCode = "tool:build",
                MenuName = "表单构建",
                MenuDescription = "表单构建工具",
                MenuIcon = "Build",
                OrderNum = 1,
                Status = 1,
                MenuType = 1, // 菜单
                MenuLevel = rootMenu.MenuLevel + 1,
                IsActive = 1,
                MenuParentId = rootMenu.Id,
                MenuAncestors = $"{rootMenu.MenuAncestors},{rootMenu.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              };

              // 表单构建按钮权限
              var buildButtons = new List<KpMenu>
              {
                new KpMenu
                {
                  MenuCode = "tool:build:query",
                  MenuName = "查询",
                  MenuType = 2, // 按钮
                  MenuPerms = "tool:build:query",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 1,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "tool:build:create",
                  MenuName = "新增",
                  MenuType = 2, // 按钮
                  MenuPerms = "tool:build:create",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 2,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "tool:build:update",
                  MenuName = "修改",
                  MenuType = 2, // 按钮
                  MenuPerms = "tool:build:update",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 3,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "tool:build:delete",
                  MenuName = "删除",
                  MenuType = 2, // 按钮
                  MenuPerms = "tool:build:delete",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 4,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                },
                new KpMenu
                {
                  MenuCode = "tool:build:export",
                  MenuName = "导出",
                  MenuType = 2, // 按钮
                  MenuPerms = "tool:build:export",
                  MenuParentId = rootMenu.Id,
                  OrderNum = 5,
                  Status = 1,
                  IsActive = 1,
                  CreatedTime = DateTime.Now,
                  UpdatedTime = DateTime.Now,
                  CreatedBy = "Kunpo365",
                  UpdatedBy = "Kunpo365",
                  TenantId = 1
                }
              };

              subMenus.Add(buildMenu);
              subMenus.AddRange(buildButtons);
            }

            // 处理子菜单和按钮权限
            foreach (var menu in subMenus)
            {
              try
              {
                // 检查菜单是否存在
                var existingMenu = _dbContext.Db.Queryable<KpMenu>()
                  .First(m => m.MenuCode == menu.MenuCode);

                if (existingMenu == null)
                {
                  // 菜单不存在，创建新菜单
                  _dbContext.Db.Insertable(menu).ExecuteCommand();
                  _logger.LogInformation("创建菜单: {MenuName} ({MenuCode})", menu.MenuName, menu.MenuCode);
                  createdCount++;
                }
                else
                {
                  // 菜单已存在，更新菜单信息
                  menu.Id = existingMenu.Id;
                  _dbContext.Db.Updateable(menu).ExecuteCommand();
                  _logger.LogInformation("更新菜单: {MenuName} ({MenuCode})", menu.MenuName, menu.MenuCode);
                  updatedCount++;
                }
              }
              catch (Exception ex)
              {
                _logger.LogError(ex, "处理菜单 {MenuName} ({MenuCode}) 失败", menu.MenuName, menu.MenuCode);
                skippedCount++;
              }
            }
          }

          _dbContext.Db.CommitTran();
        }
        catch (Exception ex)
        {
          _dbContext.Db.RollbackTran();
          _logger.LogError(ex, "初始化菜单数据失败");
          throw;
        }

        _logger.LogInformation("菜单数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          createdCount + updatedCount + skippedCount, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "初始化菜单数据失败");
        throw;
      }
    }
  }
}