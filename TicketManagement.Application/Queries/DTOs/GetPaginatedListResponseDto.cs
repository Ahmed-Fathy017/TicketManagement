﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Queries.DTOs
{
    public record GetPaginatedListResponseDto<T>(IReadOnlyList<T> Items, int TotalCount);
}
