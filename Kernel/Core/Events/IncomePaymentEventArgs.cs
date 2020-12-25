using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions.Models;
using Filuet.Utils.Common.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class IncomePaymentEventArgs : EventArgs
    {
        public string OrderNumber { get; set; }

        public IncomePayment Income { get; set; }

        public override string ToString()
            => JsonSerializer.Serialize(Income, typeof(object), JsonSerializationOptions.EventPrettyOptions);
    }
}
