using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Events;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces
{
    public interface IUvsAdapter
    {
        event EventHandler<UvsIncomeEventArgs> OnUvsPayment;
        event EventHandler<UvsOrderCancelEventArgs> OnUvsOrderCancelled;

        /// <summary>
        /// Specify working mode: operator or POS terminal
        /// </summary>
        /// <param name="mode"></param>
        void SetDepMode(UvsDepMode mode);

        /// <summary>
        /// Send order details to UVS
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="dsId"></param>
        /// <param name="dsName"></param>
        /// <param name="totaldue"></param>
        /// <param name="orderLines"></param>
        /// <returns></returns>
        bool CreateOrder(string orderNumber, string dsId, string dsName, decimal totaldue, IList<OrderLine> orderLines);

        bool CancelOrder(string orderNumber);

        bool ConfirmPayment(string orderNumber);

        bool IsOrderCanceled(string orderNumber);
    }
}