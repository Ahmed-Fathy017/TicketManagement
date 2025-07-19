using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Commands.DTOs;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Interfaces;

namespace TicketManagement.Application.Commands
{
    internal class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ServiceResult<Guid>>
    {
        private readonly ITicketService _ticketService;

        public CreateTicketCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<ServiceResult<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            return await _ticketService.CreateTicketAsync(request.Request);
        }
    }
}
