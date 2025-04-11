// -----------------------------------------------------------------------
// <copyright file="KpExcelOption.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>Excel配置选项</summary>
// -----------------------------------------------------------------------

using System;

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// Excel配置选项
  /// </summary>
  public class KpExcelOption
  {
    /// <summary>
    /// Excel包配置
    /// </summary>
    public ExcelPackageOption? ExcelPackage { get; set; }

    /// <summary>
    /// 工作簿配置
    /// </summary>
    public WorkbookOption? Workbook { get; set; }
  }

  /// <summary>
  /// Excel包配置
  /// </summary>
  public class ExcelPackageOption
  {
    /// <summary>
    /// 许可证上下文
    /// </summary>
    public string? LicenseContext { get; set; }

    /// <summary>
    /// 兼容性配置
    /// </summary>
    public CompatibilityOption? Compatibility { get; set; }
  }

  /// <summary>
  /// 兼容性配置
  /// </summary>
  public class CompatibilityOption
  {
    /// <summary>
    /// 工作表是否基于1
    /// </summary>
    public bool IsWorksheets1Based { get; set; }
  }

  /// <summary>
  /// 工作簿配置
  /// </summary>
  public class WorkbookOption
  {
    /// <summary>
    /// 工作簿属性
    /// </summary>
    public PropertiesOption? Properties { get; set; }
  }

  /// <summary>
  /// 工作簿属性配置
  /// </summary>
  public class PropertiesOption
  {
    /// <summary>
    /// 作者
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// 类别
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// 公司
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    public string? Manager { get; set; }

    /// <summary>
    /// 应用程序
    /// </summary>
    public string? Application { get; set; }

    /// <summary>
    /// 应用程序版本
    /// </summary>
    public string? AppVersion { get; set; }

    /// <summary>
    /// 超链接基础地址
    /// </summary>
    public string? HyperlinkBase { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }
  }
}