using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Query.GetAllCategory;

public class GetAllCategoryQuery(string search, int pageSize) : IQuery<PagedResponse<CategoryResponse>>
{
    public int PageNumber { get; set; } = 1;
    public string Search { get; set; } = search;
    public int PageSize { get; set; } = pageSize;
}
