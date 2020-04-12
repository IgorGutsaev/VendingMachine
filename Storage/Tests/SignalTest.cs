using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Tests
{
    public class SignalTest : BaseTest
    {
        [Theory]
        [InlineData("{ foo: bar }")]
        public void Test_Create_Planogram_Entity(string planogram)
        {
            // Prepare
            Planogram source = Planogram.Create(planogram);

            // Validate
            Assert.NotNull(source);
            Assert.True(!string.IsNullOrWhiteSpace(source.Id));
            Assert.Equal(planogram, source.Data);
        }

        [Theory]
        [InlineData("{ foo: bar }")]
        public void Test_Save_Planogram(string planogram)
        {
            // Prepare
            Planogram source = Planogram.Create(planogram);
            string id = source.Id;
            IStorageService service = NewSignalService;

            // Pre-validate
            Assert.NotNull(service);

            // Perform
            service.Add(source);
            Planogram target = service.Get(x => x.Id == id).SingleOrDefault();

            // Post-validate
            Assert.NotNull(target);
            Assert.Equal(source.Data, target.Data);
            Assert.Equal(source.Timestamp, target.Timestamp);
        }
    }
}
