using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsList.Infrastructure.Command;
using CarsList.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsList.Api.Controllers
{   
    [Route("[controller]")]
    public class CarsController : Controller
    {
        public readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string mark)
        {
            var cars = await _carService.BrowseAsync(mark);

            return Json(cars);
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> Get(Guid carId)
        {
            var @car = await _carService.GetAsync(carId);
            if (@car == null)
            {
                return NotFound();
            }

            return Json(@car);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateCar command)
        {
            command.CarId = Guid.NewGuid();
            await _carService.CreateAsync(command.CarId, command.Mark, command.Model, command.Capacity, command.DateOc, command.DateReview, command.CarType);
          

            return Created($"/cars/{command.CarId}", null);
        }

        [HttpPut("{carId}")]

        public async Task<IActionResult> Put(Guid carId, [FromBody] UpdateCar command)
        {
            await _carService.UpdateAsync(carId, command.Mark, command.Model, command.Capacity, command.DateOc, command.DateReview, command.CarType);

            return NoContent();
        }

        [HttpDelete("{carId}")]

        public async Task<IActionResult> Delete(Guid carId)
        {
            await _carService.DeleteAsync(carId);

            return NoContent();
        }
    }
}
