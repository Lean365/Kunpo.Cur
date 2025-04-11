// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>缓存配置</summary>
// <remarks>处理缓存的配置</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// 缓存配置
  /// </summary>
  public class KpCacheOption
  {
    /// <summary>
    /// 缓存类型
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Redis配置
    /// </summary>
    public KpRedisOption Redis { get; set; } = new();

    /// <summary>
    /// 内存缓存配置
    /// </summary>
    public KpMemoryOption Memory { get; set; } = new();

    /// <summary>
    /// 过期时间配置
    /// </summary>
    public KpExpireOption Expire { get; set; } = new();

    /// <summary>
    /// 清理配置
    /// </summary>
    public KpCleanupOption Cleanup { get; set; } = new();
  }

  /// <summary>
  /// Redis配置
  /// </summary>
  public class KpRedisOption
  {
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// 数据库ID
    /// </summary>
    public int DatabaseId { get; set; }
  }

  /// <summary>
  /// 内存缓存配置
  /// </summary>
  public class KpMemoryOption
  {
    /// <summary>
    /// 大小限制（MB）
    /// </summary>
    public int SizeLimit { get; set; }

    /// <summary>
    /// 压缩百分比
    /// </summary>
    public double CompactionPercentage { get; set; }

    /// <summary>
    /// 过期扫描频率
    /// </summary>
    public string ExpirationScanFrequency { get; set; } = string.Empty;

    /// <summary>
    /// 内存阈值（MB）
    /// </summary>
    public int MemoryThresholdMB { get; set; }

    /// <summary>
    /// 最大清理项数
    /// </summary>
    public int MaxItemsToRemove { get; set; }
  }

  /// <summary>
  /// 过期时间配置
  /// </summary>
  public class KpExpireOption
  {
    /// <summary>
    /// 默认过期时间（分钟）
    /// </summary>
    public int DefaultExpireMinutes { get; set; }

    /// <summary>
    /// 最大过期时间（分钟）
    /// </summary>
    public int MaxExpireMinutes { get; set; }

    /// <summary>
    /// 最小过期时间（分钟）
    /// </summary>
    public int MinExpireMinutes { get; set; }

    /// <summary>
    /// 是否启用滑动过期
    /// </summary>
    public bool EnableSlidingExpiration { get; set; }
  }

  /// <summary>
  /// 清理配置
  /// </summary>
  public class KpCleanupOption
  {
    /// <summary>
    /// 是否启用自动清理
    /// </summary>
    public bool EnableAutoCleanup { get; set; }

    /// <summary>
    /// 清理间隔（分钟）
    /// </summary>
    public int CleanupIntervalMinutes { get; set; }

    /// <summary>
    /// 内存阈值（MB）
    /// </summary>
    public int MemoryThresholdMB { get; set; }

    /// <summary>
    /// 最大清理项数
    /// </summary>
    public int MaxItemsToRemove { get; set; }
  }
}