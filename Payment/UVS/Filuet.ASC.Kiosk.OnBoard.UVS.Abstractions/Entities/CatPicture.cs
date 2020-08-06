using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CatPicture
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int doc_id { get; set; }
        public string category_name { get; set; }
        public string short_category_name { get; set; }
        public int picture_id { get; set; }
        public int op_nr { get; set; }
        public DateTime? timestamp { get; set; }
        public byte[] tstamp { get; set; }
        public int? Active { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
    }
}
