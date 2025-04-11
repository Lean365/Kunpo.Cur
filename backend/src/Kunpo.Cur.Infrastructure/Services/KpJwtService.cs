// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>JWT服务</summary>
// <remarks>处理JWT的生成、验证和刷新等操作</remarks>
// -----------------------------------------------------------------------

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Kunpo.Cur.Common.Options;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Domain.Entities.Identity;
using Kunpo.Cur.Common.Exceptions;
using Kunpo.Cur.Infrastructure.Repositories;

namespace Kunpo.Cur.Infrastructure.Services
{
  /// <summary>
  /// JWT服务
  /// </summary>
  public class KpJwtService : IKpJwtService
  {
    private readonly IKpBaseRepository<KpTokenBlacklist> _tokenBlacklistRepository;
    private readonly IKpBaseRepository<KpUser> _userRepository;
    private readonly KpJwtOption _jwtOption;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="tokenBlacklistRepository">令牌黑名单仓储</param>
    /// <param name="userRepository">用户仓储</param>
    /// <param name="jwtOption">JWT配置</param>
    public KpJwtService(
        IKpBaseRepository<KpTokenBlacklist> tokenBlacklistRepository,
        IKpBaseRepository<KpUser> userRepository,
        IOptions<KpJwtOption> jwtOption)
    {
      _tokenBlacklistRepository = tokenBlacklistRepository;
      _userRepository = userRepository;
      _jwtOption = jwtOption.Value;
    }

    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="userName">用户名</param>
    /// <param name="permissions">权限列表</param>
    /// <returns>访问令牌</returns>
    public string GenerateAccessToken(long userId, string userName, IEnumerable<string> permissions)
    {
      var claims = new List<Claim>
      {
        new(ClaimTypes.NameIdentifier, userId.ToString()),
        new(ClaimTypes.Name, userName)
      };

      claims.AddRange(permissions.Select(permission => new Claim(ClaimTypes.Role, permission)));

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _jwtOption.Issuer,
        audience: _jwtOption.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtOption.ExpireMinutes),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>刷新令牌</returns>
    public string GenerateRefreshToken(long userId)
    {
      var claims = new List<Claim>
      {
        new(ClaimTypes.NameIdentifier, userId.ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _jwtOption.Issuer,
        audience: _jwtOption.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddDays(_jwtOption.RefreshTokenExpireDays),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// 验证令牌
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否有效</returns>
    public bool ValidateToken(string token)
    {
      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtOption.SecretKey);

        var tokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidIssuer = _jwtOption.Issuer,
          ValidateAudience = true,
          ValidAudience = _jwtOption.Audience,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };

        tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// 添加到黑名单
    /// </summary>
    /// <param name="token">令牌</param>
    /// <param name="expiration">过期时间</param>
    public void AddToBlacklist(string token, DateTime expiration)
    {
      var blacklist = new KpTokenBlacklist
      {
        Token = token,
        ExpireTime = expiration,
        BlacklistTime = DateTime.Now
      };

      _tokenBlacklistRepository.CreateAsync(blacklist).Wait();
    }

    /// <summary>
    /// 是否在黑名单中
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>是否在黑名单中</returns>
    public bool IsTokenBlacklisted(string token)
    {
      var blacklist = _tokenBlacklistRepository.GetListAsync(x => x.Token == token).Result;
      return blacklist.Any();
    }

    /// <summary>
    /// 生成访问令牌和刷新令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>访问令牌和刷新令牌</returns>
    public async Task<(string AccessToken, string RefreshToken)> GenerateTokensAsync(KpUser user)
    {
      var accessToken = await GenerateTokenAsync(user);
      var refreshToken = await GenerateRefreshTokenAsync(user);
      return (accessToken, refreshToken);
    }

    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>访问令牌</returns>
    public Task<string> GenerateTokenAsync(KpUser user)
    {
      var claims = new List<Claim>
      {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.UserName ?? string.Empty),
        new(ClaimTypes.Email, user.UserEmail ?? string.Empty),
        new(ClaimTypes.MobilePhone, user.UserPhone ?? string.Empty),
        new(ClaimTypes.Role, user.Roles ?? string.Empty)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _jwtOption.Issuer,
        audience: _jwtOption.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtOption.ExpireMinutes),
        signingCredentials: credentials);

      return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>刷新令牌</returns>
    public Task<string> GenerateRefreshTokenAsync(KpUser user)
    {
      var claims = new List<Claim>
      {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.UserName ?? string.Empty)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _jwtOption.Issuer,
        audience: _jwtOption.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddDays(_jwtOption.RefreshTokenExpireDays),
        signingCredentials: credentials);

      return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>新的访问令牌和刷新令牌</returns>
    public async Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken)
    {
      try
      {
        // 验证刷新令牌
        var principal = ValidateToken(refreshToken, true);
        if (principal == null)
        {
          throw new Exception("无效的刷新令牌");
        }

        // 获取用户ID
        var userId = GetUserIdFromToken(refreshToken);
        if (userId == 0)
        {
          throw new Exception("无效的刷新令牌");
        }

        // 将旧的刷新令牌加入黑名单
        var oldRefreshTokenBlacklist = new KpTokenBlacklist
        {
          Token = refreshToken,
          TokenType = 1,
          ExpireTime = DateTime.Now.AddDays(_jwtOption.RefreshTokenExpireDays),
          BlacklistReason = "刷新令牌"
        };

        await _tokenBlacklistRepository.CreateAsync(oldRefreshTokenBlacklist);

        // 生成新的访问令牌和刷新令牌
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
          throw new Exception("用户不存在");
        }

        return await GenerateTokensAsync(user);
      }
      catch (Exception ex)
      {
        throw new Exception("刷新令牌失败", ex);
      }
    }

    /// <summary>
    /// 验证令牌
    /// </summary>
    /// <param name="token">令牌</param>
    /// <param name="isRefreshToken">是否是刷新令牌</param>
    /// <returns>令牌主体</returns>
    public ClaimsPrincipal? ValidateToken(string token, bool isRefreshToken = false)
    {
      try
      {
        // 检查令牌是否在黑名单中
        var blacklisted = _tokenBlacklistRepository.GetListAsync(x =>
          x.Token == token &&
          x.TokenType == (isRefreshToken ? 1 : 0) &&
          x.ExpireTime > DateTime.Now).Result.FirstOrDefault();

        if (blacklisted != null)
        {
          return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));

        var tokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = _jwtOption.Issuer,
          ValidAudience = _jwtOption.Audience,
          IssuerSigningKey = key,
          ClockSkew = TimeSpan.Zero
        };

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
        return principal;
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 生成访问令牌
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="userName">用户名</param>
    /// <param name="roles">角色列表</param>
    /// <returns>访问令牌</returns>
    public string? GenerateAccessToken(long userId, string? userName, string[] roles)
    {
      if (string.IsNullOrEmpty(userName))
      {
        return null;
      }

      var claims = new List<Claim>
      {
        new(ClaimTypes.NameIdentifier, userId.ToString()),
        new(ClaimTypes.Name, userName)
      };

      // 添加角色声明
      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _jwtOption.Issuer,
        audience: _jwtOption.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtOption.ExpireMinutes),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// 生成刷新令牌
    /// </summary>
    /// <returns>刷新令牌</returns>
    public string? GenerateRefreshToken()
    {
      return Guid.NewGuid().ToString("N");
    }

    /// <summary>
    /// 验证访问令牌
    /// </summary>
    /// <param name="token">访问令牌</param>
    /// <returns>是否有效</returns>
    public bool ValidateAccessToken(string? token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return false;
      }

      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtOption.SecretKey);

        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidIssuer = _jwtOption.Issuer,
          ValidateAudience = true,
          ValidAudience = _jwtOption.Audience,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        }, out _);

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// 从令牌中获取用户ID
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>用户ID</returns>
    public long GetUserIdFromToken(string? token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return 0;
      }

      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        return userIdClaim != null && long.TryParse(userIdClaim.Value, out var userId) ? userId : 0;
      }
      catch
      {
        return 0;
      }
    }

    /// <summary>
    /// 从令牌中获取用户名
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>用户名</returns>
    public string? GetUserNameFromToken(string? token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return null;
      }

      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        return jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 从令牌中获取角色列表
    /// </summary>
    /// <param name="token">令牌</param>
    /// <returns>角色列表</returns>
    public string[] GetRolesFromToken(string? token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return Array.Empty<string>();
      }

      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        return jwtToken.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
      }
      catch
      {
        return Array.Empty<string>();
      }
    }

    /// <summary>
    /// 登出
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>是否成功</returns>
    public async Task<bool> LogoutAsync(string accessToken, string refreshToken)
    {
      var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOption.ExpireMinutes);
      var refreshTokenExpiration = DateTime.Now.AddDays(_jwtOption.RefreshTokenExpireDays);

      var blacklist = new List<KpTokenBlacklist>
      {
        new KpTokenBlacklist
        {
          Token = accessToken,
          ExpireTime = accessTokenExpiration,
          BlacklistTime = DateTime.Now
        },
        new KpTokenBlacklist
        {
          Token = refreshToken,
          ExpireTime = refreshTokenExpiration,
          BlacklistTime = DateTime.Now
        }
      };

      foreach (var item in blacklist)
      {
        await _tokenBlacklistRepository.CreateAsync(item);
      }

      return true;
    }
  }
}