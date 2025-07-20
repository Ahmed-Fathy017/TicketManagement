using Microsoft.AspNetCore.SignalR;
using TicketManagement.Application.Interfaces;
using TicketManagement.WebApi.Hubs;

namespace TicketManagement.WebApi.Services
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<DataChangeHub> _hubContext;
        private readonly ILogger<SignalRNotificationService> _logger;

        public SignalRNotificationService(IHubContext<DataChangeHub> hubContext, ILogger<SignalRNotificationService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task NotifyTicketCreatedAsync(object ticketData)
        {
            try
            {
                _logger.LogInformation("Sending SignalR notification for new ticket: {TicketData}", ticketData);
                await _hubContext.Clients.All.SendAsync("TicketCreated", ticketData);
                _logger.LogInformation("SignalR notification sent successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SignalR notification");
                throw;
            }
        }
    }
}
