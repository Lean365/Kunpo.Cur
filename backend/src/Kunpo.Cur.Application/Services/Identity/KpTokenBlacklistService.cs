// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>令牌黑名单服务实现</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using System.Linq.Expressions;
using SqlSugar;
using AutoMapper;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 令牌黑名单服务实现
  /// </summary>
  public class KpTokenBlacklistService : KpBaseService, IKpTokenBlacklistService
  {
    private readonly IKpBaseRepository<KpTokenBlacklist> _tokenBlacklistRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="tokenBlacklistRepository">令牌黑名单仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpTokenBlacklistService(
      ILogger<KpTokenBlacklistService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpTokenBlacklist> tokenBlacklistRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _tokenBlacklistRepository = tokenBlacklistRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取令牌黑名单列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>令牌黑名单列表</returns>
    public async Task<KpPageResult<KpTokenBlacklistDto>> GetListAsync(KpTokenBlacklistQueryDto query)
    {
      var predicate = Expressionable.Create<KpTokenBlacklist>()
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(query.TokenType.HasValue, it => it.TokenType == query.TokenType);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy ?? "BlacklistTime",
        OrderType = query.OrderType ?? "desc"
      };

      var (items, total) = await _tokenBlacklistRepository.GetPageAsync<KpTokenBlacklistDto>(request, predicate.ToExpression());

      return new KpPageResult<KpTokenBlacklistDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取令牌黑名单详情
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>令牌黑名单详情</returns>
    public async Task<KpTokenBlacklistDto> GetByIdAsync(long id)
    {
      var tokenBlacklist = await _tokenBlacklistRepository.GetByIdAsync(id);
      return _mapper.Map<KpTokenBlacklistDto>(tokenBlacklist);
    }

    /// <summary>
    /// 创建令牌黑名单
    /// </summary>
    /// <param name="dto">创建数据传输对象</param>
    /// <returns>主键ID</returns>
    public async Task<long> CreateAsync(KpTokenBlacklistCreateDto dto)
    {
      // 验证令牌是否已在黑名单中
      var exists = await _tokenBlacklistRepository.GetFirstOrDefaultAsync(t => t.Token == dto.Token);
      if (exists != null)
      {
        throw new KpBusinessException("令牌已在黑名单中");
      }

      // 创建黑名单记录
      var tokenBlacklist = _mapper.Map<KpTokenBlacklist>(dto);
      tokenBlacklist.BlacklistTime = DateTime.Now;

      await _tokenBlacklistRepository.CreateAsync(tokenBlacklist);

      return tokenBlacklist.Id;
    }

    /// <summary>
    /// 删除令牌黑名单
    /// </summary>
    /// <param name="dto">删除数据传输对象</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(KpTokenBlacklistDeleteDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("主键ID不能为空");
      }

      // 获取黑名单记录
      var tokenBlacklist = await _tokenBlacklistRepository.GetByIdAsync(dto.Id);
      if (tokenBlacklist == null)
      {
        throw new KpBusinessException("黑名单记录不存在");
      }

      // 删除黑名单记录
      await _tokenBlacklistRepository.DeleteAsync(dto.Id);

      return true;
    }

    /// <summary>
    /// 导出令牌黑名单
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>导出数据</returns>
    public async Task<List<KpTokenBlacklistExportDto>> ExportAsync(KpTokenBlacklistQueryDto query)
    {
      var predicate = Expressionable.Create<KpTokenBlacklist>()
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(query.TokenType.HasValue, it => it.TokenType == query.TokenType);

      var list = await _tokenBlacklistRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpTokenBlacklistExportDto>>(list);
    }

    /// <summary>
    /// 检查令牌是否在黑名单中
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否在黑名单中</returns>
    public async Task<bool> IsTokenBlacklistedAsync(string token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return false;
      }

      var blacklist = await _tokenBlacklistRepository.GetFirstOrDefaultAsync(t => t.Token == token);
      if (blacklist == null)
      {
        return false;
      }

      // 如果令牌已过期，从黑名单中移除
      if (blacklist.ExpireTime <= DateTime.Now)
      {
        await _tokenBlacklistRepository.DeleteAsync(blacklist.Id);
        return false;
      }

      return true;
    }

    /// <summary>
    /// 清理过期的黑名单记录
    /// </summary>
    /// <returns>是否成功</returns>
    public async Task<bool> CleanExpiredAsync()
    {
      var now = DateTime.Now;
      var expiredRecords = await _tokenBlacklistRepository.GetListAsync(t => t.ExpireTime <= now);

      if (expiredRecords.Any())
      {
        foreach (var record in expiredRecords)
        {
          await _tokenBlacklistRepository.DeleteAsync(record.Id);
        }
      }

      return true;
    }
  }
}
