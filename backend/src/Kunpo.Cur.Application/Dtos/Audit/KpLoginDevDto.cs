// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录设备数据传输对象</summary>
// -----------------------------------------------------------------------


using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Newtonsoft.Json;
using SqlSugar;

namespace Kunpo.Cur.Application.Dtos.Audit
{
  /// <summary>
  /// 登录设备DTO
  /// </summary>
  public class KpLoginDevDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [Required(ErrorMessage = "设备ID不能为空")]
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(100, ErrorMessage = "设备名称长度不能超过100个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    /// <remarks>
    /// 0：未知，1：PC，2：手机，3：平板，4：其他，默认为0
    /// </remarks>
    [Required(ErrorMessage = "设备类型不能为空")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备制造商
    /// </summary>
    [StringLength(100, ErrorMessage = "设备制造商长度不能超过100个字符")]
    public string? DeviceManufacturer { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [StringLength(100, ErrorMessage = "设备型号长度不能超过100个字符")]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    /// <remarks>
    /// 0：离线，1：在线，默认为0
    /// </remarks>
    [Required(ErrorMessage = "设备状态不能为空")]
    public int DeviceStatus { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }

    #region 首次登录信息
    /// <summary>
    /// 首次登录时间
    /// </summary>
    public DateTime? FirstLoginTime { get; set; }

    /// <summary>
    /// 首次登录环境ID
    /// </summary>
    public long? FirstLoginEnvId { get; set; }
    #endregion

    #region 末次登录信息
    /// <summary>
    /// 末次登录时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// 末次登录环境ID
    /// </summary>
    public long? LastLoginEnvId { get; set; }
    #endregion

    #region 导航属性
    /// <summary>
    /// 首次登录环境信息
    /// </summary>
    public KpLoginEnvDto? FirstLoginEnv { get; set; }

    /// <summary>
    /// 末次登录环境信息
    /// </summary>
    public KpLoginEnvDto? LastLoginEnv { get; set; }
    #endregion
  }

  /// <summary>
  /// 登录设备查询DTO
  /// </summary>
  public class KpLoginDeviceQueryDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(100, ErrorMessage = "设备名称长度不能超过100个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public int? DeviceType { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    public int? DeviceStatus { get; set; }

    /// <summary>
    /// 关键字
    /// </summary>
    [StringLength(50, ErrorMessage = "关键字长度不能超过50个字符")]
    public string? Keyword { get; set; }

    /// <summary>
    /// 关键字字段
    /// </summary>
    public string[]? KeywordFields { get; set; } = new[] { nameof(KpLoginDevDto.DeviceId), nameof(KpLoginDevDto.DeviceName), nameof(KpLoginDevDto.DeviceManufacturer), nameof(KpLoginDevDto.DeviceModel) };
  }

  /// <summary>
  /// 登录设备创建DTO
  /// </summary>
  public class KpLoginDeviceCreateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [Required(ErrorMessage = "设备ID不能为空")]
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(100, ErrorMessage = "设备名称长度不能超过100个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    [Required(ErrorMessage = "设备类型不能为空")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备制造商
    /// </summary>
    [StringLength(100, ErrorMessage = "设备制造商长度不能超过100个字符")]
    public string? DeviceManufacturer { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [StringLength(100, ErrorMessage = "设备型号长度不能超过100个字符")]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    [Required(ErrorMessage = "设备状态不能为空")]
    public int DeviceStatus { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }
  }

  /// <summary>
  /// 登录设备更新DTO
  /// </summary>
  public class KpLoginDeviceUpdateDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [Required(ErrorMessage = "设备ID不能为空")]
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    [StringLength(100, ErrorMessage = "设备名称长度不能超过100个字符")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    [Required(ErrorMessage = "设备类型不能为空")]
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备制造商
    /// </summary>
    [StringLength(100, ErrorMessage = "设备制造商长度不能超过100个字符")]
    public string? DeviceManufacturer { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    [StringLength(100, ErrorMessage = "设备型号长度不能超过100个字符")]
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    [Required(ErrorMessage = "设备状态不能为空")]
    public int DeviceStatus { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }
  }

  /// <summary>
  /// 登录设备导出DTO
  /// </summary>
  public class KpLoginDeviceExportDto
  {
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// 设备名称
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public int DeviceType { get; set; }

    /// <summary>
    /// 设备制造商
    /// </summary>
    public string? DeviceManufacturer { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? DeviceModel { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    public int DeviceStatus { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    public string? CustomData { get; set; }
  }
}