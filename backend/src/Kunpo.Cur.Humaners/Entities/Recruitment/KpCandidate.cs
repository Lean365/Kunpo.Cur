/******************************************************************************
 * 文件名称：KpCandidate.cs
 * 文件描述：候选人信息实体类
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
  /// 候选人信息实体类
  /// </summary>
  [SugarTable("kp_hr_candidate", "候选人信息")]
  [SugarIndex("idx_candidate_code", nameof(CandidateCode), OrderByType.Asc)]
  public class KpCandidate : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 候选人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "candidate_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "候选人编码", IsNullable = false)]
    public string? CandidateCode { get; set; }

    /// <summary>
    /// 候选人姓名
    /// </summary>
    [Required]
    [StringLength(50)]
    [SugarColumn(ColumnName = "candidate_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "候选人姓名", IsNullable = false)]
    public string? CandidateName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "gender", ColumnDescription = "性别", IsNullable = false)]
    public int Gender { get; set; }

    /// <summary>
    /// 出生日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "birth_date", ColumnDataType = "date", ColumnDescription = "出生日期", IsNullable = false)]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = false)]
    public string? Phone { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = false)]
    public string? Email { get; set; }
    #endregion

    #region 教育信息
    /// <summary>
    /// 最高学历
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "highest_education", ColumnDescription = "最高学历", IsNullable = false)]
    public int HighestEducation { get; set; }

    /// <summary>
    /// 毕业院校
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "graduate_school", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "毕业院校", IsNullable = false)]
    public string? GraduateSchool { get; set; }

    /// <summary>
    /// 专业
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "major", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "专业", IsNullable = false)]
    public string? Major { get; set; }

    /// <summary>
    /// 毕业时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "graduate_date", ColumnDataType = "date", ColumnDescription = "毕业时间", IsNullable = false)]
    public DateTime GraduateDate { get; set; }
    #endregion

    #region 工作信息
    /// <summary>
    /// 工作经验
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "work_experience", ColumnDescription = "工作经验", IsNullable = false)]
    public int WorkExperience { get; set; }

    /// <summary>
    /// 当前公司
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "current_company", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "当前公司", IsNullable = true)]
    public string? CurrentCompany { get; set; }

    /// <summary>
    /// 当前职位
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "current_position", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "当前职位", IsNullable = true)]
    public string? CurrentPosition { get; set; }

    /// <summary>
    /// 期望薪资
    /// </summary>
    [SugarColumn(ColumnName = "expected_salary", ColumnDescription = "期望薪资", IsNullable = true)]
    public decimal? ExpectedSalary { get; set; }
    #endregion

    #region 应聘信息
    /// <summary>
    /// 招聘需求编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "recruitment_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "招聘需求编码", IsNullable = false)]
    public string? RecruitmentCode { get; set; }

    /// <summary>
    /// 应聘状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "application_status", ColumnDescription = "应聘状态", IsNullable = false)]
    public int ApplicationStatus { get; set; }

    /// <summary>
    /// 应聘渠道
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "application_channel", ColumnDescription = "应聘渠道", IsNullable = false)]
    public int ApplicationChannel { get; set; }

    /// <summary>
    /// 应聘时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "application_date", ColumnDataType = "datetime", ColumnDescription = "应聘时间", IsNullable = false)]
    public DateTime ApplicationDate { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 简历路径
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "resume_path", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "简历路径", IsNullable = true)]
    public string? ResumePath { get; set; }

    /// <summary>
    /// 候选人备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "candidate_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "候选人备注", IsNullable = true)]
    public string? CandidateRemarks { get; set; }
    #endregion
  }
}