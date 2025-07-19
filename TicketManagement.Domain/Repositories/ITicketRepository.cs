using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;
using TicketManagement.Domain.Repositories.Models;

namespace TicketManagement.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task AddAsync(Ticket ticket);
        Task<PaginatedResult<Ticket>> GetPaginatedListAsync(int pageNumber, int pageSize);
        Task<Ticket?> GetByIdAsync(Guid ticketId);
        Task UpdateAsync(Ticket claim);
    }
}
