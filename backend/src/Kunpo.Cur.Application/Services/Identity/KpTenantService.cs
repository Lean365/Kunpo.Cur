// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>租户服务实现</summary>
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
  /// 租户服务实现
  /// </summary>
  public class KpTenantService : KpBaseService, IKpTenantService
  {
    private readonly IKpBaseRepository<KpTenant> _tenantRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="tenantRepository">租户仓储</param>
    /// <param name="mapper">映射服务</param>
    public KpTenantService(
      ILogger<KpTenantService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpTenant> tenantRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _tenantRepository = tenantRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户列表</returns>
    public async Task<KpPageResult<KpTenantDto>> GetListAsync(KpTenantQueryDto query)
    {
      var predicate = Expressionable.Create<KpTenant>()
        .AndIF(!string.IsNullOrEmpty(query.TenantName), it => it.TenantName != null && it.TenantName.Contains(query.TenantName!))
        .AndIF(!string.IsNullOrEmpty(query.TenantCode), it => it.TenantCode != null && it.TenantCode.Contains(query.TenantCode!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.IsEnabled.HasValue, it => it.Status == query.IsEnabled);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _tenantRepository.GetPageAsync<KpTenantDto>(request, predicate.ToExpression());

      return new KpPageResult<KpTenantDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取租户详情
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>租户详情</returns>
    public async Task<KpTenantDto> GetByIdAsync(long id)
    {
      var tenant = await _tenantRepository.GetByIdAsync(id);
      return _mapper.Map<KpTenantDto>(tenant);
    }

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="input">租户信息</param>
    /// <returns>租户ID</returns>
    public async Task<long> CreateAsync(KpTenantCreateDto input)
    {
      // 验证租户编码唯一性
      var exists = await _tenantRepository.ExistsAsync(t => t.TenantCode == input.TenantCode);
      if (exists)
      {
        throw new KpBusinessException("租户编码已存在");
      }

      // 验证租户名称唯一性
      exists = await _tenantRepository.ExistsAsync(t => t.TenantName == input.TenantName);
      if (exists)
      {
        throw new KpBusinessException("租户名称已存在");
      }

      // 验证租户简称唯一性
      if (!string.IsNullOrEmpty(input.TenantShortName))
      {
        exists = await _tenantRepository.ExistsAsync(t => t.TenantShortName == input.TenantShortName);
        if (exists)
        {
          throw new KpBusinessException("租户简称已存在");
        }
      }

      // 验证租户电话唯一性
      if (!string.IsNullOrEmpty(input.TenantPhone))
      {
        exists = await _tenantRepository.ExistsAsync(t => t.TenantPhone == input.TenantPhone);
        if (exists)
        {
          throw new KpBusinessException("租户电话已存在");
        }
      }

      // 验证租户邮箱唯一性
      if (!string.IsNullOrEmpty(input.TenantEmail))
      {
        exists = await _tenantRepository.ExistsAsync(t => t.TenantEmail == input.TenantEmail);
        if (exists)
        {
          throw new KpBusinessException("租户邮箱已存在");
        }
      }

      // 创建租户
      var tenant = _mapper.Map<KpTenant>(input);
      tenant.Status = 1;
      tenant.TenantIsTrial = 0;
      tenant.TenantTrialDays = 0;

      await _tenantRepository.CreateAsync(tenant);

      return tenant.Id;
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="input">租户信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpTenantUpdateDto input)
    {
      // 参数验证
      if (input.Id <= 0)
      {
        throw new KpBusinessException("租户ID不能为空");
      }

      // 获取租户信息
      var tenant = await _tenantRepository.GetByIdAsync(input.Id);
      if (tenant == null)
      {
        throw new KpBusinessException("租户不存在");
      }

      // 检查租户编码是否已存在
      if (tenant.TenantCode != input.TenantCode)
      {
        var exists = await _tenantRepository.ExistsAsync(t => t.TenantCode == input.TenantCode, input.Id);
        if (exists)
        {
          throw new KpBusinessException("租户编码已存在");
        }
      }

      // 检查租户名称是否已存在
      if (tenant.TenantName != input.TenantName)
      {
        var exists = await _tenantRepository.ExistsAsync(t => t.TenantName == input.TenantName, input.Id);
        if (exists)
        {
          throw new KpBusinessException("租户名称已存在");
        }
      }

      // 检查租户简称是否已存在
      if (tenant.TenantShortName != input.TenantShortName)
      {
        if (!string.IsNullOrEmpty(input.TenantShortName))
        {
          var exists = await _tenantRepository.ExistsAsync(t => t.TenantShortName == input.TenantShortName, input.Id);
          if (exists)
          {
            throw new KpBusinessException("租户简称已存在");
          }
        }
      }

      // 检查租户电话是否已存在
      if (tenant.TenantPhone != input.TenantPhone)
      {
        if (!string.IsNullOrEmpty(input.TenantPhone))
        {
          var exists = await _tenantRepository.ExistsAsync(t => t.TenantPhone == input.TenantPhone, input.Id);
          if (exists)
          {
            throw new KpBusinessException("租户电话已存在");
          }
        }
      }

      // 检查租户邮箱是否已存在
      if (tenant.TenantEmail != input.TenantEmail)
      {
        if (!string.IsNullOrEmpty(input.TenantEmail))
        {
          var exists = await _tenantRepository.ExistsAsync(t => t.TenantEmail == input.TenantEmail, input.Id);
          if (exists)
          {
            throw new KpBusinessException("租户邮箱已存在");
          }
        }
      }

      // 更新租户信息
      tenant.TenantCode = input.TenantCode;
      tenant.TenantName = input.TenantName;
      tenant.TenantShortName = input.TenantShortName;
      tenant.TenantDescription = input.TenantDesc;
      tenant.TenantContact = input.TenantContact;
      tenant.TenantPhone = input.TenantPhone;
      tenant.TenantEmail = input.TenantEmail;
      tenant.TenantAddress = input.TenantAddress;
      tenant.TenantExpireTime = input.TenantExpireTime;

      await _tenantRepository.UpdateAsync(tenant);

      return true;
    }

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      // 参数验证
      if (id <= 0)
      {
        throw new KpBusinessException("租户ID不能为空");
      }

      // 获取租户信息
      var tenant = await _tenantRepository.GetByIdAsync(id);
      if (tenant == null)
      {
        throw new KpBusinessException("租户不存在");
      }

      // 删除租户
      await _tenantRepository.DeleteAsync(id);

      return true;
    }

    /// <summary>
    /// 修改租户状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpTenantChangeStatusDto input)
    {
      // 参数验证
      if (input.Id <= 0)
      {
        throw new KpBusinessException("租户ID不能为空");
      }

      // 获取租户信息
      var tenant = await _tenantRepository.GetByIdAsync(input.Id);
      if (tenant == null)
      {
        throw new KpBusinessException("租户不存在");
      }

      // 更新租户状态
      tenant.Status = input.IsEnabled;

      await _tenantRepository.UpdateAsync(tenant);

      return true;
    }

    /// <summary>
    /// 导入租户
    /// </summary>
    /// <param name="tenants">租户列表</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpTenantImportDto> tenants)
    {
      var result = new KpImportResult
      {
        Total = tenants.Count,
        Success = 0,
        Fail = 0,
        Errors = new List<string>()
      };

      foreach (var tenant in tenants)
      {
        try
        {
          // 检查租户编码是否已存在
          var exists = await _tenantRepository.ExistsAsync(t => t.TenantCode == tenant.TenantCode);
          if (exists)
          {
            throw new KpBusinessException("租户编码已存在");
          }

          // 检查租户名称是否已存在
          exists = await _tenantRepository.ExistsAsync(t => t.TenantName == tenant.TenantName);
          if (exists)
          {
            throw new KpBusinessException("租户名称已存在");
          }

          // 检查租户简称是否已存在
          if (!string.IsNullOrEmpty(tenant.TenantShortName))
          {
            exists = await _tenantRepository.ExistsAsync(t => t.TenantShortName == tenant.TenantShortName);
            if (exists)
            {
              throw new KpBusinessException("租户简称已存在");
            }
          }

          // 检查租户电话是否已存在
          if (!string.IsNullOrEmpty(tenant.TenantPhone))
          {
            exists = await _tenantRepository.ExistsAsync(t => t.TenantPhone == tenant.TenantPhone);
            if (exists)
            {
              throw new KpBusinessException("租户电话已存在");
            }
          }

          // 检查租户邮箱是否已存在
          if (!string.IsNullOrEmpty(tenant.TenantEmail))
          {
            exists = await _tenantRepository.ExistsAsync(t => t.TenantEmail == tenant.TenantEmail);
            if (exists)
            {
              throw new KpBusinessException("租户邮箱已存在");
            }
          }

          // 创建租户
          var entity = _mapper.Map<KpTenant>(tenant);
          entity.Status = 1;
          entity.TenantIsTrial = 0;
          entity.TenantTrialDays = 0;

          await _tenantRepository.CreateAsync(entity);

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
    /// 导出租户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>租户导出数据</returns>
    public async Task<List<KpTenantExportDto>> ExportAsync(KpTenantQueryDto query)
    {
      var predicate = Expressionable.Create<KpTenant>()
        .AndIF(!string.IsNullOrEmpty(query.TenantName), it => it.TenantName != null && it.TenantName.Contains(query.TenantName!))
        .AndIF(!string.IsNullOrEmpty(query.TenantCode), it => it.TenantCode != null && it.TenantCode.Contains(query.TenantCode!))
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.IsEnabled.HasValue, it => it.Status == query.IsEnabled);

      var tenants = await _tenantRepository.GetListAsync(predicate.ToExpression());
      var dtos = _mapper.Map<List<KpTenantExportDto>>(tenants);

      // 设置状态标签
      foreach (var dto in dtos)
      {
        dto.StatusLabel = dto.Status switch
        {
          0 => "禁用",
          1 => "启用",
          2 => "待审核",
          3 => "已过期",
          _ => "未知"
        };

        dto.IsEnabledLabel = dto.IsEnabled switch
        {
          0 => "否",
          1 => "是",
          _ => "未知"
        };
      }

      return dtos;
    }

    /// <summary>
    /// 获取租户导入模板
    /// </summary>
    /// <returns>租户导入模板</returns>
    public async Task<KpTenantTemplateDto> GetImportTemplateAsync()
    {
      return await Task.FromResult(new KpTenantTemplateDto
      {
        TenantName = "示例租户",
        TenantCode = "SAMPLE",
        TenantDesc = "示例租户描述",
        TenantContact = "张三",
        TenantPhone = "13800138000",
        TenantEmail = "sample@kunpo.com",
        TenantAddress = "示例地址",
        Status = 1,
        TenantExpireTime = DateTime.Now.AddYears(1),
        IsEnabled = 1,
        OrderNum = 1,
        StatusLabel = "启用",
        IsEnabledLabel = "是"
      });
    }
  }
}