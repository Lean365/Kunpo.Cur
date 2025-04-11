// ================================================
// 描 述：基础客户数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Logistics.Dtos.Sales
{
  /// <summary>
  /// 基础客户删除数据传输对象
  /// </summary>
  public class KpClientDeleteDto
  {
    /// <summary>
    /// 客户ID
    /// </summary>
    [Required(ErrorMessage = "客户ID不能为空")]
    public long Id { get; set; }
  }
}