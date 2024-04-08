using MediatR;
using ST.Application.Commons.Response;
using ST.Application.Feature.Orders.Event;
using ST.Application.Wrappers;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Command
{
    public class CreateOrderCommandHandler(IOrderRepository _orderRepository,
                IOrderDetailRepository _orderDetailRepository,
                IMediator _mediator,
                IAccountRepository _accountRepository,
                ITicketRepository _ticketRepository)
                : ICommandHandler<CreateOrderCommand, Response>
    {
        public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetByIdAsync(request.Request.UserId);
            if (user == null)
            {
                return Response.NotFound("User", request.Request.UserId);
            }
            var ticketIds = request.Request.Details.Select(d => d.TicketId).ToList();
            if (!await _ticketRepository.CheckTicketsExistAsync(ticketIds))
            {
                return Response.Failure("Ticket not found!!!");
            }
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

                var orderCreatedEvent = new OrderCreatedEvent(order);
                await _mediator.Publish(orderCreatedEvent).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"Error handling OrderCreatedEvent {t.Exception}");
                    }
                    Console.WriteLine("OrderCreatedEvent handled successfully");
                }, TaskScheduler.Default);
                return Response.CreateSuccessfully("Order");
            }
            catch (Exception)
            {
                return Response.CreateFailed("Order");
            }
        }
    }
}