
using TicketManagement.WebApi.Extensions;
using TicketManagement.WebApi.Hubs;

namespace TicketManagement.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            builder.Services.AddSignalR();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(allowedOrigins!)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            // Registering Application and Infrastructure Services
            builder.Services.AddServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // CORS must be before SignalR and Authorization
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            // Map SignalR hub
            app.MapHub<DataChangeHub>("/hubs/dataChange");

            app.MapControllers();

            app.Run();
        }
    }
}
