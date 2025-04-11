using Kunpo.Cur.Application.Services.Identity;
using Kunpo.Cur.Application.Services.Localization;
using Kunpo.Cur.Common.Apps;
using Kunpo.Cur.Common.Cache;
using Kunpo.Cur.Common.Extensions;
using Kunpo.Cur.Common.Filters;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Common.Options;
using Kunpo.Cur.Common.Utils;
using Kunpo.Cur.Domain.Entities.Core;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Infrastructure.Data;
using Kunpo.Cur.Infrastructure.Data.Identity;
using Kunpo.Cur.Infrastructure.Extensions;
using Kunpo.Cur.Infrastructure.Repositories;
using Kunpo.Cur.Infrastructure.Services;
using Kunpo.Cur.Infrastructure.Setup;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Kunpo.Cur.Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);

// 配置 Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext());

// 添加跨域服务
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
  {
    policy.WithOrigins(
          "http://localhost:5172",  // 前端 HTTP
          "https://localhost:7172", // 前端 HTTPS
          "http://localhost:5173",  // 后端 HTTP
          "https://localhost:7173"  // 后端 HTTPS
      )
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials()
      .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
  });
});

// 配置选项
builder.Services.Configure<KpJwtOption>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<KpCacheOption>(builder.Configuration.GetSection("Cache"));
builder.Services.Configure<KpCaptchaOption>(builder.Configuration.GetSection("Captcha"));

// 添加数据库服务
builder.Services.AddKpDatabase(builder.Configuration);

// 配置 JWT
builder.Services.AddScoped<IKpJwtService, KpJwtService>();

// 添加用户上下文服务
builder.Services.AddScoped<IKpUserContext, KpUserContext>();

// 添加用户仓储服务
builder.Services.AddScoped<IKpBaseRepository<KpUser>, KpBaseRepository<KpUser>>();

// 添加令牌黑名单仓储服务
builder.Services.AddScoped<IKpBaseRepository<KpTokenBlacklist>, KpBaseRepository<KpTokenBlacklist>>();

// 添加认证服务
builder.Services.AddScoped<IKpAuthService, KpAuthService>();

// 添加安全服务
builder.Services.AddKpSecurity(builder.Configuration);

// 添加安全上下文服务
builder.Services.AddScoped<IKpSecurityContext, KpSecurityContext>();

// 添加授权服务
builder.Services.AddAuthorization();

// 添加 Swagger 服务
builder.Services.AddKpSwagger();

// 添加缓存服务
builder.Services.AddKpCache(builder.Configuration);

// 添加验证码服务
builder.Services.AddKpCaptcha(builder.Configuration);

// 添加本地化服务
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
builder.Services.AddScoped<IKpLocalizationService, KpLocalizationService>();

// 添加语言和翻译仓储服务
builder.Services.AddScoped<IKpBaseRepository<KpLanguage>, KpBaseRepository<KpLanguage>>();
builder.Services.AddScoped<IKpBaseRepository<KpTranslate>, KpBaseRepository<KpTranslate>>();

// 添加 HTTP 上下文访问器
builder.Services.AddHttpContextAccessor();

// 添加 SignalR 服务
builder.Services.AddSignalR();
builder.Services.AddKpSignalR();

// 添加控制器
builder.Services.AddControllers(options =>
{
  options.Filters.Add<KpPermissionFilter>();
});

// 添加AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 添加服务
builder.Services.AddKpServices(builder.Configuration);

// 添加仓储
builder.Services.AddScoped(typeof(IKpBaseRepository<>), typeof(KpBaseRepository<>));

// 添加本地化服务
builder.Services.AddScoped<IKpLocalizationService, KpLocalizationService>();

// 初始化IP位置数据库
var dbPath = Path.Combine(builder.Environment.WebRootPath, "data", "ip2region.xdb");
KpIpLocationHelper.Initialize(dbPath);

var app = builder.Build();

// 初始化 KpApp
KpInternalApp.Initialize(app.Services, app.Environment, builder.Configuration);

// 使用跨域中间件
app.UseCors();

// 开启访问静态文件/wwwroot目录文件
app.UseStaticFiles();

// 使用 Serilog 请求日志
app.UseSerilogRequestLogging();

// 配置安全中间件
app.UseKpSecurity();

// 配置中间件
if (app.Environment.IsDevelopment())
{
  app.UseKpSwagger();
}

// 配置 SignalR 路由
app.MapHub<HbtSignalRHub>("/signalr/hub");

app.UseHttpsRedirection();

app.UseAuthorization();

// 确保 wwwroot 目录存在
var captchaOptions = app.Services.GetRequiredService<IOptions<KpCaptchaOption>>().Value;
var wwwrootPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot");
if (!Directory.Exists(wwwrootPath))
{
  Directory.CreateDirectory(wwwrootPath);
  app.Logger.LogInformation("创建wwwroot目录: {Path}", wwwrootPath);
}

var backgroundPath = Path.Combine(wwwrootPath, captchaOptions.BackgroundPath);
if (!Directory.Exists(backgroundPath))
{
  Directory.CreateDirectory(backgroundPath);
  app.Logger.LogInformation("创建背景图片目录: {Path}", backgroundPath);
}

var templatePath = Path.Combine(wwwrootPath, captchaOptions.TemplatePath);
if (!Directory.Exists(templatePath))
{
  Directory.CreateDirectory(templatePath);
  app.Logger.LogInformation("创建模板目录: {Path}", templatePath);
}

// 初始化验证码服务
using (var scope = app.Services.CreateScope())
{
  var captchaHelper = scope.ServiceProvider.GetRequiredService<KpCaptchaHelper>();
  await captchaHelper.DownloadBackgroundImagesAsync();
}

// 初始化数据库
using (var scope = app.Services.CreateScope())
{
  var dbOptions = scope.ServiceProvider.GetRequiredService<IOptions<KpDatabaseOption>>().Value;
  var dbInitializer = scope.ServiceProvider.GetRequiredService<KpDbInitializer>();

  // 如果需要初始化数据库结构或种子数据
  if (dbOptions.EnableInitData || dbOptions.EnableInitSeedsData)
  {
    dbInitializer.Initialize();
  }
  else
  {
    app.Logger.LogInformation("跳过数据库初始化 (EnableInitData = false, EnableInitSeedsData = false)");
  }
}

app.Run();