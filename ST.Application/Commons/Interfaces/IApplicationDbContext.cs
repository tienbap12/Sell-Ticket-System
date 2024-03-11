using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Ticket> Tickets { get; set; }
        void DetachAllEntities();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}