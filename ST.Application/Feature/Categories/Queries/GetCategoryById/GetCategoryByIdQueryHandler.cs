using AutoMapper;
using Mapster;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Data;
using ST.Domain.Entities;

namespace ST.Application.Feature.Categories.Query.GetCategoryById;

internal class GetCategoryByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<Response<CategoryResponse>> Handle(GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var categoryRepo = unitOfWork.GetRepository<Category>();
        var category = await categoryRepo.GetByIdAsync(request.Id);
        var result = category.Adapt<CategoryResponse>();
        return Response<CategoryResponse>.Success("Lấy dữ liệu thành công", result);
    }
}