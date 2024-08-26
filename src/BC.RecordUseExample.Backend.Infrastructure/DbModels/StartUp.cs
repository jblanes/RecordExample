using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace BC.RecordUseExample.Backend.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddSqlPersistence(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            if (isDevelopment)
            {
                services.AddDbContext<SqlDbContext>(
                    options =>
                        options.UseSqlServer(
                           configuration.GetConnectionString("DbConnString")
                           )
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors()
                            .LogTo(m => Debug.WriteLine(m), Microsoft.Extensions.Logging.LogLevel.Information)
                            );

            }
            else
            {
                services.AddDbContextPool<SqlDbContext>(options =>
                 options.UseSqlServer(
                    configuration.GetConnectionString("DbConnString")
                       ));
            }

            return services;
        }
    }
}
