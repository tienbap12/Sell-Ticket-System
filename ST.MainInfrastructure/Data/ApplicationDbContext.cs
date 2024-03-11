using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST.Application.Commons.Interfaces;
using ST.Domain.Commons;
using ST.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext,
        IApplicationDbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entityEntry in ChangeTracker.Entries<IAuditInfo>())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entityEntry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted).ToList();
            foreach (var entityEntry in changedEntriesCopy)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

    }
}
