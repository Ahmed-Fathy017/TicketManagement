using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Queries.DTOs
{
    public record GetPaginatedListRequestDto(int PageNumber, int PageSize);
}
