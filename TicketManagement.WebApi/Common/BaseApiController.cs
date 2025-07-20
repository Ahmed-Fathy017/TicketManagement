using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Common.Enums;
using TicketManagement.Application.Common.Models;

namespace TicketManagement.WebApi.Common
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private readonly ILogger _logger;

        protected BaseApiController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType());
        }

        protected IActionResult FromServiceResult<T>(ServiceResult<T> result)
        {
            if (result.Status != ServiceResultStatus.Success)
                _logger.LogWarning("ServiceResult failed. Status: {Status}, Message: {Message}", result.Status.ToString(), result.Message);

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
