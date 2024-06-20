using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Interfaces;
using ST.MainInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    /// <summary>
    /// Represents a generic repository for accessing and manipulating entities of type TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public GenericRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity with the specified ID, or null if not found.</returns>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        public async Task CreateAsync(TEntity entity)
        {
            await _unitOfWork.CreateAsync(entity);
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(TEntity entity)
        {
            await _unitOfWork.UpdateAsync(entity);
        }

        /// <summary>
        /// Deletes an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.DeleteAsync<TEntity>(id);
        }

        /// <summary>
        /// Inserts a range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        public async Task InserRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.CreateRangeAsync(entities);
        }
    }
}
