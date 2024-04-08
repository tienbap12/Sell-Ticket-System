using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public async Task<bool> CheckTicketsExistAsync(List<int> ids)
        {
            return await _dbSet.Where(t => ids.Contains(t.Id)).CountAsync() == ids.Count;
        }
        public async Task<List<Ticket>> GetAllTicketWithCategory()
        {
            return await _dbSet.Include(c => c.Category).ToListAsync();
        }
        public async Task<Ticket> GetTicketByIdWCate(int id)
        {
            return await _dbSet.Include(c => c.Category)
                                .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}
