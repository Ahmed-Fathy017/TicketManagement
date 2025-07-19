using Microsoft.Extensions.DependencyInjection;
using TicketManagement.WebApi.Extensions;
using TicketManagement.Infrastructure.Extensions;
using TicketManagement.Application.Extensions;

namespace TicketManagement.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Application Services
        services.AddApplicationServices(configuration);
        
        // Register Infrastructure Services
        services.AddInfrastructureServices(configuration);
        
        return services;
    }
} 