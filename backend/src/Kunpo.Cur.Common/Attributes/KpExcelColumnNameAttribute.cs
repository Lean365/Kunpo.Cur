// -----------------------------------------------------------------------
// <copyright file="KpExcelColumnNameAttribute.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>Excel列名属性</summary>
// -----------------------------------------------------------------------

using System;

namespace Kunpo.Cur.Common.Attributes
{
  /// <summary>
  /// Excel列名特性
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class KpExcelColumnNameAttribute : Attribute
  {
    /// <summary>
    /// 列名
    /// </summary>
    public string? ColumnName { get; }

    /// <summary>
    /// 是否忽略
    /// </summary>
    public bool ExcelIgnore { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="columnName">列名</param>
    public KpExcelColumnNameAttribute(string? columnName)
    {
      ColumnName = columnName;
      ExcelIgnore = false;
    }
  }
}