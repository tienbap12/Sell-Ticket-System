using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ST.Domain.Entities;

namespace ST.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetails>> GetAllOrderDetail(Guid id);
        Task InserRangeAsync(IEnumerable<OrderDetails> orderDetails);
    }
}