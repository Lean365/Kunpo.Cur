// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>业务类型</summary>
// <remarks>处理业务的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Enums
{
  /// <summary>
  /// 业务类型
  /// </summary>
  public enum KpBusinessType
  {
    #region 基础操作（1-10）
    /// <summary>
    /// 其他
    /// </summary>
    Other = 0,

    /// <summary>
    /// 创建
    /// </summary>
    Create = 1,

    /// <summary>
    /// 更新
    /// </summary>
    Update = 2,

    /// <summary>
    /// 删除
    /// </summary>
    Delete = 3,

    /// <summary>
    /// 查询
    /// </summary>
    Query = 4,

    /// <summary>
    /// 导出
    /// </summary>
    Export = 5,

    /// <summary>
    /// 导入
    /// </summary>
    Import = 6,

    /// <summary>
    /// 重置
    /// </summary>
    Reset = 7,

    /// <summary>
    /// 复制
    /// </summary>
    Copy = 8,

    /// <summary>
    /// 移动
    /// </summary>
    Move = 9,

    /// <summary>
    /// 排序
    /// </summary>
    Sort = 10,
    #endregion

    #region 状态操作（11-20）
    /// <summary>
    /// 启用
    /// </summary>
    Enable = 11,

    /// <summary>
    /// 禁用
    /// </summary>
    Disable = 12,

    /// <summary>
    /// 发布
    /// </summary>
    Publish = 13,

    /// <summary>
    /// 下架
    /// </summary>
    Unpublish = 14,

    /// <summary>
    /// 锁定
    /// </summary>
    Lock = 15,

    /// <summary>
    /// 解锁
    /// </summary>
    Unlock = 16,

    /// <summary>
    /// 归档
    /// </summary>
    Archive = 17,

    /// <summary>
    /// 取消归档
    /// </summary>
    Unarchive = 18,

    /// <summary>
    /// 标记
    /// </summary>
    Mark = 19,

    /// <summary>
    /// 取消标记
    /// </summary>
    Unmark = 20,
    #endregion

    #region 审核操作（21-30）
    /// <summary>
    /// 提交
    /// </summary>
    Submit = 21,

    /// <summary>
    /// 审核
    /// </summary>
    Audit = 22,

    /// <summary>
    /// 驳回
    /// </summary>
    Reject = 23,

    /// <summary>
    /// 撤销
    /// </summary>
    Revoke = 24,

    /// <summary>
    /// 退回
    /// </summary>
    Return = 25,

    /// <summary>
    /// 转交
    /// </summary>
    Transfer = 26,

    /// <summary>
    /// 加签
    /// </summary>
    Countersign = 27,

    /// <summary>
    /// 会签
    /// </summary>
    JointSign = 28,

    /// <summary>
    /// 催办
    /// </summary>
    Urge = 29,

    /// <summary>
    /// 撤回
    /// </summary>
    Withdraw = 30,
    #endregion

    #region 权限操作（31-40）
    /// <summary>
    /// 分配
    /// </summary>
    Assign = 31,

    /// <summary>
    /// 取消分配
    /// </summary>
    Unassign = 32,

    /// <summary>
    /// 授权
    /// </summary>
    Authorize = 33,

    /// <summary>
    /// 取消授权
    /// </summary>
    Unauthorize = 34,

    /// <summary>
    /// 委派
    /// </summary>
    Delegate = 35,

    /// <summary>
    /// 取消委派
    /// </summary>
    Undelegate = 36,

    /// <summary>
    /// 共享
    /// </summary>
    Share = 37,

    /// <summary>
    /// 取消共享
    /// </summary>
    Unshare = 38,

    /// <summary>
    /// 继承
    /// </summary>
    Inherit = 39,

    /// <summary>
    /// 取消继承
    /// </summary>
    Uninherit = 40,
    #endregion

    #region 数据操作（41-50）
    /// <summary>
    /// 合并
    /// </summary>
    Merge = 41,

    /// <summary>
    /// 拆分
    /// </summary>
    Split = 42,

    /// <summary>
    /// 转换
    /// </summary>
    Convert = 43,

    /// <summary>
    /// 同步
    /// </summary>
    Sync = 44,

    /// <summary>
    /// 备份
    /// </summary>
    Backup = 45,

    /// <summary>
    /// 恢复
    /// </summary>
    Restore = 46,

    /// <summary>
    /// 清理
    /// </summary>
    Clean = 47,

    /// <summary>
    /// 优化
    /// </summary>
    Optimize = 48,

    /// <summary>
    /// 校验
    /// </summary>
    Validate = 49,

    /// <summary>
    /// 修复
    /// </summary>
    Repair = 50,
    #endregion

    #region 通知操作（51-60）
    /// <summary>
    /// 通知
    /// </summary>
    Notify = 51,

    /// <summary>
    /// 提醒
    /// </summary>
    Remind = 52,

    /// <summary>
    /// 警告
    /// </summary>
    Warn = 53,

    /// <summary>
    /// 确认
    /// </summary>
    Confirm = 54,

    /// <summary>
    /// 反馈
    /// </summary>
    Feedback = 55,

    /// <summary>
    /// 评价
    /// </summary>
    Evaluate = 56,

    /// <summary>
    /// 举报
    /// </summary>
    Report = 57,

    /// <summary>
    /// 申诉
    /// </summary>
    Appeal = 58,

    /// <summary>
    /// 建议
    /// </summary>
    Suggest = 59,

    /// <summary>
    /// 投诉
    /// </summary>
    Complain = 60
    #endregion
  }
}