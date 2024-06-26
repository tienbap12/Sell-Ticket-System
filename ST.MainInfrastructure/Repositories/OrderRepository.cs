using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<Order>(context, unitOfWork), IOrderRepository
    {
        public async Task<Order> GetDetailOrderAsync(Guid id)
        {
            return await _dbSet.Include(x => x.Details)
                                        .ThenInclude(t => t.Ticket)
                                        .Where(o => o.Id == id)
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrderByUserIdAsync(Guid id)
        {
            return await _dbSet.Where(o => o.UserId == id)
                                        .ToListAsync();
        }
    }
}