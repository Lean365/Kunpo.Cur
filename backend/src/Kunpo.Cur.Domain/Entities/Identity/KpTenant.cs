// -----------------------------------------------------------------------
// <copyright file="KpTenant.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>租户实体</summary>
// -----------------------------------------------------------------------

using SqlSugar;
using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 租户实体
    /// </summary>
    [SugarTable("kp_id_tenant", "租户")]
    [SugarIndex("idx_tenant_code", nameof(TenantCode), OrderByType.Asc)]
    [SugarIndex("idx_tenant_name", nameof(TenantName), OrderByType.Asc)]
    public class KpTenant : KpBaseEntity
    {
        #region 基础信息

        /// <summary>
        /// 租户编码
        /// </summary>
        [SugarColumn(ColumnName = "tenant_code", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户编码", IsNullable = false)]
        public string? TenantCode { get; set; }

        /// <summary>
        /// 租户名称
        /// </summary>
        [SugarColumn(ColumnName = "tenant_name", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "租户名称", IsNullable = false)]
        public string? TenantName { get; set; }

        /// <summary>
        /// 租户简称
        /// </summary>
        [SugarColumn(ColumnName = "tenant_short_name", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户简称", IsNullable = true)]
        public string? TenantShortName { get; set; }

        /// <summary>
        /// 租户描述
        /// </summary>
        [SugarColumn(ColumnName = "tenant_description", ColumnDataType = "nvarchar", Length = 500, ColumnDescription = "租户描述", IsNullable = true)]
        public string? TenantDescription { get; set; }

        /// <summary>
        /// 租户Logo
        /// </summary>
        [SugarColumn(ColumnName = "tenant_logo", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "租户Logo", IsNullable = true)]
        public string? TenantLogo { get; set; }

        #endregion 基础信息

        #region 联系信息

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "tenant_contact", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "联系人", IsNullable = true)]
        public string? TenantContact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [SugarColumn(ColumnName = "tenant_phone", ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "联系电话", IsNullable = true)]
        public string? TenantPhone { get; set; }

        /// <summary>
        /// 联系邮箱
        /// </summary>
        [SugarColumn(ColumnName = "tenant_email", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "联系邮箱", IsNullable = true)]
        public string? TenantEmail { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [SugarColumn(ColumnName = "tenant_address", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "联系地址", IsNullable = true)]
        public string? TenantAddress { get; set; }

        #endregion 联系信息

        #region 业务信息

        /// <summary>
        /// 租户类型
        /// </summary>
        /// <remarks>
        /// 0：企业，1：个人，2：政府，3：其他，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "tenant_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "租户类型", IsNullable = false)]
        public int TenantType { get; set; }

        /// <summary>
        /// 租户规模
        /// </summary>
        /// <remarks>
        /// 0：小型，1：中型，2：大型，3：特大型，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "tenant_scale", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "租户规模", IsNullable = false)]
        public int TenantScale { get; set; }

        /// <summary>
        /// 租户行业
        /// </summary>
        [SugarColumn(ColumnName = "tenant_industry", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户行业", IsNullable = true)]
        public string? TenantIndustry { get; set; }

        /// <summary>
        /// 租户区域
        /// </summary>
        [SugarColumn(ColumnName = "tenant_region", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户区域", IsNullable = true)]
        public string? TenantRegion { get; set; }

        #endregion 业务信息

        #region 系统配置

        /// <summary>
        /// 租户域名
        /// </summary>
        [SugarColumn(ColumnName = "tenant_domain", ColumnDataType = "nvarchar", Length = 100, ColumnDescription = "租户域名", IsNullable = true)]
        public string? TenantDomain { get; set; }

        /// <summary>
        /// 租户主题
        /// </summary>
        [SugarColumn(ColumnName = "tenant_theme", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户主题", IsNullable = true)]
        public string? TenantTheme { get; set; }

        /// <summary>
        /// 租户语言
        /// </summary>
        [SugarColumn(ColumnName = "tenant_language", ColumnDataType = "int", ColumnDescription = "租户语言", IsNullable = true)]
        public int TenantLanguage { get; set; }

        /// <summary>
        /// 租户时区
        /// </summary>
        [SugarColumn(ColumnName = "tenant_time_zone", ColumnDataType = "nvarchar", Length = 50, ColumnDescription = "租户时区", IsNullable = true)]
        public string? TenantTimeZone { get; set; }

        #endregion 系统配置

        #region 状态控制

        /// <summary>
        /// 租户状态
        /// </summary>
        /// <remarks>
        /// 0：禁用，1：启用，2：待审核，3：已过期，默认为1
        /// </remarks>
        [SugarColumn(ColumnName = "status", ColumnDataType = "int", DefaultValue = "1", ColumnDescription = "租户状态", IsNullable = false)]
        public int Status { get; set; }

        /// <summary>
        /// 是否试用
        /// </summary>
        /// <remarks>
        /// 0：否，1：是，默认为0
        /// </remarks>
        [SugarColumn(ColumnName = "tenant_is_trial", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "是否试用", IsNullable = false)]
        public int TenantIsTrial { get; set; }

        /// <summary>
        /// 试用天数
        /// </summary>
        [SugarColumn(ColumnName = "tenant_trial_days", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "试用天数", IsNullable = false)]
        public int TenantTrialDays { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        [SugarColumn(ColumnName = "tenant_expire_time", ColumnDataType = "datetime", ColumnDescription = "到期时间", IsNullable = true)]
        public DateTime? TenantExpireTime { get; set; }

        #endregion 状态控制

        #region 扩展信息

        /// <summary>
        /// 租户配置
        /// </summary>
        [SugarColumn(ColumnName = "tenant_config", ColumnDataType = "nvarchar", Length = 4000, ColumnDescription = "租户配置", IsNullable = true)]
        public string? TenantConfig { get; set; }

        #endregion 扩展信息

        #region 导航属性

        /// <summary>
        /// 租户用户列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpUser.TenantId))]
        public List<KpUser>? Users { get; set; }

        /// <summary>
        /// 租户部门列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpDept.TenantId))]
        public List<KpDept>? Depts { get; set; }

        /// <summary>
        /// 租户角色列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpRole.TenantId))]
        public List<KpRole>? Roles { get; set; }

        /// <summary>
        /// 租户岗位列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpPost.TenantId))]
        public List<KpPost>? Posts { get; set; }

        /// <summary>
        /// 租户菜单列表
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(KpMenu.TenantId))]
        public List<KpMenu>? Menus { get; set; }

        #endregion 导航属性
    }
}