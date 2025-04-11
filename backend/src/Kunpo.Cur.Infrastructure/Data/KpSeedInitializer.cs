// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>种子数据初始化器</summary>
// <remarks>处理种子数据的初始化、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Kunpo.Cur.Infrastructure.Data.Seeds;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Kunpo.Cur.Infrastructure.Data
{
  /// <summary>
  /// 种子数据初始化器
  /// </summary>
  public class KpSeedInitializer
  {
    /// <summary>
    /// 数据库上下文
    /// </summary>
    private readonly KpSqlSugarDbContext _dbContext;

    /// <summary>
    /// 日志记录器
    /// </summary>
    private readonly ILogger<KpSeedInitializer> _logger;

    /// <summary>
    /// 服务提供者
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="dbContext">数据库上下文</param>
    /// <param name="logger">日志记录器</param>
    /// <param name="serviceProvider">服务提供者</param>
    public KpSeedInitializer(
      KpSqlSugarDbContext dbContext,
      ILogger<KpSeedInitializer> logger,
      IServiceProvider serviceProvider)
    {
      _dbContext = dbContext;
      _logger = logger;
      _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// 初始化种子数据
    /// </summary>
    /// <remarks>
    /// 按照以下顺序初始化数据：
    /// 1. 租户数据
    /// 2. 部门数据
    /// 3. 角色数据
    /// 4. 岗位数据
    /// 5. 菜单数据
    /// 6. 用户数据
    /// 7. 用户关联数据
    /// </remarks>
    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始初始化种子数据...");

        // 获取所有种子类
        var seedTypes = AppDomain.CurrentDomain.GetAssemblies()
          .SelectMany(a => a.GetTypes())
          .Where(t => t.IsClass &&
                     !t.IsAbstract &&
                     t.Namespace?.Contains("Seeds") == true &&
                     t.Name.EndsWith("Seed"))
          .ToList();

        _logger.LogInformation("找到 {Count} 个种子类", seedTypes.Count);

        // 记录所有找到的种子类
        foreach (var seedType in seedTypes)
        {
          _logger.LogInformation("种子类: {TypeName} ({Namespace})", seedType.Name, seedType.Namespace);
        }

        int totalCreated = 0;
        int totalUpdated = 0;
        int totalSkipped = 0;

        foreach (var seedType in seedTypes)
        {
          try
          {
            _logger.LogInformation("开始初始化 {SeedName}", seedType.Name);

            // 使用服务提供者创建种子类实例
            var seed = _serviceProvider.GetService(seedType);
            if (seed == null)
            {
              _logger.LogError("创建种子类实例失败: {SeedName}", seedType.Name);
              totalSkipped++;
              continue;
            }

            // 调用初始化方法
            var initializeMethod = seedType.GetMethod("Initialize");
            if (initializeMethod == null)
            {
              _logger.LogError("未找到Initialize方法: {SeedName}", seedType.Name);
              totalSkipped++;
              continue;
            }

            // 执行初始化
            initializeMethod.Invoke(seed, null);
            _logger.LogInformation("完成初始化 {SeedName}", seedType.Name);
          }
          catch (Exception ex)
          {
            _logger.LogError(ex, "初始化 {SeedName} 失败", seedType.Name);
            totalSkipped++;
          }
        }

        _logger.LogInformation("种子数据初始化完成，共处理 {Total} 条数据，其中创建 {Created} 条，更新 {Updated} 条，跳过 {Skipped} 条",
          totalCreated + totalUpdated + totalSkipped, totalCreated, totalUpdated, totalSkipped);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "种子数据初始化失败");
        throw;
      }
    }
  }
}