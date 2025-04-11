/******************************************************************************
 * 文件名称：KpOffer.cs
 * 文件描述：录用通知实体类
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
  /// 录用通知实体类
  /// </summary>
  [SugarTable("kp_hr_offer", "录用通知")]
  [SugarIndex("idx_offer_code", nameof(OfferCode), OrderByType.Asc)]
  public class KpOffer : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 录用通知编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "offer_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "录用通知编码", IsNullable = false)]
    public string? OfferCode { get; set; }

    /// <summary>
    /// 候选人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "candidate_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "候选人编码", IsNullable = false)]
    public string? CandidateCode { get; set; }

    /// <summary>
    /// 招聘需求编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "recruitment_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "招聘需求编码", IsNullable = false)]
    public string? RecruitmentCode { get; set; }

    /// <summary>
    /// 录用状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "offer_status", ColumnDescription = "录用状态", IsNullable = false)]
    public int OfferStatus { get; set; }
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
    /// 工作地点
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "work_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "工作地点", IsNullable = false)]
    public string? WorkLocation { get; set; }
    #endregion

    #region 薪资信息
    /// <summary>
    /// 基本工资
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "base_salary", ColumnDescription = "基本工资", IsNullable = false)]
    public decimal BaseSalary { get; set; }

    /// <summary>
    /// 绩效工资
    /// </summary>
    [SugarColumn(ColumnName = "performance_salary", ColumnDescription = "绩效工资", IsNullable = true)]
    public decimal? PerformanceSalary { get; set; }

    /// <summary>
    /// 津贴补贴
    /// </summary>
    [SugarColumn(ColumnName = "allowance", ColumnDescription = "津贴补贴", IsNullable = true)]
    public decimal? Allowance { get; set; }

    /// <summary>
    /// 其他收入
    /// </summary>
    [SugarColumn(ColumnName = "other_income", ColumnDescription = "其他收入", IsNullable = true)]
    public decimal? OtherIncome { get; set; }
    #endregion

    #region 入职信息
    /// <summary>
    /// 入职日期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "join_date", ColumnDataType = "date", ColumnDescription = "入职日期", IsNullable = false)]
    public DateTime JoinDate { get; set; }

    /// <summary>
    /// 试用期
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "probation_period", ColumnDescription = "试用期", IsNullable = false)]
    public int ProbationPeriod { get; set; }

    /// <summary>
    /// 劳动合同期限
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "contract_period", ColumnDescription = "劳动合同期限", IsNullable = false)]
    public int ContractPeriod { get; set; }

    /// <summary>
    /// 报到地点
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "report_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "报到地点", IsNullable = false)]
    public string? ReportLocation { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否接受
    /// </summary>
    [SugarColumn(ColumnName = "is_accepted", ColumnDescription = "是否接受", IsNullable = false, DefaultValue = "0")]
    public bool IsAccepted { get; set; }

    /// <summary>
    /// 接受时间
    /// </summary>
    [SugarColumn(ColumnName = "accept_time", ColumnDataType = "datetime", ColumnDescription = "接受时间", IsNullable = true)]
    public DateTime? AcceptTime { get; set; }

    /// <summary>
    /// 录用备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "offer_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "录用备注", IsNullable = true)]
    public string? OfferRemarks { get; set; }
    #endregion
  }
}