using Application.Models;
using CrossCutting.Enum;
using CrossCutting.Helpers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace WebApi.Config
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = x =>
                    {
                        return new BadRequestObjectResult(ResponseHelper<IList<string>>.AddResponse(
                            result: ModelStateResponseHelper.ResponseInvalidModel(x.ModelState),
                            success: ResponseHttpMessageEnum.InvalidModel.Success,
                            statusCode: ResponseHttpMessageEnum.InvalidModel.StatusCode,
                            message: ResponseHttpMessageEnum.InvalidModel.Message
                        ));
                    };
                });

            services.AddTransient<IValidator<OwnerDto>, OwnerValidator>();
            services.AddTransient<IValidator<PropertyDto>, PropertyValidator>();
            services.AddTransient<IValidator<PropertyImageDto>, PropertyImageValidator>();
            services.AddTransient<IValidator<PropertyTraceDto>, PropertyTraceValidator>();
            return services;
        }
    }
}
