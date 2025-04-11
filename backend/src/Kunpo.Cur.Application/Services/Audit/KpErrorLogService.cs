// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>错误日志服务实现</summary>
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
  /// 错误日志服务实现
  /// </summary>
  public class KpErrorLogService : KpBaseService, IKpErrorLogService
  {
    private readonly IKpBaseRepository<KpErrorLog> _errorLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="errorLogRepository">错误日志仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpErrorLogService(
      ILogger<KpErrorLogService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpErrorLog> errorLogRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _errorLogRepository = errorLogRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    public async Task<KpPageResult<KpErrorLogDto>> GetListAsync(KpErrorLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpErrorLog>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(query.ErrorType.HasValue, it => it.ErrorType == query.ErrorType)
        .AndIF(!string.IsNullOrEmpty(query.ErrorCode), it => it.ErrorCode != null && it.ErrorCode.Contains(query.ErrorCode!))
        .AndIF(!string.IsNullOrEmpty(query.ErrorIp), it => it.ErrorIp != null && it.ErrorIp.Contains(query.ErrorIp!))
        .AndIF(!string.IsNullOrEmpty(query.RequestUrl), it => it.RequestUrl != null && it.RequestUrl.Contains(query.RequestUrl!))
        .AndIF(!string.IsNullOrEmpty(query.RequestMethod), it => it.RequestMethod != null && it.RequestMethod.Contains(query.RequestMethod!))
        .AndIF(query.StartTime.HasValue, it => it.ErrorTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.ErrorTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _errorLogRepository.GetPageAsync<KpErrorLogDto>(request, predicate.ToExpression());

      return new KpPageResult<KpErrorLogDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取错误日志详情
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>错误日志详情</returns>
    public async Task<KpErrorLogDto> GetByIdAsync(long id)
    {
      var errorLog = await _errorLogRepository.GetByIdAsync(id);
      if (errorLog == null)
      {
        throw new KpBusinessException("错误日志不存在");
      }
      return _mapper.Map<KpErrorLogDto>(errorLog);
    }

    /// <summary>
    /// 创建错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>错误日志ID</returns>
    public async Task<long> CreateAsync(KpErrorLogCreateDto input)
    {
      var errorLog = _mapper.Map<KpErrorLog>(input);
      await _errorLogRepository.CreateAsync(errorLog);
      return errorLog.Id;
    }

    /// <summary>
    /// 更新错误日志
    /// </summary>
    /// <param name="input">错误日志信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpErrorLogUpdateDto input)
    {
      var errorLog = await _errorLogRepository.GetByIdAsync(input.Id);
      if (errorLog == null)
      {
        throw new KpBusinessException("错误日志不存在");
      }

      _mapper.Map(input, errorLog);
      return await _errorLogRepository.UpdateAsync(errorLog);
    }

    /// <summary>
    /// 删除错误日志
    /// </summary>
    /// <param name="id">错误日志ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var errorLog = await _errorLogRepository.GetByIdAsync(id);
      if (errorLog == null)
      {
        throw new KpBusinessException("错误日志不存在");
      }

      return await _errorLogRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出错误日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>错误日志列表</returns>
    public async Task<List<KpErrorLogExportDto>> ExportListAsync(KpErrorLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpErrorLog>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(query.ErrorType.HasValue, it => it.ErrorType == query.ErrorType)
        .AndIF(!string.IsNullOrEmpty(query.ErrorCode), it => it.ErrorCode != null && it.ErrorCode.Contains(query.ErrorCode!))
        .AndIF(!string.IsNullOrEmpty(query.ErrorIp), it => it.ErrorIp != null && it.ErrorIp.Contains(query.ErrorIp!))
        .AndIF(!string.IsNullOrEmpty(query.RequestUrl), it => it.RequestUrl != null && it.RequestUrl.Contains(query.RequestUrl!))
        .AndIF(!string.IsNullOrEmpty(query.RequestMethod), it => it.RequestMethod != null && it.RequestMethod.Contains(query.RequestMethod!))
        .AndIF(query.StartTime.HasValue, it => it.ErrorTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.ErrorTime <= query.EndTime);

      var errorLogs = await _errorLogRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpErrorLogExportDto>>(errorLogs);
    }
  }
}