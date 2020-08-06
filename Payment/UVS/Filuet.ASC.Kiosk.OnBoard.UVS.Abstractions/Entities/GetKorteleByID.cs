
namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class GetKorteleByID
    {
        public string Id_number { get; set; }

        private short? CardType { get; set; }

        private int? Statusas { get; set; }

        public string Key1B { get; set; }
        public string PusePIN { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public int ID { get; set; }
    }
}
