// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>客户实体类</summary>
// <remarks>处理客户的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Logistics.Entities.Sales
{
  /// <summary>
  /// 客户实体
  /// </summary>
  [SugarTable("kp_log_customer", "客户")]
  [SugarIndex("idx_customer_code", nameof(CustomerCode), OrderByType.Asc)]
  [SugarIndex("idx_customer_name", nameof(CustomerName), OrderByType.Asc)]
  [SugarIndex("idx_customer_type", nameof(CustomerType), OrderByType.Asc)]
  public class KpCustomer : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 客户编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "客户编码", IsNullable = false)]
    public string? CustomerCode { get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "customer_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "客户名称", IsNullable = false)]
    public string? CustomerName { get; set; }

    /// <summary>
    /// 客户简称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "客户简称", IsNullable = true)]
    public string? CustomerShortName { get; set; }

    /// <summary>
    /// 客户类型
    /// </summary>
    /// <remarks>
    /// 0：普通客户，1：VIP客户，2：战略客户，3：潜在客户，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "customer_type", DefaultValue = "0", ColumnDescription = "客户类型", IsNullable = false)]
    public int CustomerType { get; set; }

    /// <summary>
    /// 客户状态
    /// </summary>
    /// <remarks>
    /// 0：活跃，1：非活跃，2：黑名单，3：待审核，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "customer_status", DefaultValue = "0", ColumnDescription = "客户状态", IsNullable = false)]
    public int CustomerStatus { get; set; }
    #endregion

    #region 公司信息
    /// <summary>
    /// 公司代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_company_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "公司代码", IsNullable = true)]
    public string? CustomerCompanyCode { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "customer_company_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "公司名称", IsNullable = true)]
    public string? CustomerCompanyName { get; set; }

    /// <summary>
    /// 统一社会信用代码
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_unified_social_credit_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "统一社会信用代码", IsNullable = true)]
    public string? CustomerUnifiedSocialCreditCode { get; set; }

    /// <summary>
    /// 注册地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "customer_registered_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "注册地址", IsNullable = true)]
    public string? CustomerRegisteredAddress { get; set; }

    /// <summary>
    /// 注册资本
    /// </summary>
    [SugarColumn(ColumnName = "customer_registered_capital", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "注册资本", IsNullable = true)]
    public decimal? CustomerRegisteredCapital { get; set; }

    /// <summary>
    /// 成立日期
    /// </summary>
    [SugarColumn(ColumnName = "customer_establishment_date", ColumnDescription = "成立日期", IsNullable = true)]
    public DateTime? CustomerEstablishmentDate { get; set; }
    #endregion

    #region 销售信息
    /// <summary>
    /// 销售区域
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_sales_area", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售区域", IsNullable = true)]
    public string? CustomerSalesArea { get; set; }

    /// <summary>
    /// 销售组织
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_sales_org", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售组织", IsNullable = true)]
    public string? CustomerSalesOrg { get; set; }

    /// <summary>
    /// 分销渠道
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_distribution_channel", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "分销渠道", IsNullable = true)]
    public string? CustomerDistributionChannel { get; set; }

    /// <summary>
    /// 销售组
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_sales_group", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售组", IsNullable = true)]
    public string? CustomerSalesGroup { get; set; }

    /// <summary>
    /// 销售代表
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_sales_rep", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售代表", IsNullable = true)]
    public string? CustomerSalesRep { get; set; }
    #endregion

    #region 财务信息
    /// <summary>
    /// 付款方式
    /// </summary>
    [SugarColumn(ColumnName = "customer_payment_method", ColumnDescription = "付款方式", IsNullable = true)]
    public int? CustomerPaymentMethod { get; set; }

    /// <summary>
    /// 付款条件
    /// </summary>
    [SugarColumn(ColumnName = "customer_payment_terms", ColumnDescription = "付款条件", IsNullable = true)]
    public int? CustomerPaymentTerms { get; set; }

    /// <summary>
    /// 信用额度
    /// </summary>
    [SugarColumn(ColumnName = "customer_credit_limit", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "信用额度", IsNullable = true)]
    public decimal? CustomerCreditLimit { get; set; }

    /// <summary>
    /// 货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "customer_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "货币", IsNullable = true)]
    public string? CustomerCurrency { get; set; }

    /// <summary>
    /// 税分类
    /// </summary>
    [SugarColumn(ColumnName = "customer_tax_classification", ColumnDescription = "税分类", IsNullable = true)]
    public int? CustomerTaxClassification { get; set; }

    /// <summary>
    /// 税码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_tax_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "税码", IsNullable = true)]
    public string? CustomerTaxCode { get; set; }
    #endregion

    #region 银行信息
    /// <summary>
    /// 银行账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_bank_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "银行账号", IsNullable = true)]
    public string? CustomerBankAccount { get; set; }

    /// <summary>
    /// 银行名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "customer_bank_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "银行名称", IsNullable = true)]
    public string? CustomerBankName { get; set; }

    /// <summary>
    /// 银行代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_bank_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "银行代码", IsNullable = true)]
    public string? CustomerBankCode { get; set; }

    /// <summary>
    /// 开户行
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "customer_bank_branch", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "开户行", IsNullable = true)]
    public string? CustomerBankBranch { get; set; }
    #endregion

    #region 联系人信息
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_contact_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人", IsNullable = true)]
    public string? CustomerContactPerson { get; set; }

    /// <summary>
    /// 联系人职位
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_contact_position", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人职位", IsNullable = true)]
    public string? CustomerContactPosition { get; set; }

    /// <summary>
    /// 联系人部门
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "customer_contact_department", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人部门", IsNullable = true)]
    public string? CustomerContactDepartment { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_contact_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? CustomerContactPhone { get; set; }

    /// <summary>
    /// 联系人手机
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_contact_mobile", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人手机", IsNullable = true)]
    public string? CustomerContactMobile { get; set; }

    /// <summary>
    /// 联系人传真
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_contact_fax", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人传真", IsNullable = true)]
    public string? CustomerContactFax { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "customer_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? CustomerEmail { get; set; }
    #endregion

    #region 地址信息
    /// <summary>
    /// 国家
    /// </summary>
    [SugarColumn(ColumnName = "customer_country", ColumnDescription = "国家", IsNullable = true)]
    public int? CustomerCountry { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [SugarColumn(ColumnName = "customer_province", ColumnDescription = "省份", IsNullable = true)]
    public int? CustomerProvince { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [SugarColumn(ColumnName = "customer_city", ColumnDescription = "城市", IsNullable = true)]
    public int? CustomerCity { get; set; }

    /// <summary>
    /// 区县
    /// </summary>
    [SugarColumn(ColumnName = "customer_district", ColumnDescription = "区县", IsNullable = true)]
    public int? CustomerDistrict { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "customer_detailed_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "详细地址", IsNullable = true)]
    public string? CustomerDetailedAddress { get; set; }

    /// <summary>
    /// 邮政编码
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "customer_postal_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "邮政编码", IsNullable = true)]
    public string? CustomerPostalCode { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 客户等级
    /// </summary>
    [SugarColumn(ColumnName = "customer_level", ColumnDescription = "客户等级", IsNullable = true)]
    public int? CustomerLevel { get; set; }

    /// <summary>
    /// 客户来源
    /// </summary>
    [SugarColumn(ColumnName = "customer_source", ColumnDescription = "客户来源", IsNullable = true)]
    public int? CustomerSource { get; set; }

    /// <summary>
    /// 客户行业
    /// </summary>
    [SugarColumn(ColumnName = "customer_industry", ColumnDescription = "客户行业", IsNullable = true)]
    public int? CustomerIndustry { get; set; }

    /// <summary>
    /// 客户规模
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "customer_scale", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "客户规模", IsNullable = true)]
    public string? CustomerScale { get; set; }

    /// <summary>
    /// 客户性质
    /// </summary>
    [SugarColumn(ColumnName = "customer_nature", ColumnDescription = "客户性质", IsNullable = true)]
    public int? CustomerNature { get; set; }

    /// <summary>
    /// 客户分类
    /// </summary>
    [SugarColumn(ColumnName = "customer_classification", ColumnDescription = "客户分类", IsNullable = true)]
    public int? CustomerClassification { get; set; }
    #endregion
  }
}