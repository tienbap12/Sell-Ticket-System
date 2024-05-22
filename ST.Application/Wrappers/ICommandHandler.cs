using MediatR;
using ST.Application.Feature.Tickets.Command.UpdateTicket;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Wrappers
{
    public interface ICommandHandler<in TCommand, T> : IRequestHandler<TCommand, T>
        where TCommand : ICommand<T>
    {
    }
}