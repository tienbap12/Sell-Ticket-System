using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Query.GetCategoryById{
    internal class GetCategoryByIdQueryHandler(IMapper mapper) : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>{
        public async Task<Response<CategoryResponse>> Handle(GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }
    }
}