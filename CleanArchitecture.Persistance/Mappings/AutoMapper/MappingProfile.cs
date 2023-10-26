using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
        }
    }
}
