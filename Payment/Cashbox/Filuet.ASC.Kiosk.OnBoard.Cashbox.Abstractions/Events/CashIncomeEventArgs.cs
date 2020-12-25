using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events
{
    public sealed class CashIncomeEventArgs : EventArgs
    {
        /// <summary>
        /// 0 is coin, 1 is note
        /// </summary>
        public bool IsBill { get; private set; }

        public Money Money { get; private set; }

        public Money NativeMoney { get; private set; }

        public static CashIncomeEventArgs CoinIncome(Money money, Money nativeMoney) => new CashIncomeEventArgs { Money = money, NativeMoney = nativeMoney, IsBill = false };

        public static CashIncomeEventArgs BillIncome(Money money, Money nativeMoney) => new CashIncomeEventArgs { Money = money, NativeMoney = nativeMoney,  IsBill = true };
    }
}
