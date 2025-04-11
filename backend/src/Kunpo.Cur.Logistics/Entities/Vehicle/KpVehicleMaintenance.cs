// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>车辆维修实体类</summary>
// <remarks>处理车辆维修的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Vehicle
{
  /// <summary>
  /// 车辆维修实体
  /// </summary>
  [SugarTable("kp_log_vehicle_maintenance", "车辆维修")]
  [SugarIndex("idx_vehicle_maintenance_code", nameof(MaintenanceCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_maintenance_vehicle", nameof(VehicleCode), OrderByType.Asc)]
  public class KpVehicleMaintenance : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 维修单号
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "maintenance_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "维修单号", IsNullable = false)]
    public string? MaintenanceCode { get; set; }

    /// <summary>
    /// 车辆编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vehicle_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车辆编码", IsNullable = false)]
    public string? VehicleCode { get; set; }

    /// <summary>
    /// 维修类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "maintenance_type", ColumnDescription = "维修类型", IsNullable = false)]
    public int MaintenanceType { get; set; }

    /// <summary>
    /// 维修状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "maintenance_status", DefaultValue = "0", ColumnDescription = "维修状态", IsNullable = false)]
    public int MaintenanceStatus { get; set; }
    #endregion

    #region 维修信息
    /// <summary>
    /// 故障描述
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "fault_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "故障描述", IsNullable = false)]
    public string? FaultDescription { get; set; }

    /// <summary>
    /// 维修项目
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "maintenance_items", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "维修项目", IsNullable = false)]
    public string? MaintenanceItems { get; set; }

    /// <summary>
    /// 维修地点
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "maintenance_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "维修地点", IsNullable = false)]
    public string? MaintenanceLocation { get; set; }

    /// <summary>
    /// 维修厂家
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "maintenance_vendor", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "维修厂家", IsNullable = false)]
    public string? MaintenanceVendor { get; set; }

    /// <summary>
    /// 计划开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "planned_start_time", ColumnDataType = "datetime", ColumnDescription = "计划开始时间", IsNullable = false)]
    public DateTime PlannedStartTime { get; set; }

    /// <summary>
    /// 计划结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "planned_end_time", ColumnDataType = "datetime", ColumnDescription = "计划结束时间", IsNullable = false)]
    public DateTime PlannedEndTime { get; set; }

    /// <summary>
    /// 预计费用
    /// </summary>
    [SugarColumn(ColumnName = "estimated_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "预计费用(元)", IsNullable = true)]
    public decimal? EstimatedCost { get; set; }
    #endregion

    #region 实际维修信息
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
    /// 实际费用
    /// </summary>
    [SugarColumn(ColumnName = "actual_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "实际费用(元)", IsNullable = true)]
    public decimal? ActualCost { get; set; }

    /// <summary>
    /// 维修结果
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "maintenance_result", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "维修结果", IsNullable = true)]
    public string? MaintenanceResult { get; set; }

    /// <summary>
    /// 维修人员
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "maintenance_personnel", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "维修人员", IsNullable = true)]
    public string? MaintenancePersonnel { get; set; }
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