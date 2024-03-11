using MediatR;

namespace ST.Application.Wrappers
{
    public interface IRequestHandlerWrapper<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IRequestWrapper<TOut>
    {
        
    }
}