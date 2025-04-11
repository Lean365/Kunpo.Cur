/******************************************************************************
 * 文件名称：KpOrganization.cs
 * 文件描述：组织架构实体类
 * 创建时间：2024-03-20
 * 创建人：系统管理员
 * 修改记录：
 * 2024-03-20 创建文件
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Humaners.Entities.Organization
{
  /// <summary>
  /// 组织架构实体类
  /// </summary>
  [SugarTable("kp_hr_organization", "组织架构")]
  [SugarIndex("idx_org_code", nameof(OrgCode), OrderByType.Asc)]
  public class KpOrganization : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 组织编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "org_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "组织编码", IsNullable = false)]
    public string? OrgCode { get; set; }

    /// <summary>
    /// 组织名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "org_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "组织名称", IsNullable = false)]
    public string? OrgName { get; set; }

    /// <summary>
    /// 组织类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "org_type", ColumnDescription = "组织类型", IsNullable = false)]
    public int OrgType { get; set; }

    /// <summary>
    /// 组织状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "org_status", ColumnDescription = "组织状态", IsNullable = false)]
    public int OrgStatus { get; set; }

    /// <summary>
    /// 组织描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "org_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "组织描述", IsNullable = true)]
    public string? OrgDescription { get; set; }
    #endregion

    #region 层级信息
    /// <summary>
    /// 父级编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "parent_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "父级编码", IsNullable = true)]
    public string? ParentCode { get; set; }

    /// <summary>
    /// 组织层级
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "org_level", ColumnDescription = "组织层级", IsNullable = false)]
    public int OrgLevel { get; set; }

    /// <summary>
    /// 组织路径
    /// </summary>
    [Required]
    [StringLength(200)]
    [SugarColumn(ColumnName = "org_path", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "组织路径", IsNullable = false)]
    public string? OrgPath { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "sort_order", ColumnDescription = "排序号", IsNullable = false)]
    public int SortOrder { get; set; }
    #endregion

    #region 管理信息
    /// <summary>
    /// 负责人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "manager_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "负责人编码", IsNullable = true)]
    public string? ManagerCode { get; set; }

    /// <summary>
    /// 负责人姓名
    /// </summary>
    [StringLength(50)]
    [SugarColumn(ColumnName = "manager_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "负责人姓名", IsNullable = true)]
    public string? ManagerName { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "contact_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
    public string? ContactPhone { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(100)]
    [SugarColumn(ColumnName = "contact_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "电子邮箱", IsNullable = true)]
    public string? ContactEmail { get; set; }
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
    /// 组织备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "org_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "组织备注", IsNullable = true)]
    public string? OrgRemarks { get; set; }
    #endregion
  }
}