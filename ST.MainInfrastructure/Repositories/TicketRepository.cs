using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        public async Task<List<Ticket>> GetAllTicketWithCategory()
        {
            return await _dbSet.Include(ticket => ticket.Category).ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdWCate(int id)
        {
            return await _dbSet.Include(ticket => ticket.Category).SingleOrDefaultAsync(t => t.Id == id);

        }
    }
}
