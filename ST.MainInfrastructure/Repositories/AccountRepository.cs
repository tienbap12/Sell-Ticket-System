using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
        }

        public async Task<Account> GetByUserName(string username)
        {
            return await _context.Accounts.Where(t => t.Username == username)
                                          .SingleOrDefaultAsync();
        }

        public async Task<string> GetRoleUser(int roleId)
        {
            return await _context.Accounts.Include(r => r.Roles)
                                            .Where(a => a.Id == roleId)
                                            .Select(a => a.Roles.Name)
                                            .FirstOrDefaultAsync();
        }
    }
}
