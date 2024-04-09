using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Query.GetAllCategory
{
    internal class GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IQueryHandler<GetAllCategoryQuery, IList<CategoryResponse>>
    {
        public async Task<Response<IList<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return Response<IList<CategoryResponse>>.Failure("Fetch data errors");
            }
            var Response = mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Response<IList<CategoryResponse>>.Success("Get data successfully!!!", Response.ToList());
        }
    }
}
