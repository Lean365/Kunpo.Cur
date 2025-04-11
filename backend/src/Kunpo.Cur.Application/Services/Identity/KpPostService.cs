// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>岗位服务实现</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Common.Models;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using System.Linq.Expressions;
using SqlSugar;
using AutoMapper;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 岗位服务实现
  /// </summary>
  public class KpPostService : KpBaseService, IKpPostService
  {
    private readonly IKpBaseRepository<KpPost> _postRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="postRepository">岗位仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpPostService(
      ILogger<KpPostService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpPost> postRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _postRepository = postRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取岗位列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位列表</returns>
    public async Task<KpPageResult<KpPostDto>> GetListAsync(KpPostQueryDto query)
    {
      var predicate = Expressionable.Create<KpPost>()
        .AndIF(!string.IsNullOrEmpty(query.PostCode), it => it.PostCode != null && it.PostCode.Contains(query.PostCode!))
        .AndIF(!string.IsNullOrEmpty(query.PostName), it => it.PostName != null && it.PostName.Contains(query.PostName!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.PostLevel.HasValue, it => it.PostLevel == query.PostLevel)
        .AndIF(query.PostSequence.HasValue, it => it.PostSequence == query.PostSequence)
        .AndIF(query.IsActive.HasValue, it => it.IsActive == query.IsActive);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _postRepository.GetPageAsync<KpPostDto>(request, predicate.ToExpression());

      return new KpPageResult<KpPostDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取岗位详情
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>岗位详情</returns>
    public async Task<KpPostDto> GetByIdAsync(long id)
    {
      var post = await _postRepository.GetByIdAsync(id);
      if (post == null)
      {
        throw new KpBusinessException("岗位不存在");
      }
      return _mapper.Map<KpPostDto>(post);
    }

    /// <summary>
    /// 创建岗位
    /// </summary>
    /// <param name="dto">创建岗位参数</param>
    /// <returns>岗位ID</returns>
    public async Task<long> CreateAsync(KpPostCreateDto dto)
    {
      // 验证岗位编码唯一性
      var exists = await _postRepository.GetFirstOrDefaultAsync(p => p.PostCode == dto.PostCode);
      if (exists != null)
      {
        throw new KpBusinessException("岗位编码已存在");
      }

      var post = _mapper.Map<KpPost>(dto);
      await _postRepository.CreateAsync(post);

      return post.Id;
    }

    /// <summary>
    /// 更新岗位
    /// </summary>
    /// <param name="dto">更新岗位参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpPostUpdateDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("岗位ID不能为空");
      }

      // 获取岗位信息
      var post = await _postRepository.GetByIdAsync(dto.Id);
      if (post == null)
      {
        throw new KpBusinessException("岗位不存在");
      }

      // 检查岗位编码是否已存在
      if (post.PostCode != dto.PostCode)
      {
        var exists = await _postRepository.GetFirstOrDefaultAsync(p => p.PostCode == dto.PostCode);
        if (exists != null)
        {
          throw new KpBusinessException("岗位编码已存在");
        }
      }

      // 更新岗位信息
      post.PostCode = dto.PostCode;
      post.PostName = dto.PostName;
      post.PostDesc = dto.PostDesc;
      post.OrderNum = dto.OrderNum;
      post.Status = dto.Status;
      post.PostLevel = dto.PostLevel;
      post.PostSequence = dto.PostSequence;
      post.IsActive = dto.IsActive;

      await _postRepository.UpdateAsync(post);

      return true;
    }

    /// <summary>
    /// 删除岗位
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      // 参数验证
      if (id <= 0)
      {
        throw new KpBusinessException("岗位ID不能为空");
      }

      // 获取岗位信息
      var post = await _postRepository.GetByIdAsync(id);
      if (post == null)
      {
        throw new KpBusinessException("岗位不存在");
      }

      // 删除岗位
      await _postRepository.DeleteAsync(id);

      return true;
    }

    /// <summary>
    /// 导入岗位
    /// </summary>
    /// <param name="dtos">岗位导入数据</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpPostImportDto> dtos)
    {
      var result = new KpImportResult
      {
        Total = dtos.Count,
        Success = 0,
        Fail = 0,
        Errors = new List<string>()
      };

      foreach (var dto in dtos)
      {
        try
        {
          // 检查岗位编码是否已存在
          var exists = await _postRepository.GetFirstOrDefaultAsync(p => p.PostCode == dto.PostCode);
          if (exists != null)
          {
            throw new KpBusinessException("岗位编码已存在");
          }

          var post = _mapper.Map<KpPost>(dto);
          await _postRepository.CreateAsync(post);

          result.Success++;
        }
        catch (Exception ex)
        {
          result.Fail++;
          result.Errors.Add($"第{result.Success + result.Fail}行: {ex.Message}");
        }
      }

      return result;
    }

    /// <summary>
    /// 导出岗位
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位导出数据</returns>
    public async Task<List<KpPostExportDto>> ExportAsync(KpPostQueryDto query)
    {
      var predicate = Expressionable.Create<KpPost>()
        .AndIF(!string.IsNullOrEmpty(query.PostCode), it => it.PostCode != null && it.PostCode.Contains(query.PostCode!))
        .AndIF(!string.IsNullOrEmpty(query.PostName), it => it.PostName != null && it.PostName.Contains(query.PostName!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.PostLevel.HasValue, it => it.PostLevel == query.PostLevel)
        .AndIF(query.PostSequence.HasValue, it => it.PostSequence == query.PostSequence)
        .AndIF(query.IsActive.HasValue, it => it.IsActive == query.IsActive);

      var posts = await _postRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpPostExportDto>>(posts);
    }

    /// <summary>
    /// 获取岗位导入模板
    /// </summary>
    /// <returns>岗位导入模板</returns>
    public Task<KpPostTemplateDto> GetImportTemplateAsync()
    {
      var template = new KpPostTemplateDto
      {
        PostCode = "POST001",
        PostName = "岗位名称",
        PostDesc = "岗位描述",
        OrderNum = 0,
        Status = 1,
        PostLevel = 0,
        PostSequence = 4,
        IsActive = 1,
        StatusLabel = "启用",
        PostLevelLabel = "实习",
        PostSequenceLabel = "其他序列",
        IsActiveLabel = "启用"
      };

      return Task.FromResult(template);
    }

    /// <summary>
    /// 修改岗位状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpPostChangeStatusDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("岗位ID不能为空");
      }

      // 获取岗位信息
      var post = await _postRepository.GetByIdAsync(dto.Id);
      if (post == null)
      {
        throw new KpBusinessException("岗位不存在");
      }

      // 更新岗位状态
      post.IsActive = dto.IsActive;

      await _postRepository.UpdateAsync(post);

      return true;
    }
  }
}