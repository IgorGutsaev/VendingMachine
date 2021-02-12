using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TheArtOfDev.HtmlRenderer.WinForms;
using Xunit;
using htmlRend = TheArtOfDev.HtmlRenderer;

namespace Filuet.ASC.Kiosk.OnBoard.SlipTest
{
    public class CanvasTest
    {
        [Fact]
        public void Test_Html_to_BMP()
        {
            // Perform
            Image image =
                HtmlRender.RenderToImage("<html><body><p>This is some html code</p><p>This is another html line</p></body>",  new Size(400, 200), Color.White);

            using MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            // Validate
            Assert.Equal(2140, ms.Length);

           // image.Save(@"D:\Test.png", ImageFormat.Png);

        }
    }
}
