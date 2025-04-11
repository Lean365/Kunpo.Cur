// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>翻译服务实现</summary>
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
  /// 翻译服务实现
  /// </summary>
  public class KpTranslateService : KpBaseService, IKpTranslateService
  {
    private readonly IKpBaseRepository<KpTranslate> _translateRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="translateRepository">翻译仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpTranslateService(
      ILogger<KpTranslateService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpTranslate> translateRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _translateRepository = translateRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    public async Task<KpPageResult<KpTranslateDto>> GetListAsync(KpTranslateQueryDto query)
    {
      var predicate = Expressionable.Create<KpTranslate>()
        .AndIF(!string.IsNullOrEmpty(query.TranslateKey), it => it.TranslateKey != null && it.TranslateKey.Contains(query.TranslateKey!))
        .AndIF(!string.IsNullOrEmpty(query.TranslateValue), it => it.TranslateValue != null && it.TranslateValue.Contains(query.TranslateValue!))
        .AndIF(query.LanguageId.HasValue, it => it.Language != null && it.Language.Id == query.LanguageId)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _translateRepository.GetPageAsync<KpTranslateDto>(request, predicate.ToExpression());

      return new KpPageResult<KpTranslateDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取翻译详情
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>翻译详情</returns>
    public async Task<KpTranslateDto> GetByIdAsync(long id)
    {
      var translate = await _translateRepository.GetByIdAsync(id);
      if (translate == null)
      {
        throw new KpBusinessException("翻译不存在");
      }
      return _mapper.Map<KpTranslateDto>(translate);
    }

    /// <summary>
    /// 创建翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>翻译ID</returns>
    public async Task<long> CreateAsync(KpTranslateCreateDto input)
    {
      var translate = _mapper.Map<KpTranslate>(input);
      await _translateRepository.CreateAsync(translate);
      return translate.Id;
    }

    /// <summary>
    /// 更新翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpTranslateUpdateDto input)
    {
      var translate = await _translateRepository.GetByIdAsync(input.Id);
      if (translate == null)
      {
        throw new KpBusinessException("翻译不存在");
      }

      _mapper.Map(input, translate);
      return await _translateRepository.UpdateAsync(translate);
    }

    /// <summary>
    /// 删除翻译
    /// </summary>
    /// <param name="id">翻译ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var translate = await _translateRepository.GetByIdAsync(id);
      if (translate == null)
      {
        throw new KpBusinessException("翻译不存在");
      }

      return await _translateRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出翻译列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>翻译列表</returns>
    public async Task<List<KpTranslateExportDto>> ExportListAsync(KpTranslateQueryDto query)
    {
      var predicate = Expressionable.Create<KpTranslate>()
        .AndIF(!string.IsNullOrEmpty(query.TranslateKey), it => it.TranslateKey != null && it.TranslateKey.Contains(query.TranslateKey!))
        .AndIF(!string.IsNullOrEmpty(query.TranslateValue), it => it.TranslateValue != null && it.TranslateValue.Contains(query.TranslateValue!))
        .AndIF(query.LanguageId.HasValue, it => it.Language != null && it.Language.Id == query.LanguageId)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var translateList = await _translateRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpTranslateExportDto>>(translateList);
    }

    /// <summary>
    /// 转置翻译数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的翻译数据</returns>
    public async Task<List<KpTranslateTransposeDto>> TransposeAsync(KpTranslateQueryDto query)
    {
      var predicate = Expressionable.Create<KpTranslate>()
        .AndIF(!string.IsNullOrEmpty(query.TranslateKey), it => it.TranslateKey != null && it.TranslateKey.Contains(query.TranslateKey!))
        .AndIF(!string.IsNullOrEmpty(query.TranslateValue), it => it.TranslateValue != null && it.TranslateValue.Contains(query.TranslateValue!))
        .AndIF(query.LanguageId.HasValue, it => it.Language != null && it.Language.Id == query.LanguageId)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var translateList = await _translateRepository.GetListAsync(predicate.ToExpression());

      // 按翻译键分组
      var groupedTranslates = translateList
        .GroupBy(t => t.TranslateKey)
        .Select(g => new KpTranslateTransposeDto
        {
          TranslateKey = g.Key,
          TranslateDesc = g.FirstOrDefault()?.TranslateDesc,
          IsEnabled = g.FirstOrDefault()?.IsEnabled ?? 1,
          OrderNum = g.FirstOrDefault()?.OrderNum ?? 0,
          Translations = g.ToDictionary(
            t => t.LanguageCode ?? string.Empty,
            t => t.TranslateValue ?? string.Empty
          )
        })
        .ToList();

      return groupedTranslates;
    }

    /// <summary>
    /// 导入翻译
    /// </summary>
    /// <param name="input">翻译信息</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(KpTranslateImportDto input)
    {
      var result = new KpImportResult();
      try
      {
        var translate = _mapper.Map<KpTranslate>(input);
        translate.CreatedTime = DateTime.Now;
        translate.CreatedBy = GetCurrentUserName();
        await _translateRepository.CreateAsync(translate);
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
    /// 获取翻译导入模板
    /// </summary>
    /// <returns>翻译导入模板</returns>
    public async Task<KpTranslateTemplateDto> GetTemplateAsync()
    {
      return new KpTranslateTemplateDto
      {
        TranslateKey = string.Empty,
        TranslateValue = string.Empty,
        LanguageId = 0,
        LanguageName = string.Empty,
        TranslateDesc = string.Empty,
        IsEnabled = 1,
        OrderNum = 0
      };
    }

    /// <summary>
    /// 修改翻译状态
    /// </summary>
    /// <param name="input">翻译状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpTranslateChangeStatusDto input)
    {
      var translate = await _translateRepository.GetByIdAsync(input.Id);
      if (translate == null)
      {
        throw new KpBusinessException("翻译不存在");
      }

      translate.IsEnabled = input.IsEnabled;
      return await _translateRepository.UpdateAsync(translate);
    }
  }
}