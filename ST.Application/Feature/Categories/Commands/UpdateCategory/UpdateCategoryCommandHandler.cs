using AutoMapper;
using ST.Application.Wrappers;
using ST.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.Categories.Commands.UpdateCategory
{
    internal class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateExist = await _categoryRepository.GetByIdAsync(request.Id);
            if (cateExist == null)
            {
                return Response.Fail("Khong ton tai cate trong he thong");
            }
            cateExist.Name = request.Request.Name;
            cateExist.ImagePath = request.Request.imagePath; // Lưu ý: Sử dụng thuộc tính ImagePath thay vì imagePath
            cateExist.SuperName = request.Request.superName;
            cateExist.SuperId = request.Request.superId;
            cateExist.Status = request.Request.status;
            cateExist.IsPublic = request.Request.isPublic;
            cateExist.Priority = request.Request.priority;

            // Lưu thay đổi vào cơ sở dữ liệu
            try
            {
                await _categoryRepository.UpdateAsync(cateExist);
                return Response.Success("Cập nhật danh mục thành công");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                return Response.Fail($"Lỗi khi cập nhật danh mục: {ex.Message}");
            }
        }
    }
}
