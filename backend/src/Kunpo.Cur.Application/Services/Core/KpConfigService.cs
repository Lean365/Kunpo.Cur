// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>配置服务实现</summary>
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
  /// 配置服务实现
  /// </summary>
  public class KpConfigService : KpBaseService, IKpConfigService
  {
    private readonly IKpBaseRepository<KpConfig> _configRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="configRepository">配置仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpConfigService(
      ILogger<KpConfigService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpConfig> configRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _configRepository = configRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    public async Task<KpPageResult<KpConfigDto>> GetListAsync(KpConfigQueryDto query)
    {
      var predicate = Expressionable.Create<KpConfig>()
        .AndIF(!string.IsNullOrEmpty(query.ConfigKey), it => it.ConfigKey != null && it.ConfigKey.Contains(query.ConfigKey!))
        .AndIF(!string.IsNullOrEmpty(query.ConfigGroup), it => it.ConfigGroup != null && it.ConfigGroup.Contains(query.ConfigGroup!))
        .AndIF(query.ConfigType.HasValue, it => it.ConfigType == query.ConfigType.Value)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled.Value);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _configRepository.GetPageAsync<KpConfigDto>(request, predicate.ToExpression());

      return new KpPageResult<KpConfigDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取配置详情
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>配置详情</returns>
    public async Task<KpConfigDto> GetByIdAsync(long id)
    {
      var config = await _configRepository.GetByIdAsync(id);
      if (config == null)
      {
        throw new KpBusinessException("配置不存在");
      }
      return _mapper.Map<KpConfigDto>(config);
    }

    /// <summary>
    /// 创建配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>配置ID</returns>
    public async Task<long> CreateAsync(KpConfigCreateDto input)
    {
      var config = _mapper.Map<KpConfig>(input);
      await _configRepository.CreateAsync(config);
      return config.Id;
    }

    /// <summary>
    /// 更新配置
    /// </summary>
    /// <param name="input">配置信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpConfigUpdateDto input)
    {
      var config = await _configRepository.GetByIdAsync(input.Id);
      if (config == null)
      {
        throw new KpBusinessException("配置不存在");
      }

      _mapper.Map(input, config);
      config.UpdatedTime = DateTime.Now;
      config.UpdatedBy = GetCurrentUserName();
      return await _configRepository.UpdateAsync(config);
    }

    /// <summary>
    /// 删除配置
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var config = await _configRepository.GetByIdAsync(id);
      if (config == null)
      {
        throw new KpBusinessException("配置不存在");
      }

      return await _configRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出配置列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>配置列表</returns>
    public async Task<List<KpConfigExportDto>> ExportListAsync(KpConfigQueryDto query)
    {
      var predicate = Expressionable.Create<KpConfig>()
        .AndIF(!string.IsNullOrEmpty(query.ConfigKey), it => it.ConfigKey != null && it.ConfigKey.Contains(query.ConfigKey!))
        .AndIF(!string.IsNullOrEmpty(query.ConfigGroup), it => it.ConfigGroup != null && it.ConfigGroup.Contains(query.ConfigGroup!))
        .AndIF(query.ConfigType.HasValue, it => it.ConfigType == query.ConfigType.Value)
        .AndIF(query.IsEnabled.HasValue, it => it.IsEnabled == query.IsEnabled.Value);

      var configs = await _configRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpConfigExportDto>>(configs);
    }

    /// <summary>
    /// 导入配置数据
    /// </summary>
    /// <param name="input">导入数据</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(KpConfigImportDto input)
    {
      var result = new KpImportResult
      {
        Total = 1,
        Success = 0,
        Fail = 0,
        Errors = new List<string>()
      };

      try
      {
        var config = _mapper.Map<KpConfig>(input);
        config.CreatedTime = DateTime.Now;
        config.CreatedBy = GetCurrentUserName();
        await _configRepository.CreateAsync(config);
        result.Success++;
      }
      catch (Exception ex)
      {
        result.Fail++;
        result.Errors.Add($"导入配置失败：{ex.Message}");
      }

      return result;
    }

    /// <summary>
    /// 获取配置模板
    /// </summary>
    /// <returns>配置模板</returns>
    public async Task<KpConfigTemplateDto> GetTemplateAsync()
    {
      var template = new KpConfigTemplateDto
      {
        ConfigKey = "配置键",
        ConfigValue = "配置值",
        ConfigDesc = "配置描述",
        ConfigType = 0,
        ConfigGroup = "配置分组",
        IsEnabled = 1,
        OrderNum = 0
      };

      return template;
    }

    /// <summary>
    /// 更改配置状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpConfigChangeStatusDto input)
    {
      var config = await _configRepository.GetByIdAsync(input.Id);
      if (config == null)
      {
        throw new KpBusinessException("配置不存在");
      }

      config.IsEnabled = input.IsEnabled;
      return await _configRepository.UpdateAsync(config);
    }
  }
}