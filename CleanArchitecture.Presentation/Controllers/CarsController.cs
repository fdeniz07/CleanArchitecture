using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
   /* [Authorize(AuthenticationSchemes = "Bearer")]*/ //Authorization islemlerini tek tek controller bazinda yapmak istemedigimden, ApiController'e bu annotation'u ekliyorum
    public sealed class CarsController : ApiController
    {
        //private readonly AppDbContext _context;

        public CarsController(IMediator mediator) : base(mediator)
        {
            //_context = context;
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
            //Rastgele 500 veri olusturma
            //IList<Car> cars = new List<Car>();

            //for (int i = 0; i < 500; i++)
            //{
            //    Car car = new()
            //    {
            //        Name = "Car " + i,
            //        Model = "Model " + i,
            //        EnginePower = i + 10
            //    };
            //    cars.Add(car);
            //}

            //await _context.Set<Car>().AddRangeAsync(cars);
            //await _context.SaveChangesAsync(cancellationToken);


            PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
