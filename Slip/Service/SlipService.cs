using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public class SlipService : ISlipService
    {
        public Slip Emergency(Order order)
        {
            throw new NotImplementedException();
        }

        public Slip Receipt(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
