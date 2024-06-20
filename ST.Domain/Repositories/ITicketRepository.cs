using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ST.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(Guid id);
        Task<bool> CheckTicketsExistAsync(List<Guid> ids);
        Task<List<Ticket>> GetAllTicketWithCategory();
        Task<Ticket> GetTicketByIdWCate(Guid id);
        Task CreateAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Guid id);
    }
}
