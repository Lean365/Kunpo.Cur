// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色种子数据初始化器</summary>
// <remarks>处理角色种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Infrastructure.Data;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  public class KpRoleSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly ILogger<KpRoleSeed> _logger;

    public KpRoleSeed(KpSqlSugarDbContext dbContext, ILogger<KpRoleSeed> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }

    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化角色数据...");

        var roles = new List<KpRole>
        {
          new KpRole
          {
            RoleName = "超级管理员",
            RoleCode = "SUPER_ADMIN",
            RoleDesc = "系统超级管理员，拥有所有权限",
            OrderNum = 1,
            Status = 1,
            DataScope = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpRole
          {
            RoleName = "管理员",
            RoleCode = "SYS_ADMIN",
            RoleDesc = "系统管理员，拥有大部分权限",
            OrderNum = 2,
            Status = 1,
            DataScope = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpRole
          {
            RoleName = "普通用户",
            RoleCode = "USER",
            RoleDesc = "普通用户，拥有基本权限",
            OrderNum = 3,
            Status = 1,
            DataScope = 3,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          }
        };

        int createdCount = 0;
        int updatedCount = 0;
        int skippedCount = 0;

        _dbContext.Db.BeginTran();

        try
        {
          foreach (var role in roles)
          {
            try
            {
              // 检查角色是否存在
              var existingRole = _dbContext.Db.Queryable<KpRole>()
                .First(r => r.RoleCode == role.RoleCode);

              if (existingRole == null)
              {
                // 角色不存在，创建新角色
                _dbContext.Db.Insertable(role).ExecuteCommand();
                _logger.LogInformation("创建角色: {RoleName} ({RoleCode})", role.RoleName, role.RoleCode);
                createdCount++;
              }
              else
              {
                // 角色已存在，更新角色信息
                role.Id = existingRole.Id;
                _dbContext.Db.Updateable(role).ExecuteCommand();
                _logger.LogInformation("更新角色: {RoleName} ({RoleCode})", role.RoleName, role.RoleCode);
                updatedCount++;
              }
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "处理角色 {RoleName} ({RoleCode}) 失败", role.RoleName, role.RoleCode);
              skippedCount++;
            }
          }

          _dbContext.Db.CommitTran();
        }
        catch (Exception ex)
        {
          _dbContext.Db.RollbackTran();
          _logger.LogError(ex, "初始化角色数据失败");
          throw;
        }

        _logger.LogInformation("角色数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          createdCount + updatedCount + skippedCount, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "初始化角色数据失败");
        throw;
      }
    }
  }
}