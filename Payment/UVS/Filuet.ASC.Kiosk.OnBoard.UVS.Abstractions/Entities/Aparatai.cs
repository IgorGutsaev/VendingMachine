using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Aparatai
    {
        public Aparatai()
        {
            CashierLogs = new HashSet<CashierLogs>();
        }

        public int AparatoId { get; set; }
        public int? NodeId { get; set; }
        public int? NetworkNr { get; set; }
        public string AparatoPavadinimas { get; set; }
        public int? AparatoNr { get; set; }
        public short? SocketNr { get; set; }
        public int? MyId { get; set; }
        public byte? Type { get; set; }
        public int? NonUvsnumber { get; set; }
        public short? KasaType { get; set; }
        public string Fnumber { get; set; }
        public int? Dep { get; set; }
        public string Ipadress { get; set; }
        public string Version { get; set; }
        public string Fbversion { get; set; }
        public int? Posnr { get; set; }
        public string Cpuname { get; set; }
        public int? Cpufreq { get; set; }
        public string HardDriveModel { get; set; }
        public string HardDriveSerial { get; set; }
        public double? HardDriveSizeMb { get; set; }
        public string VideoName { get; set; }
        public int? VideoRamKb { get; set; }
        public int? RamMb { get; set; }

        public virtual ICollection<CashierLogs> CashierLogs { get; set; }
    }
}
