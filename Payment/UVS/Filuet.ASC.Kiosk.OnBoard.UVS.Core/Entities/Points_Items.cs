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
    
    public partial class Points_Items
    {
        public int id { get; set; }
        public int KvitoEiluteId { get; set; }
        public Nullable<double> Points { get; set; }
        public Nullable<int> DiscountIdentificator { get; set; }
    
        public virtual KvitoEilute KvitoEilute { get; set; }
    }
}
