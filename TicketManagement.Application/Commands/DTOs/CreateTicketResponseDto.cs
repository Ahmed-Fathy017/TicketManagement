using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Commands.DTOs
{
    public record CreateTicketResponseDto(Guid TicketId, string Message);
}
