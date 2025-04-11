// -----------------------------------------------------------------------
// <copyright file="KpUser.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>用户实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Kunpo.Cur.Domain.Interfaces;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [SugarTable("kp_id_user", "用户")]
    [SugarIndex("idx_user_name", nameof(UserName), OrderByType.Asc)]
    [SugarIndex("idx_user_email", nameof(UserEmail), OrderByType.Asc)]
    [SugarIndex("idx_user_phone", nameof(UserPhone), OrderByType.Asc)]
    [SugarIndex("idx_user_dept", nameof(UserDeptId), OrderByType.Asc)]
    public class KpUser : KpBaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "user_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户名", IsNullable = false)]
        public string? UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [SugarColumn(ColumnName = "user_nick_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "用户昵称", IsNullable = true)]
        public string? UserNickName { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [SugarColumn(ColumnName = "user_real_name", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "用户真实姓名", IsNullable = true)]
        public string? UserRealName { get; set; }

        /// <summary>
        /// 用户英文名
        /// </summary>
        [SugarColumn(ColumnName = "user_english_name", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "用户英文名", IsNullable = true)]
        public string? UserEnglishName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        /// <remarks>
        /// 0：普通用户，1：管理员，2：超级管理员，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "user_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "用户类型", IsNullable = false)]
        public int UserType { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        [SugarColumn(ColumnName = "user_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "用户邮箱", IsNullable = true)]
        public string? UserEmail { get; set; }

        /// <summary>
        /// 用户手机
        /// </summary>
        [SugarColumn(ColumnName = "user_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "用户手机", IsNullable = true)]
        public string? UserPhone { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [SugarColumn(ColumnName = "user_avatar", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "用户头像", IsNullable = true)]
        public string? UserAvatar { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        /// <remarks>
        /// 0：未知，1：男，2：女，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "user_gender", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "用户性别", IsNullable = false)]
        public int UserGender { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [SugarColumn(ColumnName = "user_password", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "用户密码", IsNullable = true)]
        public string? UserPassword { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>
        [SugarColumn(ColumnName = "user_salt", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "密码盐值", IsNullable = true)]
        public string? UserSalt { get; set; }

        /// <summary>
        /// 密码过期时间
        /// </summary>
        [SugarColumn(ColumnName = "user_password_expire_time", ColumnDataType = "datetime", ColumnDescription = "密码过期时间", IsNullable = true)]
        public DateTime? UserPasswordExpireTime { get; set; }

        /// <summary>
        /// 登录失败次数
        /// </summary>
        [SugarColumn(ColumnName = "user_login_fail_count", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "登录失败次数", IsNullable = false)]
        public int UserLoginFailCount { get; set; }

        /// <summary>
        /// 登录锁定时间
        /// </summary>
        [SugarColumn(ColumnName = "user_login_lock_time", ColumnDataType = "datetime", ColumnDescription = "登录锁定时间", IsNullable = true)]
        public DateTime? UserLoginLockTime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [SugarColumn(ColumnName = "user_last_login_time", ColumnDataType = "datetime", ColumnDescription = "最后登录时间", IsNullable = true)]
        public DateTime? UserLastLoginTime { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "用户状态", IsNullable = false)]
        public int Status { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        /// <remarks>
        /// 0：否，1：是，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "user_is_locked", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否锁定", IsNullable = false)]
        public int UserIsLocked { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        /// <remarks>
        /// 关联部门表(kp_dept)的主键
        /// </remarks>
        [SugarColumn(ColumnName = "user_dept_id", ColumnDataType = "bigint", IsNullable = true, DefaultValue = "0", ColumnDescription = "部门ID")]
        public long? UserDeptId { get; set; }

        /// <summary>
        /// 角色列表（逗号分隔）
        /// </summary>
        [SugarColumn(ColumnName = "user_roles", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "角色列表", IsNullable = true)]
        public string? Roles { get; set; }

        /// <summary>
        /// 用户角色列表
        /// </summary>
        [Navigate(NavigateType.ManyToMany, nameof(KpUserRole), nameof(KpUserRole.UserId), nameof(KpUserRole.RoleId))]
        public List<KpRole>? RolesList { get; set; }

        /// <summary>
        /// 用户部门列表
        /// </summary>
        [Navigate(NavigateType.ManyToMany, nameof(KpUserDept), nameof(KpUserDept.UserId), nameof(KpUserDept.DeptId))]
        public List<KpDept>? Depts { get; set; }

        /// <summary>
        /// 用户岗位列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpUserPost.UserId))]
        public List<KpUserPost> UserPosts { get; set; } = new();
    }
}