using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Commands.DTOs;
using TicketManagement.Application.Common.Models;

namespace TicketManagement.Application.Commands
{
    public class CreateTicketCommand : IRequest<ServiceResult<Guid>>
    {
        public CreateTicketRequestDto Request { get; }

        public CreateTicketCommand(CreateTicketRequestDto request)
        {
            Request = request;
        }
    }
}
