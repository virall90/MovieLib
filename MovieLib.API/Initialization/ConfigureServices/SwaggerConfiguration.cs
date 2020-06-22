using Microsoft.Extensions.DependencyInjection;

namespace MovieLib.API.Initialization.ConfigureServices
{
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Добавление настройки на Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config => {
                config.PostProcess = (document) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "MovieLib-API";
                    document.Info.Description = "ASP.NET Core 3.1 MovieLib-API";
                };
            });

            return services;
        }
    }
}