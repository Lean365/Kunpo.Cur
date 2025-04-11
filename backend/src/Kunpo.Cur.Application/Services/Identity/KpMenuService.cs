// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>菜单服务实现</summary>
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
  /// 菜单服务实现
  /// </summary>
  public class KpMenuService : KpBaseService, IKpMenuService
  {
    private readonly IKpBaseRepository<KpMenu> _menuRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="menuRepository">菜单仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpMenuService(
      ILogger<KpMenuService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpMenu> menuRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _menuRepository = menuRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单列表</returns>
    public async Task<KpPageResult<KpMenuDto>> GetListAsync(KpMenuQueryDto query)
    {
      var predicate = Expressionable.Create<KpMenu>()
        .AndIF(!string.IsNullOrEmpty(query.MenuName), it => it.MenuName != null && it.MenuName.Contains(query.MenuName!))
        .AndIF(!string.IsNullOrEmpty(query.MenuCode), it => it.MenuCode != null && it.MenuCode.Contains(query.MenuCode!))
        .AndIF(query.MenuType.HasValue, it => it.MenuType == query.MenuType.Value)
        .AndIF(query.Status.HasValue, it => it.Status == query.Status.Value)
        .AndIF(query.IsEnabled.HasValue, it => it.IsActive == query.IsEnabled.Value)
        .AndIF(query.ParentId.HasValue, it => it.MenuParentId == query.ParentId.Value);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _menuRepository.GetPageAsync<KpMenuDto>(request, predicate.ToExpression());

      return new KpPageResult<KpMenuDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取菜单详情
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>菜单详情</returns>
    public async Task<KpMenuDto> GetByIdAsync(long id)
    {
      var menu = await _menuRepository.GetByIdAsync(id);
      if (menu == null)
      {
        throw new KpBusinessException($"菜单不存在：{id}");
      }
      return _mapper.Map<KpMenuDto>(menu);
    }

    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="dto">创建菜单参数</param>
    /// <returns>菜单ID</returns>
    public async Task<long> CreateAsync(KpMenuCreateDto dto)
    {
      // 验证菜单编码唯一性
      var exists = await _menuRepository.GetFirstOrDefaultAsync(m => m.MenuCode == dto.MenuCode);
      if (exists != null)
      {
        throw new KpBusinessException("菜单编码已存在");
      }

      var menu = _mapper.Map<KpMenu>(dto);

      // 设置父级ID和祖级列表
      if (dto.ParentId > 0)
      {
        var parentMenu = await _menuRepository.GetByIdAsync(dto.ParentId);
        if (parentMenu == null)
        {
          throw new KpBusinessException($"父菜单不存在：{dto.ParentId}");
        }
        menu.MenuParentId = dto.ParentId;
        menu.MenuAncestors = string.IsNullOrEmpty(parentMenu.MenuAncestors)
          ? parentMenu.Id.ToString()
          : $"{parentMenu.MenuAncestors},{parentMenu.Id}";
        menu.MenuLevel = parentMenu.MenuLevel + 1;
      }
      else
      {
        menu.MenuParentId = 0;
        menu.MenuAncestors = "0";
        menu.MenuLevel = 1;
      }

      // 创建菜单
      await _menuRepository.CreateAsync(menu);

      return menu.Id;
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto">更新菜单参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpMenuUpdateDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("菜单ID不能为空");
      }

      // 获取菜单信息
      var menu = await _menuRepository.GetByIdAsync(dto.Id);
      if (menu == null)
      {
        throw new KpBusinessException($"菜单不存在：{dto.Id}");
      }

      // 检查菜单编码是否已存在
      if (menu.MenuCode != dto.MenuCode)
      {
        var exists = await _menuRepository.GetFirstOrDefaultAsync(m => m.MenuCode == dto.MenuCode);
        if (exists != null)
        {
          throw new KpBusinessException("菜单编码已存在");
        }
      }

      // 更新菜单信息
      menu.MenuName = dto.MenuName;
      menu.MenuCode = dto.MenuCode;
      menu.MenuIcon = dto.MenuIcon;
      menu.MenuPath = dto.MenuPath;
      menu.MenuComponent = dto.MenuComponent;
      menu.MenuPerms = dto.MenuPerms;
      menu.MenuType = dto.MenuType;
      menu.Status = dto.Status;
      menu.MenuDescription = dto.MenuDesc;
      menu.IsActive = dto.IsEnabled;
      menu.OrderNum = dto.OrderNum;

      // 如果父级ID发生变化，需要更新父级ID和祖级列表
      if (menu.MenuParentId != dto.ParentId)
      {
        if (dto.ParentId > 0)
        {
          var parentMenu = await _menuRepository.GetByIdAsync(dto.ParentId);
          if (parentMenu == null)
          {
            throw new KpBusinessException($"父菜单不存在：{dto.ParentId}");
          }
          menu.MenuParentId = dto.ParentId;
          menu.MenuAncestors = string.IsNullOrEmpty(parentMenu.MenuAncestors)
            ? parentMenu.Id.ToString()
            : $"{parentMenu.MenuAncestors},{parentMenu.Id}";
          menu.MenuLevel = parentMenu.MenuLevel + 1;
        }
        else
        {
          menu.MenuParentId = 0;
          menu.MenuAncestors = "0";
          menu.MenuLevel = 1;
        }
      }

      await _menuRepository.UpdateAsync(menu);

      return true;
    }

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      // 参数验证
      if (id <= 0)
      {
        throw new KpBusinessException("菜单ID不能为空");
      }

      // 获取菜单信息
      var menu = await _menuRepository.GetByIdAsync(id);
      if (menu == null)
      {
        throw new KpBusinessException($"菜单不存在：{id}");
      }

      // 检查是否有子菜单
      var hasChildren = await _menuRepository.GetFirstOrDefaultAsync(m => m.MenuParentId == id);
      if (hasChildren != null)
      {
        throw new KpBusinessException("存在子菜单，无法删除");
      }

      // 删除菜单
      await _menuRepository.DeleteAsync(id);

      return true;
    }

    /// <summary>
    /// 根据父ID获取菜单列表
    /// </summary>
    /// <param name="parentId">父菜单ID</param>
    /// <returns>菜单列表</returns>
    public async Task<List<KpMenuDto>> GetByParentIdAsync(long parentId)
    {
      var predicate = Expressionable.Create<KpMenu>()
        .And(it => it.MenuParentId == parentId)
        .And(it => it.IsActive == 1);

      var menus = await _menuRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpMenuDto>>(menus);
    }

    /// <summary>
    /// 获取菜单树
    /// </summary>
    /// <returns>菜单树</returns>
    public async Task<List<KpMenuDto>> GetTreeAsync()
    {
      // 获取所有启用的菜单
      var predicate = Expressionable.Create<KpMenu>()
        .And(it => it.IsActive == 1);

      var allMenus = await _menuRepository.GetListAsync(predicate.ToExpression());
      var menuDtos = _mapper.Map<List<KpMenuDto>>(allMenus);

      // 构建树形结构
      return BuildMenuTree(menuDtos);
    }

    /// <summary>
    /// 导入菜单
    /// </summary>
    /// <param name="dtos">菜单导入数据</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpMenuImportDto> dtos)
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
          // 检查菜单编码是否已存在
          var exists = await _menuRepository.GetFirstOrDefaultAsync(m => m.MenuCode == dto.MenuCode);
          if (exists != null)
          {
            throw new KpBusinessException("菜单编码已存在");
          }

          var menu = _mapper.Map<KpMenu>(dto);

          // 设置父级ID和祖级列表
          if (dto.ParentId > 0)
          {
            var parentMenu = await _menuRepository.GetByIdAsync(dto.ParentId);
            if (parentMenu == null)
            {
              throw new KpBusinessException($"父菜单不存在：{dto.ParentId}");
            }
            menu.MenuParentId = dto.ParentId;
            menu.MenuAncestors = string.IsNullOrEmpty(parentMenu.MenuAncestors)
              ? parentMenu.Id.ToString()
              : $"{parentMenu.MenuAncestors},{parentMenu.Id}";
            menu.MenuLevel = parentMenu.MenuLevel + 1;
          }
          else
          {
            menu.MenuParentId = 0;
            menu.MenuAncestors = "0";
            menu.MenuLevel = 1;
          }

          // 创建菜单
          await _menuRepository.CreateAsync(menu);

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
    /// 导出菜单
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>菜单导出数据</returns>
    public async Task<List<KpMenuExportDto>> ExportAsync(KpMenuQueryDto query)
    {
      var predicate = Expressionable.Create<KpMenu>()
        .AndIF(!string.IsNullOrEmpty(query.MenuName), it => it.MenuName != null && it.MenuName.Contains(query.MenuName!))
        .AndIF(!string.IsNullOrEmpty(query.MenuCode), it => it.MenuCode != null && it.MenuCode.Contains(query.MenuCode!))
        .AndIF(query.MenuType.HasValue, it => it.MenuType == query.MenuType.Value)
        .AndIF(query.Status.HasValue, it => it.Status == query.Status.Value)
        .AndIF(query.IsEnabled.HasValue, it => it.IsActive == query.IsEnabled.Value)
        .AndIF(query.ParentId.HasValue, it => it.MenuParentId == query.ParentId.Value);

      var menus = await _menuRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpMenuExportDto>>(menus);
    }

    /// <summary>
    /// 获取菜单导入模板
    /// </summary>
    /// <returns>菜单导入模板</returns>
    public async Task<KpMenuTemplateDto> GetImportTemplateAsync()
    {
      return new KpMenuTemplateDto
      {
        ParentId = 0,
        ParentName = "父菜单名称",
        MenuName = "菜单名称",
        MenuCode = "菜单编码",
        MenuIcon = "菜单图标",
        MenuPath = "菜单路径",
        MenuComponent = "菜单组件",
        MenuPerms = "菜单权限",
        MenuType = 0,
        Status = 1,
        MenuDesc = "菜单描述",
        IsEnabled = 1,
        OrderNum = 0,
        MenuTypeLabel = "0：目录，1：菜单，2：按钮",
        StatusLabel = "0：禁用，1：启用",
        IsEnabledLabel = "0：禁用，1：启用"
      };
    }

    /// <summary>
    /// 修改菜单状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpMenuChangeStatusDto dto)
    {
      // 参数验证
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("菜单ID不能为空");
      }

      // 获取菜单信息
      var menu = await _menuRepository.GetByIdAsync(dto.Id);
      if (menu == null)
      {
        throw new KpBusinessException($"菜单不存在：{dto.Id}");
      }

      // 更新菜单状态
      menu.IsActive = dto.IsEnabled;

      await _menuRepository.UpdateAsync(menu);

      return true;
    }

    /// <summary>
    /// 修改菜单排序
    /// </summary>
    /// <param name="dto">排序信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeSortAsync(KpMenuSortDto dto)
    {
      // 参数校验
      if (dto.Id <= 0)
      {
        throw new KpBusinessException("菜单ID不能小于等于0");
      }

      // 获取菜单信息
      var menu = await _menuRepository.GetByIdAsync(dto.Id);
      if (menu == null)
      {
        throw new KpBusinessException("菜单不存在");
      }

      // 如果父级ID发生变化，需要更新菜单的层级信息
      if (menu.MenuParentId != dto.ParentId)
      {
        // 获取新的父级菜单
        var parentMenu = await _menuRepository.GetByIdAsync(dto.ParentId);
        if (parentMenu == null)
        {
          throw new KpBusinessException("父级菜单不存在");
        }

        // 更新父级ID和祖级列表
        menu.MenuParentId = dto.ParentId;
        menu.MenuAncestors = parentMenu.MenuAncestors + "," + parentMenu.Id;
      }

      // 更新排序号
      menu.OrderNum = dto.OrderNum;

      // 保存更改
      return await _menuRepository.UpdateAsync(menu);
    }

    /// <summary>
    /// 构建菜单树
    /// </summary>
    /// <param name="menus">菜单列表</param>
    /// <param name="parentId">父菜单ID</param>
    /// <returns>菜单树</returns>
    private List<KpMenuDto> BuildMenuTree(List<KpMenuDto> menus, long parentId = 0)
    {
      var children = menus.Where(m => m.ParentId == parentId).ToList();
      foreach (var child in children)
      {
        child.Children = BuildMenuTree(menus, child.Id);
      }
      return children;
    }
  }
}