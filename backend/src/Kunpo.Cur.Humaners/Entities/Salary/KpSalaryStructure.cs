/******************************************************************************
 * 文件名称：KpSalaryStructure.cs
 * 文件描述：薪资结构实体类
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
  /// 薪资结构实体类
  /// </summary>
  [SugarTable("kp_hr_salary_structure", "薪资结构")]
  [SugarIndex("idx_salary_structure_code", nameof(StructureCode), OrderByType.Asc)]
  public class KpSalaryStructure : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 结构编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "structure_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "结构编码", IsNullable = false)]
    public string? StructureCode { get; set; }

    /// <summary>
    /// 结构名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "structure_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "结构名称", IsNullable = false)]
    public string? StructureName { get; set; }

    /// <summary>
    /// 结构简称
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "structure_short_name", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "结构简称", IsNullable = true)]
    public string? StructureShortName { get; set; }

    /// <summary>
    /// 结构英文名
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "structure_english_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "结构英文名", IsNullable = true)]
    public string? StructureEnglishName { get; set; }

    /// <summary>
    /// 结构类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "structure_type", ColumnDescription = "结构类型", IsNullable = false)]
    public int StructureType { get; set; }

    /// <summary>
    /// 结构状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "structure_status", ColumnDescription = "结构状态", IsNullable = false)]
    public int StructureStatus { get; set; }

    /// <summary>
    /// 结构描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "structure_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "结构描述", IsNullable = true)]
    public string? StructureDescription { get; set; }
    #endregion

    #region 适用信息
    /// <summary>
    /// 适用部门
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "applicable_departments", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "适用部门", IsNullable = true)]
    public string? ApplicableDepartments { get; set; }

    /// <summary>
    /// 适用职位
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "applicable_positions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "适用职位", IsNullable = true)]
    public string? ApplicablePositions { get; set; }

    /// <summary>
    /// 适用职级
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "applicable_job_levels", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "适用职级", IsNullable = true)]
    public string? ApplicableJobLevels { get; set; }

    /// <summary>
    /// 适用员工类型
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "applicable_employee_types", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "适用员工类型", IsNullable = true)]
    public string? ApplicableEmployeeTypes { get; set; }
    #endregion

    #region 薪资项目
    /// <summary>
    /// 基本工资项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "base_salary_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "基本工资项目", IsNullable = true)]
    public string? BaseSalaryItem { get; set; }

    /// <summary>
    /// 岗位工资项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "position_salary_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "岗位工资项目", IsNullable = true)]
    public string? PositionSalaryItem { get; set; }

    /// <summary>
    /// 绩效工资项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "performance_salary_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "绩效工资项目", IsNullable = true)]
    public string? PerformanceSalaryItem { get; set; }

    /// <summary>
    /// 加班工资项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "overtime_salary_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "加班工资项目", IsNullable = true)]
    public string? OvertimeSalaryItem { get; set; }

    /// <summary>
    /// 津贴项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "allowance_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "津贴项目", IsNullable = true)]
    public string? AllowanceItem { get; set; }

    /// <summary>
    /// 奖金项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "bonus_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "奖金项目", IsNullable = true)]
    public string? BonusItem { get; set; }

    /// <summary>
    /// 其他收入项目
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "other_income_item", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "其他收入项目", IsNullable = true)]
    public string? OtherIncomeItem { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否默认
    /// </summary>
    [SugarColumn(ColumnName = "is_default", ColumnDescription = "是否默认", IsNullable = false, DefaultValue = "0")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// 是否允许修改
    /// </summary>
    [SugarColumn(ColumnName = "is_allow_modify", ColumnDescription = "是否允许修改", IsNullable = false, DefaultValue = "1")]
    public bool IsAllowModify { get; set; }

    /// <summary>
    /// 结构备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "structure_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "结构备注", IsNullable = true)]
    public string? StructureRemarks { get; set; }
    #endregion
  }
}