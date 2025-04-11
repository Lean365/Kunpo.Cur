/******************************************************************************
 * 文件名称：KpPosition.cs
 * 文件描述：职位实体类
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
  /// 职位实体类
  /// </summary>
  [SugarTable("kp_hr_position", "职位")]
  [SugarIndex("idx_position_code", nameof(PositionCode), OrderByType.Asc)]
  public class KpPosition : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 职位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "position_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职位编码", IsNullable = false)]
    public string? PositionCode { get; set; }

    /// <summary>
    /// 职位名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "position_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "职位名称", IsNullable = false)]
    public string? PositionName { get; set; }

    /// <summary>
    /// 职位类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_type", ColumnDescription = "职位类型", IsNullable = false)]
    public int PositionType { get; set; }

    /// <summary>
    /// 职位状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "position_status", ColumnDescription = "职位状态", IsNullable = false)]
    public int PositionStatus { get; set; }

    /// <summary>
    /// 职位描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "职位描述", IsNullable = true)]
    public string? PositionDescription { get; set; }
    #endregion

    #region 组织信息
    /// <summary>
    /// 部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "部门编码", IsNullable = false)]
    public string? DepartmentCode { get; set; }

    /// <summary>
    /// 职级编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职级编码", IsNullable = false)]
    public string? JobLevelCode { get; set; }

    /// <summary>
    /// 职称编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_title_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职称编码", IsNullable = true)]
    public string? JobTitleCode { get; set; }
    #endregion

    #region 职责信息
    /// <summary>
    /// 职位职责
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "position_responsibility", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "职位职责", IsNullable = true)]
    public string? PositionResponsibility { get; set; }

    /// <summary>
    /// 职位要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "position_requirement", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "职位要求", IsNullable = true)]
    public string? PositionRequirement { get; set; }

    /// <summary>
    /// 职位内容
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "position_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "职位内容", IsNullable = true)]
    public string? PositionContent { get; set; }
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
    /// 职位备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "position_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "职位备注", IsNullable = true)]
    public string? PositionRemarks { get; set; }
    #endregion
  }
}