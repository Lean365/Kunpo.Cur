// ================================================
// 描 述：任务跟踪数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Routine.Dtos.Task
{
  /// <summary>
  /// 任务跟踪删除数据传输对象
  /// </summary>
  public class KpTaskTrackingDeleteDto
  {
    /// <summary>
    /// 跟踪ID
    /// </summary>
    [Required(ErrorMessage = "跟踪ID不能为空")]
    public long Id { get; set; }
  }
}