// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>验证码扩展方法</summary>
// <remarks>处理验证码的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Common.Utils;
using Kunpo.Cur.Common.Options;
using Microsoft.AspNetCore.Builder;

namespace Kunpo.Cur.Common.Extensions
{
  /// <summary>
  /// 验证码扩展方法
  /// </summary>
  public static class KpCaptchaExtensions
  {
    /// <summary>
    /// 添加验证码服务
    /// </summary>
    public static IServiceCollection AddKpCaptcha(this IServiceCollection services, IConfiguration configuration)
    {
      // 注册验证码配置
      services.Configure<KpCaptchaOption>(configuration.GetSection("Captcha"));

      // 注册验证码服务
      services.AddScoped<KpCaptchaHelper>();

      return services;
    }

    /// <summary>
    /// 初始化验证码服务
    /// </summary>
    public static IApplicationBuilder InitializeKpCaptcha(this IApplicationBuilder app)
    {
      // 在应用启动时下载背景图片
      using (var scope = app.ApplicationServices.CreateScope())
      {
        var captchaHelper = scope.ServiceProvider.GetRequiredService<KpCaptchaHelper>();
        captchaHelper.DownloadBackgroundImagesAsync().GetAwaiter().GetResult();
      }

      return app;
    }
  }
}