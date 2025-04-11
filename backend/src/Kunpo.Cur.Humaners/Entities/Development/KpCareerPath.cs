/******************************************************************************
 * 文件名称：KpCareerPath.cs
 * 文件描述：职业发展路径实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Development
{
  /// <summary>
  /// 职业发展路径实体类
  /// </summary>
  [SugarTable("kp_hr_career_path", "职业发展路径")]
  [SugarIndex("idx_career_path_code", nameof(CareerPathCode), OrderByType.Asc)]
  public class KpCareerPath : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 发展路径编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "career_path_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "发展路径编码", IsNullable = false)]
    public string? CareerPathCode { get; set; }

    /// <summary>
    /// 发展路径名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "career_path_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "发展路径名称", IsNullable = false)]
    public string? CareerPathName { get; set; }

    /// <summary>
    /// 发展路径类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "career_path_type", ColumnDescription = "发展路径类型", IsNullable = false)]
    public int CareerPathType { get; set; }

    /// <summary>
    /// 发展路径状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "career_path_status", ColumnDescription = "发展路径状态", IsNullable = false)]
    public int CareerPathStatus { get; set; }

    /// <summary>
    /// 发展路径描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "career_path_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "发展路径描述", IsNullable = true)]
    public string? CareerPathDescription { get; set; }
    #endregion

    #region 路径信息
    /// <summary>
    /// 起始岗位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "start_job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "起始岗位编码", IsNullable = false)]
    public string? StartJobCode { get; set; }

    /// <summary>
    /// 目标岗位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "target_job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "目标岗位编码", IsNullable = false)]
    public string? TargetJobCode { get; set; }

    /// <summary>
    /// 发展周期
    /// </summary>
    [SugarColumn(ColumnName = "development_period", ColumnDescription = "发展周期", IsNullable = true)]
    public int? DevelopmentPeriod { get; set; }

    /// <summary>
    /// 发展要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "development_requirement", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "发展要求", IsNullable = true)]
    public string? DevelopmentRequirement { get; set; }
    #endregion

    #region 能力要求
    /// <summary>
    /// 技能要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "skill_requirement", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "技能要求", IsNullable = true)]
    public string? SkillRequirement { get; set; }

    /// <summary>
    /// 知识要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "knowledge_requirement", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "知识要求", IsNullable = true)]
    public string? KnowledgeRequirement { get; set; }

    /// <summary>
    /// 经验要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "experience_requirement", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "经验要求", IsNullable = true)]
    public string? ExperienceRequirement { get; set; }
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
    /// 发展路径备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "career_path_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "发展路径备注", IsNullable = true)]
    public string? CareerPathRemarks { get; set; }
    #endregion
  }
}