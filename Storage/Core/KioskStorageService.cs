using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class KioskStorageService : AscBaseService<IAscUnitOfWork>, IKioskStorageService
    {
        private IPlanogramRepository _planogramRepository;

        protected IPlanogramRepository PlanogramRepository
        {
            get
            {
                if (_planogramRepository == null)
                    _planogramRepository = new PlanogramRepository((LocalStorageContext)UnitOfWork?.GetContext());

                return _planogramRepository;
            }
        }

        public KioskStorageService(IAscUnitOfWork uow)
            : base(uow)
        { }

        public void Add(Planogram planogram) => PlanogramRepository.Add(planogram);

        public void Truncate()
        {
            PlanogramRepository.Truncate();
        }

        public int Count() => PlanogramRepository.Count();     

        public IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram) => PlanogramRepository.Get(planogram).ToList();

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
