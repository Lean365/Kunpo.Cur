// -----------------------------------------------------------------------
// <copyright file="KpDept.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>部门实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 部门实体
    /// </summary>
    [SugarTable("kp_id_dept")]
    [SugarIndex("idx_dept_code", nameof(DeptCode), OrderByType.Asc)]
    [SugarIndex("idx_dept_parent", nameof(DeptParentId), OrderByType.Asc)]
    public class KpDept : KpBaseEntity
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        [SugarColumn(ColumnName = "dept_name", ColumnDataType = "nvarchar", Length = 50, IsNullable = false, ColumnDescription = "部门名称")]
        public string? DeptName { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        [SugarColumn(ColumnName = "dept_code", ColumnDataType = "nvarchar", Length = 50, IsNullable = false, ColumnDescription = "部门编码")]
        public string? DeptCode { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        [SugarColumn(ColumnName = "dept_desc", ColumnDataType = "nvarchar", Length = 200, IsNullable = true, ColumnDescription = "部门描述")]
        public string? DeptDesc { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [SugarColumn(ColumnName = "dept_parent_id", ColumnDataType = "bigint", IsNullable = true, ColumnDescription = "父级ID")]
        public long? DeptParentId { get; set; }

        /// <summary>
        /// 祖级列表
        /// </summary>
        /// <remarks>
        /// 记录所有父级ID，用逗号分隔，如：1,2,3
        /// </remarks>
        [SugarColumn(ColumnName = "dept_ancestors", ColumnDataType = "nvarchar", Length = 500, IsNullable = true, ColumnDescription = "祖级列表")]
        public string? DeptAncestors { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        /// <remarks>
        /// 从1开始，1表示顶级部门
        /// </remarks>
        [SugarColumn(ColumnName = "dept_level", ColumnDataType = "int", IsNullable = false, ColumnDescription = "层级", DefaultValue = "1")]
        public int DeptLevel { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", IsNullable = false, ColumnDescription = "排序", DefaultValue = "0")]
        public int OrderNum { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_active", ColumnDataType = "int", IsNullable = false, ColumnDescription = "是否启用", DefaultValue = "1")]
        public int IsActive { get; set; }

        /// <summary>
        /// 部门状态
        /// </summary>
        /// <remarks>
        /// 0：草稿
        /// 1：正常
        /// 2：停用
        /// </remarks>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", IsNullable = false, ColumnDescription = "部门状态", DefaultValue = "1")]
        public int Status { get; set; }

        /// <summary>
        /// 部门用户列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpUser.UserDeptId))]
        public List<KpUser>? Users { get; set; }

        /// <summary>
        /// 子部门列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(DeptParentId))]
        public List<KpDept>? Children { get; set; }
    }
}