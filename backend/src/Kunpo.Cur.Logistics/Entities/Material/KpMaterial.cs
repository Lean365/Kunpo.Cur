// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>物料实体类</summary>
// <remarks>处理物料的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Material
{
  /// <summary>
  /// 集团物料主数据
  /// </summary>
  [SugarTable("kp_log_material", "集团物料主数据")]
  [SugarIndex("idx_material_code", nameof(MaterialCode), OrderByType.Asc)]
  [SugarIndex("idx_material_name", nameof(MaterialName), OrderByType.Asc)]
  [SugarIndex("idx_material_type", nameof(MaterialType), OrderByType.Asc)]
  public class KpMaterial : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 物料编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "物料编码", IsNullable = false)]
    public string? MaterialCode { get; set; }

    /// <summary>
    /// 物料名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "material_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "物料名称", IsNullable = false)]
    public string? MaterialName { get; set; }

    /// <summary>
    /// 物料简称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "material_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "物料简称", IsNullable = true)]
    public string? MaterialShortName { get; set; }

    /// <summary>
    /// 物料类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "material_type", ColumnDescription = "物料类型", IsNullable = false)]
    public int MaterialType { get; set; }

    /// <summary>
    /// 物料状态
    /// </summary>
    [SugarColumn(ColumnName = "material_status", DefaultValue = "0", ColumnDescription = "物料状态", IsNullable = false)]
    public int MaterialStatus { get; set; }

    /// <summary>
    /// 物料组
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_group", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "物料组", IsNullable = true)]
    public string? MaterialGroup { get; set; }

    /// <summary>
    /// 物料分类
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_category", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "物料分类", IsNullable = true)]
    public string? MaterialCategory { get; set; }

    /// <summary>
    /// 物料描述
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_description", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料描述", IsNullable = true)]
    public string? MaterialDescription { get; set; }

    /// <summary>
    /// 物料规格
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "material_specification", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "物料规格", IsNullable = true)]
    public string? MaterialSpecification { get; set; }

    /// <summary>
    /// 物料型号
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "material_model", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "物料型号", IsNullable = true)]
    public string? MaterialModel { get; set; }

    /// <summary>
    /// 物料品牌
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "material_brand", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "物料品牌", IsNullable = true)]
    public string? MaterialBrand { get; set; }

    /// <summary>
    /// 物料产地
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "material_origin", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "物料产地", IsNullable = true)]
    public string? MaterialOrigin { get; set; }

    /// <summary>
    /// 物料等级
    /// </summary>
    [SugarColumn(ColumnName = "material_level", ColumnDescription = "物料等级", IsNullable = true)]
    public int? MaterialLevel { get; set; }

    /// <summary>
    /// 物料来源
    /// </summary>
    [SugarColumn(ColumnName = "material_source", ColumnDescription = "物料来源", IsNullable = true)]
    public int? MaterialSource { get; set; }

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

    #region 基本数据
    /// <summary>
    /// 基本计量单位
    /// </summary>
    [Required]
    [StringLength(10)]
    [SugarColumn(ColumnName = "base_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "基本计量单位", IsNullable = false)]
    public string? BaseUnit { get; set; }

    /// <summary>
    /// 重量单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "weight_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "重量单位", IsNullable = true)]
    public string? WeightUnit { get; set; }

    /// <summary>
    /// 毛重
    /// </summary>
    [SugarColumn(ColumnName = "gross_weight", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "毛重", IsNullable = true)]
    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// 净重
    /// </summary>
    [SugarColumn(ColumnName = "net_weight", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "净重", IsNullable = true)]
    public decimal? NetWeight { get; set; }

    /// <summary>
    /// 体积单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "volume_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "体积单位", IsNullable = true)]
    public string? VolumeUnit { get; set; }

    /// <summary>
    /// 体积
    /// </summary>
    [SugarColumn(ColumnName = "volume", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "体积", IsNullable = true)]
    public decimal? Volume { get; set; }

    /// <summary>
    /// 尺寸单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "dimension_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "尺寸单位", IsNullable = true)]
    public string? DimensionUnit { get; set; }

    /// <summary>
    /// 长度
    /// </summary>
    [SugarColumn(ColumnName = "length", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "长度", IsNullable = true)]
    public decimal? Length { get; set; }

    /// <summary>
    /// 宽度
    /// </summary>
    [SugarColumn(ColumnName = "width", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "宽度", IsNullable = true)]
    public decimal? Width { get; set; }

    /// <summary>
    /// 高度
    /// </summary>
    [SugarColumn(ColumnName = "height", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "高度", IsNullable = true)]
    public decimal? Height { get; set; }

    /// <summary>
    /// 物料有效期
    /// </summary>
    [SugarColumn(ColumnName = "material_validity", ColumnDataType = "int", ColumnDescription = "物料有效期(天)", IsNullable = true)]
    public int? MaterialValidity { get; set; }

    /// <summary>
    /// 物料保质期
    /// </summary>
    [SugarColumn(ColumnName = "material_shelf_life", ColumnDataType = "int", ColumnDescription = "物料保质期(天)", IsNullable = true)]
    public int? MaterialShelfLife { get; set; }

    /// <summary>
    /// 物料温度要求
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "material_temperature", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "物料温度要求", IsNullable = true)]
    public string? MaterialTemperature { get; set; }

    /// <summary>
    /// 物料湿度要求
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "material_humidity", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "物料湿度要求", IsNullable = true)]
    public string? MaterialHumidity { get; set; }

    /// <summary>
    /// 物料包装要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_package", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料包装要求", IsNullable = true)]
    public string? MaterialPackage { get; set; }

    /// <summary>
    /// 物料运输要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_transport", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料运输要求", IsNullable = true)]
    public string? MaterialTransport { get; set; }

    /// <summary>
    /// 物料存储要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_storage", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料存储要求", IsNullable = true)]
    public string? MaterialStorage { get; set; }

    /// <summary>
    /// 物料安全要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_safety", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料安全要求", IsNullable = true)]
    public string? MaterialSafety { get; set; }

    /// <summary>
    /// 物料环保要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_environmental", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料环保要求", IsNullable = true)]
    public string? MaterialEnvironmental { get; set; }

    /// <summary>
    /// 物料质量要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_quality", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料质量要求", IsNullable = true)]
    public string? MaterialQuality { get; set; }

    /// <summary>
    /// 物料检验要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_inspection", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料检验要求", IsNullable = true)]
    public string? MaterialInspection { get; set; }

    /// <summary>
    /// 物料使用要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_usage", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料使用要求", IsNullable = true)]
    public string? MaterialUsage { get; set; }

    /// <summary>
    /// 物料维护要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_maintenance", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料维护要求", IsNullable = true)]
    public string? MaterialMaintenance { get; set; }

    /// <summary>
    /// 物料报废要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_scrap", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料报废要求", IsNullable = true)]
    public string? MaterialScrap { get; set; }

    /// <summary>
    /// 物料回收要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_recycle", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料回收要求", IsNullable = true)]
    public string? MaterialRecycle { get; set; }

    /// <summary>
    /// 物料处理要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_disposal", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料处理要求", IsNullable = true)]
    public string? MaterialDisposal { get; set; }

    /// <summary>
    /// 物料标签要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_label", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料标签要求", IsNullable = true)]
    public string? MaterialLabel { get; set; }

    /// <summary>
    /// 物料文档要求
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "material_document", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "物料文档要求", IsNullable = true)]
    public string? MaterialDocument { get; set; }

    /// <summary>
    /// 物料图片
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_image", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "物料图片", IsNullable = true)]
    public string? MaterialImage { get; set; }

    /// <summary>
    /// 物料文档
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_file", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "物料文档", IsNullable = true)]
    public string? MaterialFile { get; set; }

    /// <summary>
    /// 物料链接
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_link", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "物料链接", IsNullable = true)]
    public string? MaterialLink { get; set; }

    /// <summary>
    /// 物料备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "物料备注", IsNullable = true)]
    public string? MaterialRemarks { get; set; }
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

    /// <summary>
    /// 采购价格单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "purchase_price_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "采购价格单位", IsNullable = true)]
    public string? PurchasePriceUnit { get; set; }

    /// <summary>
    /// 标准采购价格
    /// </summary>
    [SugarColumn(ColumnName = "standard_purchase_price", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "标准采购价格", IsNullable = true)]
    public decimal? StandardPurchasePrice { get; set; }

    /// <summary>
    /// 采购价格货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "purchase_price_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "采购价格货币", IsNullable = true)]
    public string? PurchasePriceCurrency { get; set; }

    /// <summary>
    /// 采购价格日期
    /// </summary>
    [SugarColumn(ColumnName = "purchase_price_date", ColumnDataType = "datetime", ColumnDescription = "采购价格日期", IsNullable = true)]
    public DateTime? PurchasePriceDate { get; set; }

    /// <summary>
    /// 采购价格来源
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "purchase_price_source", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购价格来源", IsNullable = true)]
    public string? PurchasePriceSource { get; set; }

    /// <summary>
    /// 采购价格备注
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_price_remarks", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购价格备注", IsNullable = true)]
    public string? PurchasePriceRemarks { get; set; }

    /// <summary>
    /// 采购提前期
    /// </summary>
    [SugarColumn(ColumnName = "purchase_lead_time", ColumnDataType = "int", ColumnDescription = "采购提前期(天)", IsNullable = true)]
    public int? PurchaseLeadTime { get; set; }

    /// <summary>
    /// 采购检验类型
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "purchase_inspection_type", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "采购检验类型", IsNullable = true)]
    public string? PurchaseInspectionType { get; set; }

    /// <summary>
    /// 采购检验规则
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_inspection_rule", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购检验规则", IsNullable = true)]
    public string? PurchaseInspectionRule { get; set; }

    /// <summary>
    /// 采购检验标准
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_inspection_standard", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购检验标准", IsNullable = true)]
    public string? PurchaseInspectionStandard { get; set; }

    /// <summary>
    /// 采购检验方法
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_inspection_method", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购检验方法", IsNullable = true)]
    public string? PurchaseInspectionMethod { get; set; }

    /// <summary>
    /// 采购检验工具
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_inspection_tool", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购检验工具", IsNullable = true)]
    public string? PurchaseInspectionTool { get; set; }

    /// <summary>
    /// 采购检验人员
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "purchase_inspection_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购检验人员", IsNullable = true)]
    public string? PurchaseInspectionPerson { get; set; }

    /// <summary>
    /// 采购检验地点
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "purchase_inspection_location", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购检验地点", IsNullable = true)]
    public string? PurchaseInspectionLocation { get; set; }

    /// <summary>
    /// 采购检验时间
    /// </summary>
    [SugarColumn(ColumnName = "purchase_inspection_time", ColumnDataType = "int", ColumnDescription = "采购检验时间(分钟)", IsNullable = true)]
    public int? PurchaseInspectionTime { get; set; }

    /// <summary>
    /// 采购检验费用
    /// </summary>
    [SugarColumn(ColumnName = "purchase_inspection_cost", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "采购检验费用", IsNullable = true)]
    public decimal? PurchaseInspectionCost { get; set; }

    /// <summary>
    /// 采购检验备注
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "purchase_inspection_remarks", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "采购检验备注", IsNullable = true)]
    public string? PurchaseInspectionRemarks { get; set; }
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

    /// <summary>
    /// 销售价格单位
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "sales_price_unit", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "销售价格单位", IsNullable = true)]
    public string? SalesPriceUnit { get; set; }

    /// <summary>
    /// 标准销售价格
    /// </summary>
    [SugarColumn(ColumnName = "standard_sales_price", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "标准销售价格", IsNullable = true)]
    public decimal? StandardSalesPrice { get; set; }

    /// <summary>
    /// 销售价格货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "sales_price_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "销售价格货币", IsNullable = true)]
    public string? SalesPriceCurrency { get; set; }

    /// <summary>
    /// 销售价格日期
    /// </summary>
    [SugarColumn(ColumnName = "sales_price_date", ColumnDataType = "datetime", ColumnDescription = "销售价格日期", IsNullable = true)]
    public DateTime? SalesPriceDate { get; set; }

    /// <summary>
    /// 销售价格来源
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "sales_price_source", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售价格来源", IsNullable = true)]
    public string? SalesPriceSource { get; set; }

    /// <summary>
    /// 销售价格备注
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_price_remarks", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售价格备注", IsNullable = true)]
    public string? SalesPriceRemarks { get; set; }

    /// <summary>
    /// 销售提前期
    /// </summary>
    [SugarColumn(ColumnName = "sales_lead_time", ColumnDataType = "int", ColumnDescription = "销售提前期(天)", IsNullable = true)]
    public int? SalesLeadTime { get; set; }

    /// <summary>
    /// 销售检验类型
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "sales_inspection_type", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "销售检验类型", IsNullable = true)]
    public string? SalesInspectionType { get; set; }

    /// <summary>
    /// 销售检验规则
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_inspection_rule", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售检验规则", IsNullable = true)]
    public string? SalesInspectionRule { get; set; }

    /// <summary>
    /// 销售检验标准
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_inspection_standard", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售检验标准", IsNullable = true)]
    public string? SalesInspectionStandard { get; set; }

    /// <summary>
    /// 销售检验方法
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_inspection_method", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售检验方法", IsNullable = true)]
    public string? SalesInspectionMethod { get; set; }

    /// <summary>
    /// 销售检验工具
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_inspection_tool", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售检验工具", IsNullable = true)]
    public string? SalesInspectionTool { get; set; }

    /// <summary>
    /// 销售检验人员
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "sales_inspection_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售检验人员", IsNullable = true)]
    public string? SalesInspectionPerson { get; set; }

    /// <summary>
    /// 销售检验地点
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "sales_inspection_location", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售检验地点", IsNullable = true)]
    public string? SalesInspectionLocation { get; set; }

    /// <summary>
    /// 销售检验时间
    /// </summary>
    [SugarColumn(ColumnName = "sales_inspection_time", ColumnDataType = "int", ColumnDescription = "销售检验时间(分钟)", IsNullable = true)]
    public int? SalesInspectionTime { get; set; }

    /// <summary>
    /// 销售检验费用
    /// </summary>
    [SugarColumn(ColumnName = "sales_inspection_cost", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "销售检验费用", IsNullable = true)]
    public decimal? SalesInspectionCost { get; set; }

    /// <summary>
    /// 销售检验备注
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "sales_inspection_remarks", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "销售检验备注", IsNullable = true)]
    public string? SalesInspectionRemarks { get; set; }
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

    /// <summary>
    /// 库存盘点周期
    /// </summary>
    [SugarColumn(ColumnName = "stock_count_cycle", ColumnDataType = "int", ColumnDescription = "库存盘点周期(天)", IsNullable = true)]
    public int? StockCountCycle { get; set; }

    /// <summary>
    /// 库存盘点方法
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "stock_count_method", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "库存盘点方法", IsNullable = true)]
    public string? StockCountMethod { get; set; }

    /// <summary>
    /// 库存盘点人员
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "stock_count_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "库存盘点人员", IsNullable = true)]
    public string? StockCountPerson { get; set; }

    /// <summary>
    /// 库存盘点地点
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "stock_count_location", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "库存盘点地点", IsNullable = true)]
    public string? StockCountLocation { get; set; }

    /// <summary>
    /// 库存盘点时间
    /// </summary>
    [SugarColumn(ColumnName = "stock_count_time", ColumnDataType = "int", ColumnDescription = "库存盘点时间(分钟)", IsNullable = true)]
    public int? StockCountTime { get; set; }

    /// <summary>
    /// 库存盘点费用
    /// </summary>
    [SugarColumn(ColumnName = "stock_count_cost", ColumnDataType = "decimal", Length = 18, DecimalDigits = 6, ColumnDescription = "库存盘点费用", IsNullable = true)]
    public decimal? StockCountCost { get; set; }

    /// <summary>
    /// 库存盘点备注
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "stock_count_remarks", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "库存盘点备注", IsNullable = true)]
    public string? StockCountRemarks { get; set; }
    #endregion

    #region 其他信息
    #endregion
  }
}