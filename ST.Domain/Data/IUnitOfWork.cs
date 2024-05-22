using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Domain.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellation = default);

        Task CreateAsync<T>(T entity) where T : class;

        Task CreateRangeAsync<T>(IEnumerable<T> entities) where T : class;

        Task UpdateAsync<T>(T entity) where T : class;

        Task DeleteAsync<T>(int id) where T : class;

        bool IsInTransaction { get; }
        bool IsSaved { get; }

        void SetIsSaved(bool isSave);

        Task BeginTransacionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollBackAsync(CancellationToken cancellationToken = default);
    }
}