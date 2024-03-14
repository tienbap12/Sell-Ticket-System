using ST.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ST.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllTicketWithCategory();
        Task<Ticket> GetTicketByIdWCate(int id);

    }
}
