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

        public MoneyNaturalized Money { get; private set; }

        public static CashIncomeEventArgs CoinIncome(MoneyNaturalized money) => new CashIncomeEventArgs { Money = money, IsBill = false };

        public static CashIncomeEventArgs BillIncome(MoneyNaturalized money) => new CashIncomeEventArgs { Money = money,  IsBill = true };
    }
}
