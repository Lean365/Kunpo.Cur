// -----------------------------------------------------------------------
// <copyright file="KpPageResult.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>分页结果</summary>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Kunpo.Cur.Common.Models
{
  /// <summary>
  /// 分页结果
  /// </summary>
  public class KpPageResult<T>
  {
    /// <summary>
    /// 总记录数
    /// </summary>
    public long Total { get; set; }

    /// <summary>
    /// 当前页码
    /// </summary>
    public int PageNum { get; set; }

    /// <summary>
    /// 每页大小
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// 是否有上一页
    /// </summary>
    public bool HasPrevious { get; set; }

    /// <summary>
    /// 是否有下一页
    /// </summary>
    public bool HasNext { get; set; }

    /// <summary>
    /// 数据列表
    /// </summary>
    public List<T> List { get; set; } = new();

    /// <summary>
    /// 创建分页结果
    /// </summary>
    public static KpPageResult<T> Create(long total, int pageNum, int pageSize, List<T> list)
    {
      var totalPages = (int)((total + pageSize - 1) / pageSize);
      return new KpPageResult<T>
      {
        Total = total,
        PageNum = pageNum,
        PageSize = pageSize,
        TotalPages = totalPages,
        HasPrevious = pageNum > 1,
        HasNext = pageNum < totalPages,
        List = list
      };
    }
  }
}