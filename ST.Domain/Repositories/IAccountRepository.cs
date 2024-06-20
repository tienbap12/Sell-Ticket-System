using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(Guid id);
        Task<Account> GetByUserName(string username);
        Task<string> GetRoleUser(Guid roleId);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid id);
    }
}
