// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>IP位置帮助类</summary>
// <remarks>处理IP位置的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using IP2Region.Net.Abstractions;
using IP2Region.Net.XDB;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// IP位置帮助类
  /// </summary>
  public static class KpIpLocationHelper
  {
    private static ISearcher? _searcher;
    private static readonly object _lock = new object();
    private static bool _initialized;

    /// <summary>
    /// 初始化IP位置数据库
    /// </summary>
    /// <param name="dbPath">数据库文件路径</param>
    public static void Initialize(string dbPath)
    {
      if (_initialized) return;

      lock (_lock)
      {
        if (_initialized) return;

        if (!File.Exists(dbPath))
        {
          throw new FileNotFoundException($"IP位置数据库文件不存在: {dbPath}");
        }

        try
        {
          // 使用 VectorIndex 缓存策略，在性能和内存使用之间取得平衡
          _searcher = new Searcher(CachePolicy.VectorIndex, dbPath);
          _initialized = true;
        }
        catch (Exception ex)
        {
          throw new Exception($"初始化IP位置数据库失败: {ex.Message}", ex);
        }
      }
    }

    /// <summary>
    /// 获取IP位置信息
    /// </summary>
    /// <param name="ip">IP地址</param>
    /// <returns>位置信息</returns>
    public static async Task<string> GetLocationAsync(string ip)
    {
      if (!_initialized)
      {
        throw new InvalidOperationException("IP位置数据库未初始化");
      }

      if (string.IsNullOrWhiteSpace(ip))
      {
        return "未知";
      }

      try
      {
        return await Task.Run(() => GetLocation(ip));
      }
      catch (Exception)
      {
        return "未知";
      }
    }

    /// <summary>
    /// 获取IP位置信息（同步方法）
    /// </summary>
    /// <param name="ip">IP地址</param>
    /// <returns>位置信息</returns>
    public static string GetLocation(string ip)
    {
      if (!_initialized)
      {
        throw new InvalidOperationException("IP位置数据库未初始化");
      }

      if (string.IsNullOrWhiteSpace(ip))
      {
        return "未知";
      }

      try
      {
        var result = _searcher!.Search(ip);
        return string.IsNullOrEmpty(result) ? "未知" : result;
      }
      catch (Exception)
      {
        return "未知";
      }
    }
  }
}