// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>日期时间工具类</summary>
// <remarks>处理日期时间的获取、转换、格式化等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.Globalization;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 日期时间工具类
  /// </summary>
  public static class KpDateTimeHelper
  {
    /// <summary>
    /// 获取当前时间戳（毫秒）
    /// </summary>
    public static long GetTimestamp()
    {
      return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    /// <summary>
    /// 获取当前时间戳（秒）
    /// </summary>
    public static long GetTimestampSeconds()
    {
      return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    /// <summary>
    /// 时间戳转DateTime
    /// </summary>
    /// <param name="timestamp">时间戳（毫秒）</param>
    public static DateTime TimestampToDateTime(long timestamp)
    {
      return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
    }

    /// <summary>
    /// DateTime转时间戳（毫秒）
    /// </summary>
    public static long DateTimeToTimestamp(DateTime dateTime)
    {
      return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
    }

    /// <summary>
    /// 获取日期范围
    /// </summary>
    /// <param name="startDate">开始日期</param>
    /// <param name="endDate">结束日期</param>
    public static (DateTime Start, DateTime End) GetDateRange(DateTime startDate, DateTime endDate)
    {
      startDate = startDate.Date;
      endDate = endDate.Date.AddDays(1).AddSeconds(-1);
      return (startDate, endDate);
    }

    /// <summary>
    /// 获取本周的开始和结束日期
    /// </summary>
    public static (DateTime Start, DateTime End) GetWeekRange(DateTime date)
    {
      var culture = CultureInfo.CurrentCulture;
      var diff = (7 + (date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek)) % 7;
      var startDate = date.AddDays(-diff).Date;
      var endDate = startDate.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
      return (startDate, endDate);
    }

    /// <summary>
    /// 获取本月的开始和结束日期
    /// </summary>
    public static (DateTime Start, DateTime End) GetMonthRange(DateTime date)
    {
      var startDate = new DateTime(date.Year, date.Month, 1);
      var endDate = startDate.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
      return (startDate, endDate);
    }

    /// <summary>
    /// 获取本季度的开始和结束日期
    /// </summary>
    public static (DateTime Start, DateTime End) GetQuarterRange(DateTime date)
    {
      var quarter = (date.Month - 1) / 3;
      var startDate = new DateTime(date.Year, quarter * 3 + 1, 1);
      var endDate = startDate.AddMonths(3).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
      return (startDate, endDate);
    }

    /// <summary>
    /// 获取本年的开始和结束日期
    /// </summary>
    public static (DateTime Start, DateTime End) GetYearRange(DateTime date)
    {
      var startDate = new DateTime(date.Year, 1, 1);
      var endDate = startDate.AddYears(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
      return (startDate, endDate);
    }

    /// <summary>
    /// 获取相对时间描述
    /// </summary>
    public static string? GetRelativeTime(DateTime dateTime)
    {
      var now = DateTime.Now;
      var diff = now - dateTime;

      if (diff.TotalSeconds < 60)
        return "刚刚";
      if (diff.TotalMinutes < 60)
        return $"{(int)diff.TotalMinutes}分钟前";
      if (diff.TotalHours < 24)
        return $"{(int)diff.TotalHours}小时前";
      if (diff.TotalDays < 30)
        return $"{(int)diff.TotalDays}天前";
      if (diff.TotalDays < 365)
        return $"{(int)(diff.TotalDays / 30)}个月前";
      return $"{(int)(diff.TotalDays / 365)}年前";
    }

    /// <summary>
    /// 格式化日期时间
    /// </summary>
    public static string? FormatDateTime(DateTime dateTime, string? format = "yyyy-MM-dd HH:mm:ss")
    {
      return dateTime.ToString(format);
    }

    /// <summary>
    /// 解析日期时间字符串
    /// </summary>
    public static DateTime? ParseDateTime(string? dateTimeStr, string? format = "yyyy-MM-dd HH:mm:ss")
    {
      if (DateTime.TryParseExact(dateTimeStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        return result;
      return null;
    }

    /// <summary>
    /// 获取工作日
    /// </summary>
    public static int GetWorkDays(DateTime startDate, DateTime endDate)
    {
      var days = 0;
      var current = startDate;

      while (current <= endDate)
      {
        if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
          days++;
        current = current.AddDays(1);
      }

      return days;
    }

    /// <summary>
    /// 获取年龄
    /// </summary>
    public static int GetAge(DateTime birthDate)
    {
      var today = DateTime.Today;
      var age = today.Year - birthDate.Year;
      if (birthDate.Date > today.AddYears(-age))
        age--;
      return age;
    }

    /// <summary>
    /// 判断是否为同一天
    /// </summary>
    public static bool IsSameDay(DateTime date1, DateTime date2)
    {
      return date1.Date == date2.Date;
    }

    /// <summary>
    /// 判断是否为同一周
    /// </summary>
    public static bool IsSameWeek(DateTime date1, DateTime date2)
    {
      var culture = CultureInfo.CurrentCulture;
      var diff = (7 + (date1.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek)) % 7;
      var weekStart1 = date1.AddDays(-diff).Date;
      diff = (7 + (date2.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek)) % 7;
      var weekStart2 = date2.AddDays(-diff).Date;
      return weekStart1 == weekStart2;
    }

    /// <summary>
    /// 判断是否为同一月
    /// </summary>
    public static bool IsSameMonth(DateTime date1, DateTime date2)
    {
      return date1.Year == date2.Year && date1.Month == date2.Month;
    }

    /// <summary>
    /// 判断是否为同一季度
    /// </summary>
    public static bool IsSameQuarter(DateTime date1, DateTime date2)
    {
      return date1.Year == date2.Year && (date1.Month - 1) / 3 == (date2.Month - 1) / 3;
    }

    /// <summary>
    /// 判断是否为同一年
    /// </summary>
    public static bool IsSameYear(DateTime date1, DateTime date2)
    {
      return date1.Year == date2.Year;
    }
  }
}