/******************************************************************************
 * 文件名称：KpHousingFund.cs
 * 文件描述：公积金记录实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Salary
{
  /// <summary>
  /// 公积金记录实体类
  /// </summary>
  [SugarTable("kp_hr_housing_fund", "公积金记录")]
  [SugarIndex("idx_housing_fund_employee_date", nameof(EmployeeCode), nameof(FundDate), OrderByType.Asc)]
  public class KpHousingFund : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 缴存日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "fund_date", ColumnDataType = "date", ColumnDescription = "缴存日期", IsNullable = false)]
    public DateTime FundDate { get; set; }

    /// <summary>
    /// 缴存状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "fund_status", ColumnDescription = "缴存状态", IsNullable = false)]
    public int FundStatus { get; set; }

    /// <summary>
    /// 缴存城市
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "fund_city", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "缴存城市", IsNullable = true)]
    public string? FundCity { get; set; }

    /// <summary>
    /// 缴存基数
    /// </summary>
    [SugarColumn(ColumnName = "fund_base", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "缴存基数", IsNullable = true)]
    public decimal? FundBase { get; set; }
    #endregion

    #region 缴存信息
    /// <summary>
    /// 个人缴存比例
    /// </summary>
    [SugarColumn(ColumnName = "personal_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "个人缴存比例", IsNullable = true)]
    public decimal? PersonalRate { get; set; }

    /// <summary>
    /// 个人缴存金额
    /// </summary>
    [SugarColumn(ColumnName = "personal_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "个人缴存金额", IsNullable = true)]
    public decimal? PersonalAmount { get; set; }

    /// <summary>
    /// 单位缴存比例
    /// </summary>
    [SugarColumn(ColumnName = "company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "单位缴存比例", IsNullable = true)]
    public decimal? CompanyRate { get; set; }

    /// <summary>
    /// 单位缴存金额
    /// </summary>
    [SugarColumn(ColumnName = "company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "单位缴存金额", IsNullable = true)]
    public decimal? CompanyAmount { get; set; }

    /// <summary>
    /// 月缴存总额
    /// </summary>
    [SugarColumn(ColumnName = "monthly_total", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "月缴存总额", IsNullable = true)]
    public decimal? MonthlyTotal { get; set; }
    #endregion

    #region 账户信息
    /// <summary>
    /// 公积金账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "fund_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "公积金账号", IsNullable = true)]
    public string? FundAccount { get; set; }

    /// <summary>
    /// 账户余额
    /// </summary>
    [SugarColumn(ColumnName = "account_balance", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "账户余额", IsNullable = true)]
    public decimal? AccountBalance { get; set; }

    /// <summary>
    /// 账户状态
    /// </summary>
    [SugarColumn(ColumnName = "account_status", ColumnDescription = "账户状态", IsNullable = true)]
    public int? AccountStatus { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否补充公积金
    /// </summary>
    [SugarColumn(ColumnName = "is_supplementary", ColumnDescription = "是否补充公积金", IsNullable = false, DefaultValue = "0")]
    public bool IsSupplementary { get; set; }

    /// <summary>
    /// 补充公积金比例
    /// </summary>
    [SugarColumn(ColumnName = "supplementary_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "补充公积金比例", IsNullable = true)]
    public decimal? SupplementaryRate { get; set; }

    /// <summary>
    /// 补充公积金金额
    /// </summary>
    [SugarColumn(ColumnName = "supplementary_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "补充公积金金额", IsNullable = true)]
    public decimal? SupplementaryAmount { get; set; }

    /// <summary>
    /// 公积金备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "fund_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "公积金备注", IsNullable = true)]
    public string? FundRemarks { get; set; }
    #endregion
  }
}