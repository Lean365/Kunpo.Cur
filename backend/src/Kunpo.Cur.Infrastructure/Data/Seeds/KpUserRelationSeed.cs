// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户关联种子数据初始化器</summary>
// <remarks>处理用户关联种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  /// <summary>
  /// 用户关联种子数据
  /// </summary>
  public class KpUserRelationSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;

    public KpUserRelationSeed(KpSqlSugarDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// 初始化用户关联数据
    /// </summary>
    public void Initialize()
    {
      _dbContext.Db.BeginTran();

      try
      {
        // 1. 获取所有用户
        var users = _dbContext.Db.Queryable<KpUser>()
          .Where(u => u.TenantId == 1)
          .ToList();
        var adminUser = users.Find(u => u.UserName == "admin");
        var sysAdminUser = users.Find(u => u.UserName == "sysadmin");
        var deptAdminUser = users.Find(u => u.UserName == "deptadmin");
        var normalUser = users.Find(u => u.UserName == "user");
        var guestUser = users.Find(u => u.UserName == "guest");

        // 2. 获取所有角色
        var roles = _dbContext.Db.Queryable<KpRole>()
          .Where(r => r.TenantId == 1)
          .ToList();
        var superAdminRole = roles.Find(r => r.RoleCode == "SUPER_ADMIN");
        var sysAdminRole = roles.Find(r => r.RoleCode == "SYS_ADMIN");
        var deptAdminRole = roles.Find(r => r.RoleCode == "DEPT_ADMIN");
        var userRole = roles.Find(r => r.RoleCode == "USER");
        var guestRole = roles.Find(r => r.RoleCode == "GUEST");

        // 3. 获取所有部门
        var depts = _dbContext.Db.Queryable<KpDept>()
          .Where(d => d.TenantId == 1)
          .ToList();
        var hqDept = depts.Find(d => d.DeptCode == "HQ");
        var kpsoftDept = depts.Find(d => d.DeptCode == "KPSOFT");
        var kpintDept = depts.Find(d => d.DeptCode == "KPINT");
        var kpdataDept = depts.Find(d => d.DeptCode == "KPDATA");

        // 4. 获取所有岗位
        var posts = _dbContext.Db.Queryable<KpPost>()
          .Where(p => p.TenantId == 1)
          .ToList();
        var ceoPost = posts.Find(p => p.PostCode == "CEO");
        var ctoPost = posts.Find(p => p.PostCode == "CTO");
        var pmPost = posts.Find(p => p.PostCode == "PM");
        var devPost = posts.Find(p => p.PostCode == "DEV");
        var testPost = posts.Find(p => p.PostCode == "TEST");

        // 5. 获取所有菜单
        var menus = _dbContext.Db.Queryable<KpMenu>()
          .Where(m => m.TenantId == 1)
          .ToList();

        // 6. 创建用户-角色关联数据
        var userRoles = new List<KpUserRole>();
        if (adminUser != null && superAdminRole != null)
        {
          userRoles.Add(new KpUserRole
          {
            UserId = adminUser.Id,
            RoleId = superAdminRole.Id,
            IsActive = 1
          });
        }
        if (sysAdminUser != null && sysAdminRole != null)
        {
          userRoles.Add(new KpUserRole
          {
            UserId = sysAdminUser.Id,
            RoleId = sysAdminRole.Id,
            IsActive = 1
          });
        }
        if (deptAdminUser != null && deptAdminRole != null)
        {
          userRoles.Add(new KpUserRole
          {
            UserId = deptAdminUser.Id,
            RoleId = deptAdminRole.Id,
            IsActive = 1
          });
        }
        if (normalUser != null && userRole != null)
        {
          userRoles.Add(new KpUserRole
          {
            UserId = normalUser.Id,
            RoleId = userRole.Id,
            IsActive = 1
          });
        }
        if (guestUser != null && guestRole != null)
        {
          userRoles.Add(new KpUserRole
          {
            UserId = guestUser.Id,
            RoleId = guestRole.Id,
            IsActive = 1
          });
        }

        // 7. 创建用户-部门关联数据
        var userDepts = new List<KpUserDept>();
        if (adminUser != null && hqDept != null)
        {
          userDepts.Add(new KpUserDept
          {
            UserId = adminUser.Id,
            DeptId = hqDept.Id,
            IsActive = 1
          });
        }
        if (sysAdminUser != null && kpsoftDept != null)
        {
          userDepts.Add(new KpUserDept
          {
            UserId = sysAdminUser.Id,
            DeptId = kpsoftDept.Id,
            IsActive = 1
          });
        }
        if (deptAdminUser != null && kpintDept != null)
        {
          userDepts.Add(new KpUserDept
          {
            UserId = deptAdminUser.Id,
            DeptId = kpintDept.Id,
            IsActive = 1
          });
        }
        if (normalUser != null && kpdataDept != null)
        {
          userDepts.Add(new KpUserDept
          {
            UserId = normalUser.Id,
            DeptId = kpdataDept.Id,
            IsActive = 1
          });
        }
        if (guestUser != null && hqDept != null)
        {
          userDepts.Add(new KpUserDept
          {
            UserId = guestUser.Id,
            DeptId = hqDept.Id,
            IsActive = 1
          });
        }

        // 8. 创建用户-岗位关联数据
        var userPosts = new List<KpUserPost>();
        if (adminUser != null && ceoPost != null)
        {
          userPosts.Add(new KpUserPost
          {
            UserId = adminUser.Id,
            PostId = ceoPost.Id,
            IsActive = 1
          });
        }
        if (sysAdminUser != null && ctoPost != null)
        {
          userPosts.Add(new KpUserPost
          {
            UserId = sysAdminUser.Id,
            PostId = ctoPost.Id,
            IsActive = 1
          });
        }
        if (deptAdminUser != null && pmPost != null)
        {
          userPosts.Add(new KpUserPost
          {
            UserId = deptAdminUser.Id,
            PostId = pmPost.Id,
            IsActive = 1
          });
        }
        if (normalUser != null && devPost != null)
        {
          userPosts.Add(new KpUserPost
          {
            UserId = normalUser.Id,
            PostId = devPost.Id,
            IsActive = 1
          });
        }
        if (guestUser != null && testPost != null)
        {
          userPosts.Add(new KpUserPost
          {
            UserId = guestUser.Id,
            PostId = testPost.Id,
            IsActive = 1
          });
        }

        // 9. 创建角色-菜单关联数据
        var roleMenus = new List<KpRoleMenu>();

        // 9.1 超级管理员角色 - 拥有所有菜单权限
        if (superAdminRole != null)
        {
          foreach (var menu in menus)
          {
            roleMenus.Add(new KpRoleMenu
            {
              RoleId = superAdminRole.Id,
              MenuId = menu.Id,
              IsActive = 1
            });
          }
        }

        // 9.2 系统管理员角色 - 拥有系统管理和监控中心权限
        if (sysAdminRole != null)
        {
          var systemMenus = menus.FindAll(m => m.MenuCode.StartsWith("system") || m.MenuCode.StartsWith("monitor"));
          foreach (var menu in systemMenus)
          {
            roleMenus.Add(new KpRoleMenu
            {
              RoleId = sysAdminRole.Id,
              MenuId = menu.Id,
              IsActive = 1
            });
          }
        }

        // 9.3 部门管理员角色 - 拥有部门管理和用户管理权限
        if (deptAdminRole != null)
        {
          var deptMenus = menus.FindAll(m => m.MenuCode == "system:dept" || m.MenuCode == "system:user");
          foreach (var menu in deptMenus)
          {
            roleMenus.Add(new KpRoleMenu
            {
              RoleId = deptAdminRole.Id,
              MenuId = menu.Id,
              IsActive = 1
            });
          }
        }

        // 9.4 普通用户角色 - 拥有基本功能权限
        if (userRole != null)
        {
          var userMenus = menus.FindAll(m =>
            m.MenuCode == "system:notice" ||
            m.MenuCode == "system:config" ||
            m.MenuCode == "monitor:online"
          );
          foreach (var menu in userMenus)
          {
            roleMenus.Add(new KpRoleMenu
            {
              RoleId = userRole.Id,
              MenuId = menu.Id,
              IsActive = 1
            });
          }
        }

        // 9.5 访客角色 - 只拥有通知公告权限
        if (guestRole != null)
        {
          var guestMenu = menus.Find(m => m.MenuCode == "system:notice");
          if (guestMenu != null)
          {
            roleMenus.Add(new KpRoleMenu
            {
              RoleId = guestRole.Id,
              MenuId = guestMenu.Id,
              IsActive = 1
            });
          }
        }

        // 10. 保存所有关联数据
        _dbContext.Db.Insertable(userRoles).ExecuteCommand();
        _dbContext.Db.Insertable(userDepts).ExecuteCommand();
        _dbContext.Db.Insertable(userPosts).ExecuteCommand();
        _dbContext.Db.Insertable(roleMenus).ExecuteCommand();

        _dbContext.Db.CommitTran();
      }
      catch (Exception ex)
      {
        _dbContext.Db.RollbackTran();
        Console.WriteLine($"初始化用户关联数据失败: {ex.Message}");
        throw;
      }
    }
  }
}