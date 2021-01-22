using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions
{
    public class ECommerceIncomeEventArgs : EventArgs
    {
        public MoneyNaturalized Income { get; set; } 
    }
}
