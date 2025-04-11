// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>工厂物料实体类</summary>
// <remarks>处理工厂物料的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Material
{
  /// <summary>
  /// 工厂物料主数据
  /// </summary>
  [SugarTable("kp_log_plant_material", "工厂物料主数据")]
  [SugarIndex("idx_plant_material", nameof(PlantCode), OrderByType.Asc, nameof(MaterialCode), OrderByType.Asc)]
  public class KpPlantMaterial : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 工厂编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "plant_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "工厂编码", IsNullable = false)]
    public string? PlantCode { get; set; }

    /// <summary>
    /// 物料编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "物料编码", IsNullable = false)]
    public string? MaterialCode { get; set; }

    /// <summary>
    /// 物料状态
    /// </summary>
    [SugarColumn(ColumnName = "material_status", DefaultValue = "0", ColumnDescription = "物料状态", IsNullable = false)]
    public int MaterialStatus { get; set; }
    #endregion

    #region 采购数据
    /// <summary>
    /// 采购组
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "purchase_group", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "采购组", IsNullable = true)]
    public string? PurchaseGroup { get; set; }

    /// <summary>
    /// 采购单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "purchase_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "采购单位", IsNullable = true)]
    public string? PurchaseUnit { get; set; }

    /// <summary>
    /// 采购单位转换系数
    /// </summary>
    [SugarColumn(ColumnName = "purchase_unit_factor", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "采购单位转换系数", IsNullable = true)]
    public decimal? PurchaseUnitFactor { get; set; }

    /// <summary>
    /// 最小采购数量
    /// </summary>
    [SugarColumn(ColumnName = "min_purchase_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "最小采购数量", IsNullable = true)]
    public decimal? MinPurchaseQty { get; set; }

    /// <summary>
    /// 标准采购订单文本
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "standard_po_text", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "标准采购订单文本", IsNullable = true)]
    public string? StandardPoText { get; set; }
    #endregion

    #region 销售数据
    /// <summary>
    /// 销售单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "sales_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "销售单位", IsNullable = true)]
    public string? SalesUnit { get; set; }

    /// <summary>
    /// 销售单位转换系数
    /// </summary>
    [SugarColumn(ColumnName = "sales_unit_factor", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "销售单位转换系数", IsNullable = true)]
    public decimal? SalesUnitFactor { get; set; }

    /// <summary>
    /// 最小销售数量
    /// </summary>
    [SugarColumn(ColumnName = "min_sales_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "最小销售数量", IsNullable = true)]
    public decimal? MinSalesQty { get; set; }

    /// <summary>
    /// 标准销售订单文本
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "standard_so_text", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "标准销售订单文本", IsNullable = true)]
    public string? StandardSoText { get; set; }
    #endregion

    #region 库存数据
    /// <summary>
    /// 库存单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "stock_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "库存单位", IsNullable = true)]
    public string? StockUnit { get; set; }

    /// <summary>
    /// 库存单位转换系数
    /// </summary>
    [SugarColumn(ColumnName = "stock_unit_factor", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "库存单位转换系数", IsNullable = true)]
    public decimal? StockUnitFactor { get; set; }

    /// <summary>
    /// 最小库存数量
    /// </summary>
    [SugarColumn(ColumnName = "min_stock_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "最小库存数量", IsNullable = true)]
    public decimal? MinStockQty { get; set; }

    /// <summary>
    /// 最大库存数量
    /// </summary>
    [SugarColumn(ColumnName = "max_stock_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "最大库存数量", IsNullable = true)]
    public decimal? MaxStockQty { get; set; }

    /// <summary>
    /// 安全库存数量
    /// </summary>
    [SugarColumn(ColumnName = "safety_stock_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "安全库存数量", IsNullable = true)]
    public decimal? SafetyStockQty { get; set; }

    /// <summary>
    /// 库存地点
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "storage_location", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "库存地点", IsNullable = true)]
    public string? StorageLocation { get; set; }

    /// <summary>
    /// 库存类型
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "storage_type", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "库存类型", IsNullable = true)]
    public string? StorageType { get; set; }

    /// <summary>
    /// 库存状态
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "storage_status", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "库存状态", IsNullable = true)]
    public string? StorageStatus { get; set; }
    #endregion

    #region 生产数据
    /// <summary>
    /// 生产单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "production_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "生产单位", IsNullable = true)]
    public string? ProductionUnit { get; set; }

    /// <summary>
    /// 生产单位转换系数
    /// </summary>
    [SugarColumn(ColumnName = "production_unit_factor", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "生产单位转换系数", IsNullable = true)]
    public decimal? ProductionUnitFactor { get; set; }

    /// <summary>
    /// 最小生产数量
    /// </summary>
    [SugarColumn(ColumnName = "min_production_qty", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "最小生产数量", IsNullable = true)]
    public decimal? MinProductionQty { get; set; }

    /// <summary>
    /// 标准生产订单文本
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "standard_mo_text", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "标准生产订单文本", IsNullable = true)]
    public string? StandardMoText { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 物料来源
    /// </summary>
    [SugarColumn(ColumnName = "material_source", ColumnDescription = "物料来源", IsNullable = true)]
    public int? MaterialSource { get; set; }

    /// <summary>
    /// 物料等级
    /// </summary>
    [SugarColumn(ColumnName = "material_level", ColumnDescription = "物料等级", IsNullable = true)]
    public int? MaterialLevel { get; set; }

    /// <summary>
    /// 物料性质
    /// </summary>
    [SugarColumn(ColumnName = "material_nature", ColumnDescription = "物料性质", IsNullable = true)]
    public int? MaterialNature { get; set; }

    /// <summary>
    /// 物料分类
    /// </summary>
    [SugarColumn(ColumnName = "material_classification", ColumnDescription = "物料分类", IsNullable = true)]
    public int? MaterialClassification { get; set; }
    #endregion
  }
}