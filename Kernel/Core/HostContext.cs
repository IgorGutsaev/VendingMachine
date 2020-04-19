using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Kernel.Core
{
    /// <summary>
    /// Host = Kiosk in context of this solution
    /// </summary>
    public class HostContext
    {
        public StorageSettings Storage { get; set; }

        public PaymentSettings Payment { get; set; }
    }
}