// -----------------------------------------------------------------------
// <copyright file="KpUserRole.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>用户-角色关联实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 用户-角色关联实体
    /// </summary>
    [SugarTable("kp_id_user_role")]
    [SugarIndex("idx_user_role_user", nameof(UserId), OrderByType.Asc)]
    [SugarIndex("idx_user_role_role", nameof(RoleId), OrderByType.Asc)]
    public class KpUserRole : KpBaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <remarks>
        /// 关联用户表(kp_user)的主键
        /// </remarks>
        [SugarColumn(IsNullable = false, ColumnDescription = "用户ID")]
        public long UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        /// <remarks>
        /// 关联角色表(kp_role)的主键
        /// </remarks>
        [SugarColumn(IsNullable = false, ColumnDescription = "角色ID")]
        public long RoleId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_active", ColumnDataType = "int", IsNullable = false, ColumnDescription = "是否启用", DefaultValue = "1")]
        public int IsActive { get; set; }
    }
}