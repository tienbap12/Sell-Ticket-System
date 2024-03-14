using AutoMapper;
using MediatR;
using ST.Application.Wrappers;
using ST.Contracts.Category;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cate = new Category
            {
                Name = request.Request.Name,
                ImagePath = request.Request.imagePath,
                IsPublic = request.Request.isPublic,
                SuperName = request.Request.superName,
                Status = request.Request.status,
                Priority = request.Request.priority,
                SuperId = request.Request.superId
            };

            await _categoryRepository.CreateAsync(cate);

            var result = _mapper.Map<CategoryResponse>(cate);
            return Response.Success("avc");
        }

    }
}
