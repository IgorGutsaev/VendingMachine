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

            _paymentProvider.OnAmountSpecified += PaymentProvider_OnAmountSpecified;

            foreach (var cashDevice in _cashService.CashDevices)
                cashDevice.OnMoneyReceived += CashDevice_OnMoneyReceived;
        }

        private void CashDevice_OnMoneyReceived(object sender, Kiosk.OnBoard.Cashbox.Abstractions.Events.CashIncomeEventArgs e)
        {
            _paymentProvider.OnMoneyIncome(e.NativeMoney);

            // Notify all cash devices about duty (a remaining part of payment) was changed
            foreach (var cashDevice in _cashService.CashDevices)
                cashDevice.ReduceOrSetDutyTo(_paymentProvider.Duty);
        }

        private void PaymentProvider_OnAmountSpecified(object sender, MoneyEventArgs e)
        {
            // Notify all cash devices about duty (a remaining part of payment) was changed
            foreach (var cashDevice in _cashService.CashDevices)
                cashDevice.ReduceOrSetDutyTo(e.Value);
        }

        private readonly ICashPaymentService _cashService;
        private readonly IPaymentProvider _paymentProvider;
    }
}
