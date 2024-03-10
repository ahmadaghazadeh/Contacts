using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot> : IScopedLifetime where TAggregateRoot : class, IAggregateRoot<TAggregateRoot>, IEntityBase
    {
        protected readonly DbContextBase DbContext;

        protected RepositoryBase(IDbContext dbContext)
        {
            this.DbContext = (DbContextBase)dbContext;
        }

        protected IQueryable<TAggregateRoot> Set => DbContext.Set<TAggregateRoot>().AsQueryable();
        protected void Create(TAggregateRoot aggregateRoot)
        {
            DbContext.Set<TAggregateRoot>().Add(aggregateRoot);
        }
        protected void CreateRange(List<TAggregateRoot> aggregateRoots)
        {
            DbContext.Set<TAggregateRoot>().AddRange(aggregateRoots);
        }

        protected void Delete(TAggregateRoot aggregateRoot)
        {
            DbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
        }
        protected void Update(TAggregateRoot aggregateRoot)
        {
            DbContext.Set<TAggregateRoot>().Update(aggregateRoot);
        }

        protected List<TAggregateRoot> GetAll()
        {
            return DbContext.Set<TAggregateRoot>().ToList();
        }

        protected bool IsExist(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return DbContext.Set<TAggregateRoot>().Any(expression);
        }
    }
}
