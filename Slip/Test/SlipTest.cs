using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipService;
using System.Drawing;
using System.Drawing.Imaging;
using TheArtOfDev.HtmlRenderer.WinForms;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.SlipTest
{
    public class SlipTest : BaseTest
    {
        [Theory]
        [MemberData(nameof(OrdersGenerator.GetOrders), MemberType = typeof(OrdersGenerator))]
        public void Test_Html_to_BMP(Order order)
        {
            // Prepare
            SlipComponentsFabric fabric = GetComponentFabric(order);


            // Pre-validate


            // Perform

            Slip slip = Slip.Create(fabric.Standard(order));

            // Post-validate
            Assert.NotNull(slip);

            Image image = HtmlRender.RenderToImage(slip.Data, new Size(250, 800), new Size(270, 800), Color.White);
            image.Save(@"D:\Test.png", ImageFormat.Png);
        }
    }
}
