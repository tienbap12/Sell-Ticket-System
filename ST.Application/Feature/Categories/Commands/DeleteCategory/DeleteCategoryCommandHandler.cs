using ST.Application.Wrappers;
using ST.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await _categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.Fail("Khong tim thay Category");
            }

            await _categoryRepository.DeleteAsync(request.Id);
            return Response.Success("Xoa danh muc thanh cong");
        }
    }
}
