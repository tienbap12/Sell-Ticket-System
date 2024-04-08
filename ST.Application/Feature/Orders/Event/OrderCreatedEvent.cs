using ST.Application.Wrappers;
using ST.Domain.Entities;

namespace ST.Application.Feature.Orders.Event
{
    public class OrderCreatedEvent(Order order) : IDomainEvent
    {
        public Order Order { get; set; } = order;
    }
}