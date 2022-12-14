using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionAPI
{
    public static class NewtonSoftConfigurationExtension
    {
        public static void NewtonSoftConfigurationRegister(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            })
           .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
           });
        }
    }
}
