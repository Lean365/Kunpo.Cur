// -----------------------------------------------------------------------
// <copyright file="KpMenu.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>菜单实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    [SugarTable("kp_id_menu", "菜单")]
    [SugarIndex("idx_menu_code", nameof(MenuCode), OrderByType.Asc)]
    [SugarIndex("idx_menu_name", nameof(MenuName), OrderByType.Asc)]
    [SugarIndex("idx_menu_parent_id", nameof(MenuParentId), OrderByType.Asc)]
    public class KpMenu : KpBaseEntity
    {
        #region 基础信息

        /// <summary>
        /// 菜单编码
        /// </summary>
        [SugarColumn(ColumnName = "menu_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "菜单编码", IsNullable = false)]
        public string? MenuCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [SugarColumn(ColumnName = "menu_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "菜单名称", IsNullable = false)]
        public string? MenuName { get; set; }

        /// <summary>
        /// 菜单翻译key
        /// </summary>
        [SugarColumn(ColumnDescription = "菜单翻译key", ColumnDataType = "nvarchar", Length = 100, DecimalDigits = 0, DefaultValue = "", IsNullable = true)]
        public string? MenuTransKey { get; set; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        [SugarColumn(ColumnDescription = "菜单描述", ColumnDataType = "nvarchar", Length = 200, DecimalDigits = 0, DefaultValue = "", IsNullable = true)]
        public string? MenuDescription { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [SugarColumn(ColumnName = "menu_icon", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "菜单图标", IsNullable = true)]
        public string? MenuIcon { get; set; }

        #endregion 基础信息

        #region 树形结构

        /// <summary>
        /// 父级ID
        /// </summary>
        [SugarColumn(ColumnName = "menu_parent_id", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "父级ID", IsNullable = false)]
        public long? MenuParentId { get; set; }

        /// <summary>
        /// 祖级列表
        /// </summary>
        /// <remarks>
        /// 记录所有父级ID，用逗号分隔，如：1,2,3
        /// </remarks>
        [SugarColumn(ColumnDescription = "祖级列表", ColumnDataType = "varchar", Length = 500, DecimalDigits = 0, DefaultValue = "", IsNullable = true)]
        public string? MenuAncestors { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        /// <remarks>
        /// 从1开始，1表示顶级菜单
        /// </remarks>
        [SugarColumn(ColumnDescription = "层级", ColumnDataType = "int", Length = 0, DecimalDigits = 0, DefaultValue = "1", IsNullable = false)]
        public int MenuLevel { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "菜单排序", IsNullable = false)]
        public int OrderNum { get; set; }

        #endregion 树形结构

        #region 功能特性

        /// <summary>
        /// 菜单类型
        /// </summary>
        /// <remarks>
        /// 0：目录，1：菜单，2：按钮，默认为0
        /// </remarks>
        [SugarColumn(ColumnDescription = "菜单类型", ColumnDataType = "int", Length = 0, DecimalDigits = 0, DefaultValue = "0", IsNullable = false)]
        public int MenuType { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        [SugarColumn(ColumnName = "menu_path", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "菜单路径", IsNullable = true)]
        public string? MenuPath { get; set; }

        /// <summary>
        /// 组件路径
        /// </summary>
        [SugarColumn(ColumnName = "menu_component", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "菜单组件", IsNullable = true)]
        public string? MenuComponent { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        [SugarColumn(ColumnName = "menu_perms", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "菜单权限", IsNullable = true)]
        public string? MenuPerms { get; set; }

        #endregion 功能特性

        #region 状态控制

        /// <summary>
        /// 是否外链
        /// </summary>
        /// <remarks>
        /// 0：否，1：是，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "is_frame", ColumnDataType = "int", ColumnDescription = "是否外链", Length = 0, DecimalDigits = 0, DefaultValue = "0", IsNullable = false)]
        public int IsFrame { get; set; }

        /// <summary>
        /// 是否缓存
        /// </summary>
        /// <remarks>
        /// 0：否，1：是，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "is_cache", ColumnDataType = "int", ColumnDescription = "是否缓存", Length = 0, DecimalDigits = 0, DefaultValue = "0", IsNullable = false)]
        public int IsCache { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        /// <remarks>
        /// 0：否，1：是，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_visible", ColumnDataType = "int", ColumnDescription = "是否可见", Length = 0, DecimalDigits = 0, DefaultValue = "1", IsNullable = false)]
        public int IsVisible { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_active", ColumnDataType = "int", ColumnDescription = "是否启用", Length = 0, DecimalDigits = 0, DefaultValue = "1", IsNullable = false)]
        public int IsActive { get; set; }

        /// <summary>
        /// 菜单状态
        /// </summary>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "菜单状态", IsNullable = false)]
        public int Status { get; set; }

        #endregion 状态控制

        #region 导航属性

        /// <summary>
        /// 子菜单列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(MenuParentId))]
        public List<KpMenu> Children { get; set; } = new();

        /// <summary>
        /// 角色菜单列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpRoleMenu.MenuId))]
        public List<KpRoleMenu> RoleMenus { get; set; } = new();

        #endregion 导航属性
    }
}