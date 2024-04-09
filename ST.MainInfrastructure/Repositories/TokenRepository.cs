using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;

namespace ST.MainInfrastructure.Repositories
{
    public class TokenRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<RefreshToken>(context, unitOfWork), ITokenRepository
    {
    }
}
