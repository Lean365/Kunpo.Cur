// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>语言服务实现</summary>
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kunpo.Cur.Application.Dtos.Core;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Entities.Core;
using Kunpo.Cur.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Exceptions;
using System.Linq.Expressions;
using SqlSugar;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using Microsoft.Extensions.Configuration;

namespace Kunpo.Cur.Application.Services.Core
{
  /// <summary>
  /// 语言服务实现
  /// </summary>
  public class KpLanguageService : KpBaseService, IKpLanguageService
  {
    private readonly IKpBaseRepository<KpLanguage> _languageRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="languageRepository">语言仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpLanguageService(
      ILogger<KpLanguageService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpLanguage> languageRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _languageRepository = languageRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    public async Task<KpPageResult<KpLanguageDto>> GetListAsync(KpLanguageQueryDto query)
    {
      var predicate = Expressionable.Create<KpLanguage>()
        .AndIF(!string.IsNullOrEmpty(query.LanguageName), it => it.LanguageName != null && it.LanguageName.Contains(query.LanguageName!))
        .AndIF(!string.IsNullOrEmpty(query.LanguageCode), it => it.LanguageCode != null && it.LanguageCode.Contains(query.LanguageCode!))
        .AndIF(query.IsDefault.HasValue, it => it.IsDefault == query.IsDefault)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled >= query.IsEnabled);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _languageRepository.GetPageAsync<KpLanguageDto>(request, predicate.ToExpression());

      return new KpPageResult<KpLanguageDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取语言详情
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>语言详情</returns>
    public async Task<KpLanguageDto> GetByIdAsync(long id)
    {
      var language = await _languageRepository.GetByIdAsync(id);
      if (language == null)
      {
        throw new KpBusinessException("语言不存在");
      }
      return _mapper.Map<KpLanguageDto>(language);
    }

    /// <summary>
    /// 创建语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>语言ID</returns>
    public async Task<long> CreateAsync(KpLanguageCreateDto input)
    {
      var language = _mapper.Map<KpLanguage>(input);
      await _languageRepository.CreateAsync(language);
      return language.Id;
    }

    /// <summary>
    /// 更新语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpLanguageUpdateDto input)
    {
      var language = await _languageRepository.GetByIdAsync(input.Id);
      if (language == null)
      {
        throw new KpBusinessException("语言不存在");
      }

      _mapper.Map(input, language);
      return await _languageRepository.UpdateAsync(language);
    }

    /// <summary>
    /// 删除语言
    /// </summary>
    /// <param name="id">语言ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var language = await _languageRepository.GetByIdAsync(id);
      if (language == null)
      {
        throw new KpBusinessException("语言不存在");
      }

      return await _languageRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出语言列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>语言列表</returns>
    public async Task<List<KpLanguageExportDto>> ExportListAsync(KpLanguageQueryDto query)
    {
      var predicate = Expressionable.Create<KpLanguage>()
        .AndIF(!string.IsNullOrEmpty(query.LanguageName), it => it.LanguageName != null && it.LanguageName.Contains(query.LanguageName!))
        .AndIF(!string.IsNullOrEmpty(query.LanguageCode), it => it.LanguageCode != null && it.LanguageCode.Contains(query.LanguageCode!))
        .AndIF(query.IsDefault.HasValue, it => it.IsDefault == query.IsDefault)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled >= query.IsEnabled);

      var languageList = await _languageRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpLanguageExportDto>>(languageList);
    }

    /// <summary>
    /// 导入语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(KpLanguageImportDto input)
    {
      var result = new KpImportResult();
      try
      {
        var language = _mapper.Map<KpLanguage>(input);
        language.CreatedTime = DateTime.Now;
        language.CreatedBy = GetCurrentUserName();
        await _languageRepository.CreateAsync(language);
        result.Success++;
      }
      catch (Exception ex)
      {
        result.Fail++;
        result.Errors.Add(ex.Message);
      }
      return result;
    }

    /// <summary>
    /// 获取语言导入模板
    /// </summary>
    /// <returns>语言导入模板</returns>
    public async Task<KpLanguageTemplateDto> GetTemplateAsync()
    {
      return new KpLanguageTemplateDto
      {
        LanguageCode = string.Empty,
        LanguageName = string.Empty,
        IsDefault = 0,
        IsEnabled = 1,
        OrderNum = 0
      };
    }

    /// <summary>
    /// 修改语言状态
    /// </summary>
    /// <param name="input">语言状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpLanguageChangeStatusDto input)
    {
      var language = await _languageRepository.GetByIdAsync(input.Id);
      if (language == null)
      {
        throw new KpBusinessException("语言不存在");
      }

      language.IsEnabled = input.IsEnabled;
      return await _languageRepository.UpdateAsync(language);
    }

    /// <summary>
    /// 设置默认语言
    /// </summary>
    /// <param name="input">语言信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> SetDefaultAsync(KpLanguageSetDefaultDto input)
    {
      var language = await _languageRepository.GetByIdAsync(input.Id);
      if (language == null)
      {
        throw new KpBusinessException("语言不存在");
      }

      // 先将所有语言设置为非默认
      var allLanguages = await _languageRepository.GetListAsync();
      foreach (var lang in allLanguages)
      {
        lang.IsDefault = 0;
        await _languageRepository.UpdateAsync(lang);
      }

      // 将指定语言设置为默认
      language.IsDefault = 1;
      return await _languageRepository.UpdateAsync(language);
    }
  }
}