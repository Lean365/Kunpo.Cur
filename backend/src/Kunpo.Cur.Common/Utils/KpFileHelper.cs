// -----------------------------------------------------------------------
// <copyright file="KpFileHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>文件操作工具类</summary>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 文件操作工具类
  /// </summary>
  public static class KpFileHelper
  {
    /// <summary>
    /// 获取文件扩展名
    /// </summary>
    public static string? GetExtension(string? fileName)
    {
      return Path.GetExtension(fileName);
    }

    /// <summary>
    /// 获取文件名（不含扩展名）
    /// </summary>
    public static string? GetFileNameWithoutExtension(string? fileName)
    {
      return Path.GetFileNameWithoutExtension(fileName);
    }

    /// <summary>
    /// 获取文件名（含扩展名）
    /// </summary>
    public static string? GetFileName(string? filePath)
    {
      return Path.GetFileName(filePath);
    }

    /// <summary>
    /// 获取目录路径
    /// </summary>
    public static string? GetDirectoryName(string? filePath)
    {
      return Path.GetDirectoryName(filePath);
    }

    /// <summary>
    /// 组合路径
    /// </summary>
    public static string? CombinePath(params string[] paths)
    {
      if (paths == null || paths.Length == 0) return null;
      var nonNullPaths = paths.Where(p => !string.IsNullOrEmpty(p)).ToArray();
      return nonNullPaths.Length > 0 ? Path.Combine(nonNullPaths) : null;
    }

    /// <summary>
    /// 确保目录存在
    /// </summary>
    public static void EnsureDirectoryExists(string? directoryPath)
    {
      if (string.IsNullOrEmpty(directoryPath)) return;
      if (!Directory.Exists(directoryPath))
      {
        Directory.CreateDirectory(directoryPath);
      }
    }

    /// <summary>
    /// 生成唯一的文件名
    /// </summary>
    public static string? GenerateUniqueFileName(string? fileName)
    {
      var extension = GetExtension(fileName);
      var nameWithoutExtension = GetFileNameWithoutExtension(fileName);
      return $"{nameWithoutExtension}_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid():N}{extension}";
    }

    /// <summary>
    /// 生成Excel文件名
    /// </summary>
    public static string? GenerateExcelFileName(string? prefix, string? suffix = null)
    {
      if (string.IsNullOrEmpty(prefix)) prefix = "Export";
      var fileName = new StringBuilder(prefix);
      if (!string.IsNullOrEmpty(suffix))
      {
        fileName.Append($"_{suffix}");
      }
      fileName.Append($"_{DateTime.Now:yyyyMMddHHmmss}");
      fileName.Append(".xlsx");
      return fileName.ToString();
    }

    /// <summary>
    /// 获取临时文件路径
    /// </summary>
    public static string? GetTempFilePath(string? fileName)
    {
      if (string.IsNullOrEmpty(fileName)) return null;
      var tempPath = Path.GetTempPath();
      return Path.Combine(tempPath, fileName);
    }

    /// <summary>
    /// 获取应用程序数据目录
    /// </summary>
    public static string? GetAppDataPath(string? subPath = null)
    {
      var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      if (!string.IsNullOrEmpty(subPath))
      {
        appDataPath = CombinePath(appDataPath, subPath);
      }
      EnsureDirectoryExists(appDataPath);
      return appDataPath;
    }

    /// <summary>
    /// 获取临时目录
    /// </summary>
    public static string? GetTempDirectory(string? subPath = null)
    {
      var tempPath = Path.GetTempPath();
      if (!string.IsNullOrEmpty(subPath))
      {
        tempPath = CombinePath(tempPath, subPath);
      }
      EnsureDirectoryExists(tempPath);
      return tempPath;
    }

    /// <summary>
    /// 获取默认 wwwroot 路径
    /// </summary>
    /// <param name="subPath">子路径</param>
    /// <returns>wwwroot 路径</returns>
    public static string? GetWwwRootPath(string? subPath = null)
    {
      var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      var contentRootPath = Environment.GetEnvironmentVariable("ASPNETCORE_CONTENTROOT");
      var webRootPath = Environment.GetEnvironmentVariable("ASPNETCORE_WEBROOT");

      string? wwwrootPath;
      if (!string.IsNullOrEmpty(webRootPath))
      {
        wwwrootPath = webRootPath;
      }
      else if (!string.IsNullOrEmpty(contentRootPath))
      {
        wwwrootPath = Path.Combine(contentRootPath, "wwwroot");
      }
      else
      {
        wwwrootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
      }

      if (!string.IsNullOrEmpty(subPath))
      {
        wwwrootPath = CombinePath(wwwrootPath, subPath);
      }

      EnsureDirectoryExists(wwwrootPath);
      return wwwrootPath;
    }

    /// <summary>
    /// 获取上传文件路径
    /// </summary>
    /// <param name="subPath">子路径</param>
    /// <returns>上传文件路径</returns>
    public static string? GetUploadPath(string? subPath = null)
    {
      var wwwrootPath = GetWwwRootPath();
      if (string.IsNullOrEmpty(wwwrootPath)) return null;

      var uploadPath = Path.Combine(wwwrootPath, "uploads");
      if (!string.IsNullOrEmpty(subPath))
      {
        uploadPath = CombinePath(uploadPath, subPath);
      }
      EnsureDirectoryExists(uploadPath);
      return uploadPath;
    }

    /// <summary>
    /// 清理临时文件
    /// </summary>
    public static void CleanTempFiles(string? directoryPath, TimeSpan maxAge)
    {
      if (!Directory.Exists(directoryPath)) return;

      var files = Directory.GetFiles(directoryPath);
      foreach (var file in files)
      {
        var fileInfo = new FileInfo(file);
        if (DateTime.Now - fileInfo.LastWriteTime > maxAge)
        {
          try
          {
            File.Delete(file);
          }
          catch
          {
            // 忽略删除失败的文件
          }
        }
      }
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns>是否删除成功</returns>
    public static bool DeleteFile(string? filePath)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(filePath))
        {
          return false;
        }

        if (!File.Exists(filePath))
        {
          return true;
        }

        File.Delete(filePath);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// 删除目录
    /// </summary>
    /// <param name="directoryPath">目录路径</param>
    /// <param name="recursive">是否递归删除子目录和文件</param>
    /// <returns>是否删除成功</returns>
    public static bool DeleteDirectory(string? directoryPath, bool recursive = true)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(directoryPath))
        {
          return false;
        }

        if (!Directory.Exists(directoryPath))
        {
          return true;
        }

        Directory.Delete(directoryPath, recursive);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// 删除目录下的所有文件
    /// </summary>
    /// <param name="directoryPath">目录路径</param>
    /// <param name="searchPattern">搜索模式，默认为*.*</param>
    /// <param name="recursive">是否递归删除子目录中的文件</param>
    /// <returns>是否删除成功</returns>
    public static bool DeleteFilesInDirectory(string? directoryPath, string? searchPattern = "*.*", bool recursive = true)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(directoryPath)) return false;
        if (!Directory.Exists(directoryPath)) return true;

        var pattern = string.IsNullOrEmpty(searchPattern) ? "*.*" : searchPattern;
        var files = Directory.GetFiles(directoryPath, pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
          File.Delete(file);
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// 删除空目录
    /// </summary>
    /// <param name="directoryPath">目录路径</param>
    /// <param name="recursive">是否递归删除子目录</param>
    /// <returns>是否删除成功</returns>
    public static bool DeleteEmptyDirectories(string? directoryPath, bool recursive = true)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(directoryPath))
        {
          return false;
        }

        if (!Directory.Exists(directoryPath))
        {
          return true;
        }

        var directories = Directory.GetDirectories(directoryPath ?? string.Empty, "*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        foreach (var directory in directories.Where(d => !string.IsNullOrEmpty(d)))
        {
          if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
          {
            Directory.Delete(directory);
          }
        }

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}