using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Command.CreateCategory
{
    internal class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : ICommandHandler<CreateCategoryCommand, Response>
    {
        public async Task<Response> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<CategoryRequest, Category>(request.Request);
            try
            {
                await categoryRepository.CreateAsync(result);
                return Response.CreateSuccessfully("Category");
            }
            catch (Exception)
            {
                return Response.CreateFailed("Category");
            }
        }
    }
}
