using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    /// <summary>
    /// Common settings of bill acceptance (not related to the real device)
    /// </summary>
    public class CashHandleSettings
    {
        public uint IssueIndex { get; set; } 

        /// <summary>
        /// In some countries there're 2 currency in use
        /// </summary>
        public CurrencyCode BaseCurrency { get; set; }

        public IEnumerable<Money> BillsToReceive { get; set; }

        public IEnumerable<Money> BillsToGiveChange { get; set; }
    }
}
