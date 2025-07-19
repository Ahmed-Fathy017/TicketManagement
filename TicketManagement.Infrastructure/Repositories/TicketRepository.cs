using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;
using TicketManagement.Domain.Repositories;

namespace TicketManagement.Infrastructure.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly TicketManagementDbContext _dbContext;

        public TicketRepository(TicketManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Ticket> AddAsync(Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Claim>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetByIdAsync(Guid claimId)
        {
            throw new NotImplementedException();
        }

        public Task<Claim> UpdateAsync(Claim claim)
        {
            throw new NotImplementedException();
        }
    }
}
