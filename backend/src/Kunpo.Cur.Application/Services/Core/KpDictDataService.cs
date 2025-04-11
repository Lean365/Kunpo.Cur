// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典数据服务实现</summary>
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
  /// 字典数据服务实现
  /// </summary>
  public class KpDictDataService : KpBaseService, IKpDictDataService
  {
    private readonly IKpBaseRepository<KpDictData> _dictDataRepository;
    private readonly IKpBaseRepository<KpLanguage> _languageRepository;
    private readonly IKpLocalizationService _localizationService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="dictDataRepository">字典数据仓储</param>
    /// <param name="languageRepository">语言数据仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpDictDataService(
      ILogger<KpDictDataService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpDictData> dictDataRepository,
      IKpBaseRepository<KpLanguage> languageRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _dictDataRepository = dictDataRepository;
      _languageRepository = languageRepository;
      _localizationService = localizationService;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    public async Task<KpPageResult<KpDictDataDto>> GetListAsync(KpDictDataQueryDto query)
    {
      var predicate = Expressionable.Create<KpDictData>()
        .AndIF(query.DictTypeId.HasValue, it => it.DictType != null && it.DictType.Id == query.DictTypeId)
        .AndIF(!string.IsNullOrEmpty(query.DictDataLabel), it => it.DictDataName != null && it.DictDataName.Contains(query.DictDataLabel!))
        .AndIF(!string.IsNullOrEmpty(query.DictDataValue), it => it.DictDataValue != null && it.DictDataValue.Contains(query.DictDataValue!))
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _dictDataRepository.GetPageAsync<KpDictDataDto>(request, predicate.ToExpression());

      return new KpPageResult<KpDictDataDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取字典数据详情
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>字典数据详情</returns>
    public async Task<KpDictDataDto> GetByIdAsync(long id)
    {
      var dictData = await _dictDataRepository.GetByIdAsync(id);
      if (dictData == null)
      {
        throw new KpBusinessException("字典数据不存在");
      }
      return _mapper.Map<KpDictDataDto>(dictData);
    }

    /// <summary>
    /// 创建字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>字典数据ID</returns>
    public async Task<long> CreateAsync(KpDictDataCreateDto input)
    {
      var dictData = _mapper.Map<KpDictData>(input);
      await _dictDataRepository.CreateAsync(dictData);
      return dictData.Id;
    }

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpDictDataUpdateDto input)
    {
      var dictData = await _dictDataRepository.GetByIdAsync(input.Id);
      if (dictData == null)
      {
        throw new KpBusinessException("字典数据不存在");
      }

      _mapper.Map(input, dictData);
      return await _dictDataRepository.UpdateAsync(dictData);
    }

    /// <summary>
    /// 删除字典数据
    /// </summary>
    /// <param name="id">字典数据ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var dictData = await _dictDataRepository.GetByIdAsync(id);
      if (dictData == null)
      {
        throw new KpBusinessException("字典数据不存在");
      }

      return await _dictDataRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出字典数据列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典数据列表</returns>
    public async Task<List<KpDictDataExportDto>> ExportListAsync(KpDictDataQueryDto query)
    {
      var predicate = Expressionable.Create<KpDictData>()
        .AndIF(query.DictTypeId.HasValue, it => it.DictType != null && it.DictType.Id == query.DictTypeId)
        .AndIF(!string.IsNullOrEmpty(query.DictDataLabel), it => it.DictDataName != null && it.DictDataName.Contains(query.DictDataLabel!))
        .AndIF(!string.IsNullOrEmpty(query.DictDataValue), it => it.DictDataValue != null && it.DictDataValue.Contains(query.DictDataValue!))
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var dictDataList = await _dictDataRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpDictDataExportDto>>(dictDataList);
    }

    /// <summary>
    /// 转置字典数据
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>转置后的字典数据</returns>
    public async Task<List<KpDictDataTransposeDto>> TransposeAsync(KpDictDataQueryDto query)
    {
      var predicate = Expressionable.Create<KpDictData>()
        .AndIF(query.DictTypeId.HasValue, it => it.DictType != null && it.DictType.Id == query.DictTypeId)
        .AndIF(!string.IsNullOrEmpty(query.DictDataLabel), it => it.DictDataName != null && it.DictDataName.Contains(query.DictDataLabel!))
        .AndIF(!string.IsNullOrEmpty(query.DictDataValue), it => it.DictDataValue != null && it.DictDataValue.Contains(query.DictDataValue!))
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var dictDataList = await _dictDataRepository.GetListAsync(predicate.ToExpression());

      // 获取所有语言
      var languages = await _languageRepository.GetListAsync();

      // 按字典类型代码分组
      var groupedDictData = dictDataList
        .GroupBy(d => d.DictType?.DictTypeCode ?? string.Empty)
        .Select(g =>
        {
          var firstItem = g.FirstOrDefault();
          if (firstItem == null) return null;

          var transposeDto = new KpDictDataTransposeDto
          {
            Id = firstItem.Id,
            DictTypeId = firstItem.DictType?.Id ?? 0,
            DictDataLabel = firstItem.DictDataName,
            DictDataValue = firstItem.DictDataValue,
            DictDataDesc = firstItem.DictDataDesc,
            ExtDataLabel = firstItem.ExtDataLabel,
            ExtDataValue = firstItem.ExtDataValue,
            CssClass = firstItem.CssClass,
            ListClass = firstItem.ListClass,
            IsEnabled = firstItem.IsEnabled,
            OrderNum = firstItem.OrderNum,
            Translations = new Dictionary<string, string>()
          };

          // 添加翻译
          foreach (var language in languages)
          {
            var translation = g.FirstOrDefault(d => d.TranslateKey == language.LanguageCode)?.DictDataName;
            transposeDto.Translations[language.LanguageCode] = translation ?? string.Empty;
          }

          return transposeDto;
        })
        .Where(d => d != null)
        .ToList();

      return groupedDictData!;
    }

    /// <summary>
    /// 导入字典数据
    /// </summary>
    /// <param name="input">字典数据信息</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(KpDictDataImportDto input)
    {
      var result = new KpImportResult();
      try
      {
        var dictData = _mapper.Map<KpDictData>(input);
        dictData.CreatedTime = DateTime.Now;
        dictData.CreatedBy = GetCurrentUserName();
        await _dictDataRepository.CreateAsync(dictData);
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
    /// 修改字典数据状态
    /// </summary>
    /// <param name="input">字典数据状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpDictDataChangeStatusDto input)
    {
      var dictData = await _dictDataRepository.GetByIdAsync(input.Id);
      if (dictData == null)
      {
        throw new KpBusinessException("字典数据不存在");
      }

      dictData.IsEnabled = input.IsEnabled;
      return await _dictDataRepository.UpdateAsync(dictData);
    }

    /// <summary>
    /// 获取字典数据导入模板
    /// </summary>
    /// <returns>字典数据导入模板</returns>
    public async Task<KpDictDataTemplateDto> GetTemplateAsync()
    {
      return new KpDictDataTemplateDto
      {
        DictTypeId = 0,
        DictDataLabel = string.Empty,
        DictDataValue = string.Empty,
        DictDataDesc = string.Empty,
        CssClass = string.Empty,
        ListClass = string.Empty,
        IsEnabled = 1,
        OrderNum = 0
      };
    }
  }
}