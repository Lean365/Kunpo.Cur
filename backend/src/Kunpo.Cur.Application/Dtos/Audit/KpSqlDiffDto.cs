// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>SQL差异数据传输对象</summary>
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
  /// SQL差异数据传输对象
  /// </summary>
  public class KpSqlDiffDto
  {
    /// <summary>
    /// SQL差异ID
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
    /// 操作类型
    /// </summary>
    /// <remarks>
    /// 0：新增，1：修改，2：删除，默认为0
    /// </remarks>
    public int OperType { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    public string? OperDescription { get; set; }

    /// <summary>
    /// 操作时间
    /// </summary>
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    public string? OperLocation { get; set; }

    /// <summary>
    /// 表名
    /// </summary>
    public string? TableName { get; set; }

    /// <summary>
    /// 主键
    /// </summary>
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// 字段名
    /// </summary>
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    public string? FieldDescription { get; set; }

    /// <summary>
    /// 原始值
    /// </summary>
    public string? OriginalValue { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    public string? NewValue { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    public string? FieldType { get; set; }

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
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
  }

  /// <summary>
  /// SQL差异查询数据传输对象
  /// </summary>
  public class KpSqlDiffQueryDto : KpPageRequest
  {
    public KpSqlDiffQueryDto()
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
      KeywordFields = new[] { "UserName", "OperModule", "OperFunction", "OperDescription", "TableName", "FieldName", "FieldDescription" };
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
  /// SQL差异创建数据传输对象
  /// </summary>
  public class KpSqlDiffCreateDto
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
    /// 操作类型
    /// </summary>
    [Required(ErrorMessage = "操作类型不能为空")]
    [Range(0, 2, ErrorMessage = "操作类型必须在0-2之间")]
    public int OperType { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [StringLength(50, ErrorMessage = "操作模块长度不能超过50个字符")]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [StringLength(50, ErrorMessage = "操作功能长度不能超过50个字符")]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [StringLength(200, ErrorMessage = "操作描述长度不能超过200个字符")]
    public string? OperDescription { get; set; }

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
    /// 表名
    /// </summary>
    [Required(ErrorMessage = "表名不能为空")]
    [StringLength(50, ErrorMessage = "表名长度不能超过50个字符")]
    public string? TableName { get; set; }

    /// <summary>
    /// 主键
    /// </summary>
    [Required(ErrorMessage = "主键不能为空")]
    [StringLength(50, ErrorMessage = "主键长度不能超过50个字符")]
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// 字段名
    /// </summary>
    [Required(ErrorMessage = "字段名不能为空")]
    [StringLength(50, ErrorMessage = "字段名长度不能超过50个字符")]
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    [StringLength(100, ErrorMessage = "字段描述长度不能超过100个字符")]
    public string? FieldDescription { get; set; }

    /// <summary>
    /// 原始值
    /// </summary>
    [StringLength(500, ErrorMessage = "原始值长度不能超过500个字符")]
    public string? OriginalValue { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    [StringLength(500, ErrorMessage = "新值长度不能超过500个字符")]
    public string? NewValue { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    [StringLength(50, ErrorMessage = "字段类型长度不能超过50个字符")]
    public string? FieldType { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [StringLength(100, ErrorMessage = "操作系统信息长度不能超过100个字符")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    [StringLength(100, ErrorMessage = "设备信息长度不能超过100个字符")]
    public string? DeviceInfo { get; set; }
  }

  /// <summary>
  /// SQL差异更新数据传输对象
  /// </summary>
  public class KpSqlDiffUpdateDto
  {
    /// <summary>
    /// SQL差异ID
    /// </summary>
    [Required(ErrorMessage = "SQL差异ID不能为空")]
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
    /// 操作类型
    /// </summary>
    [Required(ErrorMessage = "操作类型不能为空")]
    [Range(0, 2, ErrorMessage = "操作类型必须在0-2之间")]
    public int OperType { get; set; }

    /// <summary>
    /// 操作模块
    /// </summary>
    [StringLength(50, ErrorMessage = "操作模块长度不能超过50个字符")]
    public string? OperModule { get; set; }

    /// <summary>
    /// 操作功能
    /// </summary>
    [StringLength(50, ErrorMessage = "操作功能长度不能超过50个字符")]
    public string? OperFunction { get; set; }

    /// <summary>
    /// 操作描述
    /// </summary>
    [StringLength(200, ErrorMessage = "操作描述长度不能超过200个字符")]
    public string? OperDescription { get; set; }

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
    /// 表名
    /// </summary>
    [Required(ErrorMessage = "表名不能为空")]
    [StringLength(50, ErrorMessage = "表名长度不能超过50个字符")]
    public string? TableName { get; set; }

    /// <summary>
    /// 主键
    /// </summary>
    [Required(ErrorMessage = "主键不能为空")]
    [StringLength(50, ErrorMessage = "主键长度不能超过50个字符")]
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// 字段名
    /// </summary>
    [Required(ErrorMessage = "字段名不能为空")]
    [StringLength(50, ErrorMessage = "字段名长度不能超过50个字符")]
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    [StringLength(100, ErrorMessage = "字段描述长度不能超过100个字符")]
    public string? FieldDescription { get; set; }

    /// <summary>
    /// 原始值
    /// </summary>
    [StringLength(500, ErrorMessage = "原始值长度不能超过500个字符")]
    public string? OriginalValue { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    [StringLength(500, ErrorMessage = "新值长度不能超过500个字符")]
    public string? NewValue { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    [StringLength(50, ErrorMessage = "字段类型长度不能超过50个字符")]
    public string? FieldType { get; set; }

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
    [StringLength(500, ErrorMessage = "错误信息长度不能超过500个字符")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 错误堆栈
    /// </summary>
    [StringLength(2000, ErrorMessage = "错误堆栈长度不能超过2000个字符")]
    public string? ErrorStack { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 操作系统信息
    /// </summary>
    [StringLength(100, ErrorMessage = "操作系统信息长度不能超过100个字符")]
    public string? OsInfo { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    [StringLength(100, ErrorMessage = "设备信息长度不能超过100个字符")]
    public string? DeviceInfo { get; set; }
  }

  /// <summary>
  /// SQL差异删除数据传输对象
  /// </summary>
  public class KpSqlDiffDeleteDto
  {
    /// <summary>
    /// SQL差异ID
    /// </summary>
    [Required(ErrorMessage = "SQL差异ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// SQL差异导出数据传输对象
  /// </summary>
  public class KpSqlDiffExportDto
  {
    /// <summary>
    /// SQL差异ID
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
    /// 操作时间
    /// </summary>
    [KpExcelColumnName("操作时间")]
    public DateTime OperTime { get; set; }

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
    /// 表名
    /// </summary>
    [KpExcelColumnName("表名")]
    public string? TableName { get; set; }

    /// <summary>
    /// 主键
    /// </summary>
    [KpExcelColumnName("主键")]
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// 字段名
    /// </summary>
    [KpExcelColumnName("字段名")]
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段描述
    /// </summary>
    [KpExcelColumnName("字段描述")]
    public string? FieldDescription { get; set; }

    /// <summary>
    /// 原始值
    /// </summary>
    [KpExcelColumnName("原始值")]
    public string? OriginalValue { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    [KpExcelColumnName("新值")]
    public string? NewValue { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    [KpExcelColumnName("字段类型")]
    public string? FieldType { get; set; }

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
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}