// ================================================
// 描 述：车辆费用数据传输对象
// 作 者：Kunpo
// 创建时间：2024-04-04
// 版 本：1.0
// ================================================

using System.ComponentModel.DataAnnotations;

namespace Kunpo.Cur.Logistics.Dtos.Vehicle
{
  /// <summary>
  /// 车辆费用删除数据传输对象
  /// </summary>
  public class KpVehicleCostDeleteDto
  {
    /// <summary>
    /// 费用单ID
    /// </summary>
    [Required(ErrorMessage = "费用单ID不能为空")]
    public long Id { get; set; }
  }
}