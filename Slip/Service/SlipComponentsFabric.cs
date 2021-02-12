using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public abstract class SlipComponentsFabric
    {
        public virtual string DateFormat => "D";

        /// <summary>
        /// Standard slip of the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual string Standard(Order order)
        {
            string html = _slipComponentRepository.GetStandard(order.Location);

            html = html.Replace($"&{VAR_ORDER_NUMBER}&", order.Number)
                .Replace($"&{VAR_ORDER_DATE}&", order.Timestamp.ToString(DateFormat));

            return html;
        }

        public virtual string Crash(Order order)
            => _slipComponentRepository.GetCrash(order.Location);

        public virtual string Test(Order order)
            => _slipComponentRepository.GetTest(order.Location);

        protected ISlipRepository _slipComponentRepository;

        const string VAR_ORDER_NUMBER = "OrderNumber";
        const string VAR_ORDER_DATE = "OrderDate";
    }
}
