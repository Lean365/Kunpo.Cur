/******************************************************************************
 * 文件名称：KpRecruitment.cs
 * 文件描述：招聘需求实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Recruitment
{
  /// <summary>
  /// 招聘需求实体类
  /// </summary>
  [SugarTable("kp_hr_recruitment", "招聘需求")]
  [SugarIndex("idx_recruitment_code", nameof(RecruitmentCode), OrderByType.Asc)]
  public class KpRecruitment : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 需求编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "recruitment_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "需求编码", IsNullable = false)]
    public string? RecruitmentCode { get; set; }

    /// <summary>
    /// 需求名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "recruitment_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "需求名称", IsNullable = false)]
    public string? RecruitmentName { get; set; }

    /// <summary>
    /// 需求类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "recruitment_type", ColumnDescription = "需求类型", IsNullable = false)]
    public int RecruitmentType { get; set; }

    /// <summary>
    /// 需求状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "recruitment_status", ColumnDescription = "需求状态", IsNullable = false)]
    public int RecruitmentStatus { get; set; }

    /// <summary>
    /// 需求描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "recruitment_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "需求描述", IsNullable = true)]
    public string? RecruitmentDescription { get; set; }
    #endregion

    #region 岗位信息
    /// <summary>
    /// 部门编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "department_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "部门编码", IsNullable = false)]
    public string? DepartmentCode { get; set; }

    /// <summary>
    /// 职位编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职位编码", IsNullable = false)]
    public string? JobCode { get; set; }

    /// <summary>
    /// 职级编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "job_level_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "职级编码", IsNullable = false)]
    public string? JobLevelCode { get; set; }

    /// <summary>
    /// 需求人数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "required_number", ColumnDescription = "需求人数", IsNullable = false)]
    public int RequiredNumber { get; set; }

    /// <summary>
    /// 工作地点
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "work_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "工作地点", IsNullable = false)]
    public string? WorkLocation { get; set; }
    #endregion

    #region 任职要求
    /// <summary>
    /// 学历要求
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "education_requirement", ColumnDescription = "学历要求", IsNullable = false)]
    public int EducationRequirement { get; set; }

    /// <summary>
    /// 工作经验
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "work_experience", ColumnDescription = "工作经验", IsNullable = false)]
    public int WorkExperience { get; set; }

    /// <summary>
    /// 技能要求
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "skill_requirement", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "技能要求", IsNullable = true)]
    public string? SkillRequirement { get; set; }

    /// <summary>
    /// 其他要求
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "other_requirement", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "其他要求", IsNullable = true)]
    public string? OtherRequirement { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 需求日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "required_date", ColumnDataType = "date", ColumnDescription = "需求日期", IsNullable = false)]
    public DateTime RequiredDate { get; set; }

    /// <summary>
    /// 截止日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "deadline_date", ColumnDataType = "date", ColumnDescription = "截止日期", IsNullable = false)]
    public DateTime DeadlineDate { get; set; }

    /// <summary>
    /// 预计入职日期
    /// </summary>
    [SugarColumn(ColumnName = "expected_join_date", ColumnDataType = "date", ColumnDescription = "预计入职日期", IsNullable = true)]
    public DateTime? ExpectedJoinDate { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否紧急
    /// </summary>
    [SugarColumn(ColumnName = "is_urgent", ColumnDescription = "是否紧急", IsNullable = false, DefaultValue = "0")]
    public bool IsUrgent { get; set; }

    /// <summary>
    /// 是否内部招聘
    /// </summary>
    [SugarColumn(ColumnName = "is_internal", ColumnDescription = "是否内部招聘", IsNullable = false, DefaultValue = "0")]
    public bool IsInternal { get; set; }

    /// <summary>
    /// 需求备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "recruitment_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "需求备注", IsNullable = true)]
    public string? RecruitmentRemarks { get; set; }
    #endregion
  }
}