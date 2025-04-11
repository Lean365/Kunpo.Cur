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
  /// 基础客户实体
  /// </summary>
  [SugarTable("kp_log_client", "基础客户")]
  [SugarIndex("idx_client_code", nameof(ClientCode), OrderByType.Asc)]
  [SugarIndex("idx_client_name", nameof(ClientName), OrderByType.Asc)]
  [SugarIndex("idx_client_type", nameof(ClientType), OrderByType.Asc)]
  public class KpClient : KpBaseEntity
  {
    #region 基础信息
    /// <summary>
    /// 客户编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "客户编码", IsNullable = false)]
    public string? ClientCode { get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "client_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "客户名称", IsNullable = false)]
    public string? ClientName { get; set; }

    /// <summary>
    /// 客户简称
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "客户简称", IsNullable = true)]
    public string? ClientShortName { get; set; }

    /// <summary>
    /// 客户类型
    /// </summary>
    /// <remarks>
    /// 0：普通客户，1：VIP客户，2：战略客户，3：潜在客户，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "client_type", DefaultValue = "0", ColumnDescription = "客户类型", IsNullable = false)]
    public int ClientType { get; set; }

    /// <summary>
    /// 客户状态
    /// </summary>
    /// <remarks>
    /// 0：活跃，1：非活跃，2：黑名单，3：待审核，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "client_status", DefaultValue = "0", ColumnDescription = "客户状态", IsNullable = false)]
    public int ClientStatus { get; set; }
    #endregion

    #region 公司信息
    /// <summary>
    /// 公司代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_company_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "公司代码", IsNullable = true)]
    public string? ClientCompanyCode { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "client_company_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "公司名称", IsNullable = true)]
    public string? ClientCompanyName { get; set; }

    /// <summary>
    /// 统一社会信用代码
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_unified_social_credit_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "统一社会信用代码", IsNullable = true)]
    public string? ClientUnifiedSocialCreditCode { get; set; }

    /// <summary>
    /// 注册地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "client_registered_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "注册地址", IsNullable = true)]
    public string? ClientRegisteredAddress { get; set; }

    /// <summary>
    /// 注册资本
    /// </summary>
    [SugarColumn(ColumnName = "client_registered_capital", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "注册资本", IsNullable = true)]
    public decimal? ClientRegisteredCapital { get; set; }

    /// <summary>
    /// 成立日期
    /// </summary>
    [SugarColumn(ColumnName = "client_establishment_date", ColumnDescription = "成立日期", IsNullable = true)]
    public DateTime? ClientEstablishmentDate { get; set; }
    #endregion

    #region 销售信息
    /// <summary>
    /// 销售区域
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_sales_area", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售区域", IsNullable = true)]
    public string? ClientSalesArea { get; set; }

    /// <summary>
    /// 销售组织
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_sales_org", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售组织", IsNullable = true)]
    public string? ClientSalesOrg { get; set; }

    /// <summary>
    /// 分销渠道
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_distribution_channel", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "分销渠道", IsNullable = true)]
    public string? ClientDistributionChannel { get; set; }

    /// <summary>
    /// 销售组
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_sales_group", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售组", IsNullable = true)]
    public string? ClientSalesGroup { get; set; }

    /// <summary>
    /// 销售代表
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_sales_rep", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "销售代表", IsNullable = true)]
    public string? ClientSalesRep { get; set; }
    #endregion

    #region 财务信息
    /// <summary>
    /// 付款方式
    /// </summary>
    [SugarColumn(ColumnName = "client_payment_method", ColumnDescription = "付款方式", IsNullable = true)]
    public int? ClientPaymentMethod { get; set; }

    /// <summary>
    /// 付款条件
    /// </summary>
    [SugarColumn(ColumnName = "client_payment_terms", ColumnDescription = "付款条件", IsNullable = true)]
    public int? ClientPaymentTerms { get; set; }

    /// <summary>
    /// 信用额度
    /// </summary>
    [SugarColumn(ColumnName = "client_credit_limit", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "信用额度", IsNullable = true)]
    public decimal? ClientCreditLimit { get; set; }

    /// <summary>
    /// 货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "client_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "货币", IsNullable = true)]
    public string? ClientCurrency { get; set; }

    /// <summary>
    /// 税分类
    /// </summary>
    [SugarColumn(ColumnName = "client_tax_classification", ColumnDescription = "税分类", IsNullable = true)]
    public int? ClientTaxClassification { get; set; }

    /// <summary>
    /// 税码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_tax_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "税码", IsNullable = true)]
    public string? ClientTaxCode { get; set; }
    #endregion

    #region 银行信息
    /// <summary>
    /// 银行账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_bank_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "银行账号", IsNullable = true)]
    public string? ClientBankAccount { get; set; }

    /// <summary>
    /// 银行名称
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "client_bank_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "银行名称", IsNullable = true)]
    public string? ClientBankName { get; set; }

    /// <summary>
    /// 银行代码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_bank_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "银行代码", IsNullable = true)]
    public string? ClientBankCode { get; set; }

    /// <summary>
    /// 开户行
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "client_bank_branch", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "开户行", IsNullable = true)]
    public string? ClientBankBranch { get; set; }
    #endregion

    #region 联系人信息
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_contact_person", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人", IsNullable = true)]
    public string? ClientContactPerson { get; set; }

    /// <summary>
    /// 联系人职位
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_contact_position", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人职位", IsNullable = true)]
    public string? ClientContactPosition { get; set; }

    /// <summary>
    /// 联系人部门
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "client_contact_department", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人部门", IsNullable = true)]
    public string? ClientContactDepartment { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_contact_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? ClientContactPhone { get; set; }

    /// <summary>
    /// 联系人手机
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_contact_mobile", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人手机", IsNullable = true)]
    public string? ClientContactMobile { get; set; }

    /// <summary>
    /// 联系人传真
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_contact_fax", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系人传真", IsNullable = true)]
    public string? ClientContactFax { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "client_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? ClientEmail { get; set; }
    #endregion

    #region 地址信息
    /// <summary>
    /// 国家
    /// </summary>
    [SugarColumn(ColumnName = "client_country", ColumnDescription = "国家", IsNullable = true)]
    public int? ClientCountry { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [SugarColumn(ColumnName = "client_province", ColumnDescription = "省份", IsNullable = true)]
    public int? ClientProvince { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [SugarColumn(ColumnName = "client_city", ColumnDescription = "城市", IsNullable = true)]
    public int? ClientCity { get; set; }

    /// <summary>
    /// 区县
    /// </summary>
    [SugarColumn(ColumnName = "client_district", ColumnDescription = "区县", IsNullable = true)]
    public int? ClientDistrict { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "client_detailed_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "详细地址", IsNullable = true)]
    public string? ClientDetailedAddress { get; set; }

    /// <summary>
    /// 邮政编码
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "client_postal_code", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "邮政编码", IsNullable = true)]
    public string? ClientPostalCode { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 客户等级
    /// </summary>
    [SugarColumn(ColumnName = "client_level", ColumnDescription = "客户等级", IsNullable = true)]
    public int? ClientLevel { get; set; }

    /// <summary>
    /// 客户来源
    /// </summary>
    [SugarColumn(ColumnName = "client_source", ColumnDescription = "客户来源", IsNullable = true)]
    public int? ClientSource { get; set; }

    /// <summary>
    /// 客户行业
    /// </summary>
    [SugarColumn(ColumnName = "client_industry", ColumnDescription = "客户行业", IsNullable = true)]
    public int? ClientIndustry { get; set; }

    /// <summary>
    /// 客户规模
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "client_scale", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "客户规模", IsNullable = true)]
    public string? ClientScale { get; set; }

    /// <summary>
    /// 客户性质
    /// </summary>
    [SugarColumn(ColumnName = "client_nature", ColumnDescription = "客户性质", IsNullable = true)]
    public int? ClientNature { get; set; }

    /// <summary>
    /// 客户分类
    /// </summary>
    [SugarColumn(ColumnName = "client_classification", ColumnDescription = "客户分类", IsNullable = true)]
    public int? ClientClassification { get; set; }
    #endregion
  }
}