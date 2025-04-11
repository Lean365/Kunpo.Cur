/******************************************************************************
 * 文件名称：KpSalaryItem.cs
 * 文件描述：薪资项目实体类
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
  /// 薪资项目实体类
  /// </summary>
  [SugarTable("kp_hr_salary_item", "薪资项目")]
  [SugarIndex("idx_salary_item_code", nameof(ItemCode), OrderByType.Asc)]
  public class KpSalaryItem : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 项目编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "item_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "项目编码", IsNullable = false)]
    public string? ItemCode { get; set; }

    /// <summary>
    /// 项目名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "item_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "项目名称", IsNullable = false)]
    public string? ItemName { get; set; }

    /// <summary>
    /// 项目简称
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "item_short_name", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "项目简称", IsNullable = true)]
    public string? ItemShortName { get; set; }

    /// <summary>
    /// 项目英文名
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "item_english_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "项目英文名", IsNullable = true)]
    public string? ItemEnglishName { get; set; }

    /// <summary>
    /// 项目类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "item_type", ColumnDescription = "项目类型", IsNullable = false)]
    public int ItemType { get; set; }

    /// <summary>
    /// 项目状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "item_status", ColumnDescription = "项目状态", IsNullable = false)]
    public int ItemStatus { get; set; }

    /// <summary>
    /// 项目描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "item_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "项目描述", IsNullable = true)]
    public string? ItemDescription { get; set; }
    #endregion

    #region 计算规则
    /// <summary>
    /// 计算方式
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "calculation_method", ColumnDescription = "计算方式", IsNullable = false)]
    public int CalculationMethod { get; set; }

    /// <summary>
    /// 计算公式
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "calculation_formula", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "计算公式", IsNullable = true)]
    public string? CalculationFormula { get; set; }

    /// <summary>
    /// 计算顺序
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "calculation_order", ColumnDescription = "计算顺序", IsNullable = false)]
    public int CalculationOrder { get; set; }

    /// <summary>
    /// 是否参与个税计算
    /// </summary>
    [SugarColumn(ColumnName = "is_taxable", ColumnDescription = "是否参与个税计算", IsNullable = false, DefaultValue = "0")]
    public bool IsTaxable { get; set; }

    /// <summary>
    /// 是否参与社保计算
    /// </summary>
    [SugarColumn(ColumnName = "is_social_security", ColumnDescription = "是否参与社保计算", IsNullable = false, DefaultValue = "0")]
    public bool IsSocialSecurity { get; set; }

    /// <summary>
    /// 是否参与公积金计算
    /// </summary>
    [SugarColumn(ColumnName = "is_housing_fund", ColumnDescription = "是否参与公积金计算", IsNullable = false, DefaultValue = "0")]
    public bool IsHousingFund { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否必填
    /// </summary>
    [SugarColumn(ColumnName = "is_required", ColumnDescription = "是否必填", IsNullable = false, DefaultValue = "0")]
    public bool IsRequired { get; set; }

    /// <summary>
    /// 是否显示
    /// </summary>
    [SugarColumn(ColumnName = "is_visible", ColumnDescription = "是否显示", IsNullable = false, DefaultValue = "1")]
    public bool IsVisible { get; set; }

    /// <summary>
    /// 项目备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "item_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "项目备注", IsNullable = true)]
    public string? ItemRemarks { get; set; }
    #endregion
  }
}