using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}
