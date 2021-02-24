using Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.Utils.Extensions;
using System.IO;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService.SlipFabrics
{
    public class LVSlipHrblFabric : SlipComponentsFabric
    {
        public LVSlipHrblFabric(ICatalogService productService, ISlipRepository slipComponentRepository)
            : base(productService)
        {
            _slipComponentRepository = slipComponentRepository;
        }

        public override string Standard(Order order)
        {
            string slip = base.Standard(order);

            string barcodeComponent = string.Empty;

            if (order.Obtaining == Ordering.Abstractions.Enums.GoodsObtainingMethod.Warehouse)
            {
                string bmpFile = Path.ChangeExtension(Path.GetTempFileName(), ".bmp");
                order.Number.TextToBarcode().Save(bmpFile);
                barcodeComponent = _slipComponentRepository.GetBarcode(order.Location, order.Language).Replace($"$v{VAR_BARCODE_IMAGE_PATH}$", bmpFile);
            }

            return slip.Replace($"$v{VAR_BARCODE_FOOTER}$", barcodeComponent);
        }

        public override string DateFormat => "yyyy-MM-dd HH:mm:ss";

        const string VAR_BARCODE_IMAGE_PATH = "BarcodeImagePath";
        const string VAR_BARCODE_FOOTER = "BarcodeFooter";
    }
}