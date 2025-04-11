// -----------------------------------------------------------------------
// <copyright file="KpUserDept.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>用户部门关联实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 用户部门关联实体
    /// </summary>
    [SugarTable("kp_id_user_dept", "用户部门关联")]
    [SugarIndex("idx_user_dept_user_id", nameof(UserId), OrderByType.Asc)]
    [SugarIndex("idx_user_dept_dept_id", nameof(DeptId), OrderByType.Asc)]
    public class KpUserDept : KpBaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <remarks>
        /// 关联用户表(kp_user)的主键
        /// </remarks>
        [SugarColumn(ColumnName = "user_id", ColumnDataType = "int", ColumnDescription = "用户ID", IsNullable = false)]
        public long UserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        /// <remarks>
        /// 关联部门表(kp_dept)的主键
        /// </remarks>
        [SugarColumn(ColumnName = "dept_id", ColumnDataType = "int", ColumnDescription = "部门ID", IsNullable = false)]
        public long DeptId { get; set; }

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