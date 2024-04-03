using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Commands.UpdateCategory
{
    internal class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await _categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.NotFound("Category", request.Id);
            }

            var updateCategory = _mapper.Map<CategoryRequest, Category>(request.Request, cateExist);

            try
            {
                await _categoryRepository.UpdateAsync(updateCategory);
                return Response.UpdateSuccessfully("Category");
            }
            catch (Exception ex)
            {
                return Response.UpdateFailed("Category");
            }
        }
    }
}
