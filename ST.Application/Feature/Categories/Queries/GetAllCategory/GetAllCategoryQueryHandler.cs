using Mapster;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Data;
using ST.Domain.Entities;

namespace ST.Application.Feature.Categories.Query.GetAllCategory
{
    internal class GetAllCategoryQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetAllCategoryQuery, List<CategoryResponse>>
    {
        public async Task<Response<List<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var cateRepo = unitOfWork.GetRepository<Category>();

            var categoryList = await cateRepo.GetAllAsync();
            var result = categoryList.Adapt<List<CategoryResponse>>();
            return Response<List<CategoryResponse>>.Success("Get all success", result);
        }
    }
}