namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    using System;
    
    public partial class UpdateTax
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double? Tax { get; set; }
        public byte? Mask { get; set; }
        public byte? Priority { get; set; }
        public DateTime? ValidFrom { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
    }
}
