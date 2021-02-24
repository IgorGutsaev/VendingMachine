using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public interface ISlipService
    {
        Slip Build(Order order, SlipType type);

        void Print(Order order, SlipType type);
    }
}
