// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>撤销日志服务实现</summary>
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
  /// 撤销日志服务实现
  /// </summary>
  public class KpRevokeLogService : KpBaseService, IKpRevokeLogService
  {
    private readonly IKpBaseRepository<KpRevokeLog> _revokeLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="revokeLogRepository">撤销日志仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpRevokeLogService(
      ILogger<KpRevokeLogService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpRevokeLog> revokeLogRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _revokeLogRepository = revokeLogRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    public async Task<KpPageResult<KpRevokeLogDto>> GetListAsync(KpRevokeLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpRevokeLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessNo), it => it.BusinessNo != null && it.BusinessNo.Contains(query.BusinessNo!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessTitle), it => it.BusinessTitle != null && it.BusinessTitle.Contains(query.BusinessTitle!))
        .AndIF(query.BusinessType.HasValue, it => it.BusinessType == query.BusinessType)
        .AndIF(query.BusinessId.HasValue, it => it.BusinessId == query.BusinessId)
        .AndIF(query.RevokeStatus.HasValue, it => it.RevokeStatus == query.RevokeStatus)
        .AndIF(query.StartTime.HasValue, it => it.RevokeTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.RevokeTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _revokeLogRepository.GetPageAsync<KpRevokeLogDto>(request, predicate.ToExpression());

      return new KpPageResult<KpRevokeLogDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取撤销日志详情
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>撤销日志详情</returns>
    public async Task<KpRevokeLogDto> GetByIdAsync(long id)
    {
      var revokeLog = await _revokeLogRepository.GetByIdAsync(id);
      if (revokeLog == null)
      {
        throw new KpBusinessException("撤销日志不存在");
      }
      return _mapper.Map<KpRevokeLogDto>(revokeLog);
    }

    /// <summary>
    /// 创建撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>撤销日志ID</returns>
    public async Task<long> CreateAsync(KpRevokeLogCreateDto input)
    {
      var revokeLog = _mapper.Map<KpRevokeLog>(input);
      await _revokeLogRepository.CreateAsync(revokeLog);
      return revokeLog.Id;
    }

    /// <summary>
    /// 更新撤销日志
    /// </summary>
    /// <param name="input">撤销日志信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpRevokeLogUpdateDto input)
    {
      var revokeLog = await _revokeLogRepository.GetByIdAsync(input.Id);
      if (revokeLog == null)
      {
        throw new KpBusinessException("撤销日志不存在");
      }

      _mapper.Map(input, revokeLog);
      return await _revokeLogRepository.UpdateAsync(revokeLog);
    }

    /// <summary>
    /// 删除撤销日志
    /// </summary>
    /// <param name="id">撤销日志ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var revokeLog = await _revokeLogRepository.GetByIdAsync(id);
      if (revokeLog == null)
      {
        throw new KpBusinessException("撤销日志不存在");
      }

      return await _revokeLogRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出撤销日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>撤销日志列表</returns>
    public async Task<List<KpRevokeLogExportDto>> ExportListAsync(KpRevokeLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpRevokeLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessNo), it => it.BusinessNo != null && it.BusinessNo.Contains(query.BusinessNo!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessTitle), it => it.BusinessTitle != null && it.BusinessTitle.Contains(query.BusinessTitle!))
        .AndIF(query.BusinessType.HasValue, it => it.BusinessType == query.BusinessType)
        .AndIF(query.BusinessId.HasValue, it => it.BusinessId == query.BusinessId)
        .AndIF(query.RevokeStatus.HasValue, it => it.RevokeStatus == query.RevokeStatus)
        .AndIF(query.StartTime.HasValue, it => it.RevokeTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.RevokeTime <= query.EndTime);

      var revokeLogs = await _revokeLogRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpRevokeLogExportDto>>(revokeLogs);
    }
  }
}