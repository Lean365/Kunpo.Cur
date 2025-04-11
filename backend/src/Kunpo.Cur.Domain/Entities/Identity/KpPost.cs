// -----------------------------------------------------------------------
// <copyright file="KpPost.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>岗位实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 岗位实体
    /// </summary>
    [SugarTable("kp_id_post", "岗位")]
    [SugarIndex("idx_post_code", nameof(PostCode), OrderByType.Asc)]
    [SugarIndex("idx_post_name", nameof(PostName), OrderByType.Asc)]
    public class KpPost : KpBaseEntity
    {
        /// <summary>
        /// 岗位编码
        /// </summary>
        [SugarColumn(ColumnName = "post_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "岗位编码", IsNullable = false)]
        public string? PostCode { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [SugarColumn(ColumnName = "post_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "岗位名称", IsNullable = false)]
        public string? PostName { get; set; }

        /// <summary>
        /// 岗位描述
        /// </summary>
        [SugarColumn(ColumnName = "post_desc", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "岗位描述", IsNullable = true)]
        public string? PostDesc { get; set; }

        /// <summary>
        /// 岗位排序
        /// </summary>
        [SugarColumn(ColumnName = "order_num", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "岗位排序", IsNullable = false)]
        public int OrderNum { get; set; }

        /// <summary>
        /// 岗位状态
        /// </summary>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "岗位状态", IsNullable = false)]
        public int Status { get; set; }

        /// <summary>
        /// 岗位等级
        /// </summary>
        /// <remarks>
        /// 0：实习，1：初级，2：中级，3：高级，4：专家，5：资深专家，6：首席专家，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "post_level", ColumnDataType = "int", IsNullable = false, ColumnDescription = "岗位等级", DefaultValue = "0")]
        public int PostLevel { get; set; }

        /// <summary>
        /// 岗位序列
        /// </summary>
        /// <remarks>
        /// 0：管理序列，1：技术序列，2：业务序列，3：职能序列，4：其他序列，默认为4
        /// </remarks>
        [SugarColumn(ColumnName = "post_sequence", ColumnDataType = "int", IsNullable = false, ColumnDescription = "岗位序列", DefaultValue = "4")]
        public int PostSequence { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "is_active", ColumnDataType = "int", IsNullable = false, ColumnDescription = "是否启用", DefaultValue = "1")]
        public int IsActive { get; set; }

        /// <summary>
        /// 岗位用户列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpUserPost.PostId))]
        public List<KpUserPost> UserPosts { get; set; } = new();
    }
}