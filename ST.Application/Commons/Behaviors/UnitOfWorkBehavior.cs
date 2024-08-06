using MediatR;
using ST.Domain.Data;

namespace ST.Application.Commons.Behaviors{
    public class UnitOfWorkBehavior<TTRequest, TTResponse>(IUnitOfWork unitOfWork)
        : IPipelineBehavior<TTRequest, TTResponse>
        where TTRequest : notnull
        where TTResponse : notnull{
        public async Task<TTResponse> Handle(TTRequest request,
            RequestHandlerDelegate<TTResponse> next,
            CancellationToken cancellationToken)
        {
            var response = await next();

            try
            {
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch
            {
                await unitOfWork.RollBackAsync(cancellationToken);
            }

            return response;
        }
    }
}