/******************************************************************************
 * 文件名称：KpTrainingMaterial.cs
 * 文件描述：培训教材实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Training
{
  /// <summary>
  /// 培训教材实体类
  /// </summary>
  [SugarTable("kp_hr_training_material", "培训教材")]
  [SugarIndex("idx_training_material_code", nameof(MaterialCode), OrderByType.Asc)]
  public class KpTrainingMaterial : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 教材编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "教材编码", IsNullable = false)]
    public string? MaterialCode { get; set; }

    /// <summary>
    /// 教材名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "material_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "教材名称", IsNullable = false)]
    public string? MaterialName { get; set; }

    /// <summary>
    /// 教材类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "material_type", ColumnDescription = "教材类型", IsNullable = false)]
    public int MaterialType { get; set; }

    /// <summary>
    /// 教材状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "material_status", ColumnDescription = "教材状态", IsNullable = false)]
    public int MaterialStatus { get; set; }

    /// <summary>
    /// 教材描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "教材描述", IsNullable = true)]
    public string? MaterialDescription { get; set; }
    #endregion

    #region 教材信息
    /// <summary>
    /// 培训计划编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "plan_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "培训计划编码", IsNullable = false)]
    public string? PlanCode { get; set; }

    /// <summary>
    /// 教材版本
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_version", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "教材版本", IsNullable = false)]
    public string? MaterialVersion { get; set; }

    /// <summary>
    /// 教材格式
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "material_format", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "教材格式", IsNullable = false)]
    public string? MaterialFormat { get; set; }

    /// <summary>
    /// 教材大小
    /// </summary>
    [SugarColumn(ColumnName = "material_size", ColumnDescription = "教材大小", IsNullable = true)]
    public long? MaterialSize { get; set; }

    /// <summary>
    /// 教材路径
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_path", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "教材路径", IsNullable = false)]
    public string? MaterialPath { get; set; }

    /// <summary>
    /// 教材URL
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_url", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "教材URL", IsNullable = true)]
    public string? MaterialUrl { get; set; }
    #endregion

    #region 使用信息
    /// <summary>
    /// 使用次数
    /// </summary>
    [SugarColumn(ColumnName = "usage_count", ColumnDescription = "使用次数", IsNullable = false, DefaultValue = "0")]
    public int UsageCount { get; set; }

    /// <summary>
    /// 最后使用时间
    /// </summary>
    [SugarColumn(ColumnName = "last_used_time", ColumnDataType = "datetime", ColumnDescription = "最后使用时间", IsNullable = true)]
    public DateTime? LastUsedTime { get; set; }

    /// <summary>
    /// 使用部门
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "usage_departments", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "使用部门", IsNullable = true)]
    public string? UsageDepartments { get; set; }

    /// <summary>
    /// 使用职位
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "usage_positions", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "使用职位", IsNullable = true)]
    public string? UsagePositions { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否公开
    /// </summary>
    [SugarColumn(ColumnName = "is_public", ColumnDescription = "是否公开", IsNullable = false, DefaultValue = "0")]
    public bool IsPublic { get; set; }

    /// <summary>
    /// 是否系统预设
    /// </summary>
    [SugarColumn(ColumnName = "is_system_preset", ColumnDescription = "是否系统预设", IsNullable = false, DefaultValue = "0")]
    public bool IsSystemPreset { get; set; }

    /// <summary>
    /// 教材备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "material_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "教材备注", IsNullable = true)]
    public string? MaterialRemarks { get; set; }
    #endregion
  }
}