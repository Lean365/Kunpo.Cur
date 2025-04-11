// ================================================
// 描 述：工厂物料主数据数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Logistics.Dtos.Material
{
  /// <summary>
  /// 工厂物料主数据删除数据传输对象
  /// </summary>
  public class KpPlantMaterialDeleteDto
  {
    /// <summary>
    /// 工厂物料ID
    /// </summary>
    [Required(ErrorMessage = "工厂物料ID不能为空")]
    public long Id { get; set; }
  }
}