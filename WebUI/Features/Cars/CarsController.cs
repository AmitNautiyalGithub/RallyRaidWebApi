using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = new List<Car>();
            Car car1 = new Car
            {
                 TeamName = "Team A",
                 Speed = 100,
                 MelfunctionChance = 0.2,
            };

            Car car2 = new Car
            {
                TeamName = "Team B",
                Speed = 90,
                MelfunctionChance = 0.15,
            };

            cars.Add(car1);
            cars.Add(car2);

            return Ok(cars);
        }
    }
}
