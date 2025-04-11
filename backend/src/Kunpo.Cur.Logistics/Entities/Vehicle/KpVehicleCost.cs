// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>车辆费用实体类</summary>
// <remarks>处理车辆费用的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Vehicle
{
  /// <summary>
  /// 车辆费用实体
  /// </summary>
  [SugarTable("kp_log_vehicle_cost", "车辆费用")]
  [SugarIndex("idx_vehicle_cost_code", nameof(CostCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_cost_vehicle", nameof(VehicleCode), OrderByType.Asc)]
  public class KpVehicleCost : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 费用单号
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "cost_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "费用单号", IsNullable = false)]
    public string? CostCode { get; set; }

    /// <summary>
    /// 车辆编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vehicle_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车辆编码", IsNullable = false)]
    public string? VehicleCode { get; set; }

    /// <summary>
    /// 费用类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "cost_type", ColumnDescription = "费用类型", IsNullable = false)]
    public int CostType { get; set; }

    /// <summary>
    /// 费用状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "cost_status", DefaultValue = "0", ColumnDescription = "费用状态", IsNullable = false)]
    public int CostStatus { get; set; }
    #endregion

    #region 费用信息
    /// <summary>
    /// 费用金额
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "cost_amount", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "费用金额(元)", IsNullable = false)]
    public decimal CostAmount { get; set; }

    /// <summary>
    /// 费用日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "cost_date", ColumnDataType = "date", ColumnDescription = "费用日期", IsNullable = false)]
    public DateTime CostDate { get; set; }

    /// <summary>
    /// 费用说明
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "cost_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "费用说明", IsNullable = false)]
    public string? CostDescription { get; set; }

    /// <summary>
    /// 费用单位
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "cost_vendor", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "费用单位", IsNullable = false)]
    public string? CostVendor { get; set; }

    /// <summary>
    /// 发票号码
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "invoice_number", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "发票号码", IsNullable = true)]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// 发票日期
    /// </summary>
    [SugarColumn(ColumnName = "invoice_date", ColumnDataType = "date", ColumnDescription = "发票日期", IsNullable = true)]
    public DateTime? InvoiceDate { get; set; }
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