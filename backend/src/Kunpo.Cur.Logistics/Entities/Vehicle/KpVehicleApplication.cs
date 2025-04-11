// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>车辆使用申请实体类</summary>
// <remarks>处理车辆使用申请的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Vehicle
{
  /// <summary>
  /// 车辆使用申请实体
  /// </summary>
  [SugarTable("kp_log_vehicle_application", "车辆使用申请")]
  [SugarIndex("idx_vehicle_application_code", nameof(ApplicationCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_application_vehicle", nameof(VehicleCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_application_applicant", nameof(ApplicantCode), OrderByType.Asc)]
  public class KpVehicleApplication : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 申请单号
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "application_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "申请单号", IsNullable = false)]
    public string? ApplicationCode { get; set; }

    /// <summary>
    /// 车辆编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vehicle_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车辆编码", IsNullable = false)]
    public string? VehicleCode { get; set; }

    /// <summary>
    /// 申请人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "applicant_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "申请人编码", IsNullable = false)]
    public string? ApplicantCode { get; set; }

    /// <summary>
    /// 申请部门
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "applicant_department", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "申请部门", IsNullable = false)]
    public string? ApplicantDepartment { get; set; }

    /// <summary>
    /// 申请状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "application_status", DefaultValue = "0", ColumnDescription = "申请状态", IsNullable = false)]
    public int ApplicationStatus { get; set; }
    #endregion

    #region 使用信息
    /// <summary>
    /// 使用事由
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "usage_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "使用事由", IsNullable = false)]
    public string? UsageReason { get; set; }

    /// <summary>
    /// 使用地点
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "usage_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "使用地点", IsNullable = false)]
    public string? UsageLocation { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "start_time", ColumnDataType = "datetime", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "end_time", ColumnDataType = "datetime", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 预计里程
    /// </summary>
    [SugarColumn(ColumnName = "estimated_mileage", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "预计里程(公里)", IsNullable = true)]
    public decimal? EstimatedMileage { get; set; }

    /// <summary>
    /// 随行人员
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "accompanying_personnel", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "随行人员", IsNullable = true)]
    public string? AccompanyingPersonnel { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人", IsNullable = true)]
    public string? Approver { get; set; }

    /// <summary>
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDataType = "datetime", ColumnDescription = "审批时间", IsNullable = true)]
    public DateTime? ApprovalTime { get; set; }

    /// <summary>
    /// 审批意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "approval_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "审批意见", IsNullable = true)]
    public string? ApprovalComment { get; set; }
    #endregion

    #region 实际使用信息
    /// <summary>
    /// 实际开始时间
    /// </summary>
    [SugarColumn(ColumnName = "actual_start_time", ColumnDataType = "datetime", ColumnDescription = "实际开始时间", IsNullable = true)]
    public DateTime? ActualStartTime { get; set; }

    /// <summary>
    /// 实际结束时间
    /// </summary>
    [SugarColumn(ColumnName = "actual_end_time", ColumnDataType = "datetime", ColumnDescription = "实际结束时间", IsNullable = true)]
    public DateTime? ActualEndTime { get; set; }

    /// <summary>
    /// 实际里程
    /// </summary>
    [SugarColumn(ColumnName = "actual_mileage", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "实际里程(公里)", IsNullable = true)]
    public decimal? ActualMileage { get; set; }

    /// <summary>
    /// 实际使用人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "actual_user", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "实际使用人", IsNullable = true)]
    public string? ActualUser { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "备注", IsNullable = true)]
    public string? Remarks { get; set; }
    #endregion
  }
}