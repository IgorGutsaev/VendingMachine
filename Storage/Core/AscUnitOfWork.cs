using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class AscUnitOfWork<TDbContext> : IAscUnitOfWork
        where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public TDbContext Context
        {
            get
            {
                return _dbContext;
            }
        }

        public AscUnitOfWork(TDbContext context)
        {
            _dbContext = context;
        }

        public virtual void Dispose()
        {
            _dbContext?.Dispose();
        }

        public DbContext GetContext()
        {
            return Context;
        }
    }
}
