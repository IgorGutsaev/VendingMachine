using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums
{
    public enum OrderAction
    {
        [Description("Open")]
        /// <summary>
        /// Open session of a new order
        /// </summary>
        Open = 1,
        [Description("MoneyIncome")]
        /// <summary>
        /// On money income of any type: cash, card, external...
        /// </summary>
        MoneyIncome = 2,
        [Description("ChangeIssue")]
        /// <summary>
        /// Extract change
        /// </summary>
        ChangeIssue = 3,
        [Description("Dispense")]
        /// <summary>
        /// Dispense the product
        /// </summary>
        Dispense = 4,
        [Description("PrintReceipt")]
        /// <summary>
        /// Print receipt
        /// </summary>
        PrintReceipt = 5,
        [Description("Complete")]
        /// <summary>
        /// Complete
        /// </summary>
        Complete = 6,
        [Description("ErrorOccured")]
        /// <summary>
        /// Error occured
        /// </summary>
        ErrorOccured = 7
    }
}
