using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Api.Configurtions
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<LisitContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppConnection")));
            services.AddDbContext<EventStoreSqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppConnection")));
        }
    }
}
