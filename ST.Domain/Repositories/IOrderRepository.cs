using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(Guid id);

        Task<Order> GetDetailOrderAsync(Guid id);

        Task<List<Order>> GetOrderByUserIdAsync(Guid id);

        Task CreateAsync(Order order);

        Task UpdateAsync(Order order);

        Task DeleteAsync(Guid id);
    }
}