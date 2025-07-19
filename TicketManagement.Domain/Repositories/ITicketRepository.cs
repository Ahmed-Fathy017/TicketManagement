using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket> AddAsync(Claim claim);
        Task<Ticket?> GetByIdAsync(Guid claimId);
        Task<IEnumerable<Claim>> GetAllAsync();
    }
}
