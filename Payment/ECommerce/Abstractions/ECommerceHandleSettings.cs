using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    /// <summary>
    /// Common settings of money acceptance
    /// </summary>
    public class ECommerceHandleSettings
    {
        /// <summary>
        /// In some countries there're 2 currencies in use
        /// </summary>
        public CurrencyCode BaseCurrency { get; set; }
    }
}
