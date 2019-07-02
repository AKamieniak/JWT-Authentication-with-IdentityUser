using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JWT.Infrastructure.Data;
using JWT.Infrastructure.Interfaces;
using JWT.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JWT.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;
        protected DbSet<TEntity> DbSet;
        protected Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> Includes;

        public Repository(ApplicationDbContext applicationDbContext, Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> includes = null)
        {
            _applicationDbContext = applicationDbContext;
            DbSet = applicationDbContext.Set<TEntity>();
            Includes = includes;
        }

        public virtual Task<IQueryable<TEntity>> GetAll()
        {
            var result = ApplyIncludes(DbSet, Includes);

            return Task.FromResult(result);
        }

        public async Task<TEntity> GetById(int entityId)
        {
            return (await GetByIds(new[] { entityId })).SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetByIds(IEnumerable<int> entityIds)
        {
            entityIds = entityIds.Distinct().ToList();

            return (await GetByQuery(entity => entityIds.Contains(entity.Id))).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetByQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return (await GetAll()).Where(predicate);
        }

        public async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task Remove(int entityId)
        {
            var entity = await DbSet.FindAsync(entityId);
            DbSet.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext?.Dispose();
        }

        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> queryable, Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> includes)
        {
            if (includes != null)
            {
                queryable = ((dynamic)includes).Compile().Invoke(queryable) as IQueryable<TEntity>;
            }

            return queryable;
        }
    }
}
