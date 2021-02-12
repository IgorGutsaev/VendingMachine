using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipService;
using Filuet.ASC.Kiosk.OnBoard.SlipService.SlipFabrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipTest
{
    public abstract class BaseTest
    {
        const string SLIP_COMPONENTS_PATH = @"\..\..\..\..\SlipComponents";

        public BaseTest()
        {
            _slipRepository = new SlipRepository(SLIP_COMPONENTS_PATH);
        }

        protected readonly ISlipRepository _slipRepository;

        protected SlipComponentsFabric GetComponentFabric(Order order)
        {
            switch (order.Location)
            {
                case Utils.Common.Business.Locale.Latvia:
                    return new LVSlipHrblFabric(_slipRepository);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
