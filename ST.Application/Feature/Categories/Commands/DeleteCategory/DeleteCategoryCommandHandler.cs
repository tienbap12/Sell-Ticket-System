using ST.Application.Feature.Categories.Commands.DeleteCategory;
using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler() : ICommandHandler<DeleteCategoryCommand, Response>
    {
        public async Task<Response> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}