// -----------------------------------------------------------------------
// <copyright file="KpPageRequest.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>分页请求参数</summary>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Kunpo.Cur.Common.Models
{
  /// <summary>
  /// 分页请求参数
  /// </summary>
  public class KpPageRequest
  {
    /// <summary>
    /// 页码
    /// </summary>
    public int PageNum { get; set; } = 1;

    /// <summary>
    /// 每页大小
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// 排序字段
    /// </summary>
    public string? OrderBy { get; set; }

    /// <summary>
    /// 排序方式
    /// </summary>
    /// <remarks>
    /// asc：升序
    /// desc：降序
    /// </remarks>
    public string? OrderType { get; set; } = "asc";

    /// <summary>
    /// 查询条件
    /// </summary>
    public Dictionary<string, object> Conditions { get; set; } = new();

    /// <summary>
    /// 时间范围
    /// </summary>
    public Dictionary<string, string[]> TimeRanges { get; set; } = new();

    /// <summary>
    /// 关键字
    /// </summary>
    public string? Keyword { get; set; }

    /// <summary>
    /// 关键字字段
    /// </summary>
    public string[]? KeywordFields { get; set; }
  }
}