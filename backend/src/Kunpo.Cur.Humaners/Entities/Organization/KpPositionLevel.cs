/******************************************************************************
 * 文件名称：KpPositionLevel.cs
 * 文件描述：岗位级别实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Organization
{
  /// <summary>
  /// 岗位级别实体类
  /// </summary>
  [SugarTable("kp_hr_position_level", "岗位级别")]
  [SugarIndex("idx_position_level_code", nameof(PositionLevelCode), OrderByType.Asc)]
  public class KpPositionLevel : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 岗位级别编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "position_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "岗位级别编码", IsNullable = false)]
    public string? PositionLevelCode { get; set; }

    /// <summary>
    /// 岗位级别名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "position_level_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "岗位级别名称", IsNullable = false)]
    public string? PositionLevelName { get; set; }

    /// <summary>
    /// 岗位级别类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_level_type", ColumnDescription = "岗位级别类型", IsNullable = false)]
    public int PositionLevelType { get; set; }

    /// <summary>
    /// 岗位级别状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_level_status", ColumnDescription = "岗位级别状态", IsNullable = false)]
    public int PositionLevelStatus { get; set; }

    /// <summary>
    /// 岗位级别描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_level_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "岗位级别描述", IsNullable = true)]
    public string? PositionLevelDescription { get; set; }
    #endregion

    #region 级别信息
    /// <summary>
    /// 岗位级别序列
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_level_sequence", ColumnDescription = "岗位级别序列", IsNullable = false)]
    public int PositionLevelSequence { get; set; }

    /// <summary>
    /// 岗位级别等级
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_level_grade", ColumnDescription = "岗位级别等级", IsNullable = false)]
    public int PositionLevelGrade { get; set; }

    /// <summary>
    /// 岗位级别系数
    /// </summary>
    [SugarColumn(ColumnName = "position_level_factor", ColumnDescription = "岗位级别系数", IsNullable = true)]
    public decimal? PositionLevelFactor { get; set; }

    /// <summary>
    /// 岗位级别薪资范围
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "position_level_salary_range", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "岗位级别薪资范围", IsNullable = true)]
    public string? PositionLevelSalaryRange { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDescription = "是否启用", IsNullable = false, DefaultValue = "1")]
    public bool IsEnabled { get; set; }

    /// <summary>
    /// 岗位级别备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_level_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "岗位级别备注", IsNullable = true)]
    public string? PositionLevelRemarks { get; set; }
    #endregion
  }
}