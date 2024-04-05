using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Command.CreateCategory
{
    internal class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Response>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CategoryRequest, Category>(request.Request);
            try
            {
                await _categoryRepository.CreateAsync(result);

                return Response.CreateSuccessfully("Category");
            }
            catch (Exception)
            {
                return Response.CreateFailed("Category");
            }
        }

    }
}
