// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>数据库配置选项</summary>
// <remarks>处理数据库的配置</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// 数据库配置
  /// </summary>
  public class KpDatabaseOption
  {
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// 数据库类型
    /// </summary>
    public int DbType { get; set; }

    /// <summary>
    /// 是否启用下划线
    /// </summary>
    public bool EnableUnderLine { get; set; }

    /// <summary>
    /// 是否启用SQL日志
    /// </summary>
    public bool EnableSqlLog { get; set; }

    /// <summary>
    /// 是否启用自动迁移
    /// </summary>
    public bool EnableAutoMigrate { get; set; }

    /// <summary>
    /// 是否启用初始数据
    /// </summary>
    public bool EnableInitData { get; set; }

    /// <summary>
    /// 是否启用种子数据
    /// </summary>
    public bool EnableInitSeedsData { get; set; }

    /// <summary>
    /// 是否显示已删除数据
    /// </summary>
    public bool ShowDeleted { get; set; } = false;

    /// <summary>
    /// 连接池选项
    /// </summary>
    public ConnectionPoolOption? ConnectionPool { get; set; }
  }

  public class ConnectionPoolOption
  {
    /// <summary>
    /// 最小连接池大小
    /// </summary>
    public int MinPoolSize { get; set; }

    /// <summary>
    /// 最大连接池大小
    /// </summary>
    public int MaxPoolSize { get; set; }

    /// <summary>
    /// 连接超时时间
    /// </summary>
    public int ConnectionTimeout { get; set; }

    /// <summary>
    /// 命令超时时间
    /// </summary>
    public int CommandTimeout { get; set; }

    /// <summary>
    /// 空闲时间
    /// </summary>
    public int IdleTime { get; set; }

    /// <summary>
    /// 繁忙时间
    /// </summary>
    public int BusyTime { get; set; }
  }
}