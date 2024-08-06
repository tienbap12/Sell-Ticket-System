using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ST.Domain.Commons.Primitives;

namespace ST.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        void DeleteAsync(Guid id);
        IQueryable<TEntity> BuildQuery { get; }
    }
}
