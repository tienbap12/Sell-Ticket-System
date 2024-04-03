﻿using MediatR;
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
