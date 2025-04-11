// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>导入结果模型</summary>
// <remarks>处理导入结果的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Kunpo.Cur.Common.Models
{
  /// <summary>
  /// 导入结果模型
  /// </summary>
  public class KpImportResult
  {
    /// <summary>
    /// 总数
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// 成功数
    /// </summary>
    public int Success { get; set; }

    /// <summary>
    /// 失败数
    /// </summary>
    public int Fail { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public List<string> Errors { get; set; } = new List<string>();
  }
}