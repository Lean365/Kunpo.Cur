// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>数据库初始化器</summary>
// <remarks>处理数据库的初始化、迁移和种子数据等操作</remarks>
// -----------------------------------------------------------------------

using SqlSugar;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Kunpo.Cur.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Options;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Domain.Entities;
using System.IO;
using System.Collections.Generic;

namespace Kunpo.Cur.Infrastructure.Data
{
  /// <summary>
  /// 数据库初始化器
  /// </summary>
  public class KpDbInitializer
  {
    /// <summary>
    /// 服务提供者
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 日志记录器
    /// </summary>
    private readonly ILogger<KpDbInitializer> _logger;

    /// <summary>
    /// 数据库配置选项
    /// </summary>
    private readonly KpDatabaseOption _options;

    /// <summary>
    /// 数据库上下文
    /// </summary>
    private readonly KpSqlSugarDbContext _dbContext;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="logger">日志记录器</param>
    /// <param name="options">数据库配置选项</param>
    /// <param name="dbContext">数据库上下文</param>
    public KpDbInitializer(
      IServiceProvider serviceProvider,
      ILogger<KpDbInitializer> logger,
      IOptions<KpDatabaseOption> options,
      KpSqlSugarDbContext dbContext)
    {
      _serviceProvider = serviceProvider;
      _logger = logger;
      _options = options.Value;
      _dbContext = dbContext;
    }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    /// <remarks>
    /// 1. 初始化数据库
    /// 2. 初始化数据表
    /// 3. 初始化种子数据
    /// </remarks>
    public void Initialize()
    {
      try
      {
        _logger.LogInformation("开始自动迁移数据库...");
        _logger.LogInformation("数据库初始化配置: EnableInitData = {EnableInitData}, EnableInitSeedsData = {EnableInitSeedsData}",
          _options.EnableInitData, _options.EnableInitSeedsData);

        // 1. 初始化数据库和表结构
        if (_options.EnableInitData)
        {
          // 检查数据库连接是否可用
          if (_dbContext.Db == null)
          {
            _logger.LogInformation("数据库连接不可用，跳过数据库初始化");
          }
          else
          {
            // 初始化数据库
            _logger.LogInformation("开始初始化数据库...");
            InitializeDatabase();
            _logger.LogInformation("数据库初始化完成");

            // 初始化数据表
            _logger.LogInformation("开始初始化数据表...");
            InitializeTables();
            _logger.LogInformation("数据表初始化完成");
          }
        }
        else
        {
          _logger.LogInformation("跳过数据库和表结构初始化 (EnableInitData = false)");
        }

        // 2. 初始化种子数据
        if (_options.EnableInitSeedsData)
        {
          // 检查数据库连接是否可用
          if (_dbContext.Db == null)
          {
            _logger.LogError("数据库连接不可用，无法初始化种子数据");
            return;
          }

          _logger.LogInformation("开始初始化种子数据...");
          InitializeSeeds();
          _logger.LogInformation("种子数据初始化完成");
        }
        else
        {
          _logger.LogInformation("跳过种子数据初始化 (EnableInitSeedsData = false)");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "数据库初始化失败");
        throw;
      }
    }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    private void InitializeDatabase()
    {
      try
      {
        // 检查数据库连接是否可用
        if (_dbContext.Db == null)
        {
          _logger.LogInformation("数据库连接不可用，跳过数据库初始化");
          return;
        }

        // 创建数据库
        _dbContext.Db.DbMaintenance.CreateDatabase();
        _logger.LogInformation("数据库创建完成");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "数据库初始化失败");
        throw;
      }
    }

    /// <summary>
    /// 初始化数据表
    /// </summary>
    /// <remarks>
    /// 1. 创建数据库
    /// 2. 获取所有实体类型
    /// 3. 创建表结构
    /// 4. 初始化数据表
    /// </remarks>
    private void InitializeTables()
    {
      try
      {
        // 检查数据库连接是否可用
        if (_dbContext.Db == null)
        {
          _logger.LogInformation("数据库连接不可用，跳过数据表初始化");
          return;
        }

        // 获取当前目录下的所有DLL
        var dllFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
          .Where(f => Path.GetFileName(f).StartsWith("Kunpo.Cur"))
          .ToList();

        _logger.LogInformation("找到 {Count} 个DLL文件", dllFiles.Count);

        // 加载所有程序集
        var assemblies = new List<Assembly>();
        foreach (var dllFile in dllFiles)
        {
          try
          {
            var assembly = Assembly.LoadFrom(dllFile);
            assemblies.Add(assembly);
            _logger.LogInformation("加载程序集: {AssemblyName}", assembly.FullName);
          }
          catch (Exception ex)
          {
            _logger.LogError(ex, "加载程序集 {DllFile} 失败", dllFile);
          }
        }

        // 确保所有程序集都已加载
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
          .Where(a => a.FullName?.StartsWith("Kunpo.Cur") == true)
          .ToList();

        _logger.LogInformation("当前已加载 {Count} 个程序集", loadedAssemblies.Count);
        foreach (var assembly in loadedAssemblies)
        {
          _logger.LogInformation("已加载程序集: {AssemblyName}", assembly.FullName);
        }

        // 获取所有实体类型
        var entityTypes = loadedAssemblies
          .SelectMany(a => a.GetTypes())
          .Where(t => t.IsClass &&
                     !t.IsAbstract &&
                     t != typeof(KpBaseEntity) &&
                     typeof(KpBaseEntity).IsAssignableFrom(t))
          .ToList();

        _logger.LogInformation("扫描到 {Count} 个实体类型需要初始化", entityTypes.Count);

        // 记录所有找到的实体类型
        foreach (var entityType in entityTypes)
        {
          _logger.LogInformation("实体类型: {TypeName} ({Namespace})", entityType.Name, entityType.Namespace);
        }

        int createdCount = 0;
        int updatedCount = 0;
        int skippedCount = 0;

        // 初始化每个实体对应的表
        foreach (var entityType in entityTypes)
        {
          try
          {
            var tableName = entityType.Name;
            var tableExists = _dbContext.Db.DbMaintenance.IsAnyTable(tableName);

            if (!tableExists)
            {
              // 表不存在，创建新表
              _dbContext.Db.CodeFirst.InitTables(entityType);
              _logger.LogInformation("创建表: {TableName}", tableName);
              createdCount++;
            }
            else
            {
              // 表已存在，更新表结构
              _dbContext.Db.CodeFirst.InitTables(entityType);
              _logger.LogInformation("更新表: {TableName}", tableName);
              updatedCount++;
            }
          }
          catch (Exception ex)
          {
            _logger.LogError(ex, "初始化表 {TableName} 失败", entityType.Name);
            skippedCount++;
          }
        }

        _logger.LogInformation("数据表初始化完成，共处理 {Total} 个表，其中创建 {Created} 个，更新 {Updated} 个，跳过 {Skipped} 个",
          entityTypes.Count, createdCount, updatedCount, skippedCount);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "数据表初始化失败");
        throw;
      }
    }

    /// <summary>
    /// 初始化种子数据
    /// </summary>
    private void InitializeSeeds()
    {
      try
      {
        // 如果EnableInitSeedsData为false，直接返回
        if (!_options.EnableInitSeedsData)
        {
          _logger.LogInformation("跳过种子数据初始化 (EnableInitSeedsData = false)");
          return;
        }

        var seedInitializer = _serviceProvider.GetRequiredService<KpSeedInitializer>();
        seedInitializer.Initialize();
        _logger.LogInformation("种子数据初始化完成");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "种子数据初始化失败");
        throw;
      }
    }
  }
}