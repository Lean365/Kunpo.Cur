// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>岗位种子数据初始化器</summary>
// <remarks>处理岗位种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  /// <summary>
  /// 岗位种子数据
  /// </summary>
  public class KpPostSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly ILogger<KpPostSeed> _logger;

    public KpPostSeed(KpSqlSugarDbContext dbContext, ILogger<KpPostSeed> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }

    /// <summary>
    /// 初始化岗位数据
    /// </summary>
    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化岗位数据...");

        // 1. 创建岗位数据
        var posts = new List<KpPost>
        {
          new KpPost
          {
            PostCode = "CEO",
            PostName = "首席执行官",
            PostDesc = "公司最高管理者，负责公司整体运营",
            OrderNum = 1,
            Status = 1,
            PostLevel = 6, // 首席专家
            PostSequence = 0, // 管理序列
            IsActive = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpPost
          {
            PostCode = "CTO",
            PostName = "首席技术官",
            PostDesc = "公司技术负责人，负责技术战略和研发管理",
            OrderNum = 2,
            Status = 1,
            PostLevel = 6, // 首席专家
            PostSequence = 1, // 技术序列
            IsActive = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpPost
          {
            PostCode = "PM",
            PostName = "项目经理",
            PostDesc = "负责项目管理和团队协调",
            OrderNum = 3,
            Status = 1,
            PostLevel = 4, // 资深专家
            PostSequence = 1, // 技术序列
            IsActive = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpPost
          {
            PostCode = "DEV",
            PostName = "开发工程师",
            PostDesc = "负责系统开发和维护",
            OrderNum = 4,
            Status = 1,
            PostLevel = 3, // 高级专家
            PostSequence = 1, // 技术序列
            IsActive = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            CreatedBy = "Kunpo365",
            UpdatedBy = "Kunpo365",
            TenantId = 1
          },
          new KpPost
          {
            PostCode = "TEST",
            PostName = "测试工程师",
            PostDesc = "负责系统测试和质量保证",
            OrderNum = 5,
            Status = 1,
            PostLevel = 3, // 高级专家
            PostSequence = 1, // 技术序列
            IsActive = 1,
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
          foreach (var post in posts)
          {
            try
            {
              // 检查岗位是否存在
              var existingPost = _dbContext.Db.Queryable<KpPost>()
                .First(p => p.PostCode == post.PostCode);

              if (existingPost == null)
              {
                // 岗位不存在，创建新岗位
                _dbContext.Db.Insertable(post).ExecuteCommand();
                _logger.LogInformation("创建岗位: {PostName} ({PostCode})", post.PostName, post.PostCode);
                createdCount++;
              }
              else
              {
                // 岗位已存在，更新岗位信息
                post.Id = existingPost.Id;
                _dbContext.Db.Updateable(post).ExecuteCommand();
                _logger.LogInformation("更新岗位: {PostName} ({PostCode})", post.PostName, post.PostCode);
                updatedCount++;
              }
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "处理岗位 {PostName} ({PostCode}) 失败", post.PostName, post.PostCode);
              skippedCount++;
            }
          }

          _dbContext.Db.CommitTran();
        }
        catch (Exception ex)
        {
          _dbContext.Db.RollbackTran();
          _logger.LogError(ex, "初始化岗位数据失败");
          throw;
        }

        _logger.LogInformation("岗位数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          createdCount + updatedCount + skippedCount, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "初始化岗位数据失败");
        throw;
      }
    }
  }
}