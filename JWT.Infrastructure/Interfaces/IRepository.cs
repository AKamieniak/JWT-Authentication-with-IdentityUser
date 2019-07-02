using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JWT.Models.Abstractions;

namespace JWT.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetByIds(IEnumerable<int> entityIds);
        Task<IEnumerable<TEntity>> GetByQuery(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task Remove(int entityId);
        Task SaveChanges();
    }
}
