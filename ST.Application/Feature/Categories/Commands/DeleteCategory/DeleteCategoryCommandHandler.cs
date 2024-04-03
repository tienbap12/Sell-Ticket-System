using ST.Application.Wrappers;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await _categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.NotFound("Category", request.Id);
            }

            await _categoryRepository.DeleteAsync(request.Id);
            return Response.CreateSuccessfully("Category");
        }
    }
}
