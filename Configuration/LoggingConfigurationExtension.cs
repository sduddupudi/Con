using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

namespace ConsumptionAPI
{
    public static class LoggingConfigurationExtension
    {
        public static void LoggingConfigurationRegister(this IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddDebug(); // Log to debug (debug window in Visual Studio or any debugger attached)
                config.AddConsole(); // Log to console (colored !)
            })
              .Configure<LoggerFilterOptions>(options =>
              {
                  options.AddFilter<DebugLoggerProvider>(null /* category*/ , LogLevel.Information /* min level */);
                  options.AddFilter<ConsoleLoggerProvider>(null  /* category*/ , LogLevel.Warning /* min level */);
              });
        }
    }
}
