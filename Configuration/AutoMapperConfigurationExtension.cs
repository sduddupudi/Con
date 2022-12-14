using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionAPI
{
    public static class AutoMapperConfigurationExtension
    {
        public static void AutoMapperConfigurationRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Startup)));
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(Startup))));
            mapperConfiguration.CompileMappings();
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
