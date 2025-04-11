/******************************************************************************
 * 文件名称：KpEmployeeFile.cs
 * 文件描述：员工档案实体类
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
  /// 员工档案实体类
  /// </summary>
  [SugarTable("kp_hr_employee_file", "员工档案")]
  [SugarIndex("idx_employee_file_code", nameof(FileCode), OrderByType.Asc)]
  public class KpEmployeeFile : KpBaseEntity
  {
    #region 基本信息
    /// <summary>
    /// 档案编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "file_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "档案编码", IsNullable = false)]
    public string? FileCode { get; set; }

    /// <summary>
    /// 员工编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "employee_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "员工编码", IsNullable = false)]
    public string? EmployeeCode { get; set; }

    /// <summary>
    /// 档案类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "file_type", ColumnDescription = "档案类型", IsNullable = false)]
    public int FileType { get; set; }

    /// <summary>
    /// 档案名称
    /// </summary>
    [Required]
    [StringLength(100)]
    [SugarColumn(ColumnName = "file_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "档案名称", IsNullable = false)]
    public string? FileName { get; set; }

    /// <summary>
    /// 档案描述
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "file_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "档案描述", IsNullable = true)]
    public string? FileDescription { get; set; }
    #endregion

    #region 文件信息
    /// <summary>
    /// 文件路径
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "file_path", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "文件路径", IsNullable = true)]
    public string? FilePath { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    [SugarColumn(ColumnName = "file_size", ColumnDescription = "文件大小", IsNullable = true)]
    public long? FileSize { get; set; }

    /// <summary>
    /// 文件格式
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "file_format", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "文件格式", IsNullable = true)]
    public string? FileFormat { get; set; }

    /// <summary>
    /// 文件版本
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "file_version", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "文件版本", IsNullable = true)]
    public string? FileVersion { get; set; }
    #endregion

    #region 管理信息
    /// <summary>
    /// 创建人编码
    /// </summary>
    [Required]
    [StringLength(20)]
    [SugarColumn(ColumnName = "creator_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "创建人编码", IsNullable = false)]
    public string? CreatorCode { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "create_time", ColumnDescription = "创建时间", IsNullable = false)]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 最后修改人编码
    /// </summary>
    [StringLength(20)]
    [SugarColumn(ColumnName = "last_modifier_code", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "最后修改人编码", IsNullable = true)]
    public string? LastModifierCode { get; set; }

    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnName = "last_modify_time", ColumnDescription = "最后修改时间", IsNullable = true)]
    public DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 档案状态
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "file_status", ColumnDescription = "档案状态", IsNullable = false)]
    public int FileStatus { get; set; }
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
    /// 档案备注
    /// </summary>
    [StringLength(500)]
    [SugarColumn(ColumnName = "file_remarks", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "档案备注", IsNullable = true)]
    public string? FileRemarks { get; set; }
    #endregion
  }
}