/******************************************************************************
 * 文件名称：KpSalaryAdjustment.cs
 * 文件描述：薪资调整记录实体类
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
  /// 薪资调整记录实体类
  /// </summary>
  [SugarTable("kp_hr_salary_adjustment", "薪资调整记录")]
  [SugarIndex("idx_salary_adjustment_employee_date", nameof(EmployeeCode), nameof(AdjustmentDate), OrderByType.Asc)]
  public class KpSalaryAdjustment : KpBaseEntity
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
    /// 调整日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "adjustment_date", ColumnDataType = "date", ColumnDescription = "调整日期", IsNullable = false)]
    public DateTime AdjustmentDate { get; set; }

    /// <summary>
    /// 调整类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "adjustment_type", ColumnDescription = "调整类型", IsNullable = false)]
    public int AdjustmentType { get; set; }

    /// <summary>
    /// 调整状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "adjustment_status", ColumnDescription = "调整状态", IsNullable = false)]
    public int AdjustmentStatus { get; set; }

    /// <summary>
    /// 调整原因
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "adjustment_reason", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "调整原因", IsNullable = true)]
    public string? AdjustmentReason { get; set; }
    #endregion

    #region 调整详情
    /// <summary>
    /// 调整前薪资结构
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "before_structure_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "调整前薪资结构", IsNullable = true)]
    public string? BeforeStructureCode { get; set; }

    /// <summary>
    /// 调整后薪资结构
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "after_structure_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "调整后薪资结构", IsNullable = true)]
    public string? AfterStructureCode { get; set; }

    /// <summary>
    /// 调整前基本工资
    /// </summary>
    [SugarColumn(ColumnName = "before_base_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "调整前基本工资", IsNullable = true)]
    public decimal? BeforeBaseSalary { get; set; }

    /// <summary>
    /// 调整后基本工资
    /// </summary>
    [SugarColumn(ColumnName = "after_base_salary", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, ColumnDescription = "调整后基本工资", IsNullable = true)]
    public decimal? AfterBaseSalary { get; set; }

    /// <summary>
    /// 调整前其他薪资项目
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "before_other_items", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "调整前其他薪资项目", IsNullable = true)]
    public string? BeforeOtherItems { get; set; }

    /// <summary>
    /// 调整后其他薪资项目
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "after_other_items", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "调整后其他薪资项目", IsNullable = true)]
    public string? AfterOtherItems { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人", IsNullable = true)]
    public string? Approver { get; set; }

    /// <summary>
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDataType = "datetime", ColumnDescription = "审批时间", IsNullable = true)]
    public DateTime? ApprovalTime { get; set; }

    /// <summary>
    /// 审批意见
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "approval_comment", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "审批意见", IsNullable = true)]
    public string? ApprovalComment { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否影响社保
    /// </summary>
    [SugarColumn(ColumnName = "is_affect_social_security", ColumnDescription = "是否影响社保", IsNullable = false, DefaultValue = "0")]
    public bool IsAffectSocialSecurity { get; set; }

    /// <summary>
    /// 是否影响公积金
    /// </summary>
    [SugarColumn(ColumnName = "is_affect_housing_fund", ColumnDescription = "是否影响公积金", IsNullable = false, DefaultValue = "0")]
    public bool IsAffectHousingFund { get; set; }

    /// <summary>
    /// 调整备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "adjustment_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "调整备注", IsNullable = true)]
    public string? AdjustmentRemarks { get; set; }
    #endregion
  }
}