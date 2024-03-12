using MediatR;
using ST.Application.Commons.Interfaces;
using ST.Domain.Data;
using System;
using System.Threading.Tasks;

namespace ST.Application.Commons.Behaviors
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task RollbackAsync()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
