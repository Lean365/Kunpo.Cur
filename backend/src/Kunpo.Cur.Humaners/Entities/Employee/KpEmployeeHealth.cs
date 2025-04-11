/******************************************************************************
 * 文件名称：KpEmployeeHealth.cs
 * 文件描述：员工健康信息实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Employee
{
  /// <summary>
  /// 员工健康信息实体类
  /// </summary>
  [SugarTable("kp_hr_employee_health", "员工健康信息")]
  [SugarIndex("idx_employee_health_code", nameof(HealthCode), OrderByType.Asc)]
  public class KpEmployeeHealth : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 健康信息编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "health_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "健康信息编码", IsNullable = false)]
    public string? HealthCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 健康信息类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "health_type", ColumnDescription = "健康信息类型", IsNullable = false)]
    public int HealthType { get; set; }

    /// <summary>
    /// 健康信息状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "health_status", ColumnDescription = "健康信息状态", IsNullable = false)]
    public int HealthStatus { get; set; }

    /// <summary>
    /// 健康信息描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "health_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "健康信息描述", IsNullable = true)]
    public string? HealthDescription { get; set; }
    #endregion

    #region 健康信息
    /// <summary>
    /// 身高
    /// </summary>
    [SugarColumn(ColumnName = "height", ColumnDescription = "身高", IsNullable = true)]
    public decimal? Height { get; set; }

    /// <summary>
    /// 体重
    /// </summary>
    [SugarColumn(ColumnName = "weight", ColumnDescription = "体重", IsNullable = true)]
    public decimal? Weight { get; set; }

    /// <summary>
    /// 血型
    /// </summary>
    [StringLength(10)]
    [SugarColumn(ColumnName = "blood_type", ColumnDataType = "nvarchar", Length = 10, ColumnDescription = "血型", IsNullable = true)]
    public string? BloodType { get; set; }

    /// <summary>
    /// 视力
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "vision", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "视力", IsNullable = true)]
    public string? Vision { get; set; }

    /// <summary>
    /// 听力
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "hearing", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "听力", IsNullable = true)]
    public string? Hearing { get; set; }

    /// <summary>
    /// 健康状况
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "health_condition", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "健康状况", IsNullable = true)]
    public string? HealthCondition { get; set; }

    /// <summary>
    /// 过敏史
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "allergy_history", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "过敏史", IsNullable = true)]
    public string? AllergyHistory { get; set; }

    /// <summary>
    /// 慢性病史
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "chronic_disease_history", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "慢性病史", IsNullable = true)]
    public string? ChronicDiseaseHistory { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 记录时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "record_time", ColumnDescription = "记录时间", IsNullable = false)]
    public DateTime RecordTime { get; set; }

    /// <summary>
    /// 下次体检时间
    /// </summary>
    [SugarColumn(ColumnName = "next_medical_exam_time", ColumnDescription = "下次体检时间", IsNullable = true)]
    public DateTime? NextMedicalExamTime { get; set; }
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
    /// 健康信息备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "health_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "健康信息备注", IsNullable = true)]
    public string? HealthRemarks { get; set; }
    #endregion
  }
}