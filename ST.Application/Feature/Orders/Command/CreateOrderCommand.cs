using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Orders.Command
{
    public class CreateOrderCommand(OrderRequest request) : ICommand<Response>
    {
        public OrderRequest Request { get; set; } = request;
    }
}