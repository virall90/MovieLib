using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace MovieLib.API.Initialization.ConfigureServices
{
    public static class SimpleInjectorConfiguration
    {
        /// <summary>
        /// Добавление основной настройки SimpleInjector
        /// </summary>
        /// <param name="services"><inheritdoc cref="IServiceCollection"/></param>
        /// <param name="container">Контейнер SimpleInjector <see cref="Container"/></param>
        public static IServiceCollection AddSimpleInjectorConfiguration(this IServiceCollection services, Container container)
        {
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
                options.AddLogging();
                options.AddLocalization();
            });

            return services;
        }
    }
}