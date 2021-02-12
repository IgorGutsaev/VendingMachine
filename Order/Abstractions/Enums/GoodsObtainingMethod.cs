using Filuet.Utils.Extensions.Helpers;

namespace Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums
{
    public enum GoodsObtainingMethod
    {
        [Code("WH")]
        /// <summary>
        /// Fetch products from warehouse
        /// </summary>
        Warehouse = 0x01,
        [Code("AS")]
        /// <summary>
        /// Fetch products from dispensing machine
        /// </summary>
        Dispensing
    }
}