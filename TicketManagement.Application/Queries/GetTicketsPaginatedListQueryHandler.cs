using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Queries.DTOs;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Application.Queries
{
    internal class GetTicketsPaginatedListQueryHandler : IRequestHandler<GetTicketsPaginatedListQuery, ServiceResult<GetPaginatedListResponseDto<Ticket>>>
    {
        private readonly ITicketService _ticketService;

        public GetTicketsPaginatedListQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<ServiceResult<GetPaginatedListResponseDto<Ticket>>> Handle(GetTicketsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetTicketsPaginatedListAsync(request.Request);
        }
    }
}
