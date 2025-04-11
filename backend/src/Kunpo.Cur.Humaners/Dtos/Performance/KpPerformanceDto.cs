// ================================================
// 描 述：绩效记录数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Humaners.Dtos.Performance
{
  /// <summary>
  /// 绩效记录删除数据传输对象
  /// </summary>
  public class KpPerformanceDeleteDto
  {
    /// <summary>
    /// 绩效ID
    /// </summary>
    [Required(ErrorMessage = "绩效ID不能为空")]
    public long Id { get; set; }
  }
}