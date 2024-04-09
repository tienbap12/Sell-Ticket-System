using MediatR;
using ST.Application.Commons.Response;

namespace ST.Application.Wrappers
{
    public interface IQueryHandler<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IQuery<TOut>
    {

    }
}