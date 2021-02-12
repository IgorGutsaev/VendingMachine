using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public interface ISlipService
    {
        Slip Receipt(Order order);

        Slip Emergency(Order order);
    }
}
