using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService.SlipFabrics
{
    public class LVSlipHrblFabric : SlipComponentsFabric
    {
        public LVSlipHrblFabric(ISlipRepository slipComponentRepository)
        {
            _slipComponentRepository = slipComponentRepository;
        }

        public override string DateFormat => "yyyy-MM-dd HH:mm:ss";
    }
}
