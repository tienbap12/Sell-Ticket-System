using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand(int id, CategoryRequest request) : ICommand<Response>
    {
        public int Id { get; set; } = id;
        public CategoryRequest Request { get; set; } = request;
    }
}