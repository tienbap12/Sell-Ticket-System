using MediatR;

namespace ST.Application.Wrappers
{
    public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {

    }
}