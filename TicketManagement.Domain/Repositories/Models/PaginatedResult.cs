using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Domain.Repositories.Models
{
    public record PaginatedResult<T> (IReadOnlyList<T> Items, int TotalCount);
}
