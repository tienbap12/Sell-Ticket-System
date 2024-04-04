using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;

namespace ST.Application.Feature.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand(CategoryRequest request) : ICommand<Response>
    {
        public CategoryRequest Request { get; set; } = request;
    }
}
