// -----------------------------------------------------------------------
// <copyright file="KpConvertHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>通用转换工具类</summary>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 通用转换工具类
  /// </summary>
  public static class KpConvertHelper
  {
    #region 基础类型转换
    /// <summary>
    /// 转换为整数
    /// </summary>
    public static int ToInt(object value, int defaultValue = 0)
    {
      if (value == null) return defaultValue;
      if (value is int intValue) return intValue;
      if (int.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为长整数
    /// </summary>
    public static long ToLong(object value, long defaultValue = 0)
    {
      if (value == null) return defaultValue;
      if (value is long longValue) return longValue;
      if (long.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为小数
    /// </summary>
    public static decimal ToDecimal(object value, decimal defaultValue = 0)
    {
      if (value == null) return defaultValue;
      if (value is decimal decimalValue) return decimalValue;
      if (decimal.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为双精度小数
    /// </summary>
    public static double ToDouble(object value, double defaultValue = 0)
    {
      if (value == null) return defaultValue;
      if (value is double doubleValue) return doubleValue;
      if (double.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为布尔值
    /// </summary>
    public static bool ToBool(object value, bool defaultValue = false)
    {
      if (value == null) return defaultValue;
      if (value is bool boolValue) return boolValue;
      if (bool.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为日期时间
    /// </summary>
    public static DateTime ToDateTime(object value, DateTime defaultValue = default)
    {
      if (value == null) return defaultValue;
      if (value is DateTime dateTimeValue) return dateTimeValue;
      if (DateTime.TryParse(value.ToString(), out var result)) return result;
      return defaultValue;
    }

    /// <summary>
    /// 转换为时间戳（毫秒）
    /// </summary>
    public static long ToTimestamp(object value, long defaultValue = 0)
    {
      if (value == null) return defaultValue;
      if (value is DateTime dateTimeValue) return ((DateTimeOffset)dateTimeValue).ToUnixTimeMilliseconds();
      if (DateTime.TryParse(value.ToString(), out var dateTime)) return ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
      return defaultValue;
    }

    /// <summary>
    /// 转换为枚举
    /// </summary>
    public static T ToEnum<T>(object value, T defaultValue = default) where T : struct
    {
      if (value == null) return defaultValue;
      if (value is T enumValue) return enumValue;
      if (Enum.TryParse(value.ToString(), true, out T result)) return result;
      return defaultValue;
    }
    #endregion

    #region 集合转换
    /// <summary>
    /// 转换为数组
    /// </summary>
    public static T[] ToArray<T>(object? value, T[]? defaultValue = default)
    {
      if (value == null) return defaultValue ?? Array.Empty<T>();
      if (value is T[] arrayValue) return arrayValue;
      if (value is IEnumerable<T> enumerableValue) return enumerableValue.ToArray();
      return defaultValue ?? Array.Empty<T>();
    }

    /// <summary>
    /// 转换为列表
    /// </summary>
    public static List<T> ToList<T>(object? value, List<T>? defaultValue = default)
    {
      if (value == null) return defaultValue ?? new List<T>();
      if (value is List<T> listValue) return listValue;
      if (value is IEnumerable<T> enumerableValue) return enumerableValue.ToList();
      return defaultValue ?? new List<T>();
    }

    /// <summary>
    /// 转换为字典
    /// </summary>
    public static Dictionary<string, TValue> ToDictionary<TValue>(object? value) where TValue : notnull
    {
      if (value == null)
      {
        return new Dictionary<string, TValue>();
      }

      if (value is IDictionary<string, TValue> dict)
      {
        return new Dictionary<string, TValue>(dict);
      }

      if (value is IDictionary dictionary)
      {
        return dictionary.Cast<DictionaryEntry>()
          .Where(entry => entry.Key != null)
          .ToDictionary(
            entry => entry.Key.ToString() ?? string.Empty,
            entry => entry.Value is TValue typedValue ? typedValue : default(TValue)!
          );
      }

      return new Dictionary<string, TValue>();
    }

    /// <summary>
    /// 转换为字典
    /// </summary>
    public static Dictionary<string, TValue> ToDictionary<TValue>(object? value, Dictionary<string, TValue>? defaultValue) where TValue : notnull
    {
      if (value == null)
      {
        return defaultValue ?? new Dictionary<string, TValue>();
      }

      if (value is IDictionary<string, TValue> dict)
      {
        return new Dictionary<string, TValue>(dict);
      }

      if (value is IDictionary dictionary)
      {
        return dictionary.Cast<DictionaryEntry>()
          .Where(entry => entry.Key != null)
          .ToDictionary(
            entry => entry.Key.ToString() ?? string.Empty,
            entry => entry.Value is TValue typedValue ? typedValue : default(TValue)!
          );
      }

      return defaultValue ?? new Dictionary<string, TValue>();
    }

    /// <summary>
    /// 转换为字典
    /// </summary>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(object? value)
        where TKey : notnull
        where TValue : notnull
    {
      if (value == null)
      {
        return new Dictionary<TKey, TValue>();
      }

      if (value is IDictionary<TKey, TValue> dict)
      {
        return new Dictionary<TKey, TValue>(dict);
      }

      if (value is IDictionary dictionary)
      {
        return dictionary.Cast<DictionaryEntry>()
          .Where(entry => entry.Key != null && entry.Key is TKey)
          .ToDictionary(
            entry => (TKey)entry.Key,
            entry => entry.Value is TValue typedValue ? typedValue : default(TValue)!
          );
      }

      return new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// 转换为字典
    /// </summary>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(object? value, Dictionary<TKey, TValue>? defaultValue)
        where TKey : notnull
        where TValue : notnull
    {
      if (value == null)
      {
        return defaultValue ?? new Dictionary<TKey, TValue>();
      }

      if (value is IDictionary<TKey, TValue> dict)
      {
        return new Dictionary<TKey, TValue>(dict);
      }

      if (value is IDictionary dictionary)
      {
        return dictionary.Cast<DictionaryEntry>()
          .Where(entry => entry.Key != null && entry.Key is TKey)
          .ToDictionary(
            entry => (TKey)entry.Key,
            entry => entry.Value is TValue typedValue ? typedValue : default(TValue)!
          );
      }

      return defaultValue ?? new Dictionary<TKey, TValue>();
    }
    #endregion

    #region 字节转换
    /// <summary>
    /// 转换为字节数组
    /// </summary>
    public static byte[]? ToBytes(string? value, Encoding? encoding = null)
    {
      if (string.IsNullOrEmpty(value)) return Array.Empty<byte>();
      encoding ??= Encoding.UTF8;
      return encoding.GetBytes(value);
    }

    /// <summary>
    /// 从字节数组转换为字符串
    /// </summary>
    public static string? FromBytes(byte[]? value, Encoding? encoding = null)
    {
      if (value == null || value.Length == 0) return string.Empty;
      encoding ??= Encoding.UTF8;
      return encoding.GetString(value);
    }

    /// <summary>
    /// 转换为十六进制字符串
    /// </summary>
    public static string? ToHex(byte[]? value)
    {
      if (value == null || value.Length == 0) return string.Empty;
      return BitConverter.ToString(value).Replace("-", "").ToLower();
    }

    /// <summary>
    /// 从十六进制字符串转换为字节数组
    /// </summary>
    public static byte[]? FromHex(string? value)
    {
      if (string.IsNullOrEmpty(value)) return Array.Empty<byte>();
      if (value.Length % 2 != 0) throw new ArgumentException("十六进制字符串长度必须为偶数");
      var bytes = new byte[value.Length / 2];
      for (int i = 0; i < bytes.Length; i++)
      {
        bytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
      }
      return bytes;
    }
    #endregion

    #region 进制转换
    /// <summary>
    /// 十进制转二进制
    /// </summary>
    public static string? ToBinary(int value)
    {
      return Convert.ToString(value, 2);
    }

    /// <summary>
    /// 二进制转十进制
    /// </summary>
    public static int FromBinary(string? value)
    {
      return Convert.ToInt32(value, 2);
    }

    /// <summary>
    /// 十进制转八进制
    /// </summary>
    public static string? ToOctal(int value)
    {
      return Convert.ToString(value, 8);
    }

    /// <summary>
    /// 八进制转十进制
    /// </summary>
    public static int FromOctal(string? value)
    {
      return Convert.ToInt32(value, 8);
    }

    /// <summary>
    /// 十进制转十六进制
    /// </summary>
    public static string? ToHexadecimal(int value)
    {
      return Convert.ToString(value, 16);
    }

    /// <summary>
    /// 十六进制转十进制
    /// </summary>
    public static int FromHexadecimal(string? value)
    {
      return Convert.ToInt32(value, 16);
    }
    #endregion

    #region 单位转换
    /// <summary>
    /// 字节转换为KB
    /// </summary>
    public static double BytesToKB(long bytes)
    {
      return Math.Round(bytes / 1024.0, 2);
    }

    /// <summary>
    /// KB转换为字节
    /// </summary>
    public static long KBToBytes(double kb)
    {
      return (long)(kb * 1024);
    }

    /// <summary>
    /// 字节转换为MB
    /// </summary>
    public static double BytesToMB(long bytes)
    {
      return Math.Round(bytes / (1024.0 * 1024), 2);
    }

    /// <summary>
    /// MB转换为字节
    /// </summary>
    public static long MBToBytes(double mb)
    {
      return (long)(mb * 1024 * 1024);
    }

    /// <summary>
    /// 字节转换为GB
    /// </summary>
    public static double BytesToGB(long bytes)
    {
      return Math.Round(bytes / (1024.0 * 1024 * 1024), 2);
    }

    /// <summary>
    /// GB转换为字节
    /// </summary>
    public static long GBToBytes(double gb)
    {
      return (long)(gb * 1024 * 1024 * 1024);
    }
    #endregion
  }
}