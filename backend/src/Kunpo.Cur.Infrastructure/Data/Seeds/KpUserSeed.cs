// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户种子数据初始化器</summary>
// <remarks>处理用户种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Utils;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.Infrastructure.Data.Seeds
{
  /// <summary>
  /// 用户种子数据
  /// </summary>
  public class KpUserSeed
  {
    private readonly KpSqlSugarDbContext _dbContext;
    private readonly ILogger<KpUserSeed> _logger;

    public KpUserSeed(KpSqlSugarDbContext dbContext, ILogger<KpUserSeed> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }

    /// <summary>
    /// 初始化用户数据
    /// </summary>
    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化用户数据...");

        // 1. 创建用户数据
        var users = new List<KpUser>
        {
          new KpUser
          {
            UserName = "admin",
            UserNickName = "管理员",
            UserType = 2,
            Status = 1,
            UserIsLocked = 0,
            UserLoginFailCount = 0,
            UserPassword = "admin123",
            UserSalt = "salt",
            UserPasswordExpireTime = DateTime.Now.AddMonths(3)
          },
          new KpUser
          {
            UserName = "user",
            UserNickName = "普通用户",
            UserType = 0,
            Status = 1,
            UserIsLocked = 0,
            UserLoginFailCount = 0,
            UserPassword = "user123",
            UserSalt = "salt",
            UserPasswordExpireTime = DateTime.Now.AddMonths(3)
          },
          new KpUser
          {
            UserName = "manager",
            UserNickName = "经理",
            UserType = 1,
            Status = 1,
            UserIsLocked = 0,
            UserLoginFailCount = 0,
            UserPassword = "manager123",
            UserSalt = "salt",
            UserPasswordExpireTime = DateTime.Now.AddMonths(3)
          },
          new KpUser
          {
            UserName = "test",
            UserNickName = "测试用户",
            UserType = 0,
            Status = 1,
            UserIsLocked = 0,
            UserLoginFailCount = 0,
            UserPassword = "test123",
            UserSalt = "salt",
            UserPasswordExpireTime = DateTime.Now.AddMonths(3)
          }
        };

        int createdCount = 0;
        int updatedCount = 0;
        int skippedCount = 0;

        _dbContext.Db.BeginTran();

        try
        {
          foreach (var user in users)
          {
            try
            {
              // 检查用户是否存在
              var existingUser = _dbContext.Db.Queryable<KpUser>()
                .First(u => u.UserName == user.UserName);

              if (existingUser == null)
              {
                // 用户不存在，创建新用户
                var (hash, salt) = KpPasswordHelper.GenerateHashAndSalt("123456");
                user.UserSalt = salt;
                user.UserPassword = hash;
                _dbContext.Db.Insertable(user).ExecuteCommand();
                _logger.LogInformation("创建用户: {UserName}", user.UserName);
                createdCount++;
              }
              else
              {
                // 用户已存在，更新用户信息
                user.Id = existingUser.Id;
                user.UserSalt = existingUser.UserSalt;
                user.UserPassword = existingUser.UserPassword;
                _dbContext.Db.Updateable(user).ExecuteCommand();
                _logger.LogInformation("更新用户: {UserName}", user.UserName);
                updatedCount++;
              }
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "处理用户 {UserName} 失败", user.UserName);
              skippedCount++;
            }
          }

          _dbContext.Db.CommitTran();
        }
        catch (Exception ex)
        {
          _dbContext.Db.RollbackTran();
          _logger.LogError(ex, "初始化用户数据失败");
          throw;
        }

        _logger.LogInformation("用户数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          createdCount + updatedCount + skippedCount, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "初始化用户数据失败");
        throw;
      }
    }
  }
}