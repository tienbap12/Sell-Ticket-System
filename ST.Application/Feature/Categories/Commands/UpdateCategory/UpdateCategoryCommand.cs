using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;

namespace ST.Application.Feature.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand(int id, CategoryRequest request) : ICommand<Response>
    {
        public int Id { get; set; } = id;
        public CategoryRequest Request { get; set; } = request;
    }
}
