using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;

namespace ST.MainInfrastructure.Repositories
{
    internal class CategoryRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<Category>(context, unitOfWork), ICategoryRepository
    {
    }
}
