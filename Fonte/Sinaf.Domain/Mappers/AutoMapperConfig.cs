using AutoMapper;

namespace Sinaf.Domain.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<DtoToEntityMappingProfile>();
                cfg.AddProfile<EntityToDtoMappingProfile>();
            });
            return configuration;
        }
    }
}
