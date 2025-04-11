// ================================================
// 描 述：供应商数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Logistics.Dtos.Material
{
  /// <summary>
  /// 供应商删除数据传输对象
  /// </summary>
  public class KpVendorDeleteDto
  {
    /// <summary>
    /// 供应商ID
    /// </summary>
    [Required(ErrorMessage = "供应商ID不能为空")]
    public long Id { get; set; }
  }
}