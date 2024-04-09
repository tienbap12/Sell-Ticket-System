using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class AccountRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<Account>(context, unitOfWork), IAccountRepository
    {
        public async Task<Account> GetByUserName(string username)
        {
            return await _dbSet.Where(t => t.Username == username)
                                            .SingleOrDefaultAsync();
        }
        public async Task<string> GetRoleUser(int roleId)
        {
            return await _dbSet.Include(r => r.Roles)
                                            .Where(a => a.Id == roleId)
                                            .Select(a => a.Roles.Name)
                                            .FirstOrDefaultAsync();
        }
    }
}
