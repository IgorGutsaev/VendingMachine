using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events
{
    public sealed class CashIssueEventArgs : EventArgs
    {
        /// <summary>
        /// 0 is coin, 1 is note
        /// </summary>
        public bool IsBill { get; private set; }

        public MoneyNaturalized Money { get; private set; }


        public static CashIssueEventArgs CoinIncome(MoneyNaturalized money) => new CashIssueEventArgs { Money = money, IsBill = false };

        public static CashIssueEventArgs BillIncome(MoneyNaturalized money) => new CashIssueEventArgs { Money = money, IsBill = true };
    }
}
