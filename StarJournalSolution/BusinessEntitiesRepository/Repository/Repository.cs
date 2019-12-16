namespace BusinessEntitiesRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    ////using Microsoft.Extensions.Configuration.Abstractions;

    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository()
        {
            ////var x = new Microsoft.Extensions.Configuration.Abstractions();
        }

        internal protected DbContext Database { get; }

        internal Repository(DbContext context)
        {
            this.Database = context;
        }

        public TEntity Get(Guid id)
        {
            return this.EntitySet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.EntitySet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.EntitySet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _ = this.EntitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _ = this.EntitySet.Remove(entity);
        }

        private DbSet<TEntity> EntitySet
        {
            get
            {
                return this.Database.Set<TEntity>();
            }
        }
    }
}
