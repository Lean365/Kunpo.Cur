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
  [SugarTable("kp_log_vendor", "供应商")]
  [SugarIndex("idx_vendor_code", nameof(VendorCode), OrderByType.Asc)]
  [SugarIndex("idx_vendor_name", nameof(VendorName), OrderByType.Asc)]
  [SugarIndex("idx_vendor_type", nameof(VendorType), OrderByType.Asc)]
  public class KpVendor : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 供应商编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "供应商编码", IsNullable = false)]
    public string? VendorCode { get; set; }

    /// <summary>
    /// 供应商名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "vendor_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "供应商名称", IsNullable = false)]
    public string? VendorName { get; set; }

    /// <summary>
    /// 供应商简称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "供应商简称", IsNullable = true)]
    public string? VendorShortName { get; set; }

    /// <summary>
    /// 供应商类型
    /// </summary>
    [SugarColumn(ColumnName = "vendor_type", DefaultValue = "0", ColumnDescription = "供应商类型", IsNullable = false)]
    public int VendorType { get; set; }

    /// <summary>
    /// 供应商状态
    /// </summary>
    [SugarColumn(ColumnName = "vendor_status", DefaultValue = "0", ColumnDescription = "供应商状态", IsNullable = false)]
    public int VendorStatus { get; set; }
    #endregion

    #region 公司信息
    /// <summary>
    /// 公司代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_company_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "公司代码", IsNullable = true)]
    public string? VendorCompanyCode { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "vendor_company_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "公司名称", IsNullable = true)]
    public string? VendorCompanyName { get; set; }

    /// <summary>
    /// 统一社会信用代码
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_unified_social_credit_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "统一社会信用代码", IsNullable = true)]
    public string? VendorUnifiedSocialCreditCode { get; set; }

    /// <summary>
    /// 注册地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "vendor_registered_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "注册地址", IsNullable = true)]
    public string? VendorRegisteredAddress { get; set; }

    /// <summary>
    /// 注册资本
    /// </summary>
    [SugarColumn(ColumnName = "vendor_registered_capital", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "注册资本", IsNullable = true)]
    public decimal? VendorRegisteredCapital { get; set; }

    /// <summary>
    /// 成立日期
    /// </summary>
    [SugarColumn(ColumnName = "vendor_establishment_date", ColumnDescription = "成立日期", IsNullable = true)]
    public DateTime? VendorEstablishmentDate { get; set; }
    #endregion

    #region 采购信息
    /// <summary>
    /// 采购组织
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_purchase_org", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购组织", IsNullable = true)]
    public string? VendorPurchaseOrg { get; set; }

    /// <summary>
    /// 采购组
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_purchase_group", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购组", IsNullable = true)]
    public string? VendorPurchaseGroup { get; set; }

    /// <summary>
    /// 采购代表
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_purchase_rep", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "采购代表", IsNullable = true)]
    public string? VendorPurchaseRep { get; set; }
    #endregion

    #region 财务信息
    /// <summary>
    /// 付款方式
    /// </summary>
    [SugarColumn(ColumnName = "vendor_payment_method", ColumnDescription = "付款方式", IsNullable = true)]
    public int? VendorPaymentMethod { get; set; }

    /// <summary>
    /// 付款条件
    /// </summary>
    [SugarColumn(ColumnName = "vendor_payment_terms", ColumnDescription = "付款条件", IsNullable = true)]
    public int? VendorPaymentTerms { get; set; }

    /// <summary>
    /// 货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "vendor_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "货币", IsNullable = true)]
    public string? VendorCurrency { get; set; }

    /// <summary>
    /// 税分类
    /// </summary>
    [SugarColumn(ColumnName = "vendor_tax_classification", ColumnDescription = "税分类", IsNullable = true)]
    public int? VendorTaxClassification { get; set; }

    /// <summary>
    /// 税码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_tax_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "税码", IsNullable = true)]
    public string? VendorTaxCode { get; set; }
    #endregion

    #region 银行信息
    /// <summary>
    /// 银行账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_bank_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "银行账号", IsNullable = true)]
    public string? VendorBankAccount { get; set; }

    /// <summary>
    /// 银行名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "vendor_bank_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "银行名称", IsNullable = true)]
    public string? VendorBankName { get; set; }

    /// <summary>
    /// 银行代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_bank_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "银行代码", IsNullable = true)]
    public string? VendorBankCode { get; set; }

    /// <summary>
    /// 开户行
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "vendor_bank_branch", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "开户行", IsNullable = true)]
    public string? VendorBankBranch { get; set; }
    #endregion

    #region 联系人信息
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_contact_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人", IsNullable = true)]
    public string? VendorContactPerson { get; set; }

    /// <summary>
    /// 联系人职位
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_contact_position", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人职位", IsNullable = true)]
    public string? VendorContactPosition { get; set; }

    /// <summary>
    /// 联系人部门
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vendor_contact_department", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人部门", IsNullable = true)]
    public string? VendorContactDepartment { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_contact_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? VendorContactPhone { get; set; }

    /// <summary>
    /// 联系人手机
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_contact_mobile", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人手机", IsNullable = true)]
    public string? VendorContactMobile { get; set; }

    /// <summary>
    /// 联系人传真
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_contact_fax", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人传真", IsNullable = true)]
    public string? VendorContactFax { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "vendor_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? VendorEmail { get; set; }
    #endregion

    #region 地址信息
    /// <summary>
    /// 国家
    /// </summary>
    [SugarColumn(ColumnName = "vendor_country", ColumnDescription = "国家", IsNullable = true)]
    public int? VendorCountry { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [SugarColumn(ColumnName = "vendor_province", ColumnDescription = "省份", IsNullable = true)]
    public int? VendorProvince { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [SugarColumn(ColumnName = "vendor_city", ColumnDescription = "城市", IsNullable = true)]
    public int? VendorCity { get; set; }

    /// <summary>
    /// 区县
    /// </summary>
    [SugarColumn(ColumnName = "vendor_district", ColumnDescription = "区县", IsNullable = true)]
    public int? VendorDistrict { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "vendor_detailed_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "详细地址", IsNullable = true)]
    public string? VendorDetailedAddress { get; set; }

    /// <summary>
    /// 邮政编码
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "vendor_postal_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "邮政编码", IsNullable = true)]
    public string? VendorPostalCode { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 供应商等级
    /// </summary>
    [SugarColumn(ColumnName = "vendor_level", ColumnDescription = "供应商等级", IsNullable = true)]
    public int? VendorLevel { get; set; }

    /// <summary>
    /// 供应商来源
    /// </summary>
    [SugarColumn(ColumnName = "vendor_source", ColumnDescription = "供应商来源", IsNullable = true)]
    public int? VendorSource { get; set; }

    /// <summary>
    /// 供应商行业
    /// </summary>
    [SugarColumn(ColumnName = "vendor_industry", ColumnDescription = "供应商行业", IsNullable = true)]
    public int? VendorIndustry { get; set; }

    /// <summary>
    /// 供应商规模
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "vendor_scale", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "供应商规模", IsNullable = true)]
    public string? VendorScale { get; set; }

    /// <summary>
    /// 供应商性质
    /// </summary>
    [SugarColumn(ColumnName = "vendor_nature", ColumnDescription = "供应商性质", IsNullable = true)]
    public int? VendorNature { get; set; }

    /// <summary>
    /// 供应商分类
    /// </summary>
    [SugarColumn(ColumnName = "vendor_classification", ColumnDescription = "供应商分类", IsNullable = true)]
    public int? VendorClassification { get; set; }
    #endregion
  }
}