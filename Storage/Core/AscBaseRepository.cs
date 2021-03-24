using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class AscBaseRepository<TDbContext, TEntity> : IAscCacheRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public bool IsAutoSave { get; protected set; }
        public TDbContext DbContext { get; protected set; }
        public DbSet<TEntity> DbSet { get; protected set; }

        public virtual IQueryable<TEntity> QueryAll
        {
            get
            {
                return this.DbSet.AsNoTracking();
            }
        }

        public AscBaseRepository(TDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");

            this.IsAutoSave = false;

            this.DbContext = dbContext;
            this.DbSet = this.DbContext.Set<TEntity>();
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                return;

            this.DbSet.AddRange(entities);
            this.SaveChanges();
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity", "Can't add null Entity to DbContext");

            this.DbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            this.DbSet.Add(entity);
            this.SaveChanges();

            this.DbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => QueryAll.Where(predicate);

        public IEnumerable<TEntity> GetAll()
        {
            return this.QueryAll.ToList();
        }

        protected virtual int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public bool Truncate()
        {
            IEnumerable<TEntity> entities = this.QueryAll.ToList();

            var tracked = DbContext.ChangeTracker.Entries<TEntity>().ToList();
            foreach (var tr in tracked)
                tr.State = EntityState.Detached;

            foreach (var entity in entities)
                this.DbSet.Remove(entity);

            this.DbContext.SaveChanges();
            this.DbContext.Database.ExecuteSqlRaw("VACUUM"); // Shrink database file. Another way is to set auto vacuum flag on database

            return true;
        }

        public virtual bool Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity", "Can't delete null Entity to DbContext");

            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            this.SaveChanges();

            return true;
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                return true;

            var tracked = this.DbContext.ChangeTracker.Entries<TEntity>().ToList();

            foreach (var tr in tracked)
                if (entities.Any(x => x.GetHashCode() == tr.Entity.GetHashCode()))
                {
                    tr.State = EntityState.Detached;
                }

            this.DbSet.RemoveRange(entities);

            this.SaveChanges();

            return true;
        }

        public int Count()
        {
            return this.QueryAll.Count();
        }
    }
}
