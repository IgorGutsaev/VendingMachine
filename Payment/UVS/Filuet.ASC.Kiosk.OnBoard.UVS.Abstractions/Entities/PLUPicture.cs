using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PLUPicture
    {
        public int id { get; set; }
        public int dep { get; set; }
        public int plu { get; set; }
        public int? category_id { get; set; }
        public string title { get; set; }
        public int? picture_id { get; set; }
        public int? picture_source_id { get; set; }
        public DateTime? updated { get; set; }
        public string category_title { get; set; }
        public int? Active { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
    }
}
