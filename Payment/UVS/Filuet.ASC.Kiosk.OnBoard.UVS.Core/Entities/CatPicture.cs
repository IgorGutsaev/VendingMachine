//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatPicture
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int doc_id { get; set; }
        public string category_name { get; set; }
        public string short_category_name { get; set; }
        public int picture_id { get; set; }
        public int op_nr { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public byte[] tstamp { get; set; }
        public Nullable<int> Active { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
    }
}
