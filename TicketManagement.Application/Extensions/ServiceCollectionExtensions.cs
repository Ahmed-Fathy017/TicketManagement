using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Commands;
using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Services;
using TicketManagement.Domain.Entities.Tickets.Interfaces;
using TicketManagement.Domain.Entities.Tickets.Services;

namespace TicketManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTicketCommand).Assembly))
                    .AddScoped<ITicketFactory, TicketFactory>()
                    .AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
