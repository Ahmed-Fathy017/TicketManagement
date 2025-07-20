using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Interfaces
{
    public interface INotificationService
    {
        Task NotifyTicketCreatedAsync(object ticketData);
    }
}
