using AutoMapper;
using MediatR;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return Response.Fail<IList<CategoryResponse>>("Lay danh sach that baii");
            }
            var result = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Response.Success<IList<CategoryResponse>>(result.ToList(), "lay danh sach thanh cong");
        }
    }
}
