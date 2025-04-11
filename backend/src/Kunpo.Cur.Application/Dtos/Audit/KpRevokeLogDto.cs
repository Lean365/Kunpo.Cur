// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>撤销日志数据传输对象</summary>
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
  /// 撤销日志数据传输对象
  /// </summary>
  public class KpRevokeLogDto
  {
    /// <summary>
    /// 撤销日志ID
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
    /// 业务类型
    /// </summary>
    /// <remarks>
    /// 0：预算审核，1：预算撤销，2：费用审核，3：费用撤销，4：合同审核，5：合同撤销，6：采购审核，7：采购撤销
    /// </remarks>
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    /// <remarks>
    /// 0,1：预算表(kp_budget)，2,3：费用表(kp_expense)，4,5：合同表(kp_contract)，6,7：采购表(kp_purchase)
    /// </remarks>
    public long BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    public string? RevokeReason { get; set; }

    /// <summary>
    /// 撤销时间
    /// </summary>
    public DateTime RevokeTime { get; set; }

    /// <summary>
    /// 撤销IP
    /// </summary>
    public string? RevokeIp { get; set; }

    /// <summary>
    /// 撤销地点
    /// </summary>
    public string? RevokeLocation { get; set; }

    /// <summary>
    /// 撤销状态
    /// </summary>
    /// <remarks>
    /// 0：失败，1：成功，默认为1
    /// </remarks>
    public int RevokeStatus { get; set; }

    /// <summary>
    /// 撤销消息
    /// </summary>
    public string? RevokeMessage { get; set; }

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
  /// 撤销日志查询数据传输对象
  /// </summary>
  public class KpRevokeLogQueryDto : KpPageRequest
  {
    public KpRevokeLogQueryDto()
    {
      TenantId = null;
      UserId = null;
      UserName = null;
      BusinessType = null;
      BusinessId = null;
      BusinessNo = null;
      BusinessTitle = null;
      RevokeStatus = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "BusinessNo", "BusinessTitle", "RevokeReason" };
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
    /// 业务类型
    /// </summary>
    public int? BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    public long? BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销状态
    /// </summary>
    public int? RevokeStatus { get; set; }

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
  /// 撤销日志创建数据传输对象
  /// </summary>
  public class KpRevokeLogCreateDto
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
    /// 业务类型
    /// </summary>
    [Required(ErrorMessage = "业务类型不能为空")]
    [Range(0, 7, ErrorMessage = "业务类型必须在0-7之间")]
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    [Required(ErrorMessage = "业务ID不能为空")]
    public long BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    [StringLength(50, ErrorMessage = "业务编号长度不能超过50个字符")]
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    [StringLength(200, ErrorMessage = "业务标题长度不能超过200个字符")]
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    [Required(ErrorMessage = "撤销原因不能为空")]
    [StringLength(500, ErrorMessage = "撤销原因长度不能超过500个字符")]
    public string? RevokeReason { get; set; }

    /// <summary>
    /// 撤销IP
    /// </summary>
    [StringLength(50, ErrorMessage = "撤销IP长度不能超过50个字符")]
    public string? RevokeIp { get; set; }

    /// <summary>
    /// 撤销地点
    /// </summary>
    [StringLength(100, ErrorMessage = "撤销地点长度不能超过100个字符")]
    public string? RevokeLocation { get; set; }

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
  /// 撤销日志更新数据传输对象
  /// </summary>
  public class KpRevokeLogUpdateDto
  {
    /// <summary>
    /// 撤销日志ID
    /// </summary>
    [Required(ErrorMessage = "撤销日志ID不能为空")]
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
    /// 业务类型
    /// </summary>
    [Required(ErrorMessage = "业务类型不能为空")]
    [Range(0, 7, ErrorMessage = "业务类型必须在0-7之间")]
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
    [Required(ErrorMessage = "业务ID不能为空")]
    public long BusinessId { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    [StringLength(50, ErrorMessage = "业务编号长度不能超过50个字符")]
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    [StringLength(200, ErrorMessage = "业务标题长度不能超过200个字符")]
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    [Required(ErrorMessage = "撤销原因不能为空")]
    [StringLength(500, ErrorMessage = "撤销原因长度不能超过500个字符")]
    public string? RevokeReason { get; set; }

    /// <summary>
    /// 撤销IP
    /// </summary>
    [StringLength(50, ErrorMessage = "撤销IP长度不能超过50个字符")]
    public string? RevokeIp { get; set; }

    /// <summary>
    /// 撤销地点
    /// </summary>
    [StringLength(100, ErrorMessage = "撤销地点长度不能超过100个字符")]
    public string? RevokeLocation { get; set; }

    /// <summary>
    /// 撤销状态
    /// </summary>
    [Required(ErrorMessage = "撤销状态不能为空")]
    [Range(0, 1, ErrorMessage = "撤销状态必须在0-1之间")]
    public int RevokeStatus { get; set; }

    /// <summary>
    /// 撤销消息
    /// </summary>
    [StringLength(500, ErrorMessage = "撤销消息长度不能超过500个字符")]
    public string? RevokeMessage { get; set; }

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
  /// 撤销日志删除数据传输对象
  /// </summary>
  public class KpRevokeLogDeleteDto
  {
    /// <summary>
    /// 撤销日志ID
    /// </summary>
    [Required(ErrorMessage = "撤销日志ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 撤销日志导出数据传输对象
  /// </summary>
  public class KpRevokeLogExportDto
  {
    /// <summary>
    /// 撤销日志ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [KpExcelColumnName("用户名")]
    public string? UserName { get; set; }

    /// <summary>
    /// 业务类型
    /// </summary>
    [KpExcelColumnName("业务类型")]
    public string? BusinessTypeLabel { get; set; }

    /// <summary>
    /// 业务编号
    /// </summary>
    [KpExcelColumnName("业务编号")]
    public string? BusinessNo { get; set; }

    /// <summary>
    /// 业务标题
    /// </summary>
    [KpExcelColumnName("业务标题")]
    public string? BusinessTitle { get; set; }

    /// <summary>
    /// 撤销原因
    /// </summary>
    [KpExcelColumnName("撤销原因")]
    public string? RevokeReason { get; set; }

    /// <summary>
    /// 撤销时间
    /// </summary>
    [KpExcelColumnName("撤销时间")]
    public DateTime RevokeTime { get; set; }

    /// <summary>
    /// 撤销IP
    /// </summary>
    [KpExcelColumnName("撤销IP")]
    public string? RevokeIp { get; set; }

    /// <summary>
    /// 撤销地点
    /// </summary>
    [KpExcelColumnName("撤销地点")]
    public string? RevokeLocation { get; set; }

    /// <summary>
    /// 撤销状态
    /// </summary>
    [KpExcelColumnName("撤销状态")]
    public string? RevokeStatusLabel { get; set; }

    /// <summary>
    /// 撤销消息
    /// </summary>
    [KpExcelColumnName("撤销消息")]
    public string? RevokeMessage { get; set; }

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