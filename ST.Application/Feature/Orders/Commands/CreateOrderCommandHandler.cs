using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Commands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Response>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            decimal total = 0;
            var order = new Order
            {
                Id = request.Request.Id,
                UserId = request.Request.UserId,
            };
            var detailList = new List<OrderDetails>();
            foreach (var item in request.Request.Details)
            {
                var ordDetails = new OrderDetails
                {
                    OrderId = order.Id,
                    TicketId = item.TicketId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };
                total += ordDetails.Price * ordDetails.Quantity;
                detailList.Add(ordDetails);
            }
            await _orderDetailRepository.InserRangeAsync(detailList);
            order.TotalAmount = total;
            try
            {
                await _orderRepository.CreateAsync(order);
                return Response.CreateSuccessfully("Order");
            }
            catch (Exception)
            {
                return Response.CreateFailed("Order");
            }
        }
    }
}
