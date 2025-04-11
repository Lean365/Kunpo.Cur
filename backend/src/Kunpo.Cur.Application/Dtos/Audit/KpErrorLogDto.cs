// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>错误日志数据传输对象</summary>
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
  /// 错误日志数据传输对象
  /// </summary>
  public class KpErrorLogDto
  {
    /// <summary>
    /// 错误日志ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    /// <remarks>
    /// 0：系统错误，1：业务错误，2：权限错误，3：数据错误，4：其他错误，默认为0
    /// </remarks>
    public int ErrorType { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    public string? ErrorDetail { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    public string? ErrorStack { get; set; }

    /// <summary>
    /// 错误时间
    /// </summary>
    public DateTime ErrorTime { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 错误地点
    /// </summary>
    public string? ErrorLocation { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    public string? RequestMethod { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    public string? RequestParams { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    public string? RequestHeaders { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    public string? OsInfo { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    public string? DeviceInfo { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
  }

  /// <summary>
  /// 错误日志查询数据传输对象
  /// </summary>
  public class KpErrorLogQueryDto : KpPageRequest
  {
    public KpErrorLogQueryDto()
    {
      TenantId = null;
      UserId = null;
      UserName = null;
      ErrorType = null;
      ErrorCode = null;
      ErrorIp = null;
      RequestUrl = null;
      RequestMethod = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "ErrorCode", "ErrorMessage", "ErrorIp", "RequestUrl" };
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
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    public int? ErrorType { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    public string? RequestMethod { get; set; }

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
  /// 错误日志创建数据传输对象
  /// </summary>
  public class KpErrorLogCreateDto
  {
    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [StringLength(50, ErrorMessage = "用户名长度不能超过50个字符")]
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    [Required(ErrorMessage = "错误类型不能为空")]
    [Range(0, 4, ErrorMessage = "错误类型必须在0-4之间")]
    public int ErrorType { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    [StringLength(50, ErrorMessage = "错误代码长度不能超过50个字符")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    [StringLength(500, ErrorMessage = "错误消息长度不能超过500个字符")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [StringLength(4000, ErrorMessage = "错误详情长度不能超过4000个字符")]
    public string? ErrorDetail { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [StringLength(4000, ErrorMessage = "错误堆栈长度不能超过4000个字符")]
    public string? ErrorStack { get; set; }

    /// <summary>
    /// 错误时间
    /// </summary>
    [Required(ErrorMessage = "错误时间不能为空")]
    public DateTime ErrorTime { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    [StringLength(50, ErrorMessage = "错误IP长度不能超过50个字符")]
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 错误地点
    /// </summary>
    [StringLength(100, ErrorMessage = "错误地点长度不能超过100个字符")]
    public string? ErrorLocation { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [StringLength(500, ErrorMessage = "请求URL长度不能超过500个字符")]
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [StringLength(10, ErrorMessage = "请求方法长度不能超过10个字符")]
    public string? RequestMethod { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求参数长度不能超过4000个字符")]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求头长度不能超过4000个字符")]
    public string? RequestHeaders { get; set; }

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
    /// 设备信息
    /// </summary>
    [StringLength(500, ErrorMessage = "设备信息长度不能超过500个字符")]
    public string? DeviceInfo { get; set; }
  }

  /// <summary>
  /// 错误日志更新数据传输对象
  /// </summary>
  public class KpErrorLogUpdateDto
  {
    /// <summary>
    /// 错误日志ID
    /// </summary>
    [Required(ErrorMessage = "错误日志ID不能为空")]
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    [Required(ErrorMessage = "租户ID不能为空")]
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [StringLength(50, ErrorMessage = "用户名长度不能超过50个字符")]
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    [Required(ErrorMessage = "错误类型不能为空")]
    [Range(0, 4, ErrorMessage = "错误类型必须在0-4之间")]
    public int ErrorType { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    [StringLength(50, ErrorMessage = "错误代码长度不能超过50个字符")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    [StringLength(500, ErrorMessage = "错误消息长度不能超过500个字符")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [StringLength(4000, ErrorMessage = "错误详情长度不能超过4000个字符")]
    public string? ErrorDetail { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [StringLength(4000, ErrorMessage = "错误堆栈长度不能超过4000个字符")]
    public string? ErrorStack { get; set; }

    /// <summary>
    /// 错误时间
    /// </summary>
    [Required(ErrorMessage = "错误时间不能为空")]
    public DateTime ErrorTime { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    [StringLength(50, ErrorMessage = "错误IP长度不能超过50个字符")]
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 错误地点
    /// </summary>
    [StringLength(100, ErrorMessage = "错误地点长度不能超过100个字符")]
    public string? ErrorLocation { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [StringLength(500, ErrorMessage = "请求URL长度不能超过500个字符")]
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [StringLength(10, ErrorMessage = "请求方法长度不能超过10个字符")]
    public string? RequestMethod { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求参数长度不能超过4000个字符")]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求头长度不能超过4000个字符")]
    public string? RequestHeaders { get; set; }

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
    /// 设备信息
    /// </summary>
    [StringLength(500, ErrorMessage = "设备信息长度不能超过500个字符")]
    public string? DeviceInfo { get; set; }
  }

  /// <summary>
  /// 错误日志删除数据传输对象
  /// </summary>
  public class KpErrorLogDeleteDto
  {
    /// <summary>
    /// 错误日志ID
    /// </summary>
    [Required(ErrorMessage = "错误日志ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 错误日志导出数据传输对象
  /// </summary>
  public class KpErrorLogExportDto
  {
    /// <summary>
    /// 错误日志ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [KpExcelColumnName("用户ID")]
    public long? UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 错误类型
    /// </summary>
    [KpExcelColumnName("错误类型")]
    public string? ErrorTypeLabel { get; set; }

    /// <summary>
    /// 错误代码
    /// </summary>
    [KpExcelColumnName("错误代码")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    [KpExcelColumnName("错误消息")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [KpExcelColumnName("错误详情")]
    public string? ErrorDetail { get; set; }

    /// <summary>
    /// 错误时间
    /// </summary>
    [KpExcelColumnName("错误时间")]
    public DateTime ErrorTime { get; set; }

    /// <summary>
    /// 错误IP
    /// </summary>
    [KpExcelColumnName("错误IP")]
    public string? ErrorIp { get; set; }

    /// <summary>
    /// 错误地点
    /// </summary>
    [KpExcelColumnName("错误地点")]
    public string? ErrorLocation { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [KpExcelColumnName("请求URL")]
    public string? RequestUrl { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [KpExcelColumnName("请求方法")]
    public string? RequestMethod { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}