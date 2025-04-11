// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>用户数据传输对象</summary>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Newtonsoft.Json;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 用户 DTO
  /// </summary>
  public class KpUserDto
  {
    /// <summary>
    /// 构造函数
    /// </summary>
    public KpUserDto()
    {
      UserName = string.Empty;
      UserPassword = string.Empty;
      UserSalt = string.Empty;
      UserNickName = string.Empty;
      UserEnglishName = string.Empty;
      UserRealName = string.Empty;
      UserEmail = string.Empty;
      UserPhone = string.Empty;
      UserAvatar = string.Empty;
      Roles = string.Empty;
    }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    public string? UserName { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string? UserNickName { get; set; }

    /// <summary>
    /// 用户英文名
    /// </summary>
    public string? UserEnglishName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    /// <remarks>
    /// 0：普通用户，1：管理员，2：超级管理员，默认为0
    /// </remarks>
    [Required(ErrorMessage = "用户类型不能为空")]
    public int UserType { get; set; }

    /// <summary>
    /// 用户真实姓名
    /// </summary>
    public string? UserRealName { get; set; }

    /// <summary>
    /// 用户邮箱
    /// </summary>
    public string? UserEmail { get; set; }

    /// <summary>
    /// 用户手机
    /// </summary>
    public string? UserPhone { get; set; }

    /// <summary>
    /// 用户头像
    /// </summary>
    public string? UserAvatar { get; set; }

    /// <summary>
    /// 用户性别
    /// </summary>
    /// <remarks>
    /// 0：未知，1：男，2：女，默认为0
    /// </remarks>
    public int UserGender { get; set; }

    /// <summary>
    /// 用户密码
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 密码盐值
    /// </summary>
    public string? UserSalt { get; set; }

    /// <summary>
    /// 密码过期时间
    /// </summary>
    public DateTime? UserPasswordExpireTime { get; set; }

    /// <summary>
    /// 登录失败次数
    /// </summary>
    public int UserLoginFailCount { get; set; }

    /// <summary>
    /// 登录锁定时间
    /// </summary>
    public DateTime? UserLoginLockTime { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
    /// </remarks>
    public int Status { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    /// <remarks>
    /// 0：否，1：是，默认为0
    /// </remarks>
    public int UserIsLocked { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    public long? UserDeptId { get; set; }

    /// <summary>
    /// 角色列表（逗号分隔）
    /// </summary>
    public string? Roles { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// 创建人ID
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// 更新人ID
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool IsDeleted { get; set; }
  }

  /// <summary>
  /// 用户查询 DTO
  /// </summary>
  public class KpUserQueryDto : KpPageRequest
  {
    public KpUserQueryDto()
    {
      UserName = null;
      UserRealName = null;
      UserPhone = null;
      UserEmail = null;
      UserDeptId = null;
      Status = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "UserRealName", "UserPhone", "UserEmail" };
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string? UserRealName { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string? UserPhone { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? UserEmail { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    public long? UserDeptId { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    public int? UserType { get; set; }

    /// <summary>
    /// 用户性别
    /// </summary>
    public int? UserGender { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public int? UserIsLocked { get; set; }
  }

  /// <summary>
  /// 创建用户 DTO
  /// </summary>
  public class KpUserCreateDto
  {
    public KpUserCreateDto()
    {
      UserName = string.Empty;
      UserPassword = string.Empty;
      UserNickName = string.Empty;
      UserEnglishName = string.Empty;
      UserRealName = string.Empty;
      UserEmail = string.Empty;
      UserPhone = string.Empty;
      UserType = 0;
      UserDeptId = 0;
    }

    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    public string? UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不能为空")]
    public string? UserPassword { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string? UserNickName { get; set; }

    /// <summary>
    /// 英文名
    /// </summary>
    public string? UserEnglishName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    public int UserType { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string? UserRealName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? UserEmail { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string? UserPhone { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    public long UserDeptId { get; set; }
  }

  /// <summary>
  /// 更新用户 DTO
  /// </summary>
  public class KpUserUpdateDto : KpUserCreateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 用户导入 DTO
  /// </summary>
  public class KpUserImportDto
  {
    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [KpExcelColumnName("昵称")]
    public string? UserNickName { get; set; }

    /// <summary>
    /// 英文名
    /// </summary>
    [KpExcelColumnName("英文名")]
    public string? UserEnglishName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    /// <remarks>
    /// 0：普通用户，1：管理员，2：超级管理员，默认为0
    /// </remarks>
    [Required(ErrorMessage = "用户类型不能为空")]
    [KpExcelColumnName("用户类型")]
    public int UserType { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    [KpExcelColumnName("真实姓名")]
    public string? UserRealName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [KpExcelColumnName("邮箱")]
    public string? UserEmail { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [KpExcelColumnName("手机号")]
    public string? UserPhone { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
    /// </remarks>
    [Required(ErrorMessage = "用户状态不能为空")]
    [KpExcelColumnName("用户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    /// <remarks>
    /// 关联部门表(kp_dept)的主键
    /// </remarks>
    [Required(ErrorMessage = "部门ID不能为空")]
    [KpExcelColumnName("部门ID")]
    public long UserDeptId { get; set; }
  }

  /// <summary>
  /// 用户导出 DTO
  /// </summary>
  public class KpUserExportDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(ValueToStringConverter))]
    [KpExcelColumnName("用户ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [KpExcelColumnName("昵称")]
    public string? UserNickName { get; set; }

    /// <summary>
    /// 英文名
    /// </summary>
    [KpExcelColumnName("英文名")]
    public string? UserEnglishName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    [KpExcelColumnName("用户类型")]
    public int UserType { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    [KpExcelColumnName("真实姓名")]
    public string? UserRealName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [KpExcelColumnName("邮箱")]
    public string? UserEmail { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [KpExcelColumnName("手机号")]
    public string? UserPhone { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    [KpExcelColumnName("用户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    [KpExcelColumnName("部门ID")]
    public long UserDeptId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 用户类型标签
    /// </summary>
    [KpExcelColumnName("用户类型")]
    public string? UserTypeLabel { get; set; }

    /// <summary>
    /// 用户状态标签
    /// </summary>
    [KpExcelColumnName("用户状态")]
    public string? StatusLabel { get; set; }
  }

  /// <summary>
  /// 用户模板 DTO
  /// </summary>
  public class KpUserTemplateDto
  {
    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [KpExcelColumnName("昵称")]
    public string? UserNickName { get; set; }

    /// <summary>
    /// 英文名
    /// </summary>
    [KpExcelColumnName("英文名")]
    public string? UserEnglishName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    /// <remarks>
    /// 0：普通用户，1：管理员，2：超级管理员，默认为0
    /// </remarks>
    [Required(ErrorMessage = "用户类型不能为空")]
    [KpExcelColumnName("用户类型")]
    public int UserType { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    [KpExcelColumnName("真实姓名")]
    public string? UserRealName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [KpExcelColumnName("邮箱")]
    public string? UserEmail { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [KpExcelColumnName("手机号")]
    public string? UserPhone { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
    /// </remarks>
    [Required(ErrorMessage = "用户状态不能为空")]
    [KpExcelColumnName("用户状态")]
    public int Status { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    /// <remarks>
    /// 关联部门表(kp_dept)的主键
    /// </remarks>
    [Required(ErrorMessage = "部门ID不能为空")]
    [KpExcelColumnName("部门ID")]
    public long UserDeptId { get; set; }

    /// <summary>
    /// 用户类型标签
    /// </summary>
    [KpExcelColumnName("用户类型")]
    public string? UserTypeLabel { get; set; }

    /// <summary>
    /// 用户状态标签
    /// </summary>
    [KpExcelColumnName("用户状态")]
    public string? StatusLabel { get; set; }
  }

  /// <summary>
  /// 修改用户状态 DTO
  /// </summary>
  public class KpUserChangeStatusDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    /// <remarks>
    /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
    /// </remarks>
    [Required(ErrorMessage = "用户状态不能为空")]
    public int Status { get; set; }
  }

  /// <summary>
  /// 修改密码 DTO
  /// </summary>
  public class KpUserChangePasswordDto
  {
    public KpUserChangePasswordDto()
    {
      OldPassword = string.Empty;
      NewPassword = string.Empty;
      ConfirmPassword = string.Empty;
    }

    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 旧密码
    /// </summary>
    [Required(ErrorMessage = "旧密码不能为空")]
    public string? OldPassword { get; set; }

    /// <summary>
    /// 新密码
    /// </summary>
    [Required(ErrorMessage = "新密码不能为空")]
    public string? NewPassword { get; set; }

    /// <summary>
    /// 确认密码
    /// </summary>
    [Required(ErrorMessage = "确认密码不能为空")]
    public string? ConfirmPassword { get; set; }
  }

  /// <summary>
  /// 重置密码 DTO
  /// </summary>
  public class KpUserResetPasswordDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 用户删除数据传输对象
  /// </summary>
  public class KpUserDeleteDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long Id { get; set; }
  }
}
