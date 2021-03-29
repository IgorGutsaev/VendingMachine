using Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.SlipService.SlipFabrics;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public class SlipService : ISlipService
    {
        public SlipService(ISlipRepository slipRepository, ICatalogService catalogService, SlipServiceSettings slipSettings)
        {
            _slipRepository = slipRepository;
            _catalogService = catalogService;
            _slipSettings = slipSettings;
            
            _printDocument = new PrintDocument();
        }

        public Slip Build(Order order, SlipType type)
        {
            _slipFabric = GetFabric(order);
            switch (type)
            {
                case SlipType.Standard:
                    return Slip.Create(_slipFabric.Standard(order));
                case SlipType.Crash:
                    return Slip.Create(_slipFabric.Crash(order));
                default:
                    throw new NotImplementedException();
            }
        }

        public bool Print(Order order, SlipType type, out string imageFile)
        {
            try
            {
                Slip slip = Build(order, type);

                Image image = HtmlRender.RenderToImage(slip.Data, new Size(250, 800), new Size(270, 800), Color.White);

                string filename = order.Number;
                int index = 0;
                string postfix = string.Empty;
                while (File.Exists(_slipSettings.SlipImageStorage + @$"\{filename}.html"))
                {
                    index++;
                    filename = $"{order.Number}_{index}";
                }

                string file = _slipSettings.SlipImageStorage + @$"\{filename}.html";

                // Put image to the image folder
                Task.Factory.StartNew(() =>
                {
                    File.WriteAllText(file, slip.Data);
                });

                imageFile = file;

                SendOnPrinter(image);
                return true;
            }
            catch
            {
                imageFile = string.Empty;
                return false;
            }
        }

        private void SendOnPrinter(Image image)
        {
            _printDocument.PrintPage += (sender, ev) => {
                ev.Graphics.DrawImage(image, Point.Empty);
                ev.HasMorePages = false;
            };

            if (_printDocument.PrinterSettings.IsValid)
            {
                _printDocument.Print();
            }
            else
            {
                throw new Exception("Printer is invalid.");
            }
        }

        private SlipComponentsFabric GetFabric(Order order)
        {
            switch (order.Location)
            {
                case Utils.Common.Business.Locale.Latvia:
                     return new LVSlipHrblFabric(_catalogService, _slipRepository);
                default:
                    throw new NotImplementedException();
            }
        }

        private SlipComponentsFabric _slipFabric;
        private readonly SlipServiceSettings _slipSettings;
        private readonly ISlipRepository _slipRepository;
        private readonly ICatalogService _catalogService;
        private readonly PrintDocument _printDocument;
    }
}
