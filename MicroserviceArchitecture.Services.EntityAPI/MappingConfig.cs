using AutoMapper;
using MicroserviceArchitecture.Services.EntityAPI.Models;
using MicroserviceArchitecture.Services.EntityAPI.Models.Dto;

namespace MicroserviceArchitecture.Services.EntityAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EntityDto, Entity>();
                config.CreateMap<Entity, EntityDto>();

            });
            return mappingConfig;

        }
    }
}
