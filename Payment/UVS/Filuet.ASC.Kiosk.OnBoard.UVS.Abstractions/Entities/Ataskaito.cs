using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class Ataskaito
    {
        public int ID { get; set; }
        public DateTime? Nuo { get; set; }
        public DateTime? Iki { get; set; }
        public int? NuoZ { get; set; }
        public int? IkiZ { get; set; }
        public int? Aparatas { get; set; }
        public bool Visi { get; set; }
        public int? NuoKvito { get; set; }
        public int? IkiKvito { get; set; }
        public int? PeriodoTipas { get; set; }
        public int? Detalumas { get; set; }
        public bool VisosGrupes { get; set; }
        public bool VisiTiekejai { get; set; }
        public int? NuoKodo { get; set; }
        public int? IkiKodo { get; set; }
        public bool RibotiPrekesKodus { get; set; }
        public bool VisiVazt { get; set; }
    }
}
