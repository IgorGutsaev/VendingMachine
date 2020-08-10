using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CatPictures
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DocId { get; set; }
        public string CategoryName { get; set; }
        public string ShortCategoryName { get; set; }
        public int PictureId { get; set; }
        public int OpNr { get; set; }
        public DateTime? Timestamp { get; set; }
        public byte[] Tstamp { get; set; }
        public int? Active { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
    }
}
