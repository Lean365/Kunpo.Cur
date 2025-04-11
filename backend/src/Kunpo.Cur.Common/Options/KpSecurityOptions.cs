// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>安全配置选项</summary>
// <remarks>处理安全的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// 安全配置选项
  /// </summary>
  public class KpSecurityOptions
  {
    /// <summary>
    /// 防伪令牌配置
    /// </summary>
    public KpAntiForgeryOptions AntiForgery { get; set; } = new();

    /// <summary>
    /// 限流配置
    /// </summary>
    public KpRateLimitOptions RateLimit { get; set; } = new();

    /// <summary>
    /// SQL注入防护配置
    /// </summary>
    public KpSqlInjectionOptions SqlInjection { get; set; } = new();
  }

  /// <summary>
  /// 防伪令牌配置
  /// </summary>
  public class KpAntiForgeryOptions
  {
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// 令牌过期时间（分钟）
    /// </summary>
    public int ExpirationMinutes { get; set; } = 30;

    /// <summary>
    /// 令牌密钥
    /// </summary>
    public string Key { get; set; } = "Kunpo.Cur.AntiForgeryKey";

    /// <summary>
    /// Cookie名称
    /// </summary>
    public string CookieName { get; set; } = "X-CSRF-TOKEN";

    /// <summary>
    /// 请求头名称
    /// </summary>
    public string HeaderName { get; set; } = "X-CSRF-TOKEN";
  }

  /// <summary>
  /// 限流配置
  /// </summary>
  public class KpRateLimitOptions
  {
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// 默认限制次数
    /// </summary>
    public int DefaultLimit { get; set; } = 100;

    /// <summary>
    /// 默认时间周期（秒）
    /// </summary>
    public int DefaultPeriod { get; set; } = 60;

    /// <summary>
    /// 限流规则
    /// </summary>
    public Dictionary<string, KpRateLimitRule> Rules { get; set; } = new();

    /// <summary>
    /// 排除路径列表
    /// </summary>
    public List<string>? ExcludePaths { get; set; }

    /// <summary>
    /// 最大请求次数
    /// </summary>
    public int MaxRequests { get; set; } = 100;

    /// <summary>
    /// 时间窗口（秒）
    /// </summary>
    public int TimeWindow { get; set; } = 60;
  }

  /// <summary>
  /// 限流规则
  /// </summary>
  public class KpRateLimitRule
  {
    /// <summary>
    /// 限制次数
    /// </summary>
    public int Limit { get; set; }

    /// <summary>
    /// 时间周期（秒）
    /// </summary>
    public int Period { get; set; }
  }

  /// <summary>
  /// SQL注入防护配置
  /// </summary>
  public class KpSqlInjectionOptions
  {
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// 是否记录日志
    /// </summary>
    public bool LogEnabled { get; set; } = true;

    /// <summary>
    /// 是否抛出异常
    /// </summary>
    public bool ThrowException { get; set; } = false;

    /// <summary>
    /// 排除路径列表
    /// </summary>
    public List<string>? ExcludePaths { get; set; }

    /// <summary>
    /// 敏感字符列表
    /// </summary>
    public List<string>? SensitiveChars { get; set; } = new()
    {
      "'", "\"", ";", "--", "/*", "*/", "xp_", "sp_", "exec", "execute",
      "select", "insert", "update", "delete", "drop", "union", "join"
    };
  }
}