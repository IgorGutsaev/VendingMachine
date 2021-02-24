using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Ecommerce.Service
{
    public class EcommerceServices : IEcommerceServices
    {
        public EcommerceServices() { }

        private IList<IEcommerceService> _services = new List<IEcommerceService>();

        public IEcommerceService this[PaymentSource source] => _services?.FirstOrDefault(x => x.Source == source);

        public IEnumerable<IEcommerceService> Services => _services;

        public void Add(IEcommerceService service)
        {
            if (_services.Any(x => x.Source == service.Source))
                throw new ArgumentException($"ECommerce service list already contains {service.Source.GetCode()}");

            _services.Add(service);
        }
    }
}