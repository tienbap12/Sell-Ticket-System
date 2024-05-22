using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ST.Domain.Entities;

namespace ST.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetails>> GetAllOrderDetail(int id);

        Task<List<OrderDetails>> GetAllOrderDetailByUserId(int id);

        Task InserRangeAsync(IEnumerable<OrderDetails> orderDetails);
    }
}