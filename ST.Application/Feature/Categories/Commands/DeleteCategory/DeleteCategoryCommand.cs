using ST.Application.Commons.Response;
using ST.Application.Wrappers;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand(int id) : ICommand<Response>
    {
        public int Id { get; set; } = id;
    }
}
