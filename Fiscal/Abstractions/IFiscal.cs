using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.OnBoard.Fiscal.Abstractions
{
    public interface IFiscal
    {
        event EventHandler<string> OnProduced;

        event EventHandler<string> OnError;

        void Build(Order order);
    }
}
