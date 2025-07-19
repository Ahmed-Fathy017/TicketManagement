using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Commands.DTOs;
using TicketManagement.Application.Common.Enums;
using TicketManagement.Application.Common.Models;
using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Queries.DTOs;
using TicketManagement.Domain.Entities.Tickets;
using TicketManagement.Domain.Entities.Tickets.Interfaces;
using TicketManagement.Domain.Repositories;

namespace TicketManagement.Application.Services
{
    internal class TicketService : ITicketService
    {
        private readonly ITicketFactory _ticketFactory;
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketFactory ticketFactory, ITicketRepository ticketRepository)
        {
            _ticketFactory = ticketFactory;
            _ticketRepository = ticketRepository;
        }

        public async Task<ServiceResult<Guid>> CreateTicketAsync(CreateTicketRequestDto requestDto)
        {
            var result = _ticketFactory.Create(requestDto.PhoneNumber, requestDto.Governorate, requestDto.District, requestDto.City);

            if (!result.IsSuccess)
                return new ServiceResult<Guid>(ServiceResultStatus.ValidationError, Guid.Empty, result.Error);

            await _ticketRepository.AddAsync(result.Value);

            return new (ServiceResultStatus.Success, result.Value.Id, "Ticket created successfully");
        }

        public async Task<ServiceResult<GetPaginatedListResponseDto<Ticket>>> GetTicketsPaginatedListAsync(GetPaginatedListRequestDto requestDto)
        {
            var result = await _ticketRepository.GetPaginatedListAsync(requestDto.PageNumber, requestDto.PageSize);

            return new ServiceResult<GetPaginatedListResponseDto<Ticket>>(
                Status: ServiceResultStatus.Success,  
                Data: new GetPaginatedListResponseDto<Ticket>(result.Items, result.TotalCount),
                Message: null);
        }

        public async Task<ServiceResult<Guid>> MarkTicketAsHandledAsync(Guid ticketId)
        {
            Ticket? ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
                return new ServiceResult<Guid>(ServiceResultStatus.NotFound, ticketId, "Ticket not found");

            ticket.MarkAsHandled();

            await _ticketRepository.UpdateAsync(ticket);

            return new ServiceResult<Guid>(ServiceResultStatus.Success, ticket.Id, "Ticket marked as handled successfully");
        }
    }
}
