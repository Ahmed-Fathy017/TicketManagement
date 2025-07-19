using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Interfaces;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Application.Commands
{
    internal class MarkTicketAsHandledCommandHandler : IRequestHandler<MarkTicketAsHandledCommand, ServiceResult<Guid>>
    {
        private readonly ITicketService _ticketService;

        public MarkTicketAsHandledCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<ServiceResult<Guid>> Handle(MarkTicketAsHandledCommand request, CancellationToken cancellationToken)
        {
            return await _ticketService.MarkTicketAsHandledAsync(request.TicketId);
        }
    }
}
