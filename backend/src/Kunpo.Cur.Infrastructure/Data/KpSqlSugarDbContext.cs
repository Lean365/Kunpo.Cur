// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SqlSugar数据库上下文</summary>
// <remarks>处理SqlSugar数据库的上下文</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using SqlSugar;
using System.Reflection;
using Kunpo.Cur.Common.Options;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Kunpo.Cur.Common.Utils;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Domain.Entities;
using Kunpo.Cur.Domain.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Infrastructure.Data
{
  /// <summary>
  /// SqlSugar数据库上下文
  /// </summary>
  public class KpSqlSugarDbContext
  {
    /// <summary>
    /// 服务提供者
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 日志记录器
    /// </summary>
    private readonly ILogger<KpSqlSugarDbContext> _logger;

    /// <summary>
    /// 数据库配置选项
    /// </summary>
    private readonly KpDatabaseOption _options;

    /// <summary>
    /// 安全上下文
    /// </summary>
    private readonly IKpSecurityContext _securityContext;

    /// <summary>
    /// SqlSugar数据库实例
    /// </summary>
    private SqlSugarScope? _db;

    /// <summary>
    /// 获取数据库实例
    /// </summary>
    public SqlSugarScope? Db
    {
      get
      {
        if (_db == null)
        {
          // 配置数据库连接
          _db = new SqlSugarScope(new ConnectionConfig()
          {
            ConnectionString = _options.ConnectionString,
            DbType = (DbType)_options.DbType,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute,
            ConfigureExternalServices = new ConfigureExternalServices
            {
              EntityService = (property, column) =>
              {
                // 自动处理软删除
                if (property.Name == "IsDeleted")
                {
                  column.IsNullable = false;
                  column.DefaultValue = "0";
                }
              }
            }
          },
          db =>
          {
            // 配置日志
            if (_options.EnableSqlLog)
            {
              db.Aop.OnLogExecuting = (sql, parameters) =>
              {
                _logger.LogDebug("SQL: {Sql}", sql);
                _logger.LogDebug("Parameters: {@Parameters}", parameters);
              };
            }
          });

          // 设置租户过滤
          var tenantId = GetCurrentTenantId();
          if (tenantId.HasValue)
          {
            _logger.LogInformation("设置租户过滤: {TenantId}", tenantId.Value);
            _db.QueryFilter.AddTableFilter<KpBaseEntity>(it => it.TenantId == tenantId.Value);
            _logger.LogInformation("已添加租户过滤条件: TenantId = {TenantId}", tenantId.Value);
          }

          // 添加软删除过滤
          var currentUser = GetCurrentUser();
          if (currentUser?.UserType != 2 && !_options.ShowDeleted) // 如果不是超级管理员且配置不显示已删除数据
          {
            _db.QueryFilter.AddTableFilter<KpBaseEntity>(it => it.IsDeleted == 0);
            _logger.LogInformation("已添加软删除过滤条件: IsDeleted = 0");
          }

          _logger.LogInformation("数据库连接初始化完成");
        }

        return _db;
      }
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="options">数据库配置选项</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="securityContext">安全上下文</param>
    public KpSqlSugarDbContext(
      IServiceProvider serviceProvider,
      ILogger<KpSqlSugarDbContext> logger,
      IOptions<KpDatabaseOption> options,
      IKpSecurityContext securityContext)
    {
      _serviceProvider = serviceProvider;
      _logger = logger;
      _options = options.Value;
      _securityContext = securityContext;

      // 配置数据库连接
      _db = new SqlSugarScope(new ConnectionConfig()
      {
        ConnectionString = _options.ConnectionString,
        DbType = (DbType)_options.DbType,
        IsAutoCloseConnection = true,
        InitKeyType = InitKeyType.Attribute,
        ConfigureExternalServices = new ConfigureExternalServices
        {
          EntityService = (property, column) =>
          {
            // 自动处理软删除
            if (property.Name == "IsDeleted")
            {
              column.IsNullable = false;
              column.DefaultValue = "0";
            }
          }
        }
      },
      db =>
      {
        // 配置日志
        if (_options.EnableSqlLog)
        {
          db.Aop.OnLogExecuting = (sql, parameters) =>
          {
            _logger.LogDebug("SQL: {Sql}", sql);
            _logger.LogDebug("Parameters: {@Parameters}", parameters);
          };
        }
      });
    }

    /// <summary>
    /// 获取当前租户ID
    /// </summary>
    /// <returns>当前租户ID，如果获取失败则返回null</returns>
    private long? GetCurrentTenantId()
    {
      try
      {
        // 获取当前HTTP上下文
        var httpContext = KpHttpContext.Current;
        if (httpContext == null)
        {
          return null;
        }

        // 1. 首先尝试从请求头中获取租户ID
        if (httpContext.Request.Headers.TryGetValue("X-Tenant-Id", out var tenantIdFromHeader))
        {
          if (long.TryParse(tenantIdFromHeader.ToString(), out var tenantId))
          {
            return tenantId;
          }
        }

        // 2. 如果请求头中没有，尝试从用户声明中获取
        var user = httpContext.User;
        if (user?.Identity?.IsAuthenticated == true)
        {
          var tenantClaim = user.FindFirst("TenantId");
          if (tenantClaim != null && long.TryParse(tenantClaim.Value, out var tenantId))
          {
            return tenantId;
          }
        }

        // 3. 如果都没有，返回默认租户ID或null
        return null;
      }
      catch
      {
        // 发生异常时返回null
        return null;
      }
    }

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    private KpUser? GetCurrentUser()
    {
      var userId = _securityContext.GetCurrentUserId();
      if (userId <= 0) return null;

      var userName = _securityContext.GetCurrentUserName();
      if (string.IsNullOrEmpty(userName)) return null;

      return new KpUser
      {
        Id = userId,
        UserName = userName,
        UserType = _securityContext.HasPermission("system:admin") ? 2 : 0 // 如果有系统管理员权限则为超级管理员
      };
    }
  }
}