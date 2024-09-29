using MediatR;

namespace ST.Application.Wrappers
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
