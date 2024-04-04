using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Queries.GetAllCategory
{
    internal class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, IList<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IList<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return Response<IList<CategoryResponse>>.Failure("Lay danh sach that baii");
            }
            var Response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Response<IList<CategoryResponse>>.Success( "lay danh sach thanh cong", Response.ToList());
        }
    }
}
