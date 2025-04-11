// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>防伪令牌工具类</summary>
// <remarks>处理防伪令牌的生成和验证</remarks>
// -----------------------------------------------------------------------

using System.Security.Cryptography;
using System.Text;
using Kunpo.Cur.Common.Options;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 防伪令牌工具类
  /// </summary>
  public static class KpAntiForgery
  {
    private static KpAntiForgeryOptions _options = new();
    private static IMemoryCache? _cache;
    private static Serilog.ILogger? _logger;

    /// <summary>
    /// 配置
    /// </summary>
    public static KpAntiForgeryOptions Options
    {
      get => _options;
      set => _options = value ?? new KpAntiForgeryOptions();
    }

    /// <summary>
    /// 缓存
    /// </summary>
    public static IMemoryCache? Cache
    {
      get => _cache;
      set => _cache = value;
    }

    /// <summary>
    /// 日志记录器
    /// </summary>
    public static Serilog.ILogger? Logger
    {
      get => _logger;
      set => _logger = value;
    }

    /// <summary>
    /// 生成防伪令牌
    /// </summary>
    /// <returns>防伪令牌</returns>
    public static string GenerateToken()
    {
      if (!_options.Enabled)
      {
        return string.Empty;
      }

      try
      {
        // 生成随机令牌
        var token = GenerateRandomToken();

        // 计算令牌哈希
        var tokenHash = ComputeHash(token);

        // 存储令牌哈希
        var cacheKey = $"AntiForgery:{tokenHash}";
        _cache?.Set(cacheKey, true, TimeSpan.FromMinutes(_options.ExpirationMinutes));

        _logger?.Information("生成防伪令牌：{Token}", token);

        return token;
      }
      catch (Exception ex)
      {
        _logger?.Error(ex, "生成防伪令牌失败");
        throw;
      }
    }

    /// <summary>
    /// 验证防伪令牌
    /// </summary>
    /// <param name="token">防伪令牌</param>
    /// <returns>是否有效</returns>
    public static bool ValidateToken(string token)
    {
      if (!_options.Enabled || string.IsNullOrEmpty(token))
      {
        return false;
      }

      try
      {
        // 计算令牌哈希
        var tokenHash = ComputeHash(token);

        // 检查令牌是否存在
        var cacheKey = $"AntiForgery:{tokenHash}";
        var exists = _cache?.TryGetValue(cacheKey, out _) ?? false;

        if (exists)
        {
          // 验证成功后移除令牌
          _cache?.Remove(cacheKey);
          _logger?.Information("验证防伪令牌成功：{Token}", token);
        }
        else
        {
          _logger?.Warning("验证防伪令牌失败：{Token}", token);
        }

        return exists;
      }
      catch (Exception ex)
      {
        _logger?.Error(ex, "验证防伪令牌失败：{Token}", token);
        return false;
      }
    }

    private static string GenerateRandomToken()
    {
      var bytes = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(bytes);
      }
      return Convert.ToBase64String(bytes);
    }

    private static string ComputeHash(string input)
    {
      using (var sha256 = SHA256.Create())
      {
        var bytes = Encoding.UTF8.GetBytes(input + _options.Key);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
      }
    }
  }
}