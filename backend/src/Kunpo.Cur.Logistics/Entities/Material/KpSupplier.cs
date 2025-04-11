// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>供应商实体类</summary>
// <remarks>处理供应商的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Material
{
  /// <summary>
  /// 供应商实体
  /// </summary>
  [SugarTable("kp_log_supplier", "供应商")]
  [SugarIndex("idx_supplier_code", nameof(SupplierCode), OrderByType.Asc)]
  [SugarIndex("idx_supplier_name", nameof(SupplierName), OrderByType.Asc)]
  [SugarIndex("idx_supplier_type", nameof(SupplierType), OrderByType.Asc)]
  public class KpSupplier : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 供应商编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "供应商编码", IsNullable = false)]
    public string? SupplierCode { get; set; }

    /// <summary>
    /// 供应商名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "supplier_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "供应商名称", IsNullable = false)]
    public string? SupplierName { get; set; }

    /// <summary>
    /// 供应商简称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "供应商简称", IsNullable = true)]
    public string? SupplierShortName { get; set; }

    /// <summary>
    /// 供应商类型
    /// </summary>
    [SugarColumn(ColumnName = "supplier_type", DefaultValue = "0", ColumnDescription = "供应商类型", IsNullable = false)]
    public int SupplierType { get; set; }

    /// <summary>
    /// 供应商状态
    /// </summary>
    [SugarColumn(ColumnName = "supplier_status", DefaultValue = "0", ColumnDescription = "供应商状态", IsNullable = false)]
    public int SupplierStatus { get; set; }
    #endregion

    #region 公司信息
    /// <summary>
    /// 公司代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_company_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "公司代码", IsNullable = true)]
    public string? SupplierCompanyCode { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "supplier_company_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "公司名称", IsNullable = true)]
    public string? SupplierCompanyName { get; set; }

    /// <summary>
    /// 统一社会信用代码
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_unified_social_credit_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "统一社会信用代码", IsNullable = true)]
    public string? SupplierUnifiedSocialCreditCode { get; set; }

    /// <summary>
    /// 注册地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "supplier_registered_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "注册地址", IsNullable = true)]
    public string? SupplierRegisteredAddress { get; set; }

    /// <summary>
    /// 注册资本
    /// </summary>
    [SugarColumn(ColumnName = "supplier_registered_capital", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "注册资本", IsNullable = true)]
    public decimal? SupplierRegisteredCapital { get; set; }

    /// <summary>
    /// 成立日期
    /// </summary>
    [SugarColumn(ColumnName = "supplier_establishment_date", ColumnDescription = "成立日期", IsNullable = true)]
    public DateTime? SupplierEstablishmentDate { get; set; }
    #endregion

    #region 采购信息
    /// <summary>
    /// 采购组织
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_purchase_org", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购组织", IsNullable = true)]
    public string? SupplierPurchaseOrg { get; set; }

    /// <summary>
    /// 采购组
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_purchase_group", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购组", IsNullable = true)]
    public string? SupplierPurchaseGroup { get; set; }

    /// <summary>
    /// 采购代表
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_purchase_rep", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购代表", IsNullable = true)]
    public string? SupplierPurchaseRep { get; set; }
    #endregion

    #region 财务信息
    /// <summary>
    /// 付款方式
    /// </summary>
    [SugarColumn(ColumnName = "supplier_payment_method", ColumnDescription = "付款方式", IsNullable = true)]
    public int? SupplierPaymentMethod { get; set; }

    /// <summary>
    /// 付款条件
    /// </summary>
    [SugarColumn(ColumnName = "supplier_payment_terms", ColumnDescription = "付款条件", IsNullable = true)]
    public int? SupplierPaymentTerms { get; set; }

    /// <summary>
    /// 货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "supplier_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "货币", IsNullable = true)]
    public string? SupplierCurrency { get; set; }

    /// <summary>
    /// 税分类
    /// </summary>
    [SugarColumn(ColumnName = "supplier_tax_classification", ColumnDescription = "税分类", IsNullable = true)]
    public int? SupplierTaxClassification { get; set; }

    /// <summary>
    /// 税码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_tax_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "税码", IsNullable = true)]
    public string? SupplierTaxCode { get; set; }
    #endregion

    #region 银行信息
    /// <summary>
    /// 银行账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_bank_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "银行账号", IsNullable = true)]
    public string? SupplierBankAccount { get; set; }

    /// <summary>
    /// 银行名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "supplier_bank_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "银行名称", IsNullable = true)]
    public string? SupplierBankName { get; set; }

    /// <summary>
    /// 银行代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_bank_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "银行代码", IsNullable = true)]
    public string? SupplierBankCode { get; set; }

    /// <summary>
    /// 开户行
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "supplier_bank_branch", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "开户行", IsNullable = true)]
    public string? SupplierBankBranch { get; set; }
    #endregion

    #region 联系人信息
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_contact_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人", IsNullable = true)]
    public string? SupplierContactPerson { get; set; }

    /// <summary>
    /// 联系人职位
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_contact_position", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人职位", IsNullable = true)]
    public string? SupplierContactPosition { get; set; }

    /// <summary>
    /// 联系人部门
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "supplier_contact_department", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人部门", IsNullable = true)]
    public string? SupplierContactDepartment { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_contact_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? SupplierContactPhone { get; set; }

    /// <summary>
    /// 联系人手机
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_contact_mobile", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人手机", IsNullable = true)]
    public string? SupplierContactMobile { get; set; }

    /// <summary>
    /// 联系人传真
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_contact_fax", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人传真", IsNullable = true)]
    public string? SupplierContactFax { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "supplier_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? SupplierEmail { get; set; }
    #endregion

    #region 地址信息
    /// <summary>
    /// 国家
    /// </summary>
    [SugarColumn(ColumnName = "supplier_country", ColumnDescription = "国家", IsNullable = true)]
    public int? SupplierCountry { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [SugarColumn(ColumnName = "supplier_province", ColumnDescription = "省份", IsNullable = true)]
    public int? SupplierProvince { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [SugarColumn(ColumnName = "supplier_city", ColumnDescription = "城市", IsNullable = true)]
    public int? SupplierCity { get; set; }

    /// <summary>
    /// 区县
    /// </summary>
    [SugarColumn(ColumnName = "supplier_district", ColumnDescription = "区县", IsNullable = true)]
    public int? SupplierDistrict { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "supplier_detailed_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "详细地址", IsNullable = true)]
    public string? SupplierDetailedAddress { get; set; }

    /// <summary>
    /// 邮政编码
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "supplier_postal_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "邮政编码", IsNullable = true)]
    public string? SupplierPostalCode { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 供应商等级
    /// </summary>
    [SugarColumn(ColumnName = "supplier_level", ColumnDescription = "供应商等级", IsNullable = true)]
    public int? SupplierLevel { get; set; }

    /// <summary>
    /// 供应商来源
    /// </summary>
    [SugarColumn(ColumnName = "supplier_source", ColumnDescription = "供应商来源", IsNullable = true)]
    public int? SupplierSource { get; set; }

    /// <summary>
    /// 供应商行业
    /// </summary>
    [SugarColumn(ColumnName = "supplier_industry", ColumnDescription = "供应商行业", IsNullable = true)]
    public int? SupplierIndustry { get; set; }

    /// <summary>
    /// 供应商规模
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "supplier_scale", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "供应商规模", IsNullable = true)]
    public string? SupplierScale { get; set; }

    /// <summary>
    /// 供应商性质
    /// </summary>
    [SugarColumn(ColumnName = "supplier_nature", ColumnDescription = "供应商性质", IsNullable = true)]
    public int? SupplierNature { get; set; }

    /// <summary>
    /// 供应商分类
    /// </summary>
    [SugarColumn(ColumnName = "supplier_classification", ColumnDescription = "供应商分类", IsNullable = true)]
    public int? SupplierClassification { get; set; }
    #endregion
  }
}