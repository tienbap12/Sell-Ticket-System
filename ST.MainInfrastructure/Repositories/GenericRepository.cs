using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Interfaces;
using ST.MainInfrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _unitOfWork.CreateAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await _unitOfWork.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.DeleteAsync<TEntity>(id);
        }

        public async Task InserRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.CreateRangeAsync(entities);
        }
    }
}
