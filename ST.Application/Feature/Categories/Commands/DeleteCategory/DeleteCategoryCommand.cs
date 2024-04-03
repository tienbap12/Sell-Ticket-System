using ST.Application.Wrappers;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand(int id) : ICommand<Result>
    {
        public int Id { get; set; } = id;
    }
}
