// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>认证数据传输对象</summary>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Application.Dtos.Identity
{
  /// <summary>
  /// 认证请求DTO
  /// </summary>
  public class KpAuthRequestDto
  {
    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    public string? UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不能为空")]
    public string? Password { get; set; }

    /// <summary>
    /// 记住我
    /// </summary>
    public bool RememberMe { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录浏览器
    /// </summary>
    public string? LoginBrowser { get; set; }

    /// <summary>
    /// 登录操作系统
    /// </summary>
    public string? LoginOs { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备操作系统
    /// </summary>
    public string? DeviceOs { get; set; }

    /// <summary>
    /// 设备操作系统版本
    /// </summary>
    public string? DeviceOsVersion { get; set; }

    /// <summary>
    /// 环境类型
    /// </summary>
    public string? EnvType { get; set; }

    /// <summary>
    /// 环境名称
    /// </summary>
    public string? EnvName { get; set; }

    /// <summary>
    /// 环境版本
    /// </summary>
    public string? EnvVersion { get; set; }

    /// <summary>
    /// 环境描述
    /// </summary>
    public string? EnvDescription { get; set; }
  }

  /// <summary>
  /// 认证响应DTO
  /// </summary>
  public class KpAuthResponseDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string? UserNickName { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    public int UserType { get; set; }

    /// <summary>
    /// 访问令牌
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime Expires { get; set; }
  }
}