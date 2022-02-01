using Application.Models;
using AutoMapper;
using CrossCutting.Helpers;
using Domain.Entities.Models;

namespace Application.Mappers
{
    public class MapperBase : MapperHelper
    {
        static MapperBase()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OwnerDto, OwnerEntity>();
                cfg.CreateMap<OwnerEntity, OwnerDto>();
                cfg.CreateMap<PropertyDto, PropertyEntity>();
                cfg.CreateMap<PropertyEntity, PropertyDto>();
                cfg.CreateMap<PropertyTraceDto, PropertyTraceEntity>();
                cfg.CreateMap<PropertyTraceEntity, PropertyTraceDto>();
                cfg.CreateMap<PropertyImageDto, PropertyImageEntity>();
                cfg.CreateMap<PropertyImageEntity, PropertyImageDto>();
            });

            staticMapper = config.CreateMapper();
        }
    }
}
