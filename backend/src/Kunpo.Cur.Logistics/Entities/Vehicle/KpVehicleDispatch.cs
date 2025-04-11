// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>车辆调度实体类</summary>
// <remarks>处理车辆调度的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Vehicle
{
  /// <summary>
  /// 车辆调度实体
  /// </summary>
  [SugarTable("kp_log_vehicle_dispatch", "车辆调度")]
  [SugarIndex("idx_vehicle_dispatch_code", nameof(DispatchCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_dispatch_vehicle", nameof(VehicleCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_dispatch_driver", nameof(DriverCode), OrderByType.Asc)]
  public class KpVehicleDispatch : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 调度单号
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "dispatch_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "调度单号", IsNullable = false)]
    public string? DispatchCode { get; set; }

    /// <summary>
    /// 车辆编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vehicle_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车辆编码", IsNullable = false)]
    public string? VehicleCode { get; set; }

    /// <summary>
    /// 司机编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "driver_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "司机编码", IsNullable = false)]
    public string? DriverCode { get; set; }

    /// <summary>
    /// 调度状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "dispatch_status", DefaultValue = "0", ColumnDescription = "调度状态", IsNullable = false)]
    public int DispatchStatus { get; set; }
    #endregion

    #region 调度信息
    /// <summary>
    /// 调度类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "dispatch_type", ColumnDescription = "调度类型", IsNullable = false)]
    public int DispatchType { get; set; }

    /// <summary>
    /// 调度事由
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "dispatch_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "调度事由", IsNullable = false)]
    public string? DispatchReason { get; set; }

    /// <summary>
    /// 出发地点
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "departure_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "出发地点", IsNullable = false)]
    public string? DepartureLocation { get; set; }

    /// <summary>
    /// 目的地
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "destination", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "目的地", IsNullable = false)]
    public string? Destination { get; set; }

    /// <summary>
    /// 计划出发时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "planned_departure_time", ColumnDataType = "datetime", ColumnDescription = "计划出发时间", IsNullable = false)]
    public DateTime PlannedDepartureTime { get; set; }

    /// <summary>
    /// 计划到达时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "planned_arrival_time", ColumnDataType = "datetime", ColumnDescription = "计划到达时间", IsNullable = false)]
    public DateTime PlannedArrivalTime { get; set; }

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

    #region 实际执行信息
    /// <summary>
    /// 实际出发时间
    /// </summary>
    [SugarColumn(ColumnName = "actual_departure_time", ColumnDataType = "datetime", ColumnDescription = "实际出发时间", IsNullable = true)]
    public DateTime? ActualDepartureTime { get; set; }

    /// <summary>
    /// 实际到达时间
    /// </summary>
    [SugarColumn(ColumnName = "actual_arrival_time", ColumnDataType = "datetime", ColumnDescription = "实际到达时间", IsNullable = true)]
    public DateTime? ActualArrivalTime { get; set; }

    /// <summary>
    /// 实际里程
    /// </summary>
    [SugarColumn(ColumnName = "actual_mileage", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "实际里程(公里)", IsNullable = true)]
    public decimal? ActualMileage { get; set; }

    /// <summary>
    /// 实际油耗
    /// </summary>
    [SugarColumn(ColumnName = "actual_fuel_consumption", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "实际油耗(升)", IsNullable = true)]
    public decimal? ActualFuelConsumption { get; set; }

    /// <summary>
    /// 实际路况
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "actual_road_condition", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "实际路况", IsNullable = true)]
    public string? ActualRoadCondition { get; set; }
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