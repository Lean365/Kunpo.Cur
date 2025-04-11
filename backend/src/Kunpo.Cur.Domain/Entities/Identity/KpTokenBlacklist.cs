// ================================================
// 描 述：令牌黑名单实体
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using SqlSugar;
using System;

namespace Kunpo.Cur.Domain.Entities.Identity
{
    /// <summary>
    /// 令牌黑名单实体
    /// </summary>
    [SugarTable("kp_id_token_blacklist", "令牌黑名单")]
    [SugarIndex("idx_token_blacklist_token", nameof(Token), OrderByType.Asc)]
    [SugarIndex("idx_token_blacklist_user", nameof(UserId), OrderByType.Asc)]
    public class KpTokenBlacklist : KpBaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(ColumnName = "user_id", ColumnDescription = "用户ID", IsNullable = false)]
        public long UserId { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        [SugarColumn(ColumnName = "token", ColumnDataType = "nvarchar", Length = 1000, ColumnDescription = "令牌", IsNullable = false)]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 令牌类型
        /// </summary>
        /// <remarks>
        /// 0：访问令牌，1：刷新令牌
        /// </remarks>
        [SugarColumn(ColumnName = "token_type", ColumnDataType = "int", DefaultValue = "0", ColumnDescription = "令牌类型", IsNullable = false)]
        public int TokenType { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [SugarColumn(ColumnName = "expire_time", ColumnDataType = "datetime", ColumnDescription = "过期时间", IsNullable = false)]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 加入黑名单时间
        /// </summary>
        [SugarColumn(ColumnName = "blacklist_time", ColumnDataType = "datetime", ColumnDescription = "加入黑名单时间", IsNullable = false)]
        public DateTime BlacklistTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 加入黑名单原因
        /// </summary>
        [SugarColumn(ColumnName = "blacklist_reason", ColumnDataType = "nvarchar", Length = 200, ColumnDescription = "加入黑名单原因", IsNullable = true)]
        public string? BlacklistReason { get; set; }
    }
}