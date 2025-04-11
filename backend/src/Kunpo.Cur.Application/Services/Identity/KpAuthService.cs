// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>认证服务实现</summary>
// -----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Common.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using System.Linq;
using Kunpo.Cur.Common.Utils;
using Kunpo.Cur.Domain.Entities.Audit;
using Kunpo.Cur.Application.Dtos.Audit;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 认证服务实现
  /// </summary>
  public class KpAuthService : KpBaseService, IKpAuthService
  {
    private readonly IKpBaseRepository<KpUser> _userRepository;
    private readonly IKpJwtService _jwtService;
    private readonly KpJwtOption _jwtOptions;
    private readonly IKpBaseRepository<KpLoginLog> _loginLogRepository;
    private readonly IKpBaseRepository<KpErrorLog> _errorLogRepository;
    private readonly IKpBaseRepository<KpLoginDev> _loginDevRepository;
    private readonly IKpBaseRepository<KpLoginEnv> _loginEnvRepository;

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
    /// <param name="loginLogRepository">登录日志仓储</param>
    /// <param name="errorLogRepository">错误日志仓储</param>
    /// <param name="loginDevRepository">登录设备仓储</param>
    /// <param name="loginEnvRepository">登录环境仓储</param>
    public KpAuthService(
      ILogger<KpAuthService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpUser> userRepository,
      IKpJwtService jwtService,
      IOptions<KpJwtOption> jwtOptions,
      IKpBaseRepository<KpLoginLog> loginLogRepository,
      IKpBaseRepository<KpErrorLog> errorLogRepository,
      IKpBaseRepository<KpLoginDev> loginDevRepository,
      IKpBaseRepository<KpLoginEnv> loginEnvRepository) : base(logger, configuration, securityContext, localizationService)
    {
      _userRepository = userRepository;
      _jwtService = jwtService;
      _jwtOptions = jwtOptions.Value;
      _loginLogRepository = loginLogRepository;
      _errorLogRepository = errorLogRepository;
      _loginDevRepository = loginDevRepository;
      _loginEnvRepository = loginEnvRepository;
    }

    /// <summary>
    /// 创建登录日志
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <param name="loginType">登录类型</param>
    /// <param name="loginStatus">登录状态</param>
    /// <param name="loginMessage">登录消息</param>
    /// <param name="loginIp">登录IP</param>
    /// <param name="loginLocation">登录地点</param>
    /// <param name="loginBrowser">登录浏览器</param>
    /// <param name="loginOs">登录操作系统</param>
    /// <returns>登录日志ID</returns>
    private async Task<long> CreateLoginLogAsync(
        KpUser user,
        int loginType,
        int loginStatus,
        string loginMessage,
        string loginIp,
        string loginLocation,
        string loginBrowser,
        string loginOs)
    {
      var loginLog = new KpLoginLog
      {
        UserId = user.Id,
        UserName = user.UserName,
        LoginType = loginType,
        LoginStatus = loginStatus,
        LoginMessage = loginMessage,
        LoginIp = loginIp,
        LoginLocation = loginLocation,
        LoginBrowser = loginBrowser,
        LoginOs = loginOs,
        LoginTime = DateTime.Now
      };

      await _loginLogRepository.CreateAsync(loginLog);
      return loginLog.Id;
    }

    /// <summary>
    /// 创建错误日志
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="userName">用户名</param>
    /// <param name="errorType">错误类型</param>
    /// <param name="errorMessage">错误消息</param>
    /// <param name="errorStack">错误堆栈</param>
    /// <param name="errorSource">错误来源</param>
    /// <returns>错误日志ID</returns>
    private async Task<long> CreateErrorLogAsync(
        long userId,
        string userName,
        int errorType,
        string errorMessage,
        string errorStack,
        string errorSource)
    {
      var errorLog = new KpErrorLog
      {
        UserId = userId,
        UserName = userName,
        ErrorType = errorType,
        ErrorMessage = errorMessage,
        ErrorStack = errorStack,
        ErrorSource = errorSource,
        ErrorTime = DateTime.Now
      };

      await _errorLogRepository.CreateAsync(errorLog);
      return errorLog.Id;
    }

    /// <summary>
    /// 创建或更新登录设备
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <param name="deviceId">设备ID</param>
    /// <param name="deviceName">设备名称</param>
    /// <param name="deviceType">设备类型</param>
    /// <param name="deviceModel">设备型号</param>
    /// <param name="deviceOs">设备操作系统</param>
    /// <param name="deviceOsVersion">设备操作系统版本</param>
    /// <returns>登录设备ID</returns>
    private async Task<long> CreateOrUpdateLoginDevAsync(
        KpUser user,
        string deviceId,
        string deviceName,
        int deviceType,
        string deviceModel,
        string deviceOs,
        string deviceOsVersion)
    {
      var loginDev = await _loginDevRepository.GetFirstOrDefaultAsync(x => x.UserId == user.Id && x.DeviceId == deviceId);
      if (loginDev == null)
      {
        loginDev = new KpLoginDev
        {
          UserId = user.Id,
          DeviceId = deviceId,
          DeviceName = deviceName,
          DeviceType = deviceType,
          DeviceModel = deviceModel,
          FirstLoginTime = DateTime.Now,
          LastLoginTime = DateTime.Now
        };
        await _loginDevRepository.CreateAsync(loginDev);
      }
      else
      {
        loginDev.LastLoginTime = DateTime.Now;
        await _loginDevRepository.UpdateAsync(loginDev);
      }

      return loginDev.Id;
    }

    /// <summary>
    /// 创建登录环境
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <param name="loginDevId">登录设备ID</param>
    /// <param name="envType">环境类型</param>
    /// <param name="envName">环境名称</param>
    /// <param name="envVersion">环境版本</param>
    /// <param name="envDescription">环境描述</param>
    /// <returns>登录环境ID</returns>
    private async Task<long> CreateLoginEnvAsync(
        KpUser user,
        long loginDevId,
        string envType,
        string envName,
        string envVersion,
        string envDescription)
    {
      var loginEnv = new KpLoginEnv
      {
        UserId = user.Id,
        DeviceId = loginDevId.ToString(),
        CustomData = $"{{ \"envType\": \"{envType}\", \"envName\": \"{envName}\", \"envVersion\": \"{envVersion}\", \"envDescription\": \"{envDescription}\" }}",
        LoginTime = DateTime.Now
      };

      await _loginEnvRepository.CreateAsync(loginEnv);
      return loginEnv.Id;
    }

    /// <summary>
    /// 用户认证
    /// </summary>
    /// <param name="authRequest">认证请求</param>
    /// <returns>认证响应</returns>
    public async Task<KpAuthResponseDto> AuthenticateAsync(KpAuthRequestDto authRequest)
    {
      try
      {
        // 参数验证
        if (string.IsNullOrEmpty(authRequest.UserName))
        {
          throw new KpBusinessException("用户名不能为空");
        }

        if (string.IsNullOrEmpty(authRequest.Password))
        {
          throw new KpBusinessException("密码不能为空");
        }

        // 获取用户信息
        var user = await _userRepository.GetFirstOrDefaultAsync(u => u.UserName == authRequest.UserName);
        if (user == null)
        {
          await CreateLoginLogAsync(
              new KpUser { UserName = authRequest.UserName },
              1, // 密码登录
              0, // 失败
              "用户名或密码错误",
              authRequest.LoginIp,
              authRequest.LoginLocation,
              authRequest.LoginBrowser,
              authRequest.LoginOs
          );
          throw new KpBusinessException("用户名或密码错误");
        }

        // 检查用户状态
        if (user.Status != 1)
        {
          await CreateLoginLogAsync(
              user,
              1, // 密码登录
              0, // 失败
              "用户已被禁用",
              authRequest.LoginIp,
              authRequest.LoginLocation,
              authRequest.LoginBrowser,
              authRequest.LoginOs
          );
          throw new KpBusinessException("用户已被禁用");
        }

        // 检查用户是否被锁定
        if (user.UserIsLocked == 1)
        {
          if (user.UserLoginLockTime.HasValue && user.UserLoginLockTime.Value.AddMinutes(30) > DateTime.Now)
          {
            await CreateLoginLogAsync(
                user,
                1, // 密码登录
                0, // 失败
                "用户已被锁定，请30分钟后再试",
                authRequest.LoginIp,
                authRequest.LoginLocation,
                authRequest.LoginBrowser,
                authRequest.LoginOs
            );
            throw new KpBusinessException("用户已被锁定，请30分钟后再试");
          }
          else
          {
            // 解锁用户
            user.UserIsLocked = 0;
            user.UserLoginFailCount = 0;
            await _userRepository.UpdateAsync(user);
          }
        }

        // 验证密码
        if (!KpPasswordHelper.VerifyPassword(authRequest.Password, user.UserSalt, user.UserPassword))
        {
          // 更新登录失败次数
          user.UserLoginFailCount++;
          if (user.UserLoginFailCount >= 5)
          {
            user.UserIsLocked = 1;
            user.UserLoginLockTime = DateTime.Now;
          }
          await _userRepository.UpdateAsync(user);

          await CreateLoginLogAsync(
              user,
              1, // 密码登录
              0, // 失败
              "用户名或密码错误",
              authRequest.LoginIp,
              authRequest.LoginLocation,
              authRequest.LoginBrowser,
              authRequest.LoginOs
          );
          throw new KpBusinessException("用户名或密码错误");
        }

        // 重置登录失败次数
        user.UserLoginFailCount = 0;
        user.UpdatedTime = DateTime.Now;
        await _userRepository.UpdateAsync(user);

        // 创建登录日志
        var loginLogId = await CreateLoginLogAsync(
            user,
            1, // 密码登录
            1, // 成功
            "登录成功",
            authRequest.LoginIp,
            authRequest.LoginLocation,
            authRequest.LoginBrowser,
            authRequest.LoginOs
        );

        // 创建或更新登录设备
        var loginDevId = await CreateOrUpdateLoginDevAsync(
            user,
            authRequest.DeviceId,
            authRequest.DeviceName,
            authRequest.DeviceType,
            authRequest.DeviceModel,
            authRequest.DeviceOs,
            authRequest.DeviceOsVersion
        );

        // 创建登录环境
        var loginEnvId = await CreateLoginEnvAsync(
            user,
            loginDevId,
            authRequest.EnvType,
            authRequest.EnvName,
            authRequest.EnvVersion,
            authRequest.EnvDescription
        );

        // 生成令牌
        var tokens = await _jwtService.GenerateTokensAsync(user);
        var accessToken = tokens.AccessToken;
        var refreshToken = tokens.RefreshToken;

        // 返回认证响应
        return new KpAuthResponseDto
        {
          UserId = user.Id,
          UserName = user.UserName,
          UserNickName = user.UserNickName,
          UserType = user.UserType,
          AccessToken = accessToken,
          RefreshToken = refreshToken,
          Expires = DateTime.Now.AddMinutes(_jwtOptions.ExpireMinutes)
        };
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "用户认证失败");
        await CreateErrorLogAsync(
            0,
            authRequest.UserName,
            0, // 默认错误类型
            ex.Message,
            ex.StackTrace,
            "KpAuthService.AuthenticateAsync"
        );
        throw;
      }
    }

    /// <summary>
    /// 用户登出
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>是否成功</returns>
    public async Task<bool> LogoutAsync(string accessToken, string refreshToken)
    {
      return await _jwtService.LogoutAsync(accessToken, refreshToken);
    }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>新的访问令牌</returns>
    public async Task<KpAuthResponseDto> RefreshTokenAsync(string refreshToken)
    {
      // 验证刷新令牌
      var principal = _jwtService.ValidateToken(refreshToken, true);
      if (principal == null)
      {
        throw new KpBusinessException("无效的刷新令牌");
      }

      // 获取用户ID
      var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if (string.IsNullOrEmpty(userId))
      {
        throw new KpBusinessException("无效的刷新令牌");
      }

      // 获取用户信息
      var user = await _userRepository.GetByIdAsync(long.Parse(userId));
      if (user == null)
      {
        throw new KpBusinessException("用户不存在");
      }

      // 检查用户状态
      if (user.Status != 1)
      {
        throw new KpBusinessException("用户已被禁用");
      }

      // 生成新的令牌
      var tokens = await _jwtService.GenerateTokensAsync(user);
      var accessToken = tokens.AccessToken;
      var newRefreshToken = tokens.RefreshToken;

      // 返回认证响应
      return new KpAuthResponseDto
      {
        UserId = user.Id,
        UserName = user.UserName,
        UserNickName = user.UserNickName,
        UserType = user.UserType,
        AccessToken = accessToken,
        RefreshToken = newRefreshToken,
        Expires = DateTime.Now.AddMinutes(_jwtOptions.ExpireMinutes)
      };
    }
  }
}