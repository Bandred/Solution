using CrossCutting.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace WebApi.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerData = AddSwaggerData.New(configuration);
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, swaggerData.Xml);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(swaggerData.Version, new OpenApiInfo { Title = swaggerData.Title, Version = swaggerData.Version });
                x.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder AddConfig(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerData = AddSwaggerData.New(configuration);
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerData.Title));

            return app;
        }
    }
}
