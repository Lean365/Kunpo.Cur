// -----------------------------------------------------------------------
// <copyright file="KpRole.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>角色实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 角色实体
    /// </summary>
    [SugarTable("kp_id_role", "角色")]
    [SugarIndex("idx_role_code", nameof(RoleCode), OrderByType.Asc)]
    [SugarIndex("idx_role_name", nameof(RoleName), OrderByType.Asc)]
    public class KpRole : KpBaseEntity
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [SugarColumn(ColumnName = "role_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "角色编码", IsNullable = false)]
        public string? RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(ColumnName = "role_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "角色名称", IsNullable = false)]
        public string? RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [SugarColumn(ColumnName = "role_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "角色描述", IsNullable = true)]
        public string? RoleDesc { get; set; }

        /// <summary>
        /// 角色排序
        /// </summary>
        [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "角色排序", IsNullable = false)]
        public int OrderNum { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "角色状态", IsNullable = false)]
        public int Status { get; set; }

        /// <summary>
        /// 数据权限类型
        /// </summary>
        /// <remarks>
        /// 0：全部数据，1：本部门数据，2：本部门及下级部门数据，3：自定义数据，4：仅本人数据，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "data_scope", ColumnDataType = "int", IsNullable = false, ColumnDescription = "数据权限类型", DefaultValue = "0")]
        public int DataScope { get; set; }

        /// <summary>
        /// 数据权限部门ID列表
        /// </summary>
        /// <remarks>
        /// 当数据权限类型为3(自定义数据)时使用，多个部门ID用逗号分隔
        /// </remarks>
        [SugarColumn(ColumnName = "role_data_dept_ids", ColumnDataType = "varchar", Length = 1000, IsNullable = true, ColumnDescription = "数据权限部门ID列表")]
        public string? RoleDataDeptIds { get; set; }

        /// <summary>
        /// 用户角色列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpUserRole.RoleId))]
        public List<KpUserRole> UserRoles { get; set; } = new List<KpUserRole>();

        /// <summary>
        /// 角色菜单列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpRoleMenu.RoleId))]
        public List<KpRoleMenu> RoleMenus { get; set; } = new List<KpRoleMenu>();
    }
}