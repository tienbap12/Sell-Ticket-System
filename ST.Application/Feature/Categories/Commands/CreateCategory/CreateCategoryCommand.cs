using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand(CategoryRequest request) : ICommand<Response>
    {
        public CategoryRequest Request { get; set; } = request;
    }
}