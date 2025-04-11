// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>操作日志服务实现</summary>
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Entities.Audit;
using Kunpo.Cur.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Exceptions;
using System.Linq.Expressions;
using SqlSugar;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using Microsoft.Extensions.Configuration;

namespace Kunpo.Cur.Application.Services.Audit
{
  /// <summary>
  /// 操作日志服务实现
  /// </summary>
  public class KpOperLogService : KpBaseService, IKpOperLogService
  {
    private readonly IKpBaseRepository<KpOperLog> _operLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="operLogRepository">操作日志仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpOperLogService(
      ILogger<KpOperLogService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpOperLog> operLogRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _operLogRepository = operLogRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    public async Task<KpPageResult<KpOperLogDto>> GetListAsync(KpOperLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpOperLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.OperModule), it => it.OperModule != null && it.OperModule.Contains(query.OperModule!))
        .AndIF(!string.IsNullOrEmpty(query.OperFunction), it => it.OperFunction != null && it.OperFunction.Contains(query.OperFunction!))
        .AndIF(query.OperType.HasValue, it => it.OperType == query.OperType)
        .AndIF(query.OperStatus.HasValue, it => it.OperStatus == query.OperStatus)
        .AndIF(query.StartTime.HasValue, it => it.OperTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.OperTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _operLogRepository.GetPageAsync<KpOperLogDto>(request, predicate.ToExpression());

      return new KpPageResult<KpOperLogDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取操作日志详情
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>操作日志详情</returns>
    public async Task<KpOperLogDto> GetByIdAsync(long id)
    {
      var operLog = await _operLogRepository.GetByIdAsync(id);
      if (operLog == null)
      {
        throw new KpBusinessException("操作日志不存在");
      }
      return _mapper.Map<KpOperLogDto>(operLog);
    }

    /// <summary>
    /// 创建操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>操作日志ID</returns>
    public async Task<long> CreateAsync(KpOperLogCreateDto input)
    {
      var operLog = _mapper.Map<KpOperLog>(input);
      await _operLogRepository.CreateAsync(operLog);
      return operLog.Id;
    }

    /// <summary>
    /// 更新操作日志
    /// </summary>
    /// <param name="input">操作日志信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpOperLogUpdateDto input)
    {
      var operLog = await _operLogRepository.GetByIdAsync(input.Id);
      if (operLog == null)
      {
        throw new KpBusinessException("操作日志不存在");
      }

      _mapper.Map(input, operLog);
      return await _operLogRepository.UpdateAsync(operLog);
    }

    /// <summary>
    /// 删除操作日志
    /// </summary>
    /// <param name="id">操作日志ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var operLog = await _operLogRepository.GetByIdAsync(id);
      if (operLog == null)
      {
        throw new KpBusinessException("操作日志不存在");
      }

      return await _operLogRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出操作日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>操作日志列表</returns>
    public async Task<List<KpOperLogExportDto>> ExportListAsync(KpOperLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpOperLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.OperModule), it => it.OperModule != null && it.OperModule.Contains(query.OperModule!))
        .AndIF(!string.IsNullOrEmpty(query.OperFunction), it => it.OperFunction != null && it.OperFunction.Contains(query.OperFunction!))
        .AndIF(query.OperType.HasValue, it => it.OperType == query.OperType)
        .AndIF(query.OperStatus.HasValue, it => it.OperStatus == query.OperStatus)
        .AndIF(query.StartTime.HasValue, it => it.OperTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.OperTime <= query.EndTime);

      var operLogs = await _operLogRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpOperLogExportDto>>(operLogs);
    }
  }
}