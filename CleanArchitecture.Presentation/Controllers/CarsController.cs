using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiController
    {
        private readonly AppDbContext _context;

        public CarsController(IMediator mediator, AppDbContext context) : base(mediator)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            IList<Car> cars = new List<Car>();

            for (int i = 0; i < 500; i++)
            {
                Car car = new()
                {
                    Name = "Car " + i,
                    Model = "Model " + i,
                    EnginePower = i + 10
                };
                cars.Add(car);
            }

            await _context.Set<Car>().AddRangeAsync(cars);
            await _context.SaveChangesAsync(cancellationToken);


            PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
