using System.Collections.Generic;
using System.Threading.Tasks;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;

namespace ST.MainInfrastructure.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}