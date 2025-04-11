// -----------------------------------------------------------------------
// <copyright file="KpBaseEntity.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>实体基类</summary>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SqlSugar;
using Kunpo.Cur.Common.Utils;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.Domain.Entities
{
  /// <summary>
  /// 基础实体类
  /// </summary>
  /// <remarks>
  /// 所有实体类的基类，包含通用字段
  /// </remarks>
  [SugarTable("kp_base_entity", "基础实体")]
  [SugarIndex("idx_tenant_id", nameof(TenantId), OrderByType.Asc)]
  public abstract class KpBaseEntity
  {
    #region 主键信息
    /// <summary>
    /// 主键
    /// </summary>
    /// <remarks>
    /// 自增主键，唯一标识
    /// </remarks>
    [SugarColumn(ColumnName = "id", ColumnDataType = "int", ColumnDescription = "主键", IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long Id { get; set; }
    #endregion

    #region 租户信息
    /// <summary>
    /// 租户ID
    /// </summary>
    /// <remarks>
    /// 多租户标识，不可为空，已建立索引
    /// </remarks>
    [SugarColumn(ColumnName = "tenant_id", ColumnDataType = "bigint", ColumnDescription = "租户ID", IsNullable = false)]
    public long TenantId { get; set; }
    #endregion

    #region 创建信息
    /// <summary>
    /// 创建人ID
    /// </summary>
    /// <remarks>
    /// 记录创建人的ID，可为空，更新时不可修改
    /// </remarks>
    [SugarColumn(ColumnName = "created_by", ColumnDataType = "nvarchar", Length = 48, ColumnDescription = "创建人ID", IsNullable = true, IsOnlyIgnoreUpdate = true)]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    /// <remarks>
    /// 记录创建的时间，不可为空，更新时不可修改
    /// </remarks>
    [SugarColumn(ColumnName = "created_time", ColumnDataType = "datetime", ColumnDescription = "创建时间", IsNullable = false, IsOnlyIgnoreUpdate = true)]
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    #endregion

    #region 更新信息
    /// <summary>
    /// 更新人ID
    /// </summary>
    /// <remarks>
    /// 记录最后更新人的ID，可为空
    /// </remarks>
    [SugarColumn(ColumnName = "updated_by", ColumnDataType = "nvarchar", Length = 48, ColumnDescription = "更新人ID", IsNullable = true)]
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    /// <remarks>
    /// 记录最后更新的时间，可为空
    /// </remarks>
    [SugarColumn(ColumnName = "updated_time", ColumnDataType = "datetime", ColumnDescription = "更新时间", IsNullable = true)]
    public DateTime? UpdatedTime { get; set; }
    #endregion

    #region 删除信息
    /// <summary>
    /// 是否删除
    /// </summary>
    /// <remarks>
    /// 0：未删除，1：已删除，默认为0
    /// </remarks>
    [SugarColumn(ColumnName = "is_deleted", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否删除", IsNullable = false)]
    public int IsDeleted { get; set; }

    /// <summary>
    /// 删除人ID
    /// </summary>
    /// <remarks>
    /// 记录删除人的ID，可为空
    /// </remarks>
    [SugarColumn(ColumnName = "deleted_by", ColumnDataType = "nvarchar", Length = 48, ColumnDescription = "删除人ID", IsNullable = true)]
    public string? DeletedBy { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    /// <remarks>
    /// 记录删除的时间，可为空
    /// </remarks>
    [SugarColumn(ColumnName = "deleted_time", ColumnDataType = "datetime", ColumnDescription = "删除时间", IsNullable = true)]
    public DateTime? DeletedTime { get; set; }
    #endregion

    #region 扩展信息
    /// <summary>
    /// 备注
    /// </summary>
    /// <remarks>
    /// 记录备注信息，最大长度500，可为空
    /// </remarks>
    [SugarColumn(ColumnName = "remark", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "备注", IsNullable = true)]
    public string? Remark { get; set; }
    #endregion
  }
}