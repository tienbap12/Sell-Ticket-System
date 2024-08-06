using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ST.Domain.Commons.Primitives;
using ST.Domain.Interfaces;

namespace ST.Domain.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellation = default);

        Task CreateAsync<T>(T entity) where T : class;

        Task CreateRangeAsync<T>(IEnumerable<T> entities) where T : class;

        Task DeleteAsync<T>(Guid id) where T : class;


        Task BeginTransacionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollBackAsync(CancellationToken cancellationToken = default);
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
    }
}