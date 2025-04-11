// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>审计日志数据传输对象</summary>
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
  /// 审计日志数据传输对象
  /// </summary>
  public class KpAuditLogDto
  {
    /// <summary>
    /// 审计日志ID
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
    /// 0：预算审核，1：预算撤销，2：报销审核，3：报销撤销，4：合同审核，5：合同撤销，6：采购审核，7：采购撤销，默认为0
    /// </remarks>
    public int BusinessType { get; set; }

    /// <summary>
    /// 业务ID
    /// </summary>
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
    /// 审核类型
    /// </summary>
    /// <remarks>
    /// 0：提交，1：同意，2：拒绝，3：退回，4：转交，默认为0
    /// </remarks>
    public int AuditType { get; set; }

    /// <summary>
    /// 审核意见
    /// </summary>
    public string? AuditComment { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    /// <remarks>
    /// 0：待审核，1：审核中，2：已通过，3：已拒绝，4：已退回，5：已转交，默认为0
    /// </remarks>
    public int AuditStatus { get; set; }

    /// <summary>
    /// 审核人ID
    /// </summary>
    public long? AuditorId { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    public string? Auditor { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核IP
    /// </summary>
    public string? AuditIp { get; set; }

    /// <summary>
    /// 审核地点
    /// </summary>
    public string? AuditLocation { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    public string? OperLocation { get; set; }

    /// <summary>
    /// 操作时间
    /// </summary>
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 附件列表
    /// </summary>
    public string? Attachments { get; set; }

    /// <summary>
    /// 服务名称
    /// </summary>
    public string? ServiceName { get; set; }

    /// <summary>
    /// 方法名称
    /// </summary>
    public string? MethodName { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    public string? Parameters { get; set; }

    /// <summary>
    /// 返回值
    /// </summary>
    public string? ReturnValue { get; set; }

    /// <summary>
    /// 执行时间
    /// </summary>
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// 执行时长
    /// </summary>
    public int ExecutionDuration { get; set; }

    /// <summary>
    /// 客户端IP
    /// </summary>
    public string? ClientIp { get; set; }

    /// <summary>
    /// 客户端名称
    /// </summary>
    public string? ClientName { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    public string? Exception { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    public string? CustomData { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
  }

  /// <summary>
  /// 审计日志查询数据传输对象
  /// </summary>
  public class KpAuditLogQueryDto : KpPageRequest
  {
    public KpAuditLogQueryDto()
    {
      TenantId = null;
      UserId = null;
      UserName = null;
      BusinessType = null;
      BusinessId = null;
      BusinessNo = null;
      BusinessTitle = null;
      AuditType = null;
      AuditStatus = null;
      AuditorId = null;
      Auditor = null;
      StartTime = null;
      EndTime = null;
      OrderBy = "CreatedTime";
      OrderType = "desc";
      Conditions = new Dictionary<string, object>();
      TimeRanges = new Dictionary<string, string[]>();
      Keyword = string.Empty;
      KeywordFields = new[] { "UserName", "BusinessNo", "BusinessTitle", "Auditor", "AuditComment" };
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
    /// 审核类型
    /// </summary>
    public int? AuditType { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    public int? AuditStatus { get; set; }

    /// <summary>
    /// 审核人ID
    /// </summary>
    public long? AuditorId { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    public string? Auditor { get; set; }

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
  /// 审计日志创建数据传输对象
  /// </summary>
  public class KpAuditLogCreateDto
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
    /// 审核类型
    /// </summary>
    [Required(ErrorMessage = "审核类型不能为空")]
    [Range(0, 4, ErrorMessage = "审核类型必须在0-4之间")]
    public int AuditType { get; set; }

    /// <summary>
    /// 审核意见
    /// </summary>
    [StringLength(500, ErrorMessage = "审核意见长度不能超过500个字符")]
    public string? AuditComment { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    [Required(ErrorMessage = "审核状态不能为空")]
    [Range(0, 5, ErrorMessage = "审核状态必须在0-5之间")]
    public int AuditStatus { get; set; }

    /// <summary>
    /// 审核人ID
    /// </summary>
    public long? AuditorId { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    [StringLength(50, ErrorMessage = "审核人长度不能超过50个字符")]
    public string? Auditor { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核IP
    /// </summary>
    [StringLength(50, ErrorMessage = "审核IP长度不能超过50个字符")]
    public string? AuditIp { get; set; }

    /// <summary>
    /// 审核地点
    /// </summary>
    [StringLength(100, ErrorMessage = "审核地点长度不能超过100个字符")]
    public string? AuditLocation { get; set; }

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
    /// 操作时间
    /// </summary>
    [Required(ErrorMessage = "操作时间不能为空")]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 附件列表
    /// </summary>
    [StringLength(4000, ErrorMessage = "附件列表长度不能超过4000个字符")]
    public string? Attachments { get; set; }

    /// <summary>
    /// 服务名称
    /// </summary>
    [Required(ErrorMessage = "服务名称不能为空")]
    [StringLength(100, ErrorMessage = "服务名称长度不能超过100个字符")]
    public string? ServiceName { get; set; }

    /// <summary>
    /// 方法名称
    /// </summary>
    [Required(ErrorMessage = "方法名称不能为空")]
    [StringLength(100, ErrorMessage = "方法名称长度不能超过100个字符")]
    public string? MethodName { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "参数长度不能超过4000个字符")]
    public string? Parameters { get; set; }

    /// <summary>
    /// 返回值
    /// </summary>
    [StringLength(4000, ErrorMessage = "返回值长度不能超过4000个字符")]
    public string? ReturnValue { get; set; }

    /// <summary>
    /// 执行时间
    /// </summary>
    [Required(ErrorMessage = "执行时间不能为空")]
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// 执行时长
    /// </summary>
    [Required(ErrorMessage = "执行时长不能为空")]
    public int ExecutionDuration { get; set; }

    /// <summary>
    /// 客户端IP
    /// </summary>
    [StringLength(50, ErrorMessage = "客户端IP长度不能超过50个字符")]
    public string? ClientIp { get; set; }

    /// <summary>
    /// 客户端名称
    /// </summary>
    [StringLength(100, ErrorMessage = "客户端名称长度不能超过100个字符")]
    public string? ClientName { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    [StringLength(2000, ErrorMessage = "异常信息长度不能超过2000个字符")]
    public string? Exception { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }
  }

  /// <summary>
  /// 审计日志更新数据传输对象
  /// </summary>
  public class KpAuditLogUpdateDto
  {
    /// <summary>
    /// 审计日志ID
    /// </summary>
    [Required(ErrorMessage = "审计日志ID不能为空")]
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
    /// 审核类型
    /// </summary>
    [Required(ErrorMessage = "审核类型不能为空")]
    [Range(0, 4, ErrorMessage = "审核类型必须在0-4之间")]
    public int AuditType { get; set; }

    /// <summary>
    /// 审核意见
    /// </summary>
    [StringLength(500, ErrorMessage = "审核意见长度不能超过500个字符")]
    public string? AuditComment { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    [Required(ErrorMessage = "审核状态不能为空")]
    [Range(0, 5, ErrorMessage = "审核状态必须在0-5之间")]
    public int AuditStatus { get; set; }

    /// <summary>
    /// 审核人ID
    /// </summary>
    public long? AuditorId { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    [StringLength(50, ErrorMessage = "审核人长度不能超过50个字符")]
    public string? Auditor { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核IP
    /// </summary>
    [StringLength(50, ErrorMessage = "审核IP长度不能超过50个字符")]
    public string? AuditIp { get; set; }

    /// <summary>
    /// 审核地点
    /// </summary>
    [StringLength(100, ErrorMessage = "审核地点长度不能超过100个字符")]
    public string? AuditLocation { get; set; }

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
    /// 操作时间
    /// </summary>
    [Required(ErrorMessage = "操作时间不能为空")]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 附件列表
    /// </summary>
    [StringLength(4000, ErrorMessage = "附件列表长度不能超过4000个字符")]
    public string? Attachments { get; set; }

    /// <summary>
    /// 服务名称
    /// </summary>
    [Required(ErrorMessage = "服务名称不能为空")]
    [StringLength(100, ErrorMessage = "服务名称长度不能超过100个字符")]
    public string? ServiceName { get; set; }

    /// <summary>
    /// 方法名称
    /// </summary>
    [Required(ErrorMessage = "方法名称不能为空")]
    [StringLength(100, ErrorMessage = "方法名称长度不能超过100个字符")]
    public string? MethodName { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    [StringLength(4000, ErrorMessage = "参数长度不能超过4000个字符")]
    public string? Parameters { get; set; }

    /// <summary>
    /// 返回值
    /// </summary>
    [StringLength(4000, ErrorMessage = "返回值长度不能超过4000个字符")]
    public string? ReturnValue { get; set; }

    /// <summary>
    /// 执行时间
    /// </summary>
    [Required(ErrorMessage = "执行时间不能为空")]
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// 执行时长
    /// </summary>
    [Required(ErrorMessage = "执行时长不能为空")]
    public int ExecutionDuration { get; set; }

    /// <summary>
    /// 客户端IP
    /// </summary>
    [StringLength(50, ErrorMessage = "客户端IP长度不能超过50个字符")]
    public string? ClientIp { get; set; }

    /// <summary>
    /// 客户端名称
    /// </summary>
    [StringLength(100, ErrorMessage = "客户端名称长度不能超过100个字符")]
    public string? ClientName { get; set; }

    /// <summary>
    /// 浏览器信息
    /// </summary>
    [StringLength(500, ErrorMessage = "浏览器信息长度不能超过500个字符")]
    public string? BrowserInfo { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    [StringLength(2000, ErrorMessage = "异常信息长度不能超过2000个字符")]
    public string? Exception { get; set; }

    /// <summary>
    /// 自定义数据
    /// </summary>
    [StringLength(2000, ErrorMessage = "自定义数据长度不能超过2000个字符")]
    public string? CustomData { get; set; }
  }

  /// <summary>
  /// 审计日志删除数据传输对象
  /// </summary>
  public class KpAuditLogDeleteDto
  {
    /// <summary>
    /// 审计日志ID
    /// </summary>
    [Required(ErrorMessage = "审计日志ID不能为空")]
    public long Id { get; set; }
  }

  /// <summary>
  /// 审计日志导出数据传输对象
  /// </summary>
  public class KpAuditLogExportDto
  {
    /// <summary>
    /// 审计日志ID
    /// </summary>
    [KpExcelColumnName("ID")]
    public long Id { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [KpExcelColumnName("用户ID")]
    public long UserId { get; set; }

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
    /// 审核类型
    /// </summary>
    [KpExcelColumnName("审核类型")]
    public string? AuditTypeLabel { get; set; }

    /// <summary>
    /// 审核意见
    /// </summary>
    [KpExcelColumnName("审核意见")]
    public string? AuditComment { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    [KpExcelColumnName("审核状态")]
    public string? AuditStatusLabel { get; set; }

    /// <summary>
    /// 审核人
    /// </summary>
    [KpExcelColumnName("审核人")]
    public string? Auditor { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    [KpExcelColumnName("审核时间")]
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核IP
    /// </summary>
    [KpExcelColumnName("审核IP")]
    public string? AuditIp { get; set; }

    /// <summary>
    /// 审核地点
    /// </summary>
    [KpExcelColumnName("审核地点")]
    public string? AuditLocation { get; set; }

    /// <summary>
    /// 操作时间
    /// </summary>
    [KpExcelColumnName("操作时间")]
    public DateTime OperTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [KpExcelColumnName("创建时间")]
    public DateTime CreatedTime { get; set; }
  }
}