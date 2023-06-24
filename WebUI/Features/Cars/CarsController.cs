using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using WebUI.Features.Cars.Models;

namespace WebUI.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);

            //var cars = new List<Car>();
            //Car car1 = new Car
            //{
            //    TeamName = "Team A",
            //    Speed = 100,
            //    MelfunctionChance = 0.2,
            //};

            //Car car2 = new Car
            //{
            //    TeamName = "Team B",
            //    Speed = 90,
            //    MelfunctionChance = 0.15,
            //};

            //cars.Add(car1);
            //cars.Add(car2);
            //return Ok(cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            //Car car1 = new Car
            //{
            //    TeamName = "Team A",
            //    Speed = 100,
            //    MelfunctionChance = 0.2,
            //};

            //return Ok(car1);


            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound($"Car with id: {id} hasn't been found.");
            }

            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar(CarCreateModel car)
        {
            var newCar = new Car
            {
                TeamName = car.TeamName,
                Speed = car.Speed,
                MelfunctionChance = car.MelfunctionChance
            };


            _context.Cars.Add(newCar);
            _context.SaveChanges();

            //var newCar = new Car
            //{
            //    Id = car.Id,
            //    TeamName = car.TeamName,
            //    Speed = car.Speed,
            //    MelfunctionChance = car.MelfunctionChance
            //};

            return Ok(newCar);
        }

        [HttpPut]
        public ActionResult<Car> UpdateCar(CarUpdateModel car)
        {
            //var updateCar = new Car
            //{
            //    Id = car.Id,
            //    TeamName = car.TeamName,
            //    Speed = car.Speed,
            //    MelfunctionChance = car.MelfunctionChance
            //};

            //return Ok(updateCar);


            var dbCar = _context.Cars.FirstOrDefault(c => c.Id == car.Id);
            if (dbCar == null)
            {
                return NotFound($"Car with id: {car.Id} hasn't been found.");
            }

            //update he car            

            dbCar.TeamName = car.TeamName;
            dbCar.Speed = car.Speed;
            dbCar.MelfunctionChance = car.MelfunctionChance;
            _context.SaveChanges();

            return Ok(dbCar);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Car> DeleteCar(int id)
        {
            var dbCar = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (dbCar == null)
            {
                return NotFound($"Car with id: {id} hasn't been found.");
            }

            _context.Cars.Remove(dbCar);
            _context.SaveChanges();

            return Ok($"Car with id {id} was successfully deleted");
        }
    }
}
