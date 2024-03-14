using MediatR;

namespace ST.Application.Wrappers
{
    public interface IQuery<T> : IRequest<Response<T>>
    {
        
    }
}