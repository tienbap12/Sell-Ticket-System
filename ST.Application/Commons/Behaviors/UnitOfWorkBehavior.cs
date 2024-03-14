using MediatR;
using ST.Application.Commons.Interfaces;
using ST.Domain.Data;

namespace ST.Application.Commons.Behaviors
{
    /* public class UnitOfWork : IUnitOfWork
     {
         private readonly IApplicationDbContext _context;

         public UnitOfWork(IApplicationDbContext context)
         {
             _context = context;
         }

         public async Task SaveChangesAsync()
         {
             await _context.SaveChangesAsync(CancellationToken.None);
         }
     }*/
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
            if (IsCommand())
            {
                await unitOfWork.SaveChangesAsync();
                return response;
            }
            else
            {
                return response;
            }
        }
        private static bool IsCommand()
        {
            return typeof(TTRequest).Name.EndsWith("Command");
        }
    }
}
