using Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public abstract class SlipComponentsFabric
    {
        public SlipComponentsFabric(ICatalogService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Standard slip of the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual string Standard(Order order)
        {
            string slip = _slipComponentRepository.GetStandard(order.Location, order.Language)
                .Replace($"$v{VAR_ORDER_NUMBER}$", order.Number)
                .Replace($"$v{VAR_ORDER_CUSTOMER_NAME}$", order.CustomerName)
                .Replace($"$v{VAR_ORDER_DATE}$", order.Timestamp.ToString(DateFormat))
                .Replace($"$v{VAR_ORDER_TOTAL_PRICE}$", order.Amount.ToString())
                .Replace($"$v{VAR_ORDER_VOLUME_POINTS}$", order.Points.ToString("n2"))
                .Replace($"$v{VAR_KIOSK}$", order.ExtraData[VAR_KIOSK].ToString())
                .Replace($"$v{VAR_ORDER_SELECTED_MONTH}$", order.ExtraData[VAR_ORDER_SELECTED_MONTH].ToString());

            string orderLine = _slipComponentRepository.GetOrderLine(order.Location, order.Language);
            StringBuilder orderLines = new StringBuilder();

            foreach (var i in order.Items)
            {
                orderLines.AppendLine(orderLine.Replace($"$v{VAR_ORDER_LINE_NAME}$", _productService.GetName(i.ProductUID, order.Language))
                    .Replace($"$v{VAR_ORDER_LINE_SKU}$", i.ProductUID)
                    .Replace($"$v{VAR_ORDER_LINE_PRICE}$", i.Amount.ToString())
                    .Replace($"$v{VAR_ORDER_LINE_QUANTITY}$", i.Quantity.ToString()));
            }
            slip = slip.Replace($"$v{VAR_ORDER_LINES}$", orderLines.ToString());

            return slip;
        }

        public virtual string Crash(Order order)
            => _slipComponentRepository.GetCrash(order.Location, order.Language);

        public virtual string Test(Order order)
            => _slipComponentRepository.GetTest(order.Location, order.Language);

        private readonly ICatalogService _productService;

        protected ISlipRepository _slipComponentRepository;

        public virtual string DateFormat => "D";

        const string VAR_ORDER_NUMBER = "OrderNumber";
        const string VAR_ORDER_DATE = "OrderDate";
        const string VAR_ORDER_CUSTOMER_NAME = "CustomerName";
        const string VAR_ORDER_TOTAL_PRICE = "TotalPrice";
        const string VAR_ORDER_VOLUME_POINTS = "VolumePoints";
        const string VAR_ORDER_LINES = "OrderLines";
        const string VAR_ORDER_LINE_NAME = "Name";
        const string VAR_ORDER_LINE_SKU = "Sku";
        const string VAR_ORDER_LINE_PRICE = "Price";
        const string VAR_ORDER_LINE_QUANTITY = "Qty";
        const string VAR_KIOSK = "Kiosk";
        const string VAR_ORDER_SELECTED_MONTH = "SelectedMonth";
    }
}