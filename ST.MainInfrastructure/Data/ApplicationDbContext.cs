using Microsoft.EntityFrameworkCore;
using ST.Domain.Commons;
using ST.Domain.Data;
using ST.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        internal readonly object _dbSet;

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

        public async Task SaveChangesAsync()
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
            await base.SaveChangesAsync();
        }


        public async Task UpdateAsync<T>( T entity) where T : class
        {
             Set<T>().Update(entity);
        }

        public async Task DeleteAsync<T>(int id) where T : class
        {
            var entity = await Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with id {id} not found.");
            }

            Set<T>().Remove(entity);
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await Set<T>().AddAsync(entity);
        }
    }
}
