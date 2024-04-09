using MediatR;
using ST.Application.Commons.Response;

namespace ST.Application.Wrappers
{
    public interface IQuery<T> : IRequest<Response<T>>
    {

    }
}