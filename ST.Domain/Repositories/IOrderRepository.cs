using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ST.Domain.Entities;

namespace ST.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(int id);

        Task<Order> GetDetailOrderAsync(int id);

        Task<List<Order>> GetOrderByUserIdAsync(int id);

        Task CreateAsync(Order order);

        Task UpdateAsync(Order order);

        Task DeleteAsync(int id);
    }
}