// -----------------------------------------------------------------------
// <copyright file="KpUserPost.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>用户-岗位关联实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 用户-岗位关联实体
    /// </summary>
    [SugarTable("kp_id_user_post")]
    [SugarIndex("idx_user_post_user", nameof(UserId), OrderByType.Asc)]
    [SugarIndex("idx_user_post_post", nameof(PostId), OrderByType.Asc)]
    public class KpUserPost : KpBaseEntity
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
        /// 岗位ID
        /// </summary>
        /// <remarks>
        /// 关联岗位表(kp_post)的主键
        /// </remarks>
        [SugarColumn(IsNullable = false, ColumnDescription = "岗位ID")]
        public long PostId { get; set; }

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