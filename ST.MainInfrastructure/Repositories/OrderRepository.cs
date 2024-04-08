using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;

namespace ST.MainInfrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
        }
        public async Task<Order> GetDetailOrderAsync(Guid id)
        {
            return await _context.Orders.Include(x => x.Details)
                                        .ThenInclude(t => t.Ticket)
                                        .Where(o => o.Id == id)
                                        .FirstOrDefaultAsync();
        }
        public async Task<List<Order>> GetOrderByUserIdAsync(int id)
        {
            return await _context.Orders.Where(o => o.UserId == id)
                                        .ToListAsync();
        }
    }
}