using Application.Services.Contracts;
using Application.Services.Servs;
using CrossCutting.Swagger;
using DataAccess.UnitOfWork.Contracts;
using DataAccess.UnitOfWork.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Config
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegister(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterVersioning(services);
            AddRegisterOthers(services);
            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IPropertyImageService, PropertyImageService>();
            services.AddTransient<IPropertyTraceService, PropertyTraceService>();
            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static IServiceCollection AddRegisterVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                var multiVersionReader = new HeaderApiVersionReader("x-version");
                options.ApiVersionReader = multiVersionReader;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            services.AddTransient<ISwaggerData, SwaggerData>();
            return services;
        }
    }
}
