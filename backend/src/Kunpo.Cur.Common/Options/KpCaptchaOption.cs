// -----------------------------------------------------------------------
// <copyright file="KpCaptchaOption.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>滑块验证码配置</summary>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Options
{
  /// <summary>
  /// 滑块验证码配置
  /// </summary>
  public class KpCaptchaOption
  {
    /// <summary>
    /// 图片宽度
    /// </summary>
    public int Width { get; set; } = 300;

    /// <summary>
    /// 图片高度
    /// </summary>
    public int Height { get; set; } = 150;

    /// <summary>
    /// 滑块宽度
    /// </summary>
    public int SliderWidth { get; set; } = 50;

    /// <summary>
    /// 滑块高度
    /// </summary>
    public int SliderHeight { get; set; } = 50;

    /// <summary>
    /// 容错范围
    /// </summary>
    public int Tolerance { get; set; } = 5;

    /// <summary>
    /// 模板图片路径（相对于wwwroot目录）
    /// </summary>
    public string? TemplatePath { get; set; }

    /// <summary>
    /// 背景图片路径（相对于wwwroot目录）
    /// </summary>
    public string? BackgroundPath { get; set; }

    /// <summary>
    /// 背景图片URL模板
    /// </summary>
    public string? BackgroundUrl { get; set; }
  }
}