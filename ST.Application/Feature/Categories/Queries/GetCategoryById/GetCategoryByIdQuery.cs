using ST.Application.Wrappers;
using ST.Contracts.Category;

namespace ST.Application.Feature.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery(int id) : IQuery<CategoryResponse>
    {
        public int Id { get; set; } = id;
    }
}
