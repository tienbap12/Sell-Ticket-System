using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ST.Domain.Commons.Abstractions;
using ST.Domain.Data;
using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ST.Domain.Commons.Primitives;
using ST.Domain.Interfaces;
using ST.MainInfrastructure.Repositories;

namespace ST.MainInfrastructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        internal readonly object _dbSet;
        private IDbContextTransaction? _transaction;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the database provider (e.g., SQL Server) if not using dependency injection
                optionsBuilder.UseSqlServer("Server=THANHTIEN-24695\\SQLEXPRESS;Database=MyST;User Id=sa;Password=123;TrustServerCertificate=True;");
            }
        }

        private Task UpdateAuditableEntities()
        {
            var entries = ChangeTracker.Entries();

            List<EntityEntry> auditableEntries =
                entries is null ? [] :
                entries.Where(entry => entry.Entity is IAuditInfo).ToList();

            foreach (var entry in auditableEntries)
            {
                if (entry.State == EntityState.Added)
                {
                    var createdOnUtcProperty = entry.Entity.GetType().GetProperty("CreatedAt");
                    createdOnUtcProperty?.SetValue(entry.Entity, DateTimeOffset.UtcNow, null);
                }

                if (entry.State == EntityState.Modified)
                {
                    var modifiedOnUtcProperty = entry.Entity.GetType().GetProperty("LastModifiedOn");
                    modifiedOnUtcProperty?.SetValue(entry.Entity, DateTimeOffset.UtcNow, null);
                }
            }
            return Task.CompletedTask;
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

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
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
            await base.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAsync<T>(Guid id) where T : class
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

        public async Task CreateRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            await Set<TEntity>().AddRangeAsync(entities);
        }


        public async Task BeginTransacionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await this.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (_transaction != null)
                    await _transaction.CommitAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
                await _transaction.RollbackAsync(cancellationToken);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            return new GenericRepository<TEntity>(this);
        }
    }
}