// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>操作日志数据传输对象</summary>
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
  /// 操作日志数据传输对象
  /// </summary>
  public class KpOperLogDto
  {
    /// <summary>
    /// 操作日志ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    /// <remarks>
    /// 0：新增，1：修改，2：删除，3：查询，4：导入，5：导出，6：其他，默认为6
    /// </remarks>
    public int OperType { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    public string? OperDescription { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    public string? RequestParams { get; set; }

    /// <summary>
    /// 响应结果
    /// </summary>
    public string? ResponseResult { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    public string? OperLocation { get; set; }

    /// <summary>
    /// 操作状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为1
    /// </remarks>
    public int OperStatus { get; set; }

    /// <summary>
    /// 操作消息
    /// </summary>
    public string? OperMessage { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    public string? ErrorStack { get; set; }

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
    /// 操作时间
    /// </summary>
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 执行时长(毫秒)
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
  }

  /// <summary>
  /// 操作日志查询数据传输对象
  /// </summary>
  public class KpOperLogQueryDto : KpPageRequest
  {
    public KpOperLogQueryDto()
    {
      TenantId = null;
      UserId = null;
      UserName = null;
      OperType = null;
      OperModule = null;
      OperFunction = null;
      OperStatus = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "OperModule", "OperFunction", "OperDescription", "Method", "Url" };
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
    /// 操作类型
    /// </summary>
    public int? OperType { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作状态
    /// </summary>
    public int? OperStatus { get; set; }

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
  /// 操作日志创建数据传输对象
  /// </summary>
  public class KpOperLogCreateDto
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
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    [StringLength(50, ErrorMessage = "用户名长度不能超过50个字符")]
    public string? UserName { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [StringLength(50, ErrorMessage = "操作模块长度不能超过50个字符")]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    [Required(ErrorMessage = "操作类型不能为空")]
    [Range(0, 6, ErrorMessage = "操作类型必须在0-6之间")]
    public int OperType { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [StringLength(50, ErrorMessage = "操作功能长度不能超过50个字符")]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [StringLength(500, ErrorMessage = "操作描述长度不能超过500个字符")]
    public string? OperDescription { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [StringLength(100, ErrorMessage = "请求方法长度不能超过100个字符")]
    public string? Method { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [StringLength(500, ErrorMessage = "请求URL长度不能超过500个字符")]
    public string? Url { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求参数长度不能超过4000个字符")]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 响应结果
    /// </summary>
    [StringLength(4000, ErrorMessage = "响应结果长度不能超过4000个字符")]
    public string? ResponseResult { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    [StringLength(50, ErrorMessage = "操作IP长度不能超过50个字符")]
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    [StringLength(100, ErrorMessage = "操作地点长度不能超过100个字符")]
    public string? OperLocation { get; set; }

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
  /// 操作日志更新数据传输对象
  /// </summary>
  public class KpOperLogUpdateDto
  {
    /// <summary>
    /// 操作日志ID
    /// </summary>
    [Required(ErrorMessage = "操作日志ID不能为空")]
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
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    [StringLength(50, ErrorMessage = "用户名长度不能超过50个字符")]
    public string? UserName { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [StringLength(50, ErrorMessage = "操作模块长度不能超过50个字符")]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    [Required(ErrorMessage = "操作类型不能为空")]
    [Range(0, 6, ErrorMessage = "操作类型必须在0-6之间")]
    public int OperType { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [StringLength(50, ErrorMessage = "操作功能长度不能超过50个字符")]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [StringLength(500, ErrorMessage = "操作描述长度不能超过500个字符")]
    public string? OperDescription { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [StringLength(100, ErrorMessage = "请求方法长度不能超过100个字符")]
    public string? Method { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [StringLength(500, ErrorMessage = "请求URL长度不能超过500个字符")]
    public string? Url { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "请求参数长度不能超过4000个字符")]
    public string? RequestParams { get; set; }

    /// <summary>
    /// 响应结果
    /// </summary>
    [StringLength(4000, ErrorMessage = "响应结果长度不能超过4000个字符")]
    public string? ResponseResult { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    [StringLength(50, ErrorMessage = "操作IP长度不能超过50个字符")]
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    [StringLength(100, ErrorMessage = "操作地点长度不能超过100个字符")]
    public string? OperLocation { get; set; }

    /// <summary>
    /// 操作状态
    /// </summary>
    [Required(ErrorMessage = "操作状态不能为空")]
    [Range(0, 1, ErrorMessage = "操作状态必须在0-1之间")]
    public int OperStatus { get; set; }

    /// <summary>
    /// 操作消息
    /// </summary>
    [StringLength(500, ErrorMessage = "操作消息长度不能超过500个字符")]
    public string? OperMessage { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    [StringLength(2000, ErrorMessage = "错误信息长度不能超过2000个字符")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [StringLength(4000, ErrorMessage = "错误堆栈长度不能超过4000个字符")]
    public string? ErrorStack { get; set; }

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

    /// <summary>
    /// 执行时长(毫秒)
    /// </summary>
    [Required(ErrorMessage = "执行时长不能为空")]
    [Range(0, int.MaxValue, ErrorMessage = "执行时长必须大于等于0")]
    public int Duration { get; set; }
  }

  /// <summary>
  /// 操作日志删除数据传输对象
  /// </summary>
  public class KpOperLogDeleteDto
  {
    /// <summary>
    /// 操作日志ID
    /// </summary>
    [Required(ErrorMessage = "操作日志ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 操作日志导出数据传输对象
  /// </summary>
  public class KpOperLogExportDto
  {
    /// <summary>
    /// 操作日志ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    [KpExcelColumnName("操作类型")]
    public string? OperTypeLabel { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [KpExcelColumnName("操作模块")]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [KpExcelColumnName("操作功能")]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [KpExcelColumnName("操作描述")]
    public string? OperDescription { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [KpExcelColumnName("请求方法")]
    public string? Method { get; set; }

    /// <summary>
    /// 请求URL
    /// </summary>
    [KpExcelColumnName("请求URL")]
    public string? Url { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    [KpExcelColumnName("操作IP")]
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    [KpExcelColumnName("操作地点")]
    public string? OperLocation { get; set; }

    /// <summary>
    /// 操作状态
    /// </summary>
    [KpExcelColumnName("操作状态")]
    public string? OperStatusLabel { get; set; }

    /// <summary>
    /// 操作消息
    /// </summary>
    [KpExcelColumnName("操作消息")]
    public string? OperMessage { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    [KpExcelColumnName("错误信息")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 操作时间
    /// </summary>
    [KpExcelColumnName("操作时间")]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 执行时长(毫秒)
    /// </summary>
    [KpExcelColumnName("执行时长(毫秒)")]
    public int Duration { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}