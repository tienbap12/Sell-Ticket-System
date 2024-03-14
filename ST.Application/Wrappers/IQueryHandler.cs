using MediatR;

namespace ST.Application.Wrappers
{
    public interface IQueryHandler<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IQuery<TOut>
    {
        
    }
}