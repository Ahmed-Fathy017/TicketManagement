using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Common.Enums;

namespace TicketManagement.Application.Common.Models
{
    public record ServiceResult<T>(ServiceResultStatus Status, T? Data, string? Message);
}
