using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services,
            SimpleInjector.Container container)
        {
            var typesToRegister =
                container.GetTypesToRegister(typeof(IHandler<,>), typeof(DependencyInjection).Assembly);
            foreach (var type in typesToRegister)
            {
                container.Register(type);
            }

            return services;
        }

        public static IMapperConfigurationExpression AddAutoMapperConfiguration(
            this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile<MappingProfile>();

            return mapperConfigurationExpression;
        }
    }
}