using Microsoft.EntityFrameworkCore;
using ST.Domain.Entities;

namespace ST.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Ticket> Tickets { get; set; }
        void DetachAllEntities();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}