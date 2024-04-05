using AutoMapper;
using MediatR;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Query.GetCategoryById
{
    internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return Response<CategoryResponse>.NotFound("Category", request.Id);
            }
            var Response = _mapper.Map<CategoryResponse>(category);
            return Response<CategoryResponse>.Success("Get data successfully!!!", Response);
        }
    }
}