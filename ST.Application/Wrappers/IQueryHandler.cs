using MediatR;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Wrappers
{
    public interface IQueryHandler<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IQuery<TOut>
    {
    }
}