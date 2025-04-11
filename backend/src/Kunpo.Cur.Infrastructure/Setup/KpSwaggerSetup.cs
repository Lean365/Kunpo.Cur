// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>Swagger配置</summary>
// <remarks>处理Swagger的配置</remarks>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Kunpo.Cur.Infrastructure.Setup
{
  /// <summary>
  /// Swagger 配置
  /// </summary>
  public static class KpSwaggerSetup
  {
    /// <summary>
    /// 添加 Swagger 服务
    /// </summary>
    public static IServiceCollection AddKpSwagger(this IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Kunpo.Cur API",
          Version = "v1",
          Description = "Kunpo.Cur API 文档",
          Contact = new OpenApiContact
          {
            Name = "Kunpo Tech",
            Email = "support@kunpo.tech",
            Url = new Uri("https://www.kunpo.tech")
          }
        });

        // 添加 JWT 认证
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
          });

        // 使用 XML 注释
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
        {
          options.IncludeXmlComments(xmlPath);
        }
      });

      return services;
    }

    /// <summary>
    /// 使用 Swagger
    /// </summary>
    public static IApplicationBuilder UseKpSwagger(this IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Kunpo.Cur API v1");
        options.RoutePrefix = "swagger";
        options.DocumentTitle = "Kunpo.Cur API 文档";
        options.DefaultModelsExpandDepth(-1); // 隐藏模型
      });

      return app;
    }
  }
}