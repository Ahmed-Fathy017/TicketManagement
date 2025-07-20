using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Commands;
using TicketManagement.Application.Commands.DTOs;
using TicketManagement.Application.Queries;
using TicketManagement.Application.Queries.DTOs;
using TicketManagement.Domain.Entities.Tickets;
using TicketManagement.WebApi.Common;

namespace TicketManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequestDto request)
        {
            var result = await _mediator.Send(new CreateTicketCommand(request));

            return FromServiceResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsPaginatedList([FromQuery] GetPaginatedListRequestDto request)
        {
            var result = await _mediator.Send(new GetTicketsPaginatedListQuery(request));

            return FromServiceResult(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkTicketAsHandled(Guid id)
        {
            var result = await _mediator.Send(new MarkTicketAsHandledCommand(id));

            return FromServiceResult(result);
        }
    }
}
