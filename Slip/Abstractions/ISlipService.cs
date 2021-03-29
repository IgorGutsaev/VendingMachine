using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public interface ISlipService
    {
        Slip Build(Order order, SlipType type);

        bool Print(Order order, SlipType type, out string imageFile);
    }
}
