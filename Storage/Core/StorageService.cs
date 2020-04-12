﻿using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class StorageService : IStorageService
    {
        protected IAscUnitOfWork _uow;

        private IPlanogramRepository _planogramRepository;

        protected IPlanogramRepository PlanogramRepository
        {
            get
            {
                if (_planogramRepository == null)
                    _planogramRepository = new PlanogramRepository((LocalStorageContext)_uow?.GetContext());

                return _planogramRepository;
            }
        }

        public StorageService(IAscUnitOfWork uow) => _uow = uow;

        public void Add(Planogram planogram) => PlanogramRepository.Add(planogram);

        public void Truncate() => PlanogramRepository.Truncate();

        public int Count() => PlanogramRepository.Count();

        public IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram)
            => PlanogramRepository.Get(planogram).AsEnumerable();

        public void Dispose() => _uow.Dispose();

        public override string ToString() => "SQLiteDB";
    }
}
