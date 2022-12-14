using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ConsumptionAPI
{
    public static class SwaggerConfigurationExtension
    {
        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", Constants.AppName + "v1"));
        }

        public static void SwaggerRegister(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = Constants.AppName, Version = "v1" });

                var commentsFile = Path.Combine(AppContext.BaseDirectory,
                $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
                if (!File.Exists(commentsFile))
                {
                    throw new Exception($"Xml comments file does not exist! ({commentsFile})");
                }
                

                options.OperationFilter<AddResponseHeadersFilter>(); 

                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
                                                                                    // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                // add Security information to each operation for OAuth2
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                // if you're using the SecurityRequirementsOperationFilter, you also need to tell Swashbuckle you're using OAuth2
                // if you're using the SecurityRequirementsOperationFilter, you also need to tell Swashbuckle you're using OAuth2
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter into field the word 'bearer' following by space and JWT",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    });
            });

            services.AddSwaggerExamples();
        }
    }
}
