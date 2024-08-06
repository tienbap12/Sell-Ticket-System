using Mapster;
using ST.Application.Feature.Categories.Commands.CreateCategory;
using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Data;
using ST.Domain.Entities;


namespace ST.Application.Feature.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateCategoryCommand, Response>
    {
        public async Task<Response> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateRepo = unitOfWork.GetRepository<Category>();

            var newCate = request.Request.Adapt<Category>();
            await cateRepo.CreateAsync(newCate);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Response.CreateSuccessfully("Category");
        }
    }
}