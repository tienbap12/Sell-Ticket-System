using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Entities;

namespace ST.Application.Feature.Categories.Command.UpdateCategory
{
    internal class UpdateCategoryCommandHandler() : ICommandHandler<UpdateCategoryCommand, Response>
    {
        public async Task<Response> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}