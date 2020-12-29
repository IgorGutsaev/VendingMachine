using Filuet.Utils.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums
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
