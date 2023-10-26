using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

namespace CleanArchitecture.Application.Service
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    }
}
