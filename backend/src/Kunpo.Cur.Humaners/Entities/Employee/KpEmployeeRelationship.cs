/******************************************************************************
 * 文件名称：KpEmployeeRelationship.cs
 * 文件描述：员工关系实体类
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
  /// 员工关系实体类
  /// </summary>
  [SugarTable("kp_hr_employee_relationship", "员工关系")]
  [SugarIndex("idx_employee_relationship_code", nameof(RelationshipCode), OrderByType.Asc)]
  public class KpEmployeeRelationship : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 关系编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "relationship_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "关系编码", IsNullable = false)]
    public string? RelationshipCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 关系类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "relationship_type", ColumnDescription = "关系类型", IsNullable = false)]
    public int RelationshipType { get; set; }

    /// <summary>
    /// 关系状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "relationship_status", ColumnDescription = "关系状态", IsNullable = false)]
    public int RelationshipStatus { get; set; }

    /// <summary>
    /// 关系描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "relationship_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "关系描述", IsNullable = true)]
    public string? RelationshipDescription { get; set; }
    #endregion

    #region 关系信息
    /// <summary>
    /// 相关员工编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "related_employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "相关员工编码", IsNullable = true)]
    public string? RelatedEmployeeCode { get; set; }

    /// <summary>
    /// 相关员工姓名
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "related_employee_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "相关员工姓名", IsNullable = true)]
    public string? RelatedEmployeeName { get; set; }

    /// <summary>
    /// 关系开始时间
    /// </summary>
    [SugarColumn(ColumnName = "relationship_start_date", ColumnDescription = "关系开始时间", IsNullable = true)]
    public DateTime? RelationshipStartDate { get; set; }

    /// <summary>
    /// 关系结束时间
    /// </summary>
    [SugarColumn(ColumnName = "relationship_end_date", ColumnDescription = "关系结束时间", IsNullable = true)]
    public DateTime? RelationshipEndDate { get; set; }
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
    /// 关系备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "relationship_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "关系备注", IsNullable = true)]
    public string? RelationshipRemarks { get; set; }
    #endregion
  }
}