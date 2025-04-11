// -----------------------------------------------------------------------
// <copyright file="KpCaptchaHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>滑块验证码帮助类</summary>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Security.Cryptography;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Common.Options;
using Kunpo.Cur.Common.Apps;
using Kunpo.Cur.Common.Utils;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 滑块验证码帮助类
  /// </summary>
  public class KpCaptchaHelper
  {
    private readonly KpCaptchaOption _options;
    private readonly HttpClient _httpClient;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<KpCaptchaHelper> _logger;

    public KpCaptchaHelper(
      IOptions<KpCaptchaOption> options,
      IWebHostEnvironment webHostEnvironment,
      ILogger<KpCaptchaHelper> logger)
    {
      _options = options.Value;
      _httpClient = new HttpClient();
      _webHostEnvironment = webHostEnvironment;
      _logger = logger;
    }

    /// <summary>
    /// 下载背景图片
    /// </summary>
    public async Task DownloadBackgroundImagesAsync()
    {
      _logger.LogInformation("开始下载验证码背景图片...");

      // 确保wwwroot目录存在
      var wwwrootPath = _webHostEnvironment.WebRootPath ?? throw new InvalidOperationException("WebRootPath未配置");
      if (!Directory.Exists(wwwrootPath))
      {
        Directory.CreateDirectory(wwwrootPath);
        _logger.LogInformation("创建wwwroot目录: {Path}", wwwrootPath);
      }

      // 构建完整的背景图片保存路径
      var backgroundPath = System.IO.Path.Combine(
        wwwrootPath,
        _options.BackgroundPath ?? throw new InvalidOperationException("BackgroundPath未配置"));

      _logger.LogInformation("背景图片保存路径: {BackgroundPath}", backgroundPath);

      // 确保背景图片目录存在
      if (!Directory.Exists(backgroundPath))
      {
        Directory.CreateDirectory(backgroundPath);
        _logger.LogInformation("创建背景图片目录: {Path}", backgroundPath);
      }

      // 清空目录
      KpFileHelper.DeleteFilesInDirectory(backgroundPath, "background_*.jpg");
      _logger.LogInformation("已清空背景图片目录");

      // 下载5张图片
      var tasks = new List<Task>();
      for (int i = 1; i <= 5; i++)
      {
        var fileName = $"background_{i}.jpg";
        var filePath = System.IO.Path.Combine(backgroundPath, fileName);
        _logger.LogInformation("开始下载第 {Index} 张背景图片: {FileName}", i, fileName);
        tasks.Add(DownloadImageAsync(i, filePath));
      }

      // 等待所有下载任务完成
      await Task.WhenAll(tasks);
      _logger.LogInformation("所有背景图片下载完成");

      // 验证是否有5张有效的图片
      var validFiles = Directory.GetFiles(backgroundPath, "background_*.jpg")
        .Where(f => new FileInfo(f).Length > 0)
        .ToList();

      if (validFiles.Count < 5)
      {
        var error = $"背景图片下载不完整，当前只有 {validFiles.Count} 张有效图片";
        _logger.LogError(error);
        throw new InvalidOperationException(error);
      }

      _logger.LogInformation("验证码背景图片初始化完成，共 {Count} 张有效图片", validFiles.Count);
    }

    private async Task DownloadImageAsync(int index, string filePath)
    {
      try
      {
        // 使用固定的图片ID范围（1-1000）来确保每次都能获取到不同的图片
        var imageId = (index + DateTime.Now.Second) % 1000 + 1;
        var url = _options.BackgroundUrl?
          .Replace("{width}", _options.Width.ToString())
          .Replace("{height}", _options.Height.ToString())
          .Replace("{index}", imageId.ToString())
          ?? throw new InvalidOperationException("BackgroundUrl 未配置");

        _logger.LogDebug("下载第 {Index} 张背景图片，URL: {Url}", index, url);

        using var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var bytes = await response.Content.ReadAsByteArrayAsync();

        // 验证下载的内容是否为有效的图片
        using var ms = new MemoryStream(bytes);
        using var img = await Image.LoadAsync<Rgba32>(ms);

        // 保存文件
        await File.WriteAllBytesAsync(filePath, bytes);
        _logger.LogInformation("第 {Index} 张背景图片下载成功，大小: {Size} 字节", index, bytes.Length);
      }
      catch (Exception ex)
      {
        var error = $"下载背景图片 {index} 失败: {ex.Message}";
        _logger.LogError(ex, error);
        throw new InvalidOperationException(error);
      }
    }

    /// <summary>
    /// 生成滑块验证码
    /// </summary>
    /// <param name="backgroundImage">背景图片</param>
    /// <param name="width">图片宽度</param>
    /// <param name="height">图片高度</param>
    /// <param name="sliderWidth">滑块宽度</param>
    /// <param name="sliderHeight">滑块高度</param>
    /// <returns>验证码信息</returns>
    public (string BackgroundBase64, string SliderBase64, int X) GenerateCaptcha()
    {
      // 1. 获取背景图片目录
      var backgroundDir = System.IO.Path.Combine(
        _webHostEnvironment.WebRootPath ?? throw new InvalidOperationException("WebRootPath未配置"),
        _options.BackgroundPath ?? throw new InvalidOperationException("BackgroundPath未配置"));
      var backgroundFiles = Directory.GetFiles(backgroundDir, "*.jpg");

      if (backgroundFiles.Length == 0)
      {
        throw new FileNotFoundException("未找到背景图片，请先调用 DownloadBackgroundImagesAsync 下载背景图片");
      }

      // 2. 随机选择一张背景图片
      var backgroundRandom = new Random();
      var backgroundFile = backgroundFiles[backgroundRandom.Next(backgroundFiles.Length)];
      using var background = Image.Load<Rgba32>(backgroundFile);

      // 3. 创建画布
      using var canvas = new Image<Rgba32>(_options.Width, _options.Height);

      // 4. 绘制背景
      canvas.Mutate(x => x.DrawImage(background, new Point(0, 0), 1f));

      // 5. 生成随机位置
      var random = new Random();
      var x = random.Next(_options.Width - _options.SliderWidth);
      var y = (_options.Height - _options.SliderHeight) / 2; // 固定Y轴位置在中间

      // 6. 加载缺口和滑块模板
      var templateDir = System.IO.Path.Combine(
        _webHostEnvironment.WebRootPath ?? throw new InvalidOperationException("WebRootPath未配置"),
        _options.TemplatePath ?? throw new InvalidOperationException("TemplatePath未配置"));

      // 随机选择一个模板目录(1-5)
      var templateIndex = random.Next(1, 6);
      var templatePath = System.IO.Path.Combine(templateDir, templateIndex.ToString());

      // 加载缺口模板
      var holePath = System.IO.Path.Combine(templatePath, "hole.png");
      if (!File.Exists(holePath))
      {
        throw new FileNotFoundException($"未找到缺口模板: {holePath}");
      }
      using var hole = Image.Load<Rgba32>(holePath);
      using var holeResized = hole.Clone(ctx => ctx.Resize(_options.SliderWidth, _options.SliderHeight));

      // 在背景上绘制缺口
      canvas.Mutate(ctx => ctx.DrawImage(holeResized, new Point(x, y), 1f));

      // 加载滑块模板
      var sliderPath = System.IO.Path.Combine(templatePath, "slider.png");
      if (!File.Exists(sliderPath))
      {
        throw new FileNotFoundException($"未找到滑块模板: {sliderPath}");
      }
      using var slider = Image.Load<Rgba32>(sliderPath);
      using var sliderResized = slider.Clone(ctx => ctx.Resize(_options.SliderWidth, _options.SliderHeight));

      // 7. 添加干扰线
      for (int i = 0; i < 5; i++)
      {
        var startX = random.Next(_options.Width);
        var startY = random.Next(_options.Height);
        var endX = random.Next(_options.Width);
        var endY = random.Next(_options.Height);
        canvas.Mutate(x => x.DrawLine(Color.White, 1, new PointF(startX, startY), new PointF(endX, endY)));
      }

      // 8. 转换为Base64
      using var ms1 = new MemoryStream();
      canvas.SaveAsPng(ms1);
      var backgroundBase64 = Convert.ToBase64String(ms1.ToArray());

      using var ms2 = new MemoryStream();
      sliderResized.SaveAsPng(ms2);
      var sliderBase64 = Convert.ToBase64String(ms2.ToArray());

      return (backgroundBase64, sliderBase64, x);
    }

    /// <summary>
    /// 验证滑块位置
    /// </summary>
    /// <param name="captchaId">验证码ID</param>
    /// <param name="x">滑块X坐标</param>
    /// <param name="y">滑块Y坐标</param>
    /// <param name="tolerance">容错范围</param>
    /// <returns>验证结果</returns>
    public bool VerifyCaptcha(string captchaId, int x, int y, int? tolerance = null)
    {
      // TODO: 从缓存或数据库中获取验证码信息
      // 这里需要实现验证码信息的存储和获取逻辑
      var actualTolerance = tolerance ?? 10; // 默认误差10px
      var actualX = x; // 实际X坐标
      var actualY = y; // 实际Y坐标

      // 验证X坐标是否在误差范围内
      return Math.Abs(actualX - x) <= actualTolerance;
    }

    /// <summary>
    /// 将图片转换为Base64字符串
    /// </summary>
    private static string ImageToBase64(Image image)
    {
      using var ms = new MemoryStream();
      image.SaveAsPng(ms);
      return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// 生成验证码ID
    /// </summary>
    private static string GenerateCaptchaId()
    {
      var bytes = new byte[16];
      using var rng = RandomNumberGenerator.Create();
      rng.GetBytes(bytes);
      return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
  }

  /// <summary>
  /// 验证码信息
  /// </summary>
  public class KpCaptchaInfo
  {
    /// <summary>
    /// 验证码ID
    /// </summary>
    public string CaptchaId { get; set; } = string.Empty;

    /// <summary>
    /// 背景图片（Base64）
    /// </summary>
    public string BackgroundImage { get; set; } = string.Empty;

    /// <summary>
    /// 滑块图片（Base64）
    /// </summary>
    public string SliderImage { get; set; } = string.Empty;

    /// <summary>
    /// 滑块X坐标
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// 滑块Y坐标
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// 图片宽度
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// 图片高度
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// 滑块宽度
    /// </summary>
    public int SliderWidth { get; set; }

    /// <summary>
    /// 滑块高度
    /// </summary>
    public int SliderHeight { get; set; }
  }
}