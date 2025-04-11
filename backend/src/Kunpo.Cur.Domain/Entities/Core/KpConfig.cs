// -----------------------------------------------------------------------
// <copyright file="KpConfig.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>系统配置实体</summary>
// -----------------------------------------------------------------------

using Kunpo.Cur.Domain.Entities;
using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Core
{
  /// <summary>
  /// 系统配置实体
  /// </summary>
  [SugarTable("kp_co_config", "系统配置")]
  [SugarIndex("idx_config_key", nameof(ConfigKey), OrderByType.Asc)]
  public class KpConfig : KpBaseEntity
  {
    /// <summary>
    /// 配置键
    /// </summary>
    [SugarColumn(ColumnName = "config_key", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "配置键", IsNullable = false)]
    public string? ConfigKey { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [SugarColumn(ColumnName = "config_value", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "配置值", IsNullable = false)]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 配置描述
    /// </summary>
    [SugarColumn(ColumnName = "config_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "配置描述", IsNullable = true)]
    public string? ConfigDesc { get; set; }

    /// <summary>
    /// 配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）
    /// </summary>
    [SugarColumn(ColumnName = "config_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "配置类型（0：文本，1：数字，2：布尔，3：日期，4：JSON）", IsNullable = false)]
    public int ConfigType { get; set; }

    /// <summary>
    /// 配置分组
    /// </summary>
    [SugarColumn(ColumnName = "config_group", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "配置分组", IsNullable = true)]
    public string? ConfigGroup { get; set; }

    /// <summary>
    /// 是否内置
    /// </summary>
    [SugarColumn(ColumnName = "is_builtin", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否内置", IsNullable = false)]
    public int IsBuiltin { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnName = "is_enabled", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
    public int IsEnabled { get; set; } = 1;

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "排序", IsNullable = false)]
    public int OrderNum { get; set; }
  }
}