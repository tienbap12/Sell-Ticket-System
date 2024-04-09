using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Command.UpdateCategory
{
    internal class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : ICommandHandler<UpdateCategoryCommand, Response>
    {
        public async Task<Response> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.NotFound("Category", request.Id);
            }

            var updateCategory = mapper.Map<CategoryRequest, Category>(request.Request, cateExist);

            try
            {
                await categoryRepository.UpdateAsync(updateCategory);
                return Response.UpdateSuccessfully("Category");
            }
            catch (Exception)
            {
                return Response.UpdateFailed("Category");
            }
        }
    }
}
