using MediatR;
using ST.Domain.Data;

namespace ST.Application.Commons.Behaviors
{
    public class UnitOfWorkBehavior<TTRequest, TTResponse>(IUnitOfWork unitOfWork)
       : IPipelineBehavior<TTRequest, TTResponse>
       where TTRequest : notnull
       where TTResponse : notnull
    {
        public async Task<TTResponse> Handle(TTRequest request,
            RequestHandlerDelegate<TTResponse> next,
            CancellationToken cancellationToken)
        {
            var response = await next();
            var isInTransaction = unitOfWork.IsInTransaction;
            var isSaved = unitOfWork.IsSaved;
            var propIsSuccess = (response as object).GetType().GetProperty("IsSuccess");
            if (propIsSuccess is not null && !(bool)propIsSuccess.GetValue(response)! && isInTransaction)
            {
                await unitOfWork.RollBackAsync(cancellationToken);
                return response;
            }

            try
            {
                if (!isSaved)
                {
                    if (IsCommand)
                        await unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    unitOfWork.SetIsSaved(false);
                }
            }
            catch
            {
                if (isInTransaction)
                    await unitOfWork.RollBackAsync(cancellationToken);
                throw;
            }

            if (isInTransaction)
                await unitOfWork.CommitAsync(cancellationToken);

            return response;
        }

        private static bool IsCommand => typeof(TTRequest).Name.EndsWith("Command");
    }
}