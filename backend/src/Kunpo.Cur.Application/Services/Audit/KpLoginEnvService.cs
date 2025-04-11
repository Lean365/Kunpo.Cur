// -----------------------------------------------------------------------
// <copyright file="KpLoginEnvService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录环境服务实现</summary>
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
  /// 登录环境服务实现
  /// </summary>
  public class KpLoginEnvService : KpBaseService, IKpLoginEnvService
  {
    private readonly IKpBaseRepository<KpLoginEnv> _loginEnvRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="loginEnvRepository">登录环境仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpLoginEnvService(
      ILogger<KpLoginEnvService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpLoginEnv> loginEnvRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _loginEnvRepository = loginEnvRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    public async Task<KpPageResult<KpLoginEnvDto>> GetListAsync(KpLoginEnvQueryDto query)
    {
      var predicate = Expressionable.Create<KpLoginEnv>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _loginEnvRepository.GetPageAsync<KpLoginEnvDto>(request, predicate.ToExpression());

      return new KpPageResult<KpLoginEnvDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取登录环境详情
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>登录环境详情</returns>
    public async Task<KpLoginEnvDto> GetByIdAsync(long id)
    {
      var loginEnv = await _loginEnvRepository.GetByIdAsync(id);
      if (loginEnv == null)
      {
        throw new KpBusinessException("登录环境不存在");
      }
      return _mapper.Map<KpLoginEnvDto>(loginEnv);
    }

    /// <summary>
    /// 创建登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>登录环境ID</returns>
    public async Task<long> CreateAsync(KpLoginEnvCreateDto input)
    {
      var loginEnv = _mapper.Map<KpLoginEnv>(input);
      await _loginEnvRepository.CreateAsync(loginEnv);
      return loginEnv.Id;
    }

    /// <summary>
    /// 更新登录环境
    /// </summary>
    /// <param name="input">登录环境信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpLoginEnvUpdateDto input)
    {
      var loginEnv = await _loginEnvRepository.GetByIdAsync(input.Id);
      if (loginEnv == null)
      {
        throw new KpBusinessException("登录环境不存在");
      }

      _mapper.Map(input, loginEnv);
      return await _loginEnvRepository.UpdateAsync(loginEnv);
    }

    /// <summary>
    /// 删除登录环境
    /// </summary>
    /// <param name="id">登录环境ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var loginEnv = await _loginEnvRepository.GetByIdAsync(id);
      if (loginEnv == null)
      {
        throw new KpBusinessException("登录环境不存在");
      }

      return await _loginEnvRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出登录环境列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>登录环境列表</returns>
    public async Task<List<KpLoginEnvExportDto>> ExportListAsync(KpLoginEnvQueryDto query)
    {
      var predicate = Expressionable.Create<KpLoginEnv>()
        .AndIF(query.TenantId.HasValue, it => it.TenantId == query.TenantId)
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var loginEnvs = await _loginEnvRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpLoginEnvExportDto>>(loginEnvs);
    }
  }
}