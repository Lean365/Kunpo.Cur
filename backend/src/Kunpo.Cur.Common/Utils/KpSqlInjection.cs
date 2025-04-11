// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL注入防护工具类</summary>
// <remarks>处理SQL注入的防护</remarks>
// -----------------------------------------------------------------------

using System.Text.RegularExpressions;
using Kunpo.Cur.Common.Options;
using Serilog;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// SQL注入防护工具类
  /// </summary>
  public static class KpSqlInjection
  {
    private static readonly string[] _sqlKeywords = new[]
    {
      "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "UNION", "JOIN",
      "WHERE", "FROM", "INTO", "VALUES", "SET", "HAVING", "GROUP BY",
      "ORDER BY", "AND", "OR", "NOT", "LIKE", "IN", "EXISTS", "BETWEEN"
    };

    private static readonly string[] _sqlOperators = new[]
    {
      "=", "<", ">", "<=", ">=", "<>", "!=", "!<", "!>",
      "+", "-", "*", "/", "%", "&", "|", "^", "~"
    };

    private static KpSqlInjectionOptions _options = new();
    private static Serilog.ILogger? _logger;

    /// <summary>
    /// 配置
    /// </summary>
    public static KpSqlInjectionOptions Options
    {
      get => _options;
      set => _options = value ?? new KpSqlInjectionOptions();
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
    /// 防止SQL注入
    /// </summary>
    /// <param name="input">输入字符串</param>
    /// <returns>安全字符串</returns>
    public static string Sanitize(string input)
    {
      if (!_options.Enabled || string.IsNullOrEmpty(input))
      {
        return input;
      }

      try
      {
        var originalInput = input;

        // 移除SQL关键字
        foreach (var keyword in _sqlKeywords)
        {
          input = Regex.Replace(input, keyword, "", RegexOptions.IgnoreCase);
        }

        // 移除SQL运算符
        foreach (var op in _sqlOperators)
        {
          input = input.Replace(op, "");
        }

        // 移除注释
        input = Regex.Replace(input, "--.*$", "", RegexOptions.Multiline);
        input = Regex.Replace(input, "/\\*.*?\\*/", "", RegexOptions.Singleline);

        // 移除多余空格
        input = Regex.Replace(input, "\\s+", " ").Trim();

        // 如果输入被修改，记录日志
        if (_options.LogEnabled && input != originalInput)
        {
          _logger?.Warning("SQL注入防护：输入被修改。原始输入：{OriginalInput}，修改后：{SanitizedInput}",
            originalInput, input);
        }

        return input;
      }
      catch (Exception ex)
      {
        _logger?.Error(ex, "SQL注入防护处理失败：{Input}", input);

        if (_options.ThrowException)
        {
          throw;
        }

        return input;
      }
    }
  }
}