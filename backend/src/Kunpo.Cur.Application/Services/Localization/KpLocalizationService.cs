// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>本地化服务实现</summary>
// -----------------------------------------------------------------------


using Microsoft.Extensions.Localization;
using Kunpo.Cur.Domain.Entities.Core;
using Microsoft.AspNetCore.Http;
using Kunpo.Cur.Domain.Interfaces;

namespace Kunpo.Cur.Application.Services.Localization
{
  /// <summary>
  /// 本地化服务实现
  /// </summary>
  public class KpLocalizationService : IKpLocalizationService
  {
    private readonly IStringLocalizer<KpLocalizationService> _localizer;
    private readonly IKpBaseRepository<KpLanguage> _languageRepository;
    private readonly IKpBaseRepository<KpTranslate> _translateRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string LanguageCookieName = "KpLanguage";

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="localizer">本地化器</param>
    /// <param name="languageRepository">语言仓储</param>
    /// <param name="translateRepository">翻译仓储</param>
    /// <param name="httpContextAccessor">HTTP上下文访问器</param>
    public KpLocalizationService(
      IStringLocalizer<KpLocalizationService> localizer,
      IKpBaseRepository<KpLanguage> languageRepository,
      IKpBaseRepository<KpTranslate> translateRepository,
      IHttpContextAccessor httpContextAccessor)
    {
      _localizer = localizer;
      _languageRepository = languageRepository;
      _translateRepository = translateRepository;
      _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 获取本地化文本
    /// </summary>
    public string GetString(string resourceType, string resourceKey, params object[] args)
    {
      // 从翻译表获取
      var translate = _translateRepository.GetFirstOrDefaultAsync(x =>
        x.TranslateKey == resourceKey &&
        x.LanguageCode == GetCurrentLanguageId()
      ).Result;

      if (translate != null)
      {
        return string.Format(translate.TranslateValue, args);
      }

      // 如果翻译表没有，则从资源文件获取
      return _localizer[resourceKey, args];
    }

    /// <summary>
    /// 获取本地化文本（带默认值）
    /// </summary>
    public string GetString(string resourceType, string resourceKey, string defaultValue, params object[] args)
    {
      // 从翻译表获取
      var translate = _translateRepository.GetFirstOrDefaultAsync(x =>
        x.TranslateKey == resourceKey &&
        x.LanguageCode == GetCurrentLanguageId()
      ).Result;

      if (translate != null)
      {
        return string.Format(translate.TranslateValue, args);
      }

      // 如果翻译表没有，则从资源文件获取
      var value = _localizer[resourceKey, args];
      return string.IsNullOrEmpty(value) ? defaultValue : value;
    }

    /// <summary>
    /// 获取当前语言
    /// </summary>
    public KpLanguage? GetCurrentLanguage()
    {
      var languageId = GetCurrentLanguageId();
      return _languageRepository.GetFirstOrDefaultAsync(x => x.Id.ToString() == languageId).Result;
    }

    /// <summary>
    /// 设置当前语言
    /// </summary>
    public void SetCurrentLanguage(string languageId)
    {
      var language = _languageRepository.GetFirstOrDefaultAsync(x => x.Id.ToString() == languageId).Result;
      if (language != null && language.IsEnabled == 1)
      {
        var options = new CookieOptions
        {
          Expires = DateTime.Now.AddYears(1),
          HttpOnly = true,
          SameSite = SameSiteMode.Lax
        };
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(LanguageCookieName, languageId, options);
      }
    }

    /// <summary>
    /// 获取当前语言ID
    /// </summary>
    private string GetCurrentLanguageId()
    {
      // 从Cookie获取
      var languageId = _httpContextAccessor.HttpContext?.Request.Cookies[LanguageCookieName];
      if (!string.IsNullOrEmpty(languageId))
      {
        return languageId;
      }

      // 从请求头获取
      languageId = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"].ToString();
      if (!string.IsNullOrEmpty(languageId))
      {
        var language = _languageRepository.GetFirstOrDefaultAsync(x => x.LanguageCode == languageId).Result;
        if (language != null && language.IsEnabled == 1)
        {
          return language.Id.ToString();
        }
      }

      // 获取默认语言
      var defaultLanguage = _languageRepository.GetFirstOrDefaultAsync(x => x.IsDefault == 1 && x.IsEnabled == 1).Result;
      return defaultLanguage?.Id.ToString() ?? string.Empty;
    }
  }
}