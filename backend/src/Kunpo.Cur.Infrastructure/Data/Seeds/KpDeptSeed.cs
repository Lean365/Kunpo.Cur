// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>部门种子数据初始化器</summary>
// <remarks>处理部门种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  public class KpDeptSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly ILogger<KpDeptSeed> _logger;

    public KpDeptSeed(KpSqlSugarDbContext dbContext, ILogger<KpDeptSeed> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }

    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化部门数据...");

        int createdCount = 0;
        int updatedCount = 0;
        int skippedCount = 0;

        _dbContext.Db.BeginTran();

        try
        {
          // 1. 创建总公司
          var rootDept = new KpDept
          {
            DeptName = "昆珀科技集团",
            DeptCode = "HQ",
            OrderNum = 1,
            Status = 1,
            DeptParentId = 0, // 顶级部门
            DeptLevel = 1,
            DeptAncestors = "0",
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          };

          // 检查总公司是否存在
          var existingRootDept = _dbContext.Db.Queryable<KpDept>()
            .First(d => d.DeptCode == rootDept.DeptCode);

          if (existingRootDept == null)
          {
            // 总公司不存在，创建新部门
            _dbContext.Db.Insertable(rootDept).ExecuteCommand();
            _logger.LogInformation("创建部门: {DeptName} ({DeptCode})", rootDept.DeptName, rootDept.DeptCode);
            createdCount++;
          }
          else
          {
            // 总公司已存在，更新部门信息
            rootDept.Id = existingRootDept.Id;
            _dbContext.Db.Updateable(rootDept).ExecuteCommand();
            _logger.LogInformation("更新部门: {DeptName} ({DeptCode})", rootDept.DeptName, rootDept.DeptCode);
            updatedCount++;
          }

          // 获取已保存的总公司
          var savedRootDept = _dbContext.Db.Queryable<KpDept>()
            .First(d => d.DeptCode == "HQ");

          // 2. 创建子公司
          var subCompanies = new List<KpDept>
          {
            new KpDept
            {
              DeptName = "昆珀软件",
              DeptCode = "KPSOFT",
              OrderNum = 1,
              Status = 1,
              DeptParentId = savedRootDept.Id,
              DeptLevel = savedRootDept.DeptLevel + 1,
              DeptAncestors = $"{savedRootDept.DeptAncestors},{savedRootDept.Id}",
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            },
            new KpDept
            {
              DeptName = "昆珀智能",
              DeptCode = "KPINT",
              OrderNum = 2,
              Status = 1,
              DeptParentId = savedRootDept.Id,
              DeptLevel = savedRootDept.DeptLevel + 1,
              DeptAncestors = $"{savedRootDept.DeptAncestors},{savedRootDept.Id}",
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            },
            new KpDept
            {
              DeptName = "昆珀数据",
              DeptCode = "KPDATA",
              OrderNum = 3,
              Status = 1,
              DeptParentId = savedRootDept.Id,
              DeptLevel = savedRootDept.DeptLevel + 1,
              DeptAncestors = $"{savedRootDept.DeptAncestors},{savedRootDept.Id}",
              CreatedTime = DateTime.Now,
              UpdatedTime = DateTime.Now,
              CreatedBy = "Kunpo365",
              UpdatedBy = "Kunpo365",
              TenantId = 1
            }
          };

          // 处理子公司
          foreach (var dept in subCompanies)
          {
            try
            {
              // 检查部门是否存在
              var existingDept = _dbContext.Db.Queryable<KpDept>()
                .First(d => d.DeptCode == dept.DeptCode);

              if (existingDept == null)
              {
                // 部门不存在，创建新部门
                _dbContext.Db.Insertable(dept).ExecuteCommand();
                _logger.LogInformation("创建部门: {DeptName} ({DeptCode})", dept.DeptName, dept.DeptCode);
                createdCount++;
              }
              else
              {
                // 部门已存在，更新部门信息
                dept.Id = existingDept.Id;
                _dbContext.Db.Updateable(dept).ExecuteCommand();
                _logger.LogInformation("更新部门: {DeptName} ({DeptCode})", dept.DeptName, dept.DeptCode);
                updatedCount++;
              }
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "处理部门 {DeptName} ({DeptCode}) 失败", dept.DeptName, dept.DeptCode);
              skippedCount++;
            }
          }

          // 获取已保存的子公司
          var savedSubCompanies = _dbContext.Db.Queryable<KpDept>()
            .Where(d => new[] { "KPSOFT", "KPINT", "KPDATA" }.Contains(d.DeptCode))
            .ToList();

          // 3. 创建各部门
          foreach (var subCompany in savedSubCompanies)
          {
            var departments = new List<KpDept>
            {
              new KpDept
              {
                DeptName = "研发部",
                DeptCode = $"{subCompany.DeptCode}-RD",
                OrderNum = 1,
                Status = 1,
                DeptParentId = subCompany.Id,
                DeptLevel = subCompany.DeptLevel + 1,
                DeptAncestors = $"{subCompany.DeptAncestors},{subCompany.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              },
              new KpDept
              {
                DeptName = "市场部",
                DeptCode = $"{subCompany.DeptCode}-MKT",
                OrderNum = 2,
                Status = 1,
                DeptParentId = subCompany.Id,
                DeptLevel = subCompany.DeptLevel + 1,
                DeptAncestors = $"{subCompany.DeptAncestors},{subCompany.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              },
              new KpDept
              {
                DeptName = "财务部",
                DeptCode = $"{subCompany.DeptCode}-FIN",
                OrderNum = 3,
                Status = 1,
                DeptParentId = subCompany.Id,
                DeptLevel = subCompany.DeptLevel + 1,
                DeptAncestors = $"{subCompany.DeptAncestors},{subCompany.Id}",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                CreatedBy = "Kunpo365",
                UpdatedBy = "Kunpo365",
                TenantId = 1
              }
            };

            // 处理部门
            foreach (var dept in departments)
            {
              try
              {
                // 检查部门是否存在
                var existingDept = _dbContext.Db.Queryable<KpDept>()
                  .First(d => d.DeptCode == dept.DeptCode);

                if (existingDept == null)
                {
                  // 部门不存在，创建新部门
                  _dbContext.Db.Insertable(dept).ExecuteCommand();
                  _logger.LogInformation("创建部门: {DeptName} ({DeptCode})", dept.DeptName, dept.DeptCode);
                  createdCount++;
                }
                else
                {
                  // 部门已存在，更新部门信息
                  dept.Id = existingDept.Id;
                  _dbContext.Db.Updateable(dept).ExecuteCommand();
                  _logger.LogInformation("更新部门: {DeptName} ({DeptCode})", dept.DeptName, dept.DeptCode);
                  updatedCount++;
                }
              }
              catch (Exception ex)
              {
                _logger.LogError(ex, "处理部门 {DeptName} ({DeptCode}) 失败", dept.DeptName, dept.DeptCode);
                skippedCount++;
              }
            }
          }

          _dbContext.Db.CommitTran();
        }
        catch (Exception ex)
        {
          _dbContext.Db.RollbackTran();
          _logger.LogError(ex, "初始化部门数据失败");
          throw;
        }

        _logger.LogInformation("部门数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          createdCount + updatedCount + skippedCount, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "初始化部门数据失败");
        throw;
      }
    }
  }
}