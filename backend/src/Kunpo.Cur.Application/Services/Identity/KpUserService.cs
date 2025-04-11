// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户服务实现</summary>
// -----------------------------------------------------------------------
using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Options;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using System.Linq.Expressions;
using SqlSugar;
using AutoMapper;
using Kunpo.Cur.Common.Utils;
using Microsoft.Extensions.Options;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 用户服务实现
  /// </summary>
  public class KpUserService : KpBaseService, IKpUserService
  {
    private readonly IKpBaseRepository<KpUser> _userRepository;
    private readonly IKpJwtService _jwtService;
    private readonly KpJwtOption _jwtOptions;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="configuration">配置服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="userRepository">用户仓储</param>
    /// <param name="jwtService">JWT服务</param>
    /// <param name="jwtOptions">JWT配置</param>
    /// <param name="mapper">映射服务</param>
    public KpUserService(
      ILogger<KpUserService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpUser> userRepository,
      IKpJwtService jwtService,
      IOptions<KpJwtOption> jwtOptions,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _userRepository = userRepository;
      _jwtService = jwtService;
      _jwtOptions = jwtOptions.Value;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户列表</returns>
    public async Task<KpPageResult<KpUserDto>> GetListAsync(KpUserQueryDto query)
    {
      var predicate = Expressionable.Create<KpUser>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName != null && it.UserName.Contains(query.UserName!))
        .AndIF(!string.IsNullOrEmpty(query.UserRealName), it => it.UserRealName != null && it.UserRealName.Contains(query.UserRealName!))
        .AndIF(!string.IsNullOrEmpty(query.UserPhone), it => it.UserPhone != null && it.UserPhone.Contains(query.UserPhone!))
        .AndIF(!string.IsNullOrEmpty(query.UserEmail), it => it.UserEmail != null && it.UserEmail.Contains(query.UserEmail!))
        .AndIF(query.UserDeptId.HasValue, it => it.UserDeptId == query.UserDeptId)
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.UserType.HasValue, it => it.UserType == query.UserType)
        .AndIF(query.UserGender.HasValue, it => it.UserGender == query.UserGender)
        .AndIF(query.UserIsLocked.HasValue, it => it.UserIsLocked == query.UserIsLocked);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _userRepository.GetPageAsync<KpUserDto>(request, predicate.ToExpression());

      return new KpPageResult<KpUserDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>用户详情</returns>
    public async Task<KpUserDto> GetByIdAsync(long id)
    {
      var user = await _userRepository.GetByIdAsync(id);
      return _mapper.Map<KpUserDto>(user);
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户信息</param>
    /// <returns>用户ID</returns>
    public async Task<long> CreateAsync(KpUserCreateDto input)
    {
      // 验证用户名唯一性
      var exists = await _userRepository.ExistsAsync(u => u.UserName == input.UserName);
      if (exists)
      {
        throw new KpBusinessException("用户名已存在");
      }

      // 验证手机号唯一性
      if (!string.IsNullOrEmpty(input.UserPhone))
      {
        exists = await _userRepository.ExistsAsync(u => u.UserPhone == input.UserPhone);
        if (exists)
        {
          throw new KpBusinessException("手机号已存在");
        }
      }

      // 验证邮箱唯一性
      if (!string.IsNullOrEmpty(input.UserEmail))
      {
        exists = await _userRepository.ExistsAsync(u => u.UserEmail == input.UserEmail);
        if (exists)
        {
          throw new KpBusinessException("邮箱已存在");
        }
      }

      // 生成盐值和密码
      var (hashedPassword, salt) = KpPasswordHelper.GenerateHashAndSalt(input.UserPassword);
      var user = _mapper.Map<KpUser>(input);
      user.UserPassword = hashedPassword;
      user.UserSalt = salt;
      user.Status = 1;
      user.UserIsLocked = 0;
      user.UserLoginFailCount = 0;

      // 创建用户
      await _userRepository.CreateAsync(user);

      return user.Id;
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input">用户信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> UpdateAsync(KpUserUpdateDto input)
    {
      // 参数验证
      if (input.Id <= 0)
      {
        throw new KpBusinessException("用户ID不能为空");
      }

      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(input.Id);
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 检查用户名是否已存在
      if (user.UserName != input.UserName)
      {
        var exists = await _userRepository.ExistsAsync(u => u.UserName == input.UserName, input.Id);
        if (exists)
        {
          throw new KpBusinessException("用户名已存在");
        }
      }

      // 检查手机号是否已存在
      if (user.UserPhone != input.UserPhone)
      {
        if (!string.IsNullOrEmpty(input.UserPhone))
        {
          var exists = await _userRepository.ExistsAsync(u => u.UserPhone == input.UserPhone, input.Id);
          if (exists)
          {
            throw new KpBusinessException("手机号已存在");
          }
        }
      }

      // 检查邮箱是否已存在
      if (user.UserEmail != input.UserEmail)
      {
        if (!string.IsNullOrEmpty(input.UserEmail))
        {
          var exists = await _userRepository.ExistsAsync(u => u.UserEmail == input.UserEmail, input.Id);
          if (exists)
          {
            throw new KpBusinessException("邮箱已存在");
          }
        }
      }

      // 更新用户信息
      user.UserName = input.UserName;
      user.UserNickName = input.UserNickName;
      user.UserEnglishName = input.UserEnglishName;
      user.UserType = input.UserType;
      user.UserRealName = input.UserRealName;
      user.UserEmail = input.UserEmail;
      user.UserPhone = input.UserPhone;
      user.UserDeptId = input.UserDeptId;

      await _userRepository.UpdateAsync(user);

      return true;
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>是否成功</returns>
    public async Task<bool> DeleteAsync(long id)
    {
      // 参数验证
      if (id <= 0)
      {
        throw new KpBusinessException("用户ID不能为空");
      }

      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(id);
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 删除用户
      await _userRepository.DeleteAsync(id);

      return true;
    }

    /// <summary>
    /// 修改用户状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangeStatusAsync(KpUserChangeStatusDto input)
    {
      // 参数验证
      if (input.Id <= 0)
      {
        throw new KpBusinessException("用户ID不能为空");
      }

      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(input.Id);
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 更新用户状态
      user.Status = input.Status;

      await _userRepository.UpdateAsync(user);

      return true;
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input">密码信息</param>
    /// <returns>是否成功</returns>
    public async Task<bool> ChangePasswordAsync(KpUserChangePasswordDto input)
    {
      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(input.Id);
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 验证旧密码
      if (!KpPasswordHelper.VerifyPassword(input.OldPassword, user.UserSalt, user.UserPassword))
      {
        throw new KpBusinessException("旧密码错误");
      }

      // 更新密码
      var (hashedPassword, salt) = KpPasswordHelper.GenerateHashAndSalt(input.NewPassword);
      user.UserPassword = hashedPassword;
      user.UserSalt = salt;
      user.UserPasswordExpireTime = DateTime.Now.AddMonths(3);

      await _userRepository.UpdateAsync(user);

      return true;
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="input">用户ID</param>
    /// <returns>新密码</returns>
    public async Task<string> ResetPasswordAsync(KpUserResetPasswordDto input)
    {
      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(input.Id);
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 生成新密码
      var newPassword = KpPasswordHelper.GenerateSalt(12);
      var (hashedPassword, salt) = KpPasswordHelper.GenerateHashAndSalt(newPassword);
      user.UserPassword = hashedPassword;
      user.UserSalt = salt;
      user.UserPasswordExpireTime = DateTime.Now.AddMonths(3);

      await _userRepository.UpdateAsync(user);

      return newPassword;
    }

    /// <summary>
    /// 导入用户
    /// </summary>
    /// <param name="users">用户列表</param>
    /// <returns>导入结果</returns>
    public async Task<KpImportResult> ImportAsync(List<KpUserImportDto> users)
    {
      var result = new KpImportResult
      {
        Total = users.Count,
        Success = 0,
        Fail = 0,
        Errors = new List<string>()
      };

      foreach (var user in users)
      {
        try
        {
          // 检查用户名是否已存在
          var exists = await _userRepository.GetFirstOrDefaultAsync(u => u.UserName == user.UserName);
          if (exists != null)
          {
            throw new KpBusinessException("用户名已存在");
          }

          // 生成盐值和密码
          var password = KpPasswordHelper.GenerateSalt(12);
          var (hashedPassword, salt) = KpPasswordHelper.GenerateHashAndSalt(password);
          var entity = _mapper.Map<KpUser>(user);
          entity.UserPassword = hashedPassword;
          entity.UserSalt = salt;
          entity.Status = 1;
          entity.UserIsLocked = 0;
          entity.UserLoginFailCount = 0;

          // 创建用户
          await _userRepository.CreateAsync(entity);

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
    /// 导出用户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户列表</returns>
    public async Task<List<KpUserExportDto>> ExportAsync(KpUserQueryDto query)
    {
      var predicate = Expressionable.Create<KpUser>()
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName.Contains(query.UserName))
        .AndIF(!string.IsNullOrEmpty(query.UserRealName), it => it.UserRealName.Contains(query.UserRealName))
        .AndIF(!string.IsNullOrEmpty(query.UserPhone), it => it.UserPhone.Contains(query.UserPhone))
        .AndIF(!string.IsNullOrEmpty(query.UserEmail), it => it.UserEmail.Contains(query.UserEmail))
        .AndIF(query.UserDeptId.HasValue, it => it.UserDeptId == query.UserDeptId)
        .AndIF(query.Status.HasValue, it => it.Status == query.Status)
        .AndIF(query.UserType.HasValue, it => it.UserType == query.UserType)
        .AndIF(query.UserGender.HasValue, it => it.UserGender == query.UserGender)
        .AndIF(query.UserIsLocked.HasValue, it => it.UserIsLocked == query.UserIsLocked);

      var users = await _userRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpUserExportDto>>(users);
    }

    /// <summary>
    /// 获取导入模板
    /// </summary>
    /// <returns>导入模板</returns>
    public async Task<KpUserTemplateDto> GetImportTemplateAsync()
    {
      return new KpUserTemplateDto
      {
        UserName = "用户名",
        UserNickName = "昵称",
        UserEnglishName = "英文名",
        UserType = 0,
        UserRealName = "真实姓名",
        UserEmail = "邮箱",
        UserPhone = "手机号",
        UserDeptId = 0,
        Status = 1,
        UserTypeLabel = "0：普通用户，1：管理员，2：超级管理员",
        StatusLabel = "0：禁用，1：启用，2：待审核，3：已过期"
      };
    }
  }
}