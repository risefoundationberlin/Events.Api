using Events.Api.Database.Models;
using Events.Api.Repositories.Implementations;
using Events.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Events.Api.Extensions
{
    public static class InjectedServices
    {
        public static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<event_managementContext>(o =>
                o.UseNpgsql(configuration.GetConnectionString("EventManagementContext")!)
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging()
                );
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEventRepository, EventRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InjectedServices).Assembly);
        }
    }
}
