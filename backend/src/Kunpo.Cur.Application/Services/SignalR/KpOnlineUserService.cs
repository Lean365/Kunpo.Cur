// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>在线用户服务实现</summary>
// -----------------------------------------------------------------------
using Kunpo.Cur.Application.Dtos.SignalR;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Domain.Entities.SignalR;
using Kunpo.Cur.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

using SqlSugar;


namespace Kunpo.Cur.Application.Services.SignalR
{
  /// <summary>
  /// 在线用户服务实现
  /// </summary>
  public class KpOnlineUserService : KpBaseService, IKpOnlineUserService
  {
    private readonly IKpBaseRepository<KpOnlineUser> _userRepository;
    private readonly IMapper _mapper;

    public KpOnlineUserService(
      ILogger<KpOnlineUserService> logger,
      IConfiguration configuration,
      IKpSecurityContext securityContext,
      IKpLocalizationService localizationService,
      IKpBaseRepository<KpOnlineUser> userRepository,
      IMapper mapper) : base(logger, configuration, securityContext, localizationService)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// 获取在线用户
    /// </summary>
    public async Task<KpOnlineUserDto?> GetAsync(long userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      if (user == null) return null;

      return _mapper.Map<KpOnlineUserDto>(user);
    }

    /// <summary>
    /// 获取在线用户列表
    /// </summary>
    public async Task<KpPageResult<KpOnlineUserDto>> GetListAsync(KpOnlineUserQueryDto query)
    {
      var predicate = Expressionable.Create<KpOnlineUser>()
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName.Contains(query.UserName))
        .AndIF(query.DeviceType.HasValue, it => it.DeviceType == query.DeviceType)
        .AndIF(query.IsOnline.HasValue, it => it.IsOnline == query.IsOnline)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var request = new KpPageRequest
      {
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        OrderBy = query.OrderBy,
        OrderType = query.OrderType
      };

      var (items, total) = await _userRepository.GetPageAsync<KpOnlineUserDto>(request, predicate.ToExpression());

      return new KpPageResult<KpOnlineUserDto>
      {
        Total = total,
        PageNum = query.PageNum,
        PageSize = query.PageSize,
        List = items
      };
    }

    /// <summary>
    /// 获取所有在线用户
    /// </summary>
    public async Task<List<KpOnlineUserDto>> GetAllAsync()
    {
      var users = await _userRepository.GetListAsync(x => x.IsOnline == 1);
      return _mapper.Map<List<KpOnlineUserDto>>(users);
    }

    /// <summary>
    /// 创建在线用户
    /// </summary>
    public async Task<long> CreateAsync(KpOnlineUserCreateDto input)
    {
      var user = _mapper.Map<KpOnlineUser>(input);
      user.LoginTime = DateTime.Now;
      user.IsOnline = 1;

      await _userRepository.CreateAsync(user);
      return user.Id;
    }

    /// <summary>
    /// 更新在线用户
    /// </summary>
    public async Task<bool> UpdateAsync(KpOnlineUserUpdateDto input)
    {
      var user = await _userRepository.GetByIdAsync(input.UserId);
      if (user == null) return false;

      user.DeviceType = input.DeviceType;
      user.DeviceId = input.DeviceId;
      user.DeviceName = input.DeviceName;
      user.DeviceModel = input.DeviceModel;
      user.IsOnline = input.IsOnline ? 1 : 0;
      user.LastActivityTime = DateTime.Now;

      await _userRepository.UpdateAsync(user);
      return true;
    }

    /// <summary>
    /// 更新用户最后活动时间
    /// </summary>
    public async Task<bool> UpdateLastActivityTimeAsync(long userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      if (user == null) return false;

      user.LastActivityTime = DateTime.Now;
      await _userRepository.UpdateAsync(user);
      return true;
    }

    /// <summary>
    /// 强制用户下线
    /// </summary>
    public async Task<bool> ForceLogoutAsync(long userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      if (user == null) return false;

      user.IsOnline = 0;
      await _userRepository.UpdateAsync(user);
      return true;
    }

    /// <summary>
    /// 检查用户是否在线
    /// </summary>
    public async Task<bool> IsOnlineAsync(long userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      return user != null && user.IsOnline == 1;
    }

    /// <summary>
    /// 删除在线用户
    /// </summary>
    public async Task<bool> DeleteAsync(KpOnlineUserDeleteDto input)
    {
      var user = await _userRepository.GetByIdAsync(input.UserId);
      if (user == null) return false;

      await _userRepository.DeleteAsync(user.Id);
      return true;
    }

    /// <summary>
    /// 导出在线用户列表
    /// </summary>
    public async Task<List<KpOnlineUserExportDto>> ExportListAsync(KpOnlineUserQueryDto query)
    {
      var predicate = Expressionable.Create<KpOnlineUser>()
        .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
        .AndIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName.Contains(query.UserName))
        .AndIF(query.DeviceType.HasValue, it => it.DeviceType == query.DeviceType)
        .AndIF(query.IsOnline.HasValue, it => it.IsOnline == query.IsOnline)
        .AndIF(query.StartTime.HasValue, it => it.LoginTime >= query.StartTime)
        .AndIF(query.EndTime.HasValue, it => it.LoginTime <= query.EndTime);

      var users = await _userRepository.GetListAsync(predicate.ToExpression());
      return _mapper.Map<List<KpOnlineUserExportDto>>(users);
    }
  }
}