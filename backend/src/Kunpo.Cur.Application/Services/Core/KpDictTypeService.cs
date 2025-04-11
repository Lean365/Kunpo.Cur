// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>字典类型服务实现</summary>
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
  /// 字典类型服务实现
  /// </summary>
  public class KpDictTypeService : KpBaseService, IKpDictTypeService
  {
    private readonly IKpBaseRepository<KpDictType> _dictTypeRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="dictTypeRepository">字典类型仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpDictTypeService(
      ILogger<KpDictTypeService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpDictType> dictTypeRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _dictTypeRepository = dictTypeRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    public async Task<KpPageResult<KpDictTypeDto>> GetListAsync(KpDictTypeQueryDto query)
    {
      var predicate = Expressionable.Create<KpDictType>()
        .AndIF(!string.IsNullOrEmpty(query.DictTypeName), it => it.DictTypeName != null && it.DictTypeName.Contains(query.DictTypeName!))
        .AndIF(!string.IsNullOrEmpty(query.DictTypeCode), it => it.DictTypeCode != null && it.DictTypeCode.Contains(query.DictTypeCode!))
        .AndIF(query.DictSource.HasValue, it => it.DictSource == query.DictSource)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _dictTypeRepository.GetPageAsync<KpDictTypeDto>(request, predicate.ToExpression());

      return new KpPageResult<KpDictTypeDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取字典类型详情
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>字典类型详情</returns>
    public async Task<KpDictTypeDto> GetByIdAsync(long id)
    {
      var dictType = await _dictTypeRepository.GetByIdAsync(id);
      if (dictType == null)
      {
        throw new KpBusinessException("字典类型不存在");
      }
      return _mapper.Map<KpDictTypeDto>(dictType);
    }

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>字典类型ID</returns>
    public async Task<long> CreateAsync(KpDictTypeCreateDto input)
    {
      var dictType = _mapper.Map<KpDictType>(input);
      await _dictTypeRepository.CreateAsync(dictType);
      return dictType.Id;
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpDictTypeUpdateDto input)
    {
      var dictType = await _dictTypeRepository.GetByIdAsync(input.Id);
      if (dictType == null)
      {
        throw new KpBusinessException("字典类型不存在");
      }

      _mapper.Map(input, dictType);
      return await _dictTypeRepository.UpdateAsync(dictType);
    }

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">字典类型ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var dictType = await _dictTypeRepository.GetByIdAsync(id);
      if (dictType == null)
      {
        throw new KpBusinessException("字典类型不存在");
      }

      return await _dictTypeRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出字典类型列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>字典类型列表</returns>
    public async Task<List<KpDictTypeExportDto>> ExportListAsync(KpDictTypeQueryDto query)
    {
      var predicate = Expressionable.Create<KpDictType>()
        .AndIF(!string.IsNullOrEmpty(query.DictTypeName), it => it.DictTypeName != null && it.DictTypeName.Contains(query.DictTypeName!))
        .AndIF(!string.IsNullOrEmpty(query.DictTypeCode), it => it.DictTypeCode != null && it.DictTypeCode.Contains(query.DictTypeCode!))
        .AndIF(query.DictSource.HasValue, it => it.DictSource == query.DictSource)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled);

      var dictTypeList = await _dictTypeRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpDictTypeExportDto>>(dictTypeList);
    }

    /// <summary>
    /// 导入字典类型
    /// </summary>
    /// <param name="input">字典类型信息</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(KpDictTypeImportDto input)
    {
      var result = new KpImportResult();
      try
      {
        var dictType = _mapper.Map<KpDictType>(input);
        dictType.CreatedTime = DateTime.Now;
        dictType.CreatedBy = GetCurrentUserName();
        await _dictTypeRepository.CreateAsync(dictType);
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
    /// 修改字典类型状态
    /// </summary>
    /// <param name="input">字典类型状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpDictTypeChangeStatusDto input)
    {
      var dictType = await _dictTypeRepository.GetByIdAsync(input.Id);
      if (dictType == null)
      {
        throw new KpBusinessException("字典类型不存在");
      }

      dictType.IsEnabled = input.IsEnabled;
      return await _dictTypeRepository.UpdateAsync(dictType);
    }

    /// <summary>
    /// 获取字典类型导入模板
    /// </summary>
    /// <returns>字典类型导入模板</returns>
    public async Task<KpDictTypeTemplateDto> GetTemplateAsync()
    {
      return new KpDictTypeTemplateDto
      {
        DictTypeName = string.Empty,
        DictTypeCode = string.Empty,
        DictTypeDesc = string.Empty,
        DictSource = 1,
        DictSqlScript = string.Empty,
        IsEnabled = 1,
        OrderNum = 0
      };
    }
  }
}