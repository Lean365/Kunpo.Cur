// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录环境数据传输对象</summary>
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
  /// 登录环境数据传输对象
  /// </summary>
  public class KpLoginEnvDto
  {
    /// <summary>
    /// 登录环境ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [Required(ErrorMessage = "登录时间不能为空")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    [StringLength(50, ErrorMessage = "登录IP长度不能超过50个字符")]
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    [StringLength(200, ErrorMessage = "登录地点长度不能超过200个字符")]
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    /// <remarks>
    /// 0：未知，1：账号密码，2：手机验证码，3：邮箱验证码，4：第三方登录，5：其他，默认为0
    /// </remarks>
    [Required(ErrorMessage = "登录类型不能为空")]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为0
    /// </remarks>
    [Required(ErrorMessage = "登录状态不能为空")]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [StringLength(500, ErrorMessage = "登录消息长度不能超过500个字符")]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [StringLength(500, ErrorMessage = "操作系统信息长度不能超过500个字符")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 网络信息
    /// </summary>
    [StringLength(500, ErrorMessage = "网络信息长度不能超过500个字符")]
    public string? NetworkInfo { get; set; }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    [StringLength(500, ErrorMessage = "地理位置信息长度不能超过500个字符")]
    public string? LocationInfo { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    #region 导航属性
    /// <summary>
    /// 登录设备信息
    /// </summary>
    public KpLoginDevDto? Device { get; set; }
    #endregion
  }

  /// <summary>
  /// 登录环境查询数据传输对象
  /// </summary>
  public class KpLoginEnvQueryDto : KpPageRequest
  {
    public KpLoginEnvQueryDto()
    {
      TenantId = null;
      UserId = null;
      DeviceType = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "BrowserInfo", "OsInfo", "NetworkInfo", "LocationInfo" };
    }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long? TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public int? DeviceType { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }
  }

  /// <summary>
  /// 登录环境创建数据传输对象
  /// </summary>
  public class KpLoginEnvCreateDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [Required(ErrorMessage = "登录时间不能为空")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    [StringLength(50, ErrorMessage = "登录IP长度不能超过50个字符")]
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    [StringLength(200, ErrorMessage = "登录地点长度不能超过200个字符")]
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    [Required(ErrorMessage = "登录类型不能为空")]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    [Required(ErrorMessage = "登录状态不能为空")]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [StringLength(500, ErrorMessage = "登录消息长度不能超过500个字符")]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [StringLength(500, ErrorMessage = "操作系统信息长度不能超过500个字符")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 网络信息
    /// </summary>
    [StringLength(500, ErrorMessage = "网络信息长度不能超过500个字符")]
    public string? NetworkInfo { get; set; }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    [StringLength(500, ErrorMessage = "地理位置信息长度不能超过500个字符")]
    public string? LocationInfo { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    public KpLoginDeviceCreateDto? Device { get; set; }
  }

  /// <summary>
  /// 登录环境更新数据传输对象
  /// </summary>
  public class KpLoginEnvUpdateDto
  {
    /// <summary>
    /// 登录环境ID
    /// </summary>
    [Required(ErrorMessage = "登录环境ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [Required(ErrorMessage = "用户ID不能为空")]
    public long UserId { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [Required(ErrorMessage = "登录时间不能为空")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    [StringLength(50, ErrorMessage = "登录IP长度不能超过50个字符")]
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    [StringLength(200, ErrorMessage = "登录地点长度不能超过200个字符")]
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    [Required(ErrorMessage = "登录类型不能为空")]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    [Required(ErrorMessage = "登录状态不能为空")]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [StringLength(500, ErrorMessage = "登录消息长度不能超过500个字符")]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [StringLength(500, ErrorMessage = "操作系统信息长度不能超过500个字符")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 网络信息
    /// </summary>
    [StringLength(500, ErrorMessage = "网络信息长度不能超过500个字符")]
    public string? NetworkInfo { get; set; }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    [StringLength(500, ErrorMessage = "地理位置信息长度不能超过500个字符")]
    public string? LocationInfo { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    public KpLoginDeviceUpdateDto? Device { get; set; }
  }

  /// <summary>
  /// 登录环境删除数据传输对象
  /// </summary>
  public class KpLoginEnvDeleteDto
  {
    /// <summary>
    /// 登录环境ID
    /// </summary>
    [Required(ErrorMessage = "登录环境ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 登录环境导出数据传输对象
  /// </summary>
  public class KpLoginEnvExportDto
  {
    /// <summary>
    /// 登录环境ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    [KpExcelColumnName("设备名称")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    [KpExcelColumnName("设备类型")]
    public string? DeviceTypeLabel { get; set; }

    /// <summary>
    /// 设备操作系统
    /// </summary>
    [KpExcelColumnName("设备操作系统")]
    public string? DeviceOs { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [KpExcelColumnName("浏览器信息")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [KpExcelColumnName("操作系统信息")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 网络信息
    /// </summary>
    [KpExcelColumnName("网络信息")]
    public string? NetworkInfo { get; set; }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    [KpExcelColumnName("地理位置信息")]
    public string? LocationInfo { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}