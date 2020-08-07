using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Plupictures
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int Plu { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public int? PictureId { get; set; }
        public int? PictureSourceId { get; set; }
        public DateTime? Updated { get; set; }
        public string CategoryTitle { get; set; }
        public int? Active { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
    }
}
