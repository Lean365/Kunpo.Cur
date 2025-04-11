// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>角色服务实现</summary>
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
  /// 角色服务实现
  /// </summary>
  public class KpRoleService : KpBaseService, IKpRoleService
  {
    private readonly IKpBaseRepository<KpRole> _roleRepository;
    private readonly IKpBaseRepository<KpRoleMenu> _roleMenuRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="roleRepository">角色仓储</param>
    /// <param name="roleMenuRepository">角色菜单仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpRoleService(
      ILogger<KpRoleService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpRole> roleRepository,
      IKpBaseRepository<KpRoleMenu> roleMenuRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _roleRepository = roleRepository;
      _roleMenuRepository = roleMenuRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色列表</returns>
    public async Task<KpPageResult<KpRoleDto>> GetListAsync(KpRoleQueryDto query)
    {
      var predicate = Expressionable.Create<KpRole>()
        .AndIF(!string.IsNullOrEmpty(query.RoleCode), it => it.RoleCode != null && it.RoleCode.Contains(query.RoleCode!))
        .AndIF(!string.IsNullOrEmpty(query.RoleName), it => it.RoleName != null && it.RoleName.Contains(query.RoleName!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.DataScope.HasValue, it => it.DataScope == query.DataScope);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _roleRepository.GetPageAsync<KpRoleDto>(request, predicate.ToExpression());

      return new KpPageResult<KpRoleDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取角色详情
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>角色详情</returns>
    public async Task<KpRoleDto> GetByIdAsync(long id)
    {
      var role = await _roleRepository.GetByIdAsync(id);
      if (role == null)
      {
        throw new KpBusinessException("角色不存在");
      }
      return _mapper.Map<KpRoleDto>(role);
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="dto">创建角色参数</param>
    /// <returns>角色ID</returns>
    public async Task<long> CreateAsync(KpRoleCreateDto dto)
    {
      // 验证角色编码唯一性
      var exists = await _roleRepository.GetFirstOrDefaultAsync(r => r.RoleCode == dto.RoleCode);
      if (exists != null)
      {
        throw new KpBusinessException("角色编码已存在");
      }

      var role = _mapper.Map<KpRole>(dto);
      await _roleRepository.CreateAsync(role);

      return role.Id;
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto">更新角色参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpRoleUpdateDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("角色ID不能为空");
      }

      // 获取角色信息
      var role = await _roleRepository.GetByIdAsync(dto.Id);
      if (role == null)
      {
        throw new KpBusinessException("角色不存在");
      }

      // 检查角色编码是否已存在
      if (role.RoleCode != dto.RoleCode)
      {
        var exists = await _roleRepository.GetFirstOrDefaultAsync(r => r.RoleCode == dto.RoleCode);
        if (exists != null)
        {
          throw new KpBusinessException("角色编码已存在");
        }
      }

      // 更新角色信息
      role.RoleCode = dto.RoleCode;
      role.RoleName = dto.RoleName;
      role.RoleDesc = dto.RoleDesc;
      role.OrderNum = dto.OrderNum;
      role.Status = dto.Status;
      role.DataScope = dto.DataScope;
      role.RoleDataDeptIds = dto.RoleDataDeptIds;

      await _roleRepository.UpdateAsync(role);

      return true;
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      // 参数验证
      if (id <= 0)
      {
        throw new KpBusinessException("角色ID不能为空");
      }

      // 获取角色信息
      var role = await _roleRepository.GetByIdAsync(id);
      if (role == null)
      {
        throw new KpBusinessException("角色不存在");
      }

      // 删除角色
      await _roleRepository.DeleteAsync(id);

      return true;
    }

    /// <summary>
    /// 导入角色
    /// </summary>
    /// <param name="dtos">角色导入数据</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpRoleImportDto> dtos)
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
          // 检查角色编码是否已存在
          var exists = await _roleRepository.GetFirstOrDefaultAsync(r => r.RoleCode == dto.RoleCode);
          if (exists != null)
          {
            throw new KpBusinessException("角色编码已存在");
          }

          var role = _mapper.Map<KpRole>(dto);
          await _roleRepository.CreateAsync(role);

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
    /// 导出角色
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>角色导出数据</returns>
    public async Task<List<KpRoleExportDto>> ExportAsync(KpRoleQueryDto query)
    {
      var predicate = Expressionable.Create<KpRole>()
        .AndIF(!string.IsNullOrEmpty(query.RoleCode), it => it.RoleCode != null && it.RoleCode.Contains(query.RoleCode!))
        .AndIF(!string.IsNullOrEmpty(query.RoleName), it => it.RoleName != null && it.RoleName.Contains(query.RoleName!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.DataScope.HasValue, it => it.DataScope == query.DataScope);

      var roles = await _roleRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpRoleExportDto>>(roles);
    }

    /// <summary>
    /// 获取角色导入模板
    /// </summary>
    /// <returns>角色导入模板</returns>
    public Task<KpRoleTemplateDto> GetImportTemplateAsync()
    {
      var template = new KpRoleTemplateDto
      {
        RoleCode = "ROLE001",
        RoleName = "角色名称",
        RoleDesc = "角色描述",
        OrderNum = 0,
        Status = 1,
        DataScope = 0,
        RoleDataDeptIds = "",
        StatusLabel = "启用",
        DataScopeLabel = "全部数据"
      };

      return Task.FromResult(template);
    }

    /// <summary>
    /// 修改角色状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpRoleChangeStatusDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("角色ID不能为空");
      }

      // 获取角色信息
      var role = await _roleRepository.GetByIdAsync(dto.Id);
      if (role == null)
      {
        throw new KpBusinessException("角色不存在");
      }

      // 更新角色状态
      role.Status = dto.Status;

      await _roleRepository.UpdateAsync(role);

      return true;
    }

    /// <summary>
    /// 分配角色菜单
    /// </summary>
    /// <param name="dto">角色菜单数据传输对象</param>
    /// <returns>是否成功</returns>
    public async Task<bool> AssignMenuAsync(KpRoleMenuDto dto)
    {
      // 参数验证
      if (dto.RoleId <= 0)
      {
        throw new KpBusinessException("角色ID不能为空");
      }

      if (dto.MenuIds == null || !dto.MenuIds.Any())
      {
        throw new KpBusinessException("菜单ID列表不能为空");
      }

      // 获取角色信息
      var role = await _roleRepository.GetByIdAsync(dto.RoleId);
      if (role == null)
      {
        throw new KpBusinessException("角色不存在");
      }

      // 删除原有菜单关联
      var existingRoleMenus = await _roleMenuRepository.GetListAsync(rm => rm.RoleId == dto.RoleId);
      foreach (var roleMenu in existingRoleMenus)
      {
        await _roleMenuRepository.DeleteAsync(roleMenu.Id);
      }

      // 添加新的菜单关联
      foreach (var menuId in dto.MenuIds)
      {
        var roleMenu = new KpRoleMenu
        {
          RoleId = dto.RoleId,
          MenuId = menuId
        };
        await _roleMenuRepository.CreateAsync(roleMenu);
      }

      return true;
    }

    /// <summary>
    /// 获取角色菜单
    /// </summary>
    /// <param name="roleId">角色ID</param>
    /// <returns>菜单ID列表</returns>
    public async Task<List<long>> GetRoleMenuAsync(long roleId)
    {
      // 参数验证
      if (roleId <= 0)
      {
        throw new KpBusinessException("角色ID不能为空");
      }

      // 获取角色菜单关联
      var roleMenus = await _roleMenuRepository.GetListAsync(rm => rm.RoleId == roleId);

      // 返回菜单ID列表
      return roleMenus.Select(rm => rm.MenuId).ToList();
    }
  }
}