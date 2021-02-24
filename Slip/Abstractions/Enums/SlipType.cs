using Filuet.Utils.Extensions.Helpers;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums
{
    public enum SlipType
    {
        [Code("standard")]
        Standard = 0x01,
        [Code("crash")]
        Crash
    }
}
