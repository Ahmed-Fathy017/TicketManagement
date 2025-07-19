using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Commands.DTOs
{
    public record CreateTicketRequestDto(string PhoneNumber, string Governorate, string District, string City);
}
