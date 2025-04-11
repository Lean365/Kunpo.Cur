/******************************************************************************
 * 文件名称：KpEmployeeMedical.cs
 * 文件描述：员工医疗记录实体类
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
  /// 员工医疗记录实体类
  /// </summary>
  [SugarTable("kp_hr_employee_medical", "员工医疗记录")]
  [SugarIndex("idx_employee_medical_code", nameof(MedicalCode), OrderByType.Asc)]
  public class KpEmployeeMedical : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 医疗记录编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "medical_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "医疗记录编码", IsNullable = false)]
    public string? MedicalCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 医疗记录类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "medical_type", ColumnDescription = "医疗记录类型", IsNullable = false)]
    public int MedicalType { get; set; }

    /// <summary>
    /// 医疗记录状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "medical_status", ColumnDescription = "医疗记录状态", IsNullable = false)]
    public int MedicalStatus { get; set; }

    /// <summary>
    /// 医疗记录描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "medical_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "医疗记录描述", IsNullable = true)]
    public string? MedicalDescription { get; set; }
    #endregion

    #region 医疗信息
    /// <summary>
    /// 医疗机构
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "medical_institution", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "医疗机构", IsNullable = true)]
    public string? MedicalInstitution { get; set; }

    /// <summary>
    /// 主治医生
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "attending_doctor", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "主治医生", IsNullable = true)]
    public string? AttendingDoctor { get; set; }

    /// <summary>
    /// 诊断结果
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "diagnosis_result", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "诊断结果", IsNullable = true)]
    public string? DiagnosisResult { get; set; }

    /// <summary>
    /// 治疗方案
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "treatment_plan", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "治疗方案", IsNullable = true)]
    public string? TreatmentPlan { get; set; }

    /// <summary>
    /// 用药记录
    /// </summary>
    [StringLength(1000)]
    [SugarColumn(ColumnName = "medication_record", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "用药记录", IsNullable = true)]
    public string? MedicationRecord { get; set; }

    /// <summary>
    /// 医疗费用
    /// </summary>
    [SugarColumn(ColumnName = "medical_cost", ColumnDescription = "医疗费用", IsNullable = true)]
    public decimal? MedicalCost { get; set; }

    /// <summary>
    /// 报销金额
    /// </summary>
    [SugarColumn(ColumnName = "reimbursement_amount", ColumnDescription = "报销金额", IsNullable = true)]
    public decimal? ReimbursementAmount { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 就诊时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "medical_time", ColumnDescription = "就诊时间", IsNullable = false)]
    public DateTime MedicalTime { get; set; }

    /// <summary>
    /// 复诊时间
    /// </summary>
    [SugarColumn(ColumnName = "follow_up_time", ColumnDescription = "复诊时间", IsNullable = true)]
    public DateTime? FollowUpTime { get; set; }

    /// <summary>
    /// 康复时间
    /// </summary>
    [SugarColumn(ColumnName = "recovery_time", ColumnDescription = "康复时间", IsNullable = true)]
    public DateTime? RecoveryTime { get; set; }
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
    /// 医疗记录备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "medical_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "医疗记录备注", IsNullable = true)]
    public string? MedicalRemarks { get; set; }
    #endregion
  }
}