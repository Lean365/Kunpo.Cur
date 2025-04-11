// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>部门服务实现</summary>
// -----------------------------------------------------------------------


using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Options;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using System.Linq.Expressions;
using SqlSugar;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 部门服务实现
  /// </summary>
  public class KpDeptService : KpBaseService, IKpDeptService
  {
    private readonly IKpBaseRepository<KpDept> _deptRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="deptRepository">部门仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpDeptService(
        ILogger<KpDeptService> logger,
        IConfiguration configuration,
        IKpSecurityContext securityContext,
        IKpLocalizationService localizationService,
        IKpBaseRepository<KpDept> deptRepository,
        IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _deptRepository = deptRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取部门列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门列表</returns>
    public async Task<KpPageResult<KpDeptDto>> GetListAsync(KpDeptQueryDto query)
    {
      var predicate = Expressionable.Create<KpDept>()
        .AndIF(!string.IsNullOrEmpty(query.DeptName), it => it.DeptName != null && it.DeptName.Contains(query.DeptName!))
        .AndIF(!string.IsNullOrEmpty(query.DeptCode), it => it.DeptCode != null && it.DeptCode.Contains(query.DeptCode!))
        .AndIF(query.IsEnabled.HasValue, it => it.IsActive == query.IsEnabled.Value)
        .AndIF(query.ParentId.HasValue, it => it.DeptParentId == query.ParentId.Value);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _deptRepository.GetPageAsync<KpDeptDto>(request, predicate.ToExpression());

      return new KpPageResult<KpDeptDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取部门详情
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>部门详情</returns>
    public async Task<KpDeptDto> GetByIdAsync(long id)
    {
      var dept = await _deptRepository.GetByIdAsync(id);
      if (dept == null)
      {
        throw new KpNotFoundException($"部门不存在：{id}");
      }
      return _mapper.Map<KpDeptDto>(dept);
    }

    /// <summary>
    /// 创建部门
    /// </summary>
    /// <param name="dto">创建部门参数</param>
    /// <returns>部门ID</returns>
    public async Task<long> CreateAsync(KpDeptCreateDto dto)
    {
      var dept = _mapper.Map<KpDept>(dto);
      await _deptRepository.CreateAsync(dept);
      return dept.Id;
    }

    /// <summary>
    /// 更新部门
    /// </summary>
    /// <param name="dto">更新部门参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpDeptUpdateDto dto)
    {
      var dept = await _deptRepository.GetByIdAsync(dto.Id);
      if (dept == null)
      {
        throw new KpNotFoundException($"部门不存在：{dto.Id}");
      }

      _mapper.Map(dto, dept);
      return await _deptRepository.UpdateAsync(dept);
    }

    /// <summary>
    /// 删除部门
    /// </summary>
    /// <param name="id">部门ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      var dept = await _deptRepository.GetByIdAsync(id);
      if (dept == null)
      {
        throw new KpNotFoundException($"部门不存在：{id}");
      }

      return await _deptRepository.DeleteAsync(id);
    }

    /// <summary>
    /// 根据父ID获取部门列表
    /// </summary>
    /// <param name="parentId">父部门ID</param>
    /// <returns>部门列表</returns>
    public async Task<List<KpDeptDto>> GetByParentIdAsync(long parentId)
    {
      var predicate = Expressionable.Create<KpDept>()
        .And(it => it.DeptParentId == parentId);
      var depts = await _deptRepository.GetListAsync(predicate.ToExpression());
      return depts.Select(_mapper.Map<KpDeptDto>).ToList();
    }

    /// <summary>
    /// 获取部门树
    /// </summary>
    /// <returns>部门树</returns>
    public async Task<List<KpDeptDto>> GetTreeAsync()
    {
      var allDepts = await _deptRepository.GetListAsync();
      var deptDtos = allDepts.Select(_mapper.Map<KpDeptDto>).ToList();
      return BuildTree(deptDtos);
    }

    /// <summary>
    /// 导入部门
    /// </summary>
    /// <param name="dtos">部门导入数据</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpDeptImportDto> dtos)
    {
      var result = new KpImportResult();
      foreach (var dto in dtos)
      {
        try
        {
          var dept = _mapper.Map<KpDept>(dto);
          await _deptRepository.CreateAsync(dept);
          result.Success++;
        }
        catch (Exception ex)
        {
          result.Fail++;
          result.Errors.Add($"导入失败：{ex.Message}");
        }
      }
      return result;
    }

    /// <summary>
    /// 导出部门
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>部门导出数据</returns>
    public async Task<List<KpDeptExportDto>> ExportAsync(KpDeptQueryDto query)
    {
      var predicate = Expressionable.Create<KpDept>()
        .AndIF(!string.IsNullOrEmpty(query.DeptName), it => it.DeptName != null && it.DeptName.Contains(query.DeptName!))
        .AndIF(!string.IsNullOrEmpty(query.DeptCode), it => it.DeptCode != null && it.DeptCode.Contains(query.DeptCode!))
        .AndIF(query.IsEnabled.HasValue, it => it.IsActive == query.IsEnabled.Value)
        .AndIF(query.ParentId.HasValue, it => it.DeptParentId == query.ParentId.Value);

      var depts = await _deptRepository.GetListAsync(predicate.ToExpression());
      return depts.Select(_mapper.Map<KpDeptExportDto>).ToList();
    }

    /// <summary>
    /// 获取部门导入模板
    /// </summary>
    /// <returns>部门导入模板</returns>
    public async Task<KpDeptTemplateDto> GetImportTemplateAsync()
    {
      return new KpDeptTemplateDto();
    }

    /// <summary>
    /// 修改部门状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpDeptChangeStatusDto dto)
    {
      var dept = await _deptRepository.GetByIdAsync(dto.Id);
      if (dept == null)
      {
        throw new KpNotFoundException($"部门不存在：{dto.Id}");
      }

      dept.IsActive = dto.IsEnabled;
      return await _deptRepository.UpdateAsync(dept);
    }

    private List<KpDeptDto> BuildTree(List<KpDeptDto> depts, long parentId = 0)
    {
      var children = depts.Where(d => d.ParentId == parentId).ToList();
      foreach (var child in children)
      {
        child.Children = BuildTree(depts, child.Id);
      }
      return children;
    }
  }
}