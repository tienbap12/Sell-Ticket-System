using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand(int id) : ICommand<Response>
    {
        public int Id { get; set; } = id;
    }
}