using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public struct OrderLine
    {
        public int SkuId;
        public string Sku;
        public string SkuName;
        public int Qty;
        public double Price;
        public bool Nds21Percent;
    }
}
