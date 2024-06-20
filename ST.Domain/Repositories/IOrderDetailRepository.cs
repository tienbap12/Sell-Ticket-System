using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetails>> GetAllOrderDetail(Guid id);

        Task<List<OrderDetails>> GetAllOrderDetailByUserId(Guid id);

        Task InserRangeAsync(IEnumerable<OrderDetails> orderDetails);
    }
}