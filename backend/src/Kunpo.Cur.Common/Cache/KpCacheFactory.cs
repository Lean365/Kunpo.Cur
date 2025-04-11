// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>缓存工厂类</summary>
// <remarks>处理缓存的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Options;

namespace Kunpo.Cur.Common.Cache
{
  /// <summary>
  /// 缓存工厂类
  /// </summary>
  public static class KpCacheFactory
  {
    /// <summary>
    /// 添加缓存服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <param name="configuration">配置</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddKpCache(this IServiceCollection services, IConfiguration configuration)
    {
      // 配置选项
      services.Configure<KpCacheOption>(configuration.GetSection("Cache"));
      var options = configuration.GetSection("Cache").Get<KpCacheOption>();

      // 添加内存缓存
      services.AddMemoryCache();

      // 根据配置添加Redis缓存
      if (options?.Type?.ToLower() == "redis" && !string.IsNullOrEmpty(options.Redis.ConnectionString))
      {
        services.AddStackExchangeRedisCache(redisOptions =>
        {
          redisOptions.Configuration = options.Redis.ConnectionString;
          if (!string.IsNullOrEmpty(options.Redis.InstanceName))
          {
            redisOptions.InstanceName = options.Redis.InstanceName;
          }
        });
      }

      // 注册缓存接口
      services.AddSingleton<IKpCache>(sp =>
      {
        var cacheOptions = sp.GetRequiredService<IOptions<KpCacheOption>>();

        if (options?.Type?.ToLower() == "redis" && !string.IsNullOrEmpty(options.Redis.ConnectionString))
        {
          return new KpRedisCache(sp.GetRequiredService<IDistributedCache>(), cacheOptions);
        }
        return new KpMemoryCache(sp.GetRequiredService<IMemoryCache>(), cacheOptions);
      });

      return services;
    }
  }
}