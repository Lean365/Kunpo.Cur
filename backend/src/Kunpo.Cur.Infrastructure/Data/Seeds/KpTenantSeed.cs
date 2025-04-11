// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户种子数据初始化器</summary>
// <remarks>处理租户种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  /// <summary>
  /// 租户种子数据
  /// </summary>
  public class KpTenantSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;

    public KpTenantSeed(KpSqlSugarDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// 初始化租户数据
    /// </summary>
    public void Initialize()
    {
      _dbContext.Db.BeginTran();
      try
      {
        // 1. 创建租户数据
        var tenants = new List<KpTenant>
        {
          new KpTenant
          {
            TenantCode = "DEFAULT",
            TenantName = "默认租户",
            TenantShortName = "默认",
            TenantDescription = "系统默认租户",
            TenantType = 0, // 企业
            TenantScale = 2, // 大型
            Status = 1, // 启用
            TenantIsTrial = 0, // 非试用
            TenantTrialDays = 0,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365"
          },
          new KpTenant
          {
            TenantCode = "KUNPO",
            TenantName = "昆珀科技",
            TenantShortName = "昆珀",
            TenantDescription = "昆珀科技有限公司",
            TenantType = 0, // 企业
            TenantScale = 2, // 大型
            Status = 1, // 启用
            TenantIsTrial = 0, // 非试用
            TenantTrialDays = 0,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365"
          },
          new KpTenant
          {
            TenantCode = "TEST",
            TenantName = "测试租户",
            TenantShortName = "测试",
            TenantDescription = "测试环境租户",
            TenantType = 0, // 企业
            TenantScale = 1, // 中型
            Status = 1, // 启用
            TenantIsTrial = 1, // 试用
            TenantTrialDays = 30,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365"
          },
          new KpTenant
          {
            TenantCode = "DEMO",
            TenantName = "演示租户",
            TenantShortName = "演示",
            TenantDescription = "演示环境租户",
            TenantType = 0, // 企业
            TenantScale = 1, // 中型
            Status = 1, // 启用
            TenantIsTrial = 1, // 试用
            TenantTrialDays = 15,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365"
          },
          new KpTenant
          {
            TenantCode = "TEMP",
            TenantName = "临时租户",
            TenantShortName = "临时",
            TenantDescription = "临时环境租户",
            TenantType = 0, // 企业
            TenantScale = 0, // 小型
            Status = 1, // 启用
            TenantIsTrial = 1, // 试用
            TenantTrialDays = 7,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365"
          }
        };

        // 2. 保存租户数据
        _dbContext.Db.Insertable(tenants).ExecuteCommand();

        _dbContext.Db.CommitTran();
      }
      catch (Exception ex)
      {
        _dbContext.Db.RollbackTran();
        Console.WriteLine($"初始化租户数据失败: {ex.Message}");
        throw;
      }
    }
  }
}