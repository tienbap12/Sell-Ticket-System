using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;

namespace ST.Application.Feature.Orders.Commands
{
    public class CreateOrderCommand(OrderRequest request) : ICommand<Response>
    {
        public OrderRequest Request { get; set; } = request;
    }
}