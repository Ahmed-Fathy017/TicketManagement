using Microsoft.AspNetCore.SignalR;

namespace TicketManagement.WebApi.Hubs
{
    public class DataChangeHub : Hub
    {
        private readonly ILogger<DataChangeHub> _logger;

        public DataChangeHub(ILogger<DataChangeHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
