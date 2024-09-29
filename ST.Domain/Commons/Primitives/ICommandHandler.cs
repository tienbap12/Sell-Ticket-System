using MediatR;

namespace ST.Application.Wrappers
{
    public interface ICommandHandler<in TCommand, T> : IRequestHandler<TCommand, T>
        where TCommand : ICommand<T>
    {
    }
}