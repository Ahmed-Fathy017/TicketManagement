using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Repositories;
using TicketManagement.Infrastructure.Repositories;

namespace TicketManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketManagementDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("TicketManagement")));

            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
