/******************************************************************************
 * 文件名称：KpPositionTitle.cs
 * 文件描述：职称信息实体类
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
  /// 职称信息实体类
  /// </summary>
  [SugarTable("kp_hr_position_title", "职称信息")]
  [SugarIndex("idx_position_title_code", nameof(PositionTitleCode), OrderByType.Asc)]
  public class KpPositionTitle : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 职称编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "position_title_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职称编码", IsNullable = false)]
    public string? PositionTitleCode { get; set; }

    /// <summary>
    /// 职称名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "position_title_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "职称名称", IsNullable = false)]
    public string? PositionTitleName { get; set; }

    /// <summary>
    /// 职称类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_title_type", ColumnDescription = "职称类型", IsNullable = false)]
    public int PositionTitleType { get; set; }

    /// <summary>
    /// 职称等级
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_title_level", ColumnDescription = "职称等级", IsNullable = false)]
    public int PositionTitleLevel { get; set; }

    /// <summary>
    /// 职称描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_title_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "职称描述", IsNullable = true)]
    public string? PositionTitleDescription { get; set; }
    #endregion

    #region 评审信息
    /// <summary>
    /// 评审条件
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "evaluation_condition", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "评审条件", IsNullable = true)]
    public string? EvaluationCondition { get; set; }

    /// <summary>
    /// 评审标准
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "evaluation_standard", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "评审标准", IsNullable = true)]
    public string? EvaluationStandard { get; set; }

    /// <summary>
    /// 评审周期
    /// </summary>
    [SugarColumn(ColumnName = "evaluation_period", ColumnDescription = "评审周期", IsNullable = true)]
    public int? EvaluationPeriod { get; set; }

    /// <summary>
    /// 评审机构
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "evaluation_organization", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "评审机构", IsNullable = true)]
    public string? EvaluationOrganization { get; set; }
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
    /// 职称备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_title_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "职称备注", IsNullable = true)]
    public string? PositionTitleRemarks { get; set; }
    #endregion
  }
}