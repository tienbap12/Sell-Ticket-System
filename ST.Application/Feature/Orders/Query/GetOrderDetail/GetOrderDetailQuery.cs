using ST.Application.Wrappers;
using ST.Constracts.Order;

namespace ST.Application.Feature.Orders.Query.GetOrderDetail
{
    public class GetOrderDetailQuery(Guid id) : IQuery<List<DetailsResponse>>
    {
        public Guid Id { get; set; } = id;
    }
}