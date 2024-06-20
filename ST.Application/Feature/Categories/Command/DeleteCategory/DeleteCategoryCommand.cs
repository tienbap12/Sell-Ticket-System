using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand(Guid id) : ICommand<Response>
    {
        public Guid Id { get; set; } = id;
    }
}