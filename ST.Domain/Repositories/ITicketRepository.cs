using ST.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ST.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<bool> CheckTicketsExistAsync(List<int> ids);
        Task<List<Ticket>> GetAllTicketWithCategory();
        Task<Ticket> GetTicketByIdWCate(int id);
        Task CreateAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
    }
}
