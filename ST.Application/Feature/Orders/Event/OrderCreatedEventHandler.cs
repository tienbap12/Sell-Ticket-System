using ST.Application.Wrappers;

namespace ST.Application.Feature.Orders.Event
{
    public class OrderCreatedEventHandler : IDomainEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Order created: {notification.Order.Id}");
            return Task.CompletedTask;
        }
    }
}