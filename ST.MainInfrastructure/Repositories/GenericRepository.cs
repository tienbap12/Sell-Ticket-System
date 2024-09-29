using Microsoft.EntityFrameworkCore;
using ST.Domain.Commons.Primitives;
using ST.Domain.Interfaces;
using ST.MainInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories;

/// <summary>
///     Represents a generic repository for accessing and manipulating entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GenericRepository{TEntity}" /> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    /// <summary>
    ///     Gets an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity with the specified ID, or null if not found.</returns>
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    ///     Gets all entities asynchronously.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    ///     Creates a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }


    /// <summary>
    ///     Deletes an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    public void DeleteAsync(Guid id)
    {
        _context.Remove(id);
    }

    public IQueryable<TEntity> BuildQuery => _dbSet.AsQueryable();

    /// <summary>
    ///     Inserts a range of entities asynchronously.
    /// </summary>
    /// <param name="entities">The entities to insert.</param>
    public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }
}