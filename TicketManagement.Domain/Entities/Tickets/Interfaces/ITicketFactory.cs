using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Domain.Entities.Tickets.Interfaces
{
    public interface ITicketFactory
    {
        Ticket Create(string phoneNumber, string governorate, string district, string city);
    }
}
