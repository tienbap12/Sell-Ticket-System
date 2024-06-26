﻿using Microsoft.EntityFrameworkCore;
using ST.Domain.Data;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using ST.MainInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.MainInfrastructure.Repositories
{
    public class TicketRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : GenericRepository<Ticket>(context, unitOfWork), ITicketRepository
    {
        public async Task<bool> CheckTicketsExistAsync(List<Guid> ids)
        {
            return await _dbSet.Where(t => ids.Contains(t.Id)).CountAsync() == ids.Count;
        }
        public async Task<List<Ticket>> GetAllTicketWithCategory()
        {
            return await _dbSet.Include(c => c.Categories).ToListAsync();
        }
        public async Task<Ticket> GetTicketByIdWCate(Guid id)
        {
            return await _dbSet.Include(c => c.Categories)
                                .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}
