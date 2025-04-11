/******************************************************************************
 * 文件名称：KpBusinessTrip.cs
 * 文件描述：出差记录实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Attendance
{
  /// <summary>
  /// 出差记录实体类
  /// </summary>
  [SugarTable("kp_hr_business_trip", "出差记录")]
  [SugarIndex("idx_business_trip_employee", nameof(EmployeeCode), OrderByType.Asc)]
  public class KpBusinessTrip : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 出差类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "trip_type", ColumnDescription = "出差类型", IsNullable = false)]
    public int TripType { get; set; }

    /// <summary>
    /// 出差状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "trip_status", ColumnDescription = "出差状态", IsNullable = false)]
    public int TripStatus { get; set; }

    /// <summary>
    /// 出差事由
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "trip_reason", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "出差事由", IsNullable = false)]
    public string? TripReason { get; set; }
    #endregion

    #region 出差信息
    /// <summary>
    /// 开始时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "start_time", ColumnDataType = "datetime", ColumnDescription = "开始时间", IsNullable = false)]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "end_time", ColumnDataType = "datetime", ColumnDescription = "结束时间", IsNullable = false)]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 出差天数
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "trip_days", ColumnDataType = "decimal", Length = 5, DecimalDigits = 2, ColumnDescription = "出差天数", IsNullable = false)]
    public decimal TripDays { get; set; }

    /// <summary>
    /// 出差地点
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "trip_location", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "出差地点", IsNullable = false)]
    public string? TripLocation { get; set; }

    /// <summary>
    /// 出差任务
    /// </summary>
    [Required]
    [StringLength(500)]
    [SugarColumn(ColumnName = "trip_task", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "出差任务", IsNullable = false)]
    public string? TripTask { get; set; }
    #endregion

    #region 费用信息
    /// <summary>
    /// 交通费用
    /// </summary>
    [SugarColumn(ColumnName = "transport_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "交通费用", IsNullable = true)]
    public decimal? TransportCost { get; set; }

    /// <summary>
    /// 住宿费用
    /// </summary>
    [SugarColumn(ColumnName = "accommodation_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "住宿费用", IsNullable = true)]
    public decimal? AccommodationCost { get; set; }

    /// <summary>
    /// 餐饮费用
    /// </summary>
    [SugarColumn(ColumnName = "meal_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "餐饮费用", IsNullable = true)]
    public decimal? MealCost { get; set; }

    /// <summary>
    /// 其他费用
    /// </summary>
    [SugarColumn(ColumnName = "other_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "其他费用", IsNullable = true)]
    public decimal? OtherCost { get; set; }

    /// <summary>
    /// 费用总额
    /// </summary>
    [SugarColumn(ColumnName = "total_cost", ColumnDataType = "decimal", Length = 10, DecimalDigits = 2, ColumnDescription = "费用总额", IsNullable = true)]
    public decimal? TotalCost { get; set; }
    #endregion

    #region 审批信息
    /// <summary>
    /// 审批人
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "approver", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "审批人", IsNullable = true)]
    public string? Approver { get; set; }

    /// <summary>
    /// 审批时间
    /// </summary>
    [SugarColumn(ColumnName = "approval_time", ColumnDataType = "datetime", ColumnDescription = "审批时间", IsNullable = true)]
    public DateTime? ApprovalTime { get; set; }

    /// <summary>
    /// 审批意见
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "approval_comment", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "审批意见", IsNullable = true)]
    public string? ApprovalComment { get; set; }
    #endregion

    #region 其他信息
    /// <summary>
    /// 是否紧急
    /// </summary>
    [SugarColumn(ColumnName = "is_urgent", ColumnDescription = "是否紧急", IsNullable = false, DefaultValue = "0")]
    public bool IsUrgent { get; set; }

    /// <summary>
    /// 是否报销
    /// </summary>
    [SugarColumn(ColumnName = "is_reimbursed", ColumnDescription = "是否报销", IsNullable = false, DefaultValue = "0")]
    public bool IsReimbursed { get; set; }

    /// <summary>
    /// 报销时间
    /// </summary>
    [SugarColumn(ColumnName = "reimbursement_time", ColumnDataType = "datetime", ColumnDescription = "报销时间", IsNullable = true)]
    public DateTime? ReimbursementTime { get; set; }

    /// <summary>
    /// 出差备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "trip_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "出差备注", IsNullable = true)]
    public string? TripRemarks { get; set; }
    #endregion
  }
}