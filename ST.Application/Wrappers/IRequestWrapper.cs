using MediatR;

namespace ST.Application.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {
        
    }
}