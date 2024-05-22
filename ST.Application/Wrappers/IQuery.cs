using MediatR;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Wrappers
{
    public interface IQuery<T> : IRequest<Response<T>>
    {
    }
}