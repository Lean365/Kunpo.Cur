/******************************************************************************
 * 文件名称：KpSalary.cs
 * 文件描述：薪资记录实体类
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
  /// 薪资记录实体类
  /// </summary>
  [SugarTable("kp_hr_salary", "薪资记录")]
  [SugarIndex("idx_salary_employee_date", nameof(EmployeeCode), nameof(SalaryDate), OrderByType.Asc)]
  public class KpSalary : KpBaseEntity
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
    /// 薪资日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "salary_date", ColumnDataType = "date", ColumnDescription = "薪资日期", IsNullable = false)]
    public DateTime SalaryDate { get; set; }

    /// <summary>
    /// 薪资状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "salary_status", ColumnDescription = "薪资状态", IsNullable = false)]
    public int SalaryStatus { get; set; }

    /// <summary>
    /// 薪资结构编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "structure_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "薪资结构编码", IsNullable = true)]
    public string? StructureCode { get; set; }
    #endregion

    #region 薪资项目
    /// <summary>
    /// 基本工资
    /// </summary>
    [SugarColumn(ColumnName = "base_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "基本工资", IsNullable = true)]
    public decimal? BaseSalary { get; set; }

    /// <summary>
    /// 岗位工资
    /// </summary>
    [SugarColumn(ColumnName = "position_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "岗位工资", IsNullable = true)]
    public decimal? PositionSalary { get; set; }

    /// <summary>
    /// 绩效工资
    /// </summary>
    [SugarColumn(ColumnName = "performance_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "绩效工资", IsNullable = true)]
    public decimal? PerformanceSalary { get; set; }

    /// <summary>
    /// 加班工资
    /// </summary>
    [SugarColumn(ColumnName = "overtime_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "加班工资", IsNullable = true)]
    public decimal? OvertimeSalary { get; set; }

    /// <summary>
    /// 津贴补贴
    /// </summary>
    [SugarColumn(ColumnName = "allowance", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "津贴补贴", IsNullable = true)]
    public decimal? Allowance { get; set; }

    /// <summary>
    /// 奖金
    /// </summary>
    [SugarColumn(ColumnName = "bonus", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "奖金", IsNullable = true)]
    public decimal? Bonus { get; set; }

    /// <summary>
    /// 其他收入
    /// </summary>
    [SugarColumn(ColumnName = "other_income", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "其他收入", IsNullable = true)]
    public decimal? OtherIncome { get; set; }
    #endregion

    #region 扣款项目
    /// <summary>
    /// 社保个人部分
    /// </summary>
    [SugarColumn(ColumnName = "social_security_personal", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "社保个人部分", IsNullable = true)]
    public decimal? SocialSecurityPersonal { get; set; }

    /// <summary>
    /// 公积金个人部分
    /// </summary>
    [SugarColumn(ColumnName = "housing_fund_personal", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "公积金个人部分", IsNullable = true)]
    public decimal? HousingFundPersonal { get; set; }

    /// <summary>
    /// 个人所得税
    /// </summary>
    [SugarColumn(ColumnName = "personal_tax", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "个人所得税", IsNullable = true)]
    public decimal? PersonalTax { get; set; }

    /// <summary>
    /// 考勤扣款
    /// </summary>
    [SugarColumn(ColumnName = "attendance_deduction", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "考勤扣款", IsNullable = true)]
    public decimal? AttendanceDeduction { get; set; }

    /// <summary>
    /// 其他扣款
    /// </summary>
    [SugarColumn(ColumnName = "other_deduction", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "其他扣款", IsNullable = true)]
    public decimal? OtherDeduction { get; set; }
    #endregion

    #region 汇总信息
    /// <summary>
    /// 应发工资
    /// </summary>
    [SugarColumn(ColumnName = "gross_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "应发工资", IsNullable = true)]
    public decimal? GrossSalary { get; set; }

    /// <summary>
    /// 实发工资
    /// </summary>
    [SugarColumn(ColumnName = "net_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "实发工资", IsNullable = true)]
    public decimal? NetSalary { get; set; }

    /// <summary>
    /// 社保公司部分
    /// </summary>
    [SugarColumn(ColumnName = "social_security_company", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "社保公司部分", IsNullable = true)]
    public decimal? SocialSecurityCompany { get; set; }

    /// <summary>
    /// 公积金公司部分
    /// </summary>
    [SugarColumn(ColumnName = "housing_fund_company", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "公积金公司部分", IsNullable = true)]
    public decimal? HousingFundCompany { get; set; }

    /// <summary>
    /// 公司总成本
    /// </summary>
    [SugarColumn(ColumnName = "company_total_cost", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "公司总成本", IsNullable = true)]
    public decimal? CompanyTotalCost { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 薪资币种
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "salary_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "薪资币种", IsNullable = true)]
    public string? SalaryCurrency { get; set; }

    /// <summary>
    /// 薪资备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "salary_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "薪资备注", IsNullable = true)]
    public string? SalaryRemarks { get; set; }
    #endregion
  }
}