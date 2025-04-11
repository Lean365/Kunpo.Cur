// -----------------------------------------------------------------------
// <copyright file="KpDeviceHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>设备和连接ID生成帮助类</summary>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Kunpo.Cur.Common.Helpers
{
  /// <summary>
  /// 设备和连接ID生成帮助类
  /// </summary>
  public static class KpDeviceHelper
  {
    /// <summary>
    /// 生成设备ID
    /// </summary>
    /// <param name="httpContext">HTTP上下文</param>
    /// <returns>设备ID</returns>
    public static string GenerateDeviceId(HttpContext? httpContext)
    {
      if (httpContext == null)
        return string.Empty;

      var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
      var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
      var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

      // 组合设备信息
      var deviceInfo = $"{userAgent}|{ipAddress}|{timestamp}";

      // 使用SHA256生成唯一标识
      using var sha256 = System.Security.Cryptography.SHA256.Create();
      var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(deviceInfo));
      return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// 获取设备类型
    /// </summary>
    /// <param name="httpContext">HTTP上下文</param>
    /// <returns>设备类型（1：Web，2：Android，3：iOS，4：Windows，5：Mac，6：Linux）</returns>
    public static int GetDeviceType(HttpContext? httpContext)
    {
      if (httpContext == null)
        return 1; // 默认为Web

      var userAgent = httpContext.Request.Headers["User-Agent"].ToString().ToLower();

      if (userAgent.Contains("android"))
        return 2; // Android
      else if (userAgent.Contains("iphone") || userAgent.Contains("ipad"))
        return 3; // iOS
      else if (userAgent.Contains("windows"))
        return 4; // Windows
      else if (userAgent.Contains("macintosh") || userAgent.Contains("mac os"))
        return 5; // Mac
      else if (userAgent.Contains("linux"))
        return 6; // Linux
      else
        return 1; // Web
    }

    /// <summary>
    /// 获取设备名称
    /// </summary>
    /// <param name="httpContext">HTTP上下文</param>
    /// <returns>设备名称</returns>
    public static string GetDeviceName(HttpContext? httpContext)
    {
      if (httpContext == null)
        return "Unknown";

      var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
      return userAgent;
    }

    /// <summary>
    /// 获取设备型号
    /// </summary>
    /// <param name="httpContext">HTTP上下文</param>
    /// <returns>设备型号</returns>
    public static string GetDeviceModel(HttpContext? httpContext)
    {
      if (httpContext == null)
        return "Unknown";

      var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
      return userAgent;
    }
  }
}