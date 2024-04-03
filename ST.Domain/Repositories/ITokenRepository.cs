using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Domain.Repositories
{
    public interface ITokenRepository
    {
        Task CreateAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
        Task DeleteAsync(int id);
    }
}
