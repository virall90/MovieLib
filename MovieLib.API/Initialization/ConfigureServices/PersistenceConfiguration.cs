using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieLib.Data;

namespace MovieLib.API.Initialization.ConfigureServices
{
    /// <summary>
    /// Добавление настройки на контекст данных
    /// </summary>
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddPersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieLibContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Main"),
                    builder => builder.MigrationsAssembly(typeof(MovieLibContext).Assembly.FullName)));

            return services;
        }
    }
}
