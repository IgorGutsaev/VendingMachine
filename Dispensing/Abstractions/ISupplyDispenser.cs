using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions
{
    public interface ISupplyDispenser: IKioskEventProducer
    {
        void Dispense();
    }
}
