// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>审计日志服务实现</summary>
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
  /// 审计日志服务实现
  /// </summary>
  public class KpAuditLogService : KpBaseService, IKpAuditLogService
  {
    private readonly IKpBaseRepository<KpAuditLog> _auditLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="auditLogRepository">审计日志仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpAuditLogService(
      ILogger<KpAuditLogService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpAuditLog> auditLogRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _auditLogRepository = auditLogRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    public async Task<KpPageResult<KpAuditLogDto>> GetListAsync(KpAuditLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpAuditLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessType.ToString()), it => it.BusinessType == query.BusinessType)
        .AndIF(!string.IsNullOrEmpty(query.BusinessNo), it => it.BusinessNo != null && it.BusinessNo.Contains(query.BusinessNo!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessTitle), it => it.BusinessTitle != null && it.BusinessTitle.Contains(query.BusinessTitle!))
        .AndIF(!string.IsNullOrEmpty(query.AuditType.ToString()), it => it.AuditType == query.AuditType)
        .AndIF(!string.IsNullOrEmpty(query.AuditStatus.ToString()), it => it.AuditStatus == query.AuditStatus)
        .AndIF(!string.IsNullOrEmpty(query.Auditor), it => it.Auditor != null && it.Auditor.Contains(query.Auditor!))
        .AndIF(query.StartTime.HasValue, it => it.OperTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.OperTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _auditLogRepository.GetPageAsync<KpAuditLogDto>(request, predicate.ToExpression());

      return new KpPageResult<KpAuditLogDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取审计日志详情
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>审计日志详情</returns>
    public async Task<KpAuditLogDto> GetByIdAsync(long id)
    {
      var auditLog = await _auditLogRepository.GetByIdAsync(id);
      if (auditLog == null)
      {
        throw new KpBusinessException("审计日志不存在");
      }
      return _mapper.Map<KpAuditLogDto>(auditLog);
    }

    /// <summary>
    /// 创建审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>审计日志ID</returns>
    public async Task<long> CreateAsync(KpAuditLogCreateDto input)
    {
      var auditLog = _mapper.Map<KpAuditLog>(input);
      await _auditLogRepository.CreateAsync(auditLog);
      return auditLog.Id;
    }

    /// <summary>
    /// 更新审计日志
    /// </summary>
    /// <param name="input">审计日志信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpAuditLogUpdateDto input)
    {
      var auditLog = await _auditLogRepository.GetByIdAsync(input.Id);
      if (auditLog == null)
      {
        throw new KpBusinessException("审计日志不存在");
      }

      _mapper.Map(input, auditLog);
      return await _auditLogRepository.UpdateAsync(auditLog);
    }

    /// <summary>
    /// 删除审计日志
    /// </summary>
    /// <param name="id">审计日志ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var auditLog = await _auditLogRepository.GetByIdAsync(id);
      if (auditLog == null)
      {
        throw new KpBusinessException("审计日志不存在");
      }

      return await _auditLogRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出审计日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>审计日志列表</returns>
    public async Task<List<KpAuditLogExportDto>> ExportListAsync(KpAuditLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpAuditLog>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessType.ToString()), it => it.BusinessType == query.BusinessType)
        .AndIF(!string.IsNullOrEmpty(query.BusinessNo), it => it.BusinessNo != null && it.BusinessNo.Contains(query.BusinessNo!))
        .AndIF(!string.IsNullOrEmpty(query.BusinessTitle), it => it.BusinessTitle != null && it.BusinessTitle.Contains(query.BusinessTitle!))
        .AndIF(!string.IsNullOrEmpty(query.AuditType.ToString()), it => it.AuditType == query.AuditType)
        .AndIF(!string.IsNullOrEmpty(query.AuditStatus.ToString()), it => it.AuditStatus == query.AuditStatus)
        .AndIF(!string.IsNullOrEmpty(query.Auditor), it => it.Auditor != null && it.Auditor.Contains(query.Auditor!))
        .AndIF(query.StartTime.HasValue, it => it.OperTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.OperTime <= query.EndTime);

      var auditLogs = await _auditLogRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpAuditLogExportDto>>(auditLogs);
    }
  }
}