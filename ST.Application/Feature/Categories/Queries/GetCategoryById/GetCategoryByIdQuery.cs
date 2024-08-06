using ST.Application.Wrappers;
using ST.Contracts.Category;

namespace ST.Application.Feature.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdQuery( Guid id) : IQuery<CategoryResponse>
    {
        public  Guid Id { get; set; } = id;
    }
}
