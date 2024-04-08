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
    public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
        }
        public async Task<List<OrderDetails>> GetAllOrderDetail(Guid id)
        {
            return await _context.OrderDetails.Where(x => x.OrderId == id).ToListAsync();
        }

        public Task<List<OrderDetails>> GetAllOrderDetailByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}