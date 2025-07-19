using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Common.Models;

namespace TicketManagement.Application.Commands
{
    public class MarkTicketAsHandledCommand : IRequest<ServiceResult<Guid>>
    {
        public Guid TicketId { get; private set; }

        public MarkTicketAsHandledCommand(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}
