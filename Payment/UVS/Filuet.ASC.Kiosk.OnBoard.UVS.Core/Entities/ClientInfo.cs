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
    
    public partial class ClientInfo
    {
        public int Id { get; set; }
        public int HeadID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string VATCode { get; set; }
        public string Address { get; set; }
        public string Template { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
    }
}
