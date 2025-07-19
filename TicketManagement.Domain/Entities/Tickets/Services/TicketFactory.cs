using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets.Interfaces;

namespace TicketManagement.Domain.Entities.Tickets.Services
{
    public class TicketFactory : ITicketFactory
    {
        public Ticket Create(string phoneNumber, string governorate, string district, string city)
        {
            return new Ticket(phoneNumber, governorate, district, city);
        }
    }
}
