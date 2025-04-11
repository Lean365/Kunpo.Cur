// -----------------------------------------------------------------------
// <copyright file="KpRoleMenu.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>角色-菜单关联实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 角色-菜单关联实体
    /// </summary>
    [SugarTable("kp_id_role_menu", "角色菜单关联")]
    [SugarIndex("idx_role_menu_role_id", nameof(RoleId), OrderByType.Asc)]
    [SugarIndex("idx_role_menu_menu_id", nameof(MenuId), OrderByType.Asc)]
    public class KpRoleMenu : KpBaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <remarks>
        /// 关联角色表(kp_role)的主键
        /// </remarks>
        [SugarColumn(ColumnName = "role_id", ColumnDataType = "int", ColumnDescription = "角色ID", IsNullable = false)]
        public long RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        /// <remarks>
        /// 关联菜单表(kp_menu)的主键
        /// </remarks>
        [SugarColumn(ColumnName = "menu_id", ColumnDataType = "int", ColumnDescription = "菜单ID", IsNullable = false)]
        public long MenuId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_active", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "是否启用", IsNullable = false)]
        public int IsActive { get; set; }
    }
}