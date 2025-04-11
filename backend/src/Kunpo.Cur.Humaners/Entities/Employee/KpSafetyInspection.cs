/******************************************************************************
 * 文件名称：KpSafetyInspection.cs
 * 文件描述：安全检查实体类
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
  /// 安全检查实体类
  /// </summary>
  [SugarTable("kp_hr_safety_inspection", "安全检查")]
  [SugarIndex("idx_safety_inspection_code", nameof(InspectionCode), OrderByType.Asc)]
  public class KpSafetyInspection : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 检查编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "inspection_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "检查编码", IsNullable = false)]
    public string? InspectionCode { get; set; }

    /// <summary>
    /// 检查名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "inspection_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "检查名称", IsNullable = false)]
    public string? InspectionName { get; set; }

    /// <summary>
    /// 检查类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "inspection_type", ColumnDescription = "检查类型", IsNullable = false)]
    public int InspectionType { get; set; }

    /// <summary>
    /// 检查状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "inspection_status", ColumnDescription = "检查状态", IsNullable = false)]
    public int InspectionStatus { get; set; }

    /// <summary>
    /// 检查描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "inspection_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "检查描述", IsNullable = true)]
    public string? InspectionDescription { get; set; }
    #endregion

    #region 检查信息
    /// <summary>
    /// 检查地点
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "inspection_location", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "检查地点", IsNullable = true)]
    public string? InspectionLocation { get; set; }

    /// <summary>
    /// 检查内容
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "inspection_content", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "检查内容", IsNullable = true)]
    public string? InspectionContent { get; set; }

    /// <summary>
    /// 检查结果
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "inspection_result", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "检查结果", IsNullable = true)]
    public string? InspectionResult { get; set; }

    /// <summary>
    /// 检查人员
    /// </summary>
    [StringLength(200)]
    [SugarColumn(ColumnName = "inspectors", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "检查人员", IsNullable = true)]
    public string? Inspectors { get; set; }

    /// <summary>
    /// 检查分数
    /// </summary>
    [SugarColumn(ColumnName = "inspection_score", ColumnDescription = "检查分数", IsNullable = true)]
    public decimal? InspectionScore { get; set; }

    /// <summary>
    /// 是否合格
    /// </summary>
    [SugarColumn(ColumnName = "is_qualified", ColumnDescription = "是否合格", IsNullable = true)]
    public bool? IsQualified { get; set; }
    #endregion

    #region 整改信息
    /// <summary>
    /// 整改要求
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "rectification_requirements", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "整改要求", IsNullable = true)]
    public string? RectificationRequirements { get; set; }

    /// <summary>
    /// 整改期限
    /// </summary>
    [SugarColumn(ColumnName = "rectification_deadline", ColumnDescription = "整改期限", IsNullable = true)]
    public DateTime? RectificationDeadline { get; set; }

    /// <summary>
    /// 整改结果
    /// </summary>
    [StringLength(2000)]
    [SugarColumn(ColumnName = "rectification_result", ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "整改结果", IsNullable = true)]
    public string? RectificationResult { get; set; }

    /// <summary>
    /// 整改完成时间
    /// </summary>
    [SugarColumn(ColumnName = "rectification_complete_time", ColumnDescription = "整改完成时间", IsNullable = true)]
    public DateTime? RectificationCompleteTime { get; set; }
    #endregion

    #region 时间信息
    /// <summary>
    /// 检查时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "inspection_time", ColumnDescription = "检查时间", IsNullable = false)]
    public DateTime InspectionTime { get; set; }

    /// <summary>
    /// 下次检查时间
    /// </summary>
    [SugarColumn(ColumnName = "next_inspection_time", ColumnDescription = "下次检查时间", IsNullable = true)]
    public DateTime? NextInspectionTime { get; set; }
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
    /// 检查备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "inspection_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "检查备注", IsNullable = true)]
    public string? InspectionRemarks { get; set; }
    #endregion
  }
}