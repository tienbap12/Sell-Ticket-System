using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Command.DeleteCategory
{
    internal class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : ICommandHandler<DeleteCategoryCommand, Response>
    {
        public async Task<Response> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.NotFound("Category", request.Id);
            }

            try
            {
                await categoryRepository.DeleteAsync(request.Id);
                return Response.CreateSuccessfully("Category");
            }
            catch (Exception)
            {
                return Response.DeleteSuccessfully("Category");
            }
        }
    }
}