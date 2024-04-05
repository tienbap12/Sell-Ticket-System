using System.Collections.Generic;
using System.Threading.Tasks;
using ST.Domain.Entities;

namespace ST.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task InserRangeAsync(IEnumerable<OrderDetails> orderDetails);
    }
}