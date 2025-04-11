// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL差异服务实现</summary>
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Application.Services.Audit;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Entities.Audit;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Application.Services;
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
  /// SQL差异服务实现
  /// </summary>
  public class KpSqlDiffService : KpBaseService, IKpSqlDiffService
  {
    private readonly IKpBaseRepository<KpSqlDiff> _sqlDiffRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="sqlDiffRepository">SQL差异仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpSqlDiffService(
      ILogger<KpSqlDiffService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpSqlDiff> sqlDiffRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _sqlDiffRepository = sqlDiffRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    public async Task<KpPageResult<KpSqlDiffDto>> GetListAsync(KpSqlDiffQueryDto query)
    {
      var predicate = Expressionable.Create<KpSqlDiff>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.OperFunction), it => it.OperFunction != null && it.OperFunction.Contains(query.OperFunction!))
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

      var (items, total) = await _sqlDiffRepository.GetPageAsync<KpSqlDiffDto>(request, predicate.ToExpression());

      return new KpPageResult<KpSqlDiffDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取SQL差异详情
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>SQL差异详情</returns>
    public async Task<KpSqlDiffDto> GetByIdAsync(long id)
    {
      var sqlDiff = await _sqlDiffRepository.GetByIdAsync(id);
      if (sqlDiff == null)
      {
        throw new KpBusinessException("SQL差异不存在");
      }
      return _mapper.Map<KpSqlDiffDto>(sqlDiff);
    }

    /// <summary>
    /// 创建SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>SQL差异ID</returns>
    public async Task<long> CreateAsync(KpSqlDiffCreateDto input)
    {
      var sqlDiff = _mapper.Map<KpSqlDiff>(input);
      await _sqlDiffRepository.CreateAsync(sqlDiff);
      return sqlDiff.Id;
    }

    /// <summary>
    /// 更新SQL差异
    /// </summary>
    /// <param name="input">SQL差异信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpSqlDiffUpdateDto input)
    {
      var sqlDiff = await _sqlDiffRepository.GetByIdAsync(input.Id);
      if (sqlDiff == null)
      {
        throw new KpBusinessException("SQL差异不存在");
      }

      _mapper.Map(input, sqlDiff);
      return await _sqlDiffRepository.UpdateAsync(sqlDiff);
    }

    /// <summary>
    /// 删除SQL差异
    /// </summary>
    /// <param name="id">SQL差异ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var sqlDiff = await _sqlDiffRepository.GetByIdAsync(id);
      if (sqlDiff == null)
      {
        throw new KpBusinessException("SQL差异不存在");
      }

      return await _sqlDiffRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 导出SQL差异列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>SQL差异列表</returns>
    public async Task<List<KpSqlDiffExportDto>> ExportListAsync(KpSqlDiffQueryDto query)
    {
      var predicate = Expressionable.Create<KpSqlDiff>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.OperFunction), it => it.OperFunction != null && it.OperFunction.Contains(query.OperFunction!))
        .AndIF(query.OperStatus.HasValue, it => it.OperStatus == query.OperStatus)
        .AndIF(query.StartTime.HasValue, it => it.OperTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.OperTime <= query.EndTime);

      var sqlDiffs = await _sqlDiffRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpSqlDiffExportDto>>(sqlDiffs);
    }
  }
}