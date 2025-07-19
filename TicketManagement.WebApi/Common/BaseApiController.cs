using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Common.Enums;
using TicketManagement.Application.Common.Models;

namespace TicketManagement.WebApi.Common
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult FromServiceResult<T>(ServiceResult<T> result)
        {
            return result.Status switch
            {
                ServiceResultStatus.Success => Ok(result),
                ServiceResultStatus.NotFound => NotFound(result.Message),
                ServiceResultStatus.ValidationError => BadRequest(result.Message),
                _ => BadRequest(result.Message)
            };
        }
    }
}
