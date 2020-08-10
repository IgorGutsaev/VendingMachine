using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces
{
    public interface IUvsAdapter
    {
        UvsDepMode UvsDepMode { get; set; }

        ///// <summary>
        ///// RData/SellDiscount/Id
        ///// </summary>
        ///// <param name="paymentId"></param>
        //public delegate void UvsPaymentDataDelegate(string paymentId, string paymentMethod, decimal paymentAmount);

        //event UvsPaymentDataDelegate UvsPaymentData;

        bool AddOrderToPlu(string orderNumber, string dsId, string dsName, double totaldue, IList<OrderLine> orderLines);
        IGenericResult CancelOrder(string orderNumber);
        IGenericResult GetOrderPaymentResult(string orderNumber);
        bool IsOrderCanceled(string orderNumber);
        void Unsubscribe();
    }
}