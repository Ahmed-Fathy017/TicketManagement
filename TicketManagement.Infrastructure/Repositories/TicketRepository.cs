using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;
using TicketManagement.Domain.Repositories;
using TicketManagement.Domain.Repositories.Models;

namespace TicketManagement.Infrastructure.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly TicketManagementDbContext _dbContext;

        public TicketRepository(TicketManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Ticket>> GetPaginatedListAsync(int pageNumber, int pageSize)
        {
            int totalCount = await _dbContext.Tickets.CountAsync();

            List<Ticket> result = await _dbContext.Tickets
                .AsNoTracking()
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Ticket>(result, totalCount);
        }

        public async Task<Ticket?> GetByIdAsync(Guid ticketId)
        {
            return await _dbContext.Tickets
                .FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
