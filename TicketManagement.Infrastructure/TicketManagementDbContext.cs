using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Infrastructure
{
    internal class TicketManagementDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TicketManagementDbContext(DbContextOptions<TicketManagementDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("UserManagement");
            builder.ApplyConfigurationsFromAssembly(typeof(TicketManagementDbContext).Assembly);
        }
    }
}
