// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>车辆实体类</summary>
// <remarks>处理车辆的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Vehicle
{
  /// <summary>
  /// 车辆基本信息实体
  /// </summary>
  [SugarTable("kp_log_vehicle", "车辆信息")]
  [SugarIndex("idx_vehicle_code", nameof(VehicleCode), OrderByType.Asc)]
  [SugarIndex("idx_vehicle_plate", nameof(PlateNumber), OrderByType.Asc)]
  public class KpVehicle : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 车辆编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vehicle_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车辆编码", IsNullable = false)]
    public string? VehicleCode { get; set; }

    /// <summary>
    /// 车牌号码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "plate_number", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "车牌号码", IsNullable = false)]
    public string? PlateNumber { get; set; }

    /// <summary>
    /// 车辆类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "vehicle_type", ColumnDescription = "车辆类型", IsNullable = false)]
    public int VehicleType { get; set; }

    /// <summary>
    /// 车辆品牌
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "vehicle_brand", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "车辆品牌", IsNullable = false)]
    public string? VehicleBrand { get; set; }

    /// <summary>
    /// 车辆型号
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "vehicle_model", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "车辆型号", IsNullable = false)]
    public string? VehicleModel { get; set; }

    /// <summary>
    /// 车辆状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "vehicle_status", DefaultValue = "0", ColumnDescription = "车辆状态", IsNullable = false)]
    public int VehicleStatus { get; set; }
    #endregion

    #region 技术参数
    /// <summary>
    /// 发动机号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "engine_number", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "发动机号", IsNullable = true)]
    public string? EngineNumber { get; set; }

    /// <summary>
    /// 车架号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vin", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "车架号", IsNullable = true)]
    public string? Vin { get; set; }

    /// <summary>
    /// 排量
    /// </summary>
    [SugarColumn(ColumnName = "displacement", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "排量", IsNullable = true)]
    public decimal? Displacement { get; set; }

    /// <summary>
    /// 燃料类型
    /// </summary>
    [SugarColumn(ColumnName = "fuel_type", ColumnDescription = "燃料类型", IsNullable = true)]
    public int? FuelType { get; set; }

    /// <summary>
    /// 座位数
    /// </summary>
    [SugarColumn(ColumnName = "seats", ColumnDescription = "座位数", IsNullable = true)]
    public int? Seats { get; set; }

    /// <summary>
    /// 载重量
    /// </summary>
    [SugarColumn(ColumnName = "load_capacity", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "载重量(吨)", IsNullable = true)]
    public decimal? LoadCapacity { get; set; }
    #endregion

    #region 使用信息
    /// <summary>
    /// 购买日期
    /// </summary>
    [SugarColumn(ColumnName = "purchase_date", ColumnDataType = "date", ColumnDescription = "购买日期", IsNullable = true)]
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// 使用年限
    /// </summary>
    [SugarColumn(ColumnName = "service_life", ColumnDataType = "int", ColumnDescription = "使用年限(年)", IsNullable = true)]
    public int? ServiceLife { get; set; }

    /// <summary>
    /// 当前里程数
    /// </summary>
    [SugarColumn(ColumnName = "current_mileage", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "当前里程数(公里)", IsNullable = true)]
    public decimal? CurrentMileage { get; set; }

    /// <summary>
    /// 上次保养里程
    /// </summary>
    [SugarColumn(ColumnName = "last_maintenance_mileage", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "上次保养里程(公里)", IsNullable = true)]
    public decimal? LastMaintenanceMileage { get; set; }

    /// <summary>
    /// 上次保养日期
    /// </summary>
    [SugarColumn(ColumnName = "last_maintenance_date", ColumnDataType = "date", ColumnDescription = "上次保养日期", IsNullable = true)]
    public DateTime? LastMaintenanceDate { get; set; }
    #endregion

    #region 保险信息
    /// <summary>
    /// 保险单号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "insurance_policy", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "保险单号", IsNullable = true)]
    public string? InsurancePolicy { get; set; }

    /// <summary>
    /// 保险公司
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "insurance_company", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "保险公司", IsNullable = true)]
    public string? InsuranceCompany { get; set; }

    /// <summary>
    /// 保险开始日期
    /// </summary>
    [SugarColumn(ColumnName = "insurance_start_date", ColumnDataType = "date", ColumnDescription = "保险开始日期", IsNullable = true)]
    public DateTime? InsuranceStartDate { get; set; }

    /// <summary>
    /// 保险结束日期
    /// </summary>
    [SugarColumn(ColumnName = "insurance_end_date", ColumnDataType = "date", ColumnDescription = "保险结束日期", IsNullable = true)]
    public DateTime? InsuranceEndDate { get; set; }
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