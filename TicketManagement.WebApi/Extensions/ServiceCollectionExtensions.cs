using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Extensions;
using TicketManagement.Application.Interfaces;
using TicketManagement.Infrastructure.Extensions;
using TicketManagement.WebApi.Extensions;
using TicketManagement.WebApi.Services;

namespace TicketManagement.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Application Services
        services.AddApplicationServices(configuration);
        
        // Register Infrastructure Services
        services.AddInfrastructureServices(configuration);

        // Register SignalR
        services.AddScoped<INotificationService, SignalRNotificationService>();


        return services;
    }
} 