using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Commands.DTOs;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Queries.DTOs;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Application.Interfaces
{
    public interface ITicketService
    {
        Task<ServiceResult<Guid>> CreateTicketAsync(CreateTicketRequestDto requestDto);
        Task<ServiceResult<GetPaginatedListResponseDto<Ticket>>> GetTicketsPaginatedListAsync(GetPaginatedListRequestDto requestDto);
        Task<ServiceResult<Guid>> MarkTicketAsHandledAsync(Guid ticketId);
    }
}
