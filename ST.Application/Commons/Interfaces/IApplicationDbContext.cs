using Microsoft.EntityFrameworkCore;
using ST.Domain.Entities;

namespace ST.Application.Commons.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Ticket> Tickets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}