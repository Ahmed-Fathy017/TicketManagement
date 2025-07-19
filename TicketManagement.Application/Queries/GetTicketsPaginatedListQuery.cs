using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Queries.DTOs;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Application.Queries
{
    public class GetTicketsPaginatedListQuery : IRequest<ServiceResult<GetPaginatedListResponseDto<Ticket>>>
    {
        public GetPaginatedListRequestDto Request { get; private set; }
        public GetTicketsPaginatedListQuery(GetPaginatedListRequestDto request)
        {
            Request = request;
        }
    }
}
