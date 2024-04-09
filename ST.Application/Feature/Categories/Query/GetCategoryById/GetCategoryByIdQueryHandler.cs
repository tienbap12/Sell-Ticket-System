using AutoMapper;
using MediatR;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Query.GetCategoryById
{
    internal class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        public async Task<Response<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return Response<CategoryResponse>.NotFound("Category", request.Id);
            }
            var Response = mapper.Map<CategoryResponse>(category);
            return Response<CategoryResponse>.Success("Get data successfully!!!", Response);
        }
    }
}