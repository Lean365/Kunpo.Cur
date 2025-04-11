// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>登录日志数据传输对象</summary>
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
  /// 登录日志数据传输对象
  /// </summary>
  public class KpLoginLogDto
  {
    /// <summary>
    /// 登录日志ID
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
    /// 用户名称
    /// </summary>
    [Required(ErrorMessage = "用户名称不能为空")]
    [StringLength(50, ErrorMessage = "用户名称长度不能超过50个字符")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 登录时间
    /// </summary>
    [Required(ErrorMessage = "登录时间不能为空")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
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
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 环境ID
    /// </summary>
    public long? EnvId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    #region 导航属性
    /// <summary>
    /// 登录设备信息
    /// </summary>
    public KpLoginDevDto? Device { get; set; }

    /// <summary>
    /// 登录环境信息
    /// </summary>
    public KpLoginEnvDto? Environment { get; set; }
    #endregion
  }

  /// <summary>
  /// 登录日志查询数据传输对象
  /// </summary>
  public class KpLoginLogQueryDto : KpPageRequest
  {
    public KpLoginLogQueryDto()
    {
      TenantId = null;
      UserId = null;
      UserName = null;
      LoginType = null;
      LoginStatus = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "LoginIp", "LoginLocation", "LoginMessage" };
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
    /// 用户名称
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    public int? LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    public int? LoginStatus { get; set; }

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
  /// 登录日志创建数据传输对象
  /// </summary>
  public class KpLoginLogCreateDto
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
    /// 用户名称
    /// </summary>
    [Required(ErrorMessage = "用户名称不能为空")]
    [StringLength(50, ErrorMessage = "用户名称长度不能超过50个字符")]
    public string UserName { get; set; } = string.Empty;

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
    [Range(0, 5, ErrorMessage = "登录类型必须在0-5之间")]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    [Required(ErrorMessage = "登录状态不能为空")]
    [Range(0, 1, ErrorMessage = "登录状态必须在0-1之间")]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [StringLength(500, ErrorMessage = "登录消息长度不能超过500个字符")]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 环境ID
    /// </summary>
    public long? EnvId { get; set; }
  }

  /// <summary>
  /// 登录日志更新数据传输对象
  /// </summary>
  public class KpLoginLogUpdateDto
  {
    /// <summary>
    /// 登录日志ID
    /// </summary>
    [Required(ErrorMessage = "登录日志ID不能为空")]
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
    /// 用户名称
    /// </summary>
    [Required(ErrorMessage = "用户名称不能为空")]
    [StringLength(50, ErrorMessage = "用户名称长度不能超过50个字符")]
    public string UserName { get; set; } = string.Empty;

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
    [Range(0, 5, ErrorMessage = "登录类型必须在0-5之间")]
    public int LoginType { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    [Required(ErrorMessage = "登录状态不能为空")]
    [Range(0, 1, ErrorMessage = "登录状态必须在0-1之间")]
    public int LoginStatus { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [StringLength(500, ErrorMessage = "登录消息长度不能超过500个字符")]
    public string? LoginMessage { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [StringLength(100, ErrorMessage = "设备ID长度不能超过100个字符")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// 环境ID
    /// </summary>
    public long? EnvId { get; set; }
  }

  /// <summary>
  /// 登录日志删除数据传输对象
  /// </summary>
  public class KpLoginLogDeleteDto
  {
    /// <summary>
    /// 登录日志ID
    /// </summary>
    [Required(ErrorMessage = "登录日志ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 登录日志导出数据传输对象
  /// </summary>
  public class KpLoginLogExportDto
  {
    /// <summary>
    /// 登录日志ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    [KpExcelColumnName("用户名称")]
    public string? UserName { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    [KpExcelColumnName("登录时间")]
    public DateTime LoginTime { get; set; }

    /// <summary>
    /// 登录IP
    /// </summary>
    [KpExcelColumnName("登录IP")]
    public string? LoginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    [KpExcelColumnName("登录地点")]
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 登录类型
    /// </summary>
    [KpExcelColumnName("登录类型")]
    public string? LoginTypeLabel { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    [KpExcelColumnName("登录状态")]
    public string? LoginStatusLabel { get; set; }

    /// <summary>
    /// 登录消息
    /// </summary>
    [KpExcelColumnName("登录消息")]
    public string? LoginMessage { get; set; }

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
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}