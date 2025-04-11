// -----------------------------------------------------------------------
// <copyright file="KpLoginLogService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录日志服务实现</summary>
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
  /// 登录日志服务实现
  /// </summary>
  public class KpLoginLogService : KpBaseService, IKpLoginLogService
  {
    private readonly IKpBaseRepository<KpLoginLog> _loginLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="loginLogRepository">登录日志仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpLoginLogService(
      ILogger<KpLoginLogService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpLoginLog> loginLogRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _loginLogRepository = loginLogRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    public async Task<KpPageResult<KpLoginLogDto>> GetListAsync(KpLoginLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpLoginLog>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(query.LoginType.HasValue, it => it.LoginType == query.LoginType)
        .AndIF(query.LoginStatus.HasValue, it => it.LoginStatus == query.LoginStatus)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _loginLogRepository.GetPageAsync<KpLoginLogDto>(request, predicate.ToExpression());

      return new KpPageResult<KpLoginLogDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取登录日志详情
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>登录日志详情</returns>
    public async Task<KpLoginLogDto> GetByIdAsync(long id)
    {
      var loginLog = await _loginLogRepository.GetByIdAsync(id);
      if (loginLog == null)
      {
        throw new KpBusinessException("登录日志不存在");
      }
      return _mapper.Map<KpLoginLogDto>(loginLog);
    }

    /// <summary>
    /// 创建登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>登录日志ID</returns>
    public async Task<long> CreateAsync(KpLoginLogCreateDto input)
    {
      var loginLog = _mapper.Map<KpLoginLog>(input);
      await _loginLogRepository.CreateAsync(loginLog);
      return loginLog.Id;
    }

    /// <summary>
    /// 更新登录日志
    /// </summary>
    /// <param name="input">登录日志信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpLoginLogUpdateDto input)
    {
      var loginLog = await _loginLogRepository.GetByIdAsync(input.Id);
      if (loginLog == null)
      {
        throw new KpBusinessException("登录日志不存在");
      }

      _mapper.Map(input, loginLog);
      return await _loginLogRepository.UpdateAsync(loginLog);
    }

    /// <summary>
    /// 删除登录日志
    /// </summary>
    /// <param name="id">登录日志ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var loginLog = await _loginLogRepository.GetByIdAsync(id);
      if (loginLog == null)
      {
        throw new KpBusinessException("登录日志不存在");
      }

      return await _loginLogRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出登录日志列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录日志列表</returns>
    public async Task<List<KpLoginLogExportDto>> ExportListAsync(KpLoginLogQueryDto query)
    {
      var predicate = Expressionable.Create<KpLoginLog>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(query.LoginType.HasValue, it => it.LoginType == query.LoginType)
        .AndIF(query.LoginStatus.HasValue, it => it.LoginStatus == query.LoginStatus)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var loginLogs = await _loginLogRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpLoginLogExportDto>>(loginLogs);
    }
  }
}