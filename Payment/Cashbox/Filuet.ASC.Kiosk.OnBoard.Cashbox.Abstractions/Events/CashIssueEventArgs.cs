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

        public Money Money { get; private set; }

        public Money NativeMoney { get; private set; }

        public static CashIssueEventArgs CoinIncome(Money money, Money nativeMoney) => new CashIssueEventArgs { Money = money, NativeMoney = nativeMoney, IsBill = false };

        public static CashIssueEventArgs BillIncome(Money money, Money nativeMoney) => new CashIssueEventArgs { Money = money, NativeMoney = nativeMoney, IsBill = true };
    }
}
