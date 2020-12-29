using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions;

namespace Filuet.ASC.OnBoard.Payment.Core
{
    public class PaymentMediator
    {
        public PaymentMediator(IPaymentProvider paymentProvider, ICashPaymentService cashService)
        {
            _cashService = cashService;
            _paymentProvider = paymentProvider;

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
        private readonly IPaymentProvider _paymentProvider;
    }
}
