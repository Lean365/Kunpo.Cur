/******************************************************************************
 * 文件名称：KpSocialSecurity.cs
 * 文件描述：社保记录实体类
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
  /// 社保记录实体类
  /// </summary>
  [SugarTable("kp_hr_social_security", "社保记录")]
  [SugarIndex("idx_social_security_employee_date", nameof(EmployeeCode), nameof(InsuranceDate), OrderByType.Asc)]
  public class KpSocialSecurity : KpBaseEntity
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
    /// 参保日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "insurance_date", ColumnDataType = "date", ColumnDescription = "参保日期", IsNullable = false)]
    public DateTime InsuranceDate { get; set; }

    /// <summary>
    /// 参保状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "insurance_status", ColumnDescription = "参保状态", IsNullable = false)]
    public int InsuranceStatus { get; set; }

    /// <summary>
    /// 参保城市
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "insurance_city", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "参保城市", IsNullable = true)]
    public string? InsuranceCity { get; set; }

    /// <summary>
    /// 参保基数
    /// </summary>
    [SugarColumn(ColumnName = "insurance_base", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "参保基数", IsNullable = true)]
    public decimal? InsuranceBase { get; set; }
    #endregion

    #region 养老保险
    /// <summary>
    /// 养老保险个人比例
    /// </summary>
    [SugarColumn(ColumnName = "pension_personal_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "养老保险个人比例", IsNullable = true)]
    public decimal? PensionPersonalRate { get; set; }

    /// <summary>
    /// 养老保险个人金额
    /// </summary>
    [SugarColumn(ColumnName = "pension_personal_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "养老保险个人金额", IsNullable = true)]
    public decimal? PensionPersonalAmount { get; set; }

    /// <summary>
    /// 养老保险公司比例
    /// </summary>
    [SugarColumn(ColumnName = "pension_company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "养老保险公司比例", IsNullable = true)]
    public decimal? PensionCompanyRate { get; set; }

    /// <summary>
    /// 养老保险公司金额
    /// </summary>
    [SugarColumn(ColumnName = "pension_company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "养老保险公司金额", IsNullable = true)]
    public decimal? PensionCompanyAmount { get; set; }
    #endregion

    #region 医疗保险
    /// <summary>
    /// 医疗保险个人比例
    /// </summary>
    [SugarColumn(ColumnName = "medical_personal_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "医疗保险个人比例", IsNullable = true)]
    public decimal? MedicalPersonalRate { get; set; }

    /// <summary>
    /// 医疗保险个人金额
    /// </summary>
    [SugarColumn(ColumnName = "medical_personal_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "医疗保险个人金额", IsNullable = true)]
    public decimal? MedicalPersonalAmount { get; set; }

    /// <summary>
    /// 医疗保险公司比例
    /// </summary>
    [SugarColumn(ColumnName = "medical_company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "医疗保险公司比例", IsNullable = true)]
    public decimal? MedicalCompanyRate { get; set; }

    /// <summary>
    /// 医疗保险公司金额
    /// </summary>
    [SugarColumn(ColumnName = "medical_company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "医疗保险公司金额", IsNullable = true)]
    public decimal? MedicalCompanyAmount { get; set; }
    #endregion

    #region 失业保险
    /// <summary>
    /// 失业保险个人比例
    /// </summary>
    [SugarColumn(ColumnName = "unemployment_personal_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "失业保险个人比例", IsNullable = true)]
    public decimal? UnemploymentPersonalRate { get; set; }

    /// <summary>
    /// 失业保险个人金额
    /// </summary>
    [SugarColumn(ColumnName = "unemployment_personal_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "失业保险个人金额", IsNullable = true)]
    public decimal? UnemploymentPersonalAmount { get; set; }

    /// <summary>
    /// 失业保险公司比例
    /// </summary>
    [SugarColumn(ColumnName = "unemployment_company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "失业保险公司比例", IsNullable = true)]
    public decimal? UnemploymentCompanyRate { get; set; }

    /// <summary>
    /// 失业保险公司金额
    /// </summary>
    [SugarColumn(ColumnName = "unemployment_company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "失业保险公司金额", IsNullable = true)]
    public decimal? UnemploymentCompanyAmount { get; set; }
    #endregion

    #region 工伤保险
    /// <summary>
    /// 工伤保险公司比例
    /// </summary>
    [SugarColumn(ColumnName = "injury_company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "工伤保险公司比例", IsNullable = true)]
    public decimal? InjuryCompanyRate { get; set; }

    /// <summary>
    /// 工伤保险公司金额
    /// </summary>
    [SugarColumn(ColumnName = "injury_company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "工伤保险公司金额", IsNullable = true)]
    public decimal? InjuryCompanyAmount { get; set; }
    #endregion

    #region 生育保险
    /// <summary>
    /// 生育保险公司比例
    /// </summary>
    [SugarColumn(ColumnName = "maternity_company_rate", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "生育保险公司比例", IsNullable = true)]
    public decimal? MaternityCompanyRate { get; set; }

    /// <summary>
    /// 生育保险公司金额
    /// </summary>
    [SugarColumn(ColumnName = "maternity_company_amount", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "生育保险公司金额", IsNullable = true)]
    public decimal? MaternityCompanyAmount { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 社保卡号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "social_security_card", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "社保卡号", IsNullable = true)]
    public string? SocialSecurityCard { get; set; }

    /// <summary>
    /// 社保备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "social_security_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "社保备注", IsNullable = true)]
    public string? SocialSecurityRemarks { get; set; }
    #endregion
  }
}