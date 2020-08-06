namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    using System;
    
    public partial class UpdateFH
    {
        public int ID { get; set; }
        public bool FooterHeader { get; set; }
        public string Text { get; set; }
        public byte Line { get; set; }
        public byte? Font { get; set; }
        public DateTime? ValidFrom { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
    }
}
