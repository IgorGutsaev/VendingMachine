using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCashPayment(this IServiceCollection serviceCollection)
        => serviceCollection.AddSingleton<ICashPaymentService>(new CashPaymentService()); 
    }
}
