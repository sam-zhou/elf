using AutoMapper;

namespace Elf.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                //config.CreateMap<Make, MakeDto>().ReverseMap();

                //config.CreateMap<Model, ModelDto>().ReverseMap();

                //config.CreateMap<Badge, BadgeDto>().ReverseMap();

                //config.CreateMap<Vehicle, VehicleDto>().ReverseMap();
            });
        }
    }
}