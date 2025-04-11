// -----------------------------------------------------------------------
// <copyright file="KpLoginDevService.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>登录设备服务实现</summary>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kunpo.Cur.Application.Dtos.Audit;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Domain.Entities.Audit;
using Kunpo.Cur.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Kunpo.Cur.Common.Exceptions;
using System.Linq.Expressions;
using SqlSugar;
using Kunpo.Cur.Common.Interfaces;
using Kunpo.Cur.Application.Services.Localization;
using Microsoft.Extensions.Configuration;

namespace Kunpo.Cur.Application.Services.Audit
{
    /// <summary>
    /// 登录设备服务实现
    /// </summary>
    public class KpLoginDevService : KpBaseService, IKpLoginDevService
    {
        private readonly IKpBaseRepository<KpLoginDev> _loginDeviceRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger">日志服务</param>
        /// <param name="configuration">配置服务</param>
        /// <param name="securityContext">安全上下文</param>
        /// <param name="localizationService">本地化服务</param>
        /// <param name="loginDeviceRepository">登录设备仓储</param>
        /// <param name="mapper">映射服务</param>
        public KpLoginDevService(
          ILogger<KpLoginDevService> logger,
          IConfiguration configuration,
          IKpSecurityContext securityContext,
          IKpLocalizationService localizationService,
          IKpBaseRepository<KpLoginDev> loginDeviceRepository,
          IMapper mapper) : base(logger, configuration, securityContext, localizationService)
        {
            _loginDeviceRepository = loginDeviceRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取登录设备列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns>登录设备列表</returns>
        public async Task<KpPageResult<KpLoginDevDto>> GetListAsync(KpLoginDeviceQueryDto query)
        {
            var predicate = Expressionable.Create<KpLoginDev>()
              .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
              .AndIF(!string.IsNullOrEmpty(query.DeviceId), it => it.DeviceId != null && it.DeviceId.Contains(query.DeviceId!))
              .AndIF(!string.IsNullOrEmpty(query.DeviceName), it => it.DeviceName != null && it.DeviceName.Contains(query.DeviceName!))
              .AndIF(query.DeviceType.HasValue, it => it.DeviceType == query.DeviceType)
              .AndIF(query.DeviceStatus.HasValue, it => it.DeviceStatus == query.DeviceStatus);

            var request = new KpPageRequest
            {
                PageNum = 1,
                PageSize = 10,
                OrderBy = "Id",
                OrderType = "desc"
            };

            var (items, total) = await _loginDeviceRepository.GetPageAsync<KpLoginDevDto>(request, predicate.ToExpression());

            return new KpPageResult<KpLoginDevDto>
            {
                Total = total,
                PageNum = request.PageNum,
                PageSize = request.PageSize,
                List = items
            };
        }

        /// <summary>
        /// 获取登录设备详情
        /// </summary>
        /// <param name="id">登录设备ID</param>
        /// <returns>登录设备详情</returns>
        public async Task<KpLoginDevDto> GetByIdAsync(long id)
        {
            var loginDevice = await _loginDeviceRepository.GetByIdAsync(id);
            if (loginDevice == null)
            {
                throw new KpBusinessException("登录设备不存在");
            }
            return _mapper.Map<KpLoginDevDto>(loginDevice);
        }

        /// <summary>
        /// 创建登录设备
        /// </summary>
        /// <param name="input">登录设备信息</param>
        /// <returns>登录设备ID</returns>
        public async Task<long> CreateAsync(KpLoginDeviceCreateDto input)
        {
            var loginDevice = _mapper.Map<KpLoginDev>(input);
            await _loginDeviceRepository.CreateAsync(loginDevice);
            return loginDevice.Id;
        }

        /// <summary>
        /// 更新登录设备
        /// </summary>
        /// <param name="input">登录设备信息</param>
        /// <returns>是否成功</returns>
        public async Task<bool> UpdateAsync(KpLoginDeviceUpdateDto input)
        {
            // 由于 KpLoginDeviceUpdateDto 中没有 Id 属性，需要从其他地方获取
            // 这里假设通过 DeviceId 和 UserId 来查找设备
            var loginDevice = await _loginDeviceRepository.GetFirstOrDefaultAsync(it => it.DeviceId == input.DeviceId && it.UserId == input.UserId);
            if (loginDevice == null)
            {
                throw new KpBusinessException("登录设备不存在");
            }

            _mapper.Map(input, loginDevice);
            return await _loginDeviceRepository.UpdateAsync(loginDevice);
        }

        /// <summary>
        /// 删除登录设备
        /// </summary>
        /// <param name="id">登录设备ID</param>
        /// <returns>是否成功</returns>
        public async Task<bool> DeleteAsync(long id)
        {
            var loginDevice = await _loginDeviceRepository.GetByIdAsync(id);
            if (loginDevice == null)
            {
                throw new KpBusinessException("登录设备不存在");
            }

            return await _loginDeviceRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 导出登录设备列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns>登录设备列表</returns>
        public async Task<List<KpLoginDeviceExportDto>> ExportListAsync(KpLoginDeviceQueryDto query)
        {
            var predicate = Expressionable.Create<KpLoginDev>()
              .AndIF(query.UserId.HasValue, it => it.UserId == query.UserId)
              .AndIF(!string.IsNullOrEmpty(query.DeviceId), it => it.DeviceId != null && it.DeviceId.Contains(query.DeviceId!))
              .AndIF(!string.IsNullOrEmpty(query.DeviceName), it => it.DeviceName != null && it.DeviceName.Contains(query.DeviceName!))
              .AndIF(query.DeviceType.HasValue, it => it.DeviceType == query.DeviceType)
              .AndIF(query.DeviceStatus.HasValue, it => it.DeviceStatus == query.DeviceStatus);

            var loginDevices = await _loginDeviceRepository.GetListAsync(predicate.ToExpression());
            return _mapper.Map<List<KpLoginDeviceExportDto>>(loginDevices);
        }
    }
}