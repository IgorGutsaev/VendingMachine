using Filuet.Utils.Extensions.Helpers;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums
{
    public enum SlipComponent
    {
        [Code("standard")]
        Standard = 0x01,
        [Code("crash")]
        Crash,
        [Code("test")]
        Test,
        [Code("line")]
        Line,
        [Code("barcode")]
        Barcode
    }
}
