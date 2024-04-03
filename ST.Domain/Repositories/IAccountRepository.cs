using ST.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task<Account> GetByUserName(string username);
        Task<string> GetRoleUser(int roleId);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
    }
}
