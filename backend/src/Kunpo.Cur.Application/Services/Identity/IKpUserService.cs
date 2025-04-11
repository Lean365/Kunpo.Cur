
// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户服务接口</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Common.Models;

namespace Kunpo.Cur.Application.Services.Identity
{
  /// <summary>
  /// 用户服务接口
  /// </summary>
  public interface IKpUserService
  {
    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户列表</returns>
    Task<KpPageResult<KpUserDto>> GetListAsync(KpUserQueryDto query);

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>用户详情</returns>
    Task<KpUserDto> GetByIdAsync(long userId);

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="dto">创建用户参数</param>
    /// <returns>用户ID</returns>
    Task<long> CreateAsync(KpUserCreateDto dto);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto">更新用户参数</param>
    /// <returns>是否成功</returns>
    Task<bool> UpdateAsync(KpUserUpdateDto dto);

    /// <summary>
    /// 导入用户
    /// </summary>
    /// <param name="dtos">用户导入数据</param>
    /// <returns>导入结果</returns>
    Task<KpImportResult> ImportAsync(List<KpUserImportDto> dtos);

    /// <summary>
    /// 导出用户
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>用户导出数据</returns>
    Task<List<KpUserExportDto>> ExportAsync(KpUserQueryDto query);

    /// <summary>
    /// 获取用户导入模板
    /// </summary>
    /// <returns>用户导入模板</returns>
    Task<KpUserTemplateDto> GetImportTemplateAsync();

    /// <summary>
    /// 修改用户状态
    /// </summary>
    /// <param name="dto">修改状态参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangeStatusAsync(KpUserChangeStatusDto dto);

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="dto">修改密码参数</param>
    /// <returns>是否成功</returns>
    Task<bool> ChangePasswordAsync(KpUserChangePasswordDto dto);

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="dto">重置密码参数</param>
    /// <returns>新密码</returns>
    Task<string> ResetPasswordAsync(KpUserResetPasswordDto dto);

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>是否成功</returns>
    Task<bool> DeleteAsync(long userId);
  }
}