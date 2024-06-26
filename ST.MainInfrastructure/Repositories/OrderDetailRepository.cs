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
    public class OrderDetailRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<OrderDetails>(context, unitOfWork), IOrderDetailRepository
    {
        public async Task<List<OrderDetails>> GetAllOrderDetail(Guid id)
        {
            return await _dbSet.Where(x => x.OrderId == id).ToListAsync();
        }

        public Task<List<OrderDetails>> GetAllOrderDetailByUserId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}