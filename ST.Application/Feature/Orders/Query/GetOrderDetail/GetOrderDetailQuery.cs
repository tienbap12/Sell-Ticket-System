using ST.Application.Wrappers;
using ST.Constracts.Order;

namespace ST.Application.Feature.Orders.Query.GetOrderDetail
{
    public class GetOrderDetailQuery(int id) : IQuery<List<DetailsResponse>>
    {
        public int Id { get; set; } = id;
    }
}