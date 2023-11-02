using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<GetAllCarQuery, Car>();
            CreateMap<RegisterCommand, User>();
        }
    }
}
