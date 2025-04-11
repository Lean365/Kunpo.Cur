// -----------------------------------------------------------------------
// <copyright file="KpStringHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>字符串工具类</summary>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 字符串工具类
  /// </summary>
  public static class KpStringHelper
  {
    #region 字符串判断
    /// <summary>
    /// 判断字符串是否为空
    /// </summary>
    public static bool IsEmpty(string? str) => string.IsNullOrEmpty(str);

    /// <summary>
    /// 判断字符串是否为空或空白
    /// </summary>
    public static bool IsBlank(string? str) => string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// 判断字符串是否相等（忽略大小写）
    /// </summary>
    public static bool EqualsIgnoreCase(string? str1, string? str2) =>
      string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// 判断字符串是否包含（忽略大小写）
    /// </summary>
    public static bool ContainsIgnoreCase(string? str, string? value)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(value)) return false;
      return str.Contains(value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 判断字符串是否以指定值开头（忽略大小写）
    /// </summary>
    public static bool StartsWithIgnoreCase(string? str, string? value)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(value)) return false;
      return str.StartsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 判断字符串是否以指定值结尾（忽略大小写）
    /// </summary>
    public static bool EndsWithIgnoreCase(string? str, string? value)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(value)) return false;
      return str.EndsWith(value, StringComparison.OrdinalIgnoreCase);
    }
    #endregion

    #region 字符串处理
    /// <summary>
    /// 获取字符串长度
    /// </summary>
    public static int Length(string? str) => str?.Length ?? 0;

    /// <summary>
    /// 截取字符串
    /// </summary>
    public static string? Substring(string? str, int startIndex, int length)
    {
      if (string.IsNullOrEmpty(str)) return str;
      if (startIndex < 0) startIndex = 0;
      if (length < 0) length = 0;
      if (startIndex >= str.Length) return string.Empty;
      if (startIndex + length > str.Length) length = str.Length - startIndex;
      return str[startIndex..(startIndex + length)];
    }

    /// <summary>
    /// 截取字符串（从开始到指定长度）
    /// </summary>
    public static string? Left(string? str, int length) => Substring(str, 0, length);

    /// <summary>
    /// 截取字符串（从结尾到指定长度）
    /// </summary>
    public static string? Right(string? str, int length)
    {
      if (string.IsNullOrEmpty(str)) return str;
      if (length < 0) length = 0;
      if (length > str.Length) length = str.Length;
      return str[^length..];
    }

    /// <summary>
    /// 截取字符串（从开始到指定字符）
    /// </summary>
    public static string? SubstringBefore(string? str, string? separator)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(separator)) return str;
      var index = str.IndexOf(separator);
      return index < 0 ? str : str[..index];
    }

    /// <summary>
    /// 截取字符串（从指定字符到结尾）
    /// </summary>
    public static string? SubstringAfter(string? str, string? separator)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(separator)) return str;
      var index = str.IndexOf(separator);
      return index < 0 ? str : str[(index + separator.Length)..];
    }

    /// <summary>
    /// 截取字符串（从开始到最后一个指定字符）
    /// </summary>
    public static string? SubstringBeforeLast(string? str, string? separator)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(separator)) return str;
      var index = str.LastIndexOf(separator);
      return index < 0 ? str : str[..index];
    }

    /// <summary>
    /// 截取字符串（从最后一个指定字符到结尾）
    /// </summary>
    public static string? SubstringAfterLast(string? str, string? separator)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(separator)) return str;
      var index = str.LastIndexOf(separator);
      return index < 0 ? str : str[(index + separator.Length)..];
    }
    #endregion

    #region 字符串格式化
    /// <summary>
    /// 格式化字符串
    /// </summary>
    public static string? Format(string? format, params object?[] args)
    {
      if (string.IsNullOrEmpty(format)) return format;
      return string.Format(format, args ?? Array.Empty<object>());
    }

    /// <summary>
    /// 格式化字符串（使用默认值）
    /// </summary>
    public static string? FormatWithDefault(string? format, string? defaultValue, params object?[] args)
    {
      if (string.IsNullOrEmpty(format)) return defaultValue;
      try
      {
        return string.Format(format, args ?? Array.Empty<object>());
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// 格式化金额
    /// </summary>
    public static string FormatMoney(decimal amount, string? currencySymbol = "¥", int decimals = 2)
    {
      return (currencySymbol ?? "¥") + amount.ToString($"N{decimals}");
    }

    /// <summary>
    /// 转换为大写金额
    /// </summary>
    public static string ToChineseMoney(decimal amount)
    {
      if (amount == 0) return "零元整";

      string[] numChinese = ["零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"];
      string[] unitChinese = ["", "拾", "佰", "仟"];
      string[] unitChineseBig = ["", "万", "亿", "万亿"];

      string result = "";
      bool isNegative = amount < 0;
      amount = Math.Abs(amount);

      long integerPart = (long)Math.Floor(amount);
      long decimalPart = (long)Math.Round((amount - integerPart) * 100);

      if (isNegative) result += "负";

      if (integerPart > 0)
      {
        int unitIndex = 0;
        while (integerPart > 0)
        {
          string section = "";
          long sectionNum = integerPart % 10000;
          int digitIndex = 0;

          while (sectionNum > 0)
          {
            int digit = (int)(sectionNum % 10);
            if (digit != 0)
            {
              section = numChinese[digit] + unitChinese[digitIndex] + section;
            }
            else if (!string.IsNullOrEmpty(section) && section[0] != '零')
            {
              section = "零" + section;
            }
            sectionNum /= 10;
            digitIndex++;
          }

          if (!string.IsNullOrEmpty(section))
          {
            result = section + unitChineseBig[unitIndex] + result;
          }

          integerPart /= 10000;
          unitIndex++;
        }
        result += "元";
      }

      if (decimalPart > 0)
      {
        int jiao = (int)(decimalPart / 10);
        int fen = (int)(decimalPart % 10);

        if (jiao > 0)
        {
          result += numChinese[jiao] + "角";
        }
        if (fen > 0)
        {
          result += numChinese[fen] + "分";
        }
      }
      else if (integerPart > 0)
      {
        result += "整";
      }

      return result;
    }

    /// <summary>
    /// 格式化文件大小
    /// </summary>
    public static string? FormatFileSize(long bytes)
    {
      string[] sizes = ["B", "KB", "MB", "GB", "TB"];
      int order = 0;
      double size = bytes;
      while (size >= 1024 && order < sizes.Length - 1)
      {
        order++;
        size /= 1024;
      }
      return $"{size:0.##} {sizes[order]}";
    }

    /// <summary>
    /// 格式化手机号码
    /// </summary>
    public static string? FormatPhoneNumber(string? phoneNumber)
    {
      if (string.IsNullOrEmpty(phoneNumber)) return phoneNumber;
      if (phoneNumber.Length != 11) return phoneNumber;
      return $"{phoneNumber[..3]}-{phoneNumber[3..7]}-{phoneNumber[7..]}";
    }

    /// <summary>
    /// 格式化身份证号码
    /// </summary>
    public static string? FormatIdCard(string? idCard)
    {
      if (string.IsNullOrEmpty(idCard)) return idCard;
      if (idCard.Length != 18) return idCard;
      return $"{idCard[..6]}-{idCard[6..10]}-{idCard[10..14]}-{idCard[14..]}";
    }
    #endregion

    #region 字符串转换
    /// <summary>
    /// 转换为驼峰命名
    /// </summary>
    public static string? ToCamelCase(string? str)
    {
      if (string.IsNullOrEmpty(str) || str.Length < 2) return str;
      return char.ToLower(str[0]) + str[1..];
    }

    /// <summary>
    /// 转换为帕斯卡命名
    /// </summary>
    public static string? ToPascalCase(string? str)
    {
      if (string.IsNullOrEmpty(str) || str.Length < 2) return str;
      return char.ToUpper(str[0]) + str[1..];
    }

    /// <summary>
    /// 转换为下划线命名
    /// </summary>
    public static string? ToSnakeCase(string? str)
    {
      if (string.IsNullOrEmpty(str) || str.Length < 2) return str;
      var result = new StringBuilder(str.Length * 2);
      result.Append(char.ToLower(str[0]));
      for (int i = 1; i < str.Length; i++)
      {
        if (char.IsUpper(str[i]))
        {
          result.Append('_');
          result.Append(char.ToLower(str[i]));
        }
        else
        {
          result.Append(str[i]);
        }
      }
      return result.ToString();
    }

    /// <summary>
    /// 转换为中划线命名
    /// </summary>
    public static string? ToKebabCase(string? str)
    {
      if (string.IsNullOrEmpty(str) || str.Length < 2) return str;
      var result = new StringBuilder(str.Length * 2);
      result.Append(char.ToLower(str[0]));
      for (int i = 1; i < str.Length; i++)
      {
        if (char.IsUpper(str[i]))
        {
          result.Append('-');
          result.Append(char.ToLower(str[i]));
        }
        else
        {
          result.Append(str[i]);
        }
      }
      return result.ToString();
    }
    #endregion

    #region 字符串验证
    /// <summary>
    /// 验证手机号码
    /// </summary>
    public static bool IsValidPhoneNumber(string? phoneNumber)
    {
      if (string.IsNullOrEmpty(phoneNumber)) return false;
      return Regex.IsMatch(phoneNumber!, @"^1[3-9]\d{9}$");
    }

    /// <summary>
    /// 验证身份证号码
    /// </summary>
    public static bool IsValidIdCard(string? idCard)
    {
      if (string.IsNullOrEmpty(idCard)) return false;
      return Regex.IsMatch(idCard!, @"^[1-9]\d{5}(18|19|20)\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$");
    }

    /// <summary>
    /// 验证邮箱地址
    /// </summary>
    public static bool IsValidEmail(string? email)
    {
      if (string.IsNullOrEmpty(email)) return false;
      return Regex.IsMatch(email!, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    /// <summary>
    /// 验证URL地址
    /// </summary>
    public static bool IsValidUrl(string? url)
    {
      if (string.IsNullOrEmpty(url)) return false;
      return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

    /// <summary>
    /// 验证IP地址
    /// </summary>
    public static bool IsValidIpAddress(string? ipAddress)
    {
      if (string.IsNullOrEmpty(ipAddress)) return false;
      return Regex.IsMatch(ipAddress!, @"^(\d{1,3}\.){3}\d{1,3}$");
    }
    #endregion

    #region 字符串加密
    /// <summary>
    /// MD5加密
    /// </summary>
    public static string? Md5(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      using var md5 = System.Security.Cryptography.MD5.Create();
      var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
      return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    /// <summary>
    /// SHA1加密
    /// </summary>
    public static string? Sha1(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      using var sha1 = System.Security.Cryptography.SHA1.Create();
      var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
      return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    /// <summary>
    /// SHA256加密
    /// </summary>
    public static string? Sha256(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      using var sha256 = System.Security.Cryptography.SHA256.Create();
      var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
      return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Base64编码
    /// </summary>
    public static string? Base64Encode(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }

    /// <summary>
    /// Base64解码
    /// </summary>
    public static string? Base64Decode(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      try
      {
        return Encoding.UTF8.GetString(Convert.FromBase64String(str));
      }
      catch
      {
        return str;
      }
    }
    #endregion

    #region 字符串清理
    /// <summary>
    /// 清理HTML标签
    /// </summary>
    public static string? CleanHtml(string? html)
    {
      if (string.IsNullOrEmpty(html)) return html;
      return Regex.Replace(html!, "<.*?>", string.Empty);
    }

    /// <summary>
    /// 清理特殊字符
    /// </summary>
    public static string? CleanSpecialChars(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      return Regex.Replace(str!, @"[^\w\s-]", string.Empty);
    }

    /// <summary>
    /// 清理空白字符
    /// </summary>
    public static string? CleanWhitespace(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      return Regex.Replace(str!, @"\s+", " ").Trim();
    }

    /// <summary>
    /// 清理重复字符
    /// </summary>
    public static string? CleanDuplicateChars(string? str)
    {
      if (string.IsNullOrEmpty(str)) return str;
      return new string(str.Distinct().ToArray());
    }
    #endregion

    #region 字符串比较
    /// <summary>
    /// 获取Levenshtein距离
    /// </summary>
    private static int GetLevenshteinDistance(string? str1, string? str2)
    {
      if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        return Math.Max(str1?.Length ?? 0, str2?.Length ?? 0);

      var matrix = new int[str1.Length + 1, str2.Length + 1];
      for (int i = 0; i <= str1.Length; i++)
        matrix[i, 0] = i;
      for (int j = 0; j <= str2.Length; j++)
        matrix[0, j] = j;

      for (int i = 1; i <= str1.Length; i++)
      {
        for (int j = 1; j <= str2.Length; j++)
        {
          var cost = str1[i - 1] == str2[j - 1] ? 0 : 1;
          matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
        }
      }
      return matrix[str1.Length, str2.Length];
    }

    /// <summary>
    /// 计算字符串相似度（Levenshtein距离）
    /// </summary>
    public static double GetSimilarity(string? str1, string? str2)
    {
      if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
        return 1.0;
      if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        return 0.0;

      var distance = GetLevenshteinDistance(str1, str2);
      var maxLength = Math.Max(str1.Length, str2.Length);
      return maxLength == 0 ? 1.0 : 1.0 - (double)distance / maxLength;
    }
    #endregion
  }
}