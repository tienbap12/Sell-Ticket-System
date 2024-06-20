using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task InserRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
