using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filuet.ASC.OnBoard.Payment.Core
{
    public class PaymentMediator
    {
        public PaymentMediator(IPaymentProvider paymentProvider, ICashPaymentService cashService, IEcommerceServices ecommerceServices)
        {
            _paymentProvider = paymentProvider;
            _cashService = cashService;
            _ecommerceServices = ecommerceServices;
            _paymentProvider.OnFetchMoneyCommand += (sender, e) =>
            {
                IEcommerceService ecomService = ecommerceServices[e.Source];

                if (ecomService != null)
                    ecomService.FetchMoney(e.Order);
                else
                {
                    switch (e.Source)
                    {
                        case Utils.Common.Business.PaymentSource.Cash:
                            foreach (ICashDeviceAdapter cashDevide in _cashService.CashDevices)
                                cashDevide.Start();
                            break;
                        default:
                            throw new NotImplementedException($"Unknown payment source {e.Source.GetCode()}");
                    }
                }
            };

            _paymentProvider.OnTotalAmountSpecified += (sender, e) => {
                // Notify all cash devices about duty (a remaining part of payment) was changed
                foreach (var cashDevice in _cashService.CashDevices)
                    cashDevice.ReduceOrSetDutyTo(e.Value);
            };

            _paymentProvider.OnGiveChangeSpecified += (sender, e) => {
                _cashService.IssueChange(e.ChangeAmount);
            };

            foreach (var cashDevice in _cashService.CashDevices)
                cashDevice.OnMoneyReceived += (sender, e) => {
                    _paymentProvider.SomeMoneyIncome(e.Money);

                    // Notify all cash devices about duty (a remaining part of payment) was changed
                    foreach (var device in _cashService.CashDevices)
                        device.ReduceOrSetDutyTo(_paymentProvider.Duty);
                };

            foreach (var cashDevice in _cashService.CashDevices)
                cashDevice.OnSomeChangeIssued += (sender, e) => {
                    _paymentProvider.SomeChangeExtracted(e.Money);
                };
        }

        private readonly ICashPaymentService _cashService;
        private readonly IEcommerceServices _ecommerceServices;
        private readonly IPaymentProvider _paymentProvider;
    }
}
