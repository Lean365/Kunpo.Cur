using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Employee
{
  /// <summary>
  /// 员工主数据
  /// </summary>
  [SugarTable("kp_hr_employee", "员工主数据")]
  [SugarIndex("idx_employee_code", nameof(EmployeeCode), OrderByType.Asc)]
  [SugarIndex("idx_employee_name", nameof(EmployeeName), OrderByType.Asc)]
  public class KpEmployee : KpBaseEntity
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
    /// 员工姓名
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "employee_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "员工姓名", IsNullable = false)]
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 员工英文名
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "employee_english_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "员工英文名", IsNullable = true)]
    public string? EmployeeEnglishName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [SugarColumn(ColumnName = "gender", ColumnDescription = "性别", IsNullable = false)]
    public int Gender { get; set; }

    /// <summary>
    /// 出生日期
    /// </summary>
    [SugarColumn(ColumnName = "birth_date", ColumnDataType = "datetime", ColumnDescription = "出生日期", IsNullable = true)]
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    [StringLength(18)]
    [SugarColumn(ColumnName = "id_card", ColumnDataType = "nvarchar", Length = 18, ColumnDescription = "身份证号", IsNullable = true)]
    public string? IdCard { get; set; }

    /// <summary>
    /// 民族
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "nationality", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "民族", IsNullable = true)]
    public string? Nationality { get; set; }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    [SugarColumn(ColumnName = "marital_status", ColumnDescription = "婚姻状况", IsNullable = true)]
    public int? MaritalStatus { get; set; }

    /// <summary>
    /// 政治面貌
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "political_status", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "政治面貌", IsNullable = true)]
    public string? PoliticalStatus { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? Phone { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? Email { get; set; }

    /// <summary>
    /// 紧急联系人
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "emergency_contact", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "紧急联系人", IsNullable = true)]
    public string? EmergencyContact { get; set; }

    /// <summary>
    /// 紧急联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "emergency_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "紧急联系电话", IsNullable = true)]
    public string? EmergencyPhone { get; set; }
    #endregion

    #region 工作信息
    /// <summary>
    /// 入职日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "hire_date", ColumnDataType = "datetime", ColumnDescription = "入职日期", IsNullable = false)]
    public DateTime HireDate { get; set; }

    /// <summary>
    /// 离职日期
    /// </summary>
    [SugarColumn(ColumnName = "leave_date", ColumnDataType = "datetime", ColumnDescription = "离职日期", IsNullable = true)]
    public DateTime? LeaveDate { get; set; }

    /// <summary>
    /// 员工状态
    /// </summary>
    [SugarColumn(ColumnName = "employee_status", DefaultValue = "0", ColumnDescription = "员工状态", IsNullable = false)]
    public int EmployeeStatus { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "部门编码", IsNullable = true)]
    public string? DepartmentCode { get; set; }

    /// <summary>
    /// 职位编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "position_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职位编码", IsNullable = true)]
    public string? PositionCode { get; set; }

    /// <summary>
    /// 职级
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_level", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职级", IsNullable = true)]
    public string? JobLevel { get; set; }

    /// <summary>
    /// 工作地点
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "work_location", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "工作地点", IsNullable = true)]
    public string? WorkLocation { get; set; }

    /// <summary>
    /// 直接上级
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "direct_supervisor", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "直接上级", IsNullable = true)]
    public string? DirectSupervisor { get; set; }

    /// <summary>
    /// 工作性质
    /// </summary>
    [SugarColumn(ColumnName = "work_nature", ColumnDescription = "工作性质", IsNullable = true)]
    public int? WorkNature { get; set; }

    /// <summary>
    /// 用工形式
    /// </summary>
    [SugarColumn(ColumnName = "employment_type", ColumnDescription = "用工形式", IsNullable = true)]
    public int? EmploymentType { get; set; }
    #endregion

    #region 薪资信息
    /// <summary>
    /// 基本工资
    /// </summary>
    [SugarColumn(ColumnName = "base_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "基本工资", IsNullable = true)]
    public decimal? BaseSalary { get; set; }

    /// <summary>
    /// 薪资货币
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "salary_currency", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "薪资货币", IsNullable = true)]
    public string? SalaryCurrency { get; set; }

    /// <summary>
    /// 薪资发放方式
    /// </summary>
    [SugarColumn(ColumnName = "salary_payment_method", ColumnDescription = "薪资发放方式", IsNullable = true)]
    public int? SalaryPaymentMethod { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "bank_account", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "银行账号", IsNullable = true)]
    public string? BankAccount { get; set; }

    /// <summary>
    /// 开户银行
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "bank_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "开户银行", IsNullable = true)]
    public string? BankName { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 员工照片
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "employee_photo", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "员工照片", IsNullable = true)]
    public string? EmployeePhoto { get; set; }

    /// <summary>
    /// 员工备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "employee_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "员工备注", IsNullable = true)]
    public string? EmployeeRemarks { get; set; }
    #endregion
  }
}