using Mapster;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Data;
using ST.Domain.Entities;

namespace ST.Application.Feature.Categories.Query.GetAllCategory
{
    internal class GetAllCategoryQueryHandler(IUnitOfWork _unitOfWork) : IQueryHandler<GetAllCategoryQuery, PagedResponse<CategoryResponse>>
    {
        public async Task<Response<PagedResponse<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var cateRepo = _unitOfWork.GetRepository<Category>();

            // Lấy danh sách danh mục với phân trang
            var categoryList = await cateRepo.GetAllAsync();
            if (!string.IsNullOrEmpty(request.search))
            {
                categoryList = categoryList
                    .Where(c => c.Name.Contains(request.search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            var totalCount = categoryList.Count; // Số lượng tổng
            var paginatedCategories = categoryList
                .Skip((request.pageNumber - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToList(); // Phân trang

            var result = paginatedCategories.Adapt<List<CategoryResponse>>();
            var pagedResponse = new PagedResponse<CategoryResponse>(result, totalCount, request.pageNumber, request.pageSize);

            return Response<PagedResponse<CategoryResponse>>.Success("Get all success", pagedResponse);
        }
    }
}
