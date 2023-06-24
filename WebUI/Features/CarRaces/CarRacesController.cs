using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Features.CarRaces.Models;

namespace WebUI.Features.CarRaces
{
    [Route("api/carraces")]
    [ApiController]
    public class CarRacesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarRacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCarRaces()
        {
            var carRaces = _context.CarRaces.ToList();
            return Ok(carRaces);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCarRaces(int id)
        {
            var carRace = _context.CarRaces.FirstOrDefault(cr => cr.Id == id);
            if (carRace == null)
            {
                return NotFound($"CarRace with id: {id} not found.");
            }
            return Ok(carRace);
        }

        [HttpPost]
        public IActionResult CreateCarRaces(CarRaceCreateModel carRace)
        {
            var newCarRace = new CarRace
            {
                Name = carRace.Name,
                Location = carRace.Location,
                Distance = carRace.Distance,
                TimeLimit = carRace.TimeLimit,
                Status = "New"
            };

            _context.CarRaces.Add(newCarRace);
            _context.SaveChanges();

            return Ok(newCarRace);
        }

        [HttpPut]
        public IActionResult UpateCarRaces(CarRaceUpdateModel carRace)
        {
            var dbCarRace = _context.CarRaces
                .Include(cr=> cr.Cars)
                .FirstOrDefault(cr => cr.Id == carRace.Id);
            if (dbCarRace == null)
            {
                return NotFound($"CarRace with id: {carRace.Id} not found.");
            }

            dbCarRace.Name = carRace.Name;
            dbCarRace.Distance = carRace.Distance;
            dbCarRace.Location = carRace.Location;
            dbCarRace.TimeLimit = carRace.TimeLimit;
            _context.SaveChanges();

            return Ok(dbCarRace);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCarRaces(int id)
        {
            var dbCarRace = _context.CarRaces
                 .Include(cr => cr.Cars)
                 .FirstOrDefault(cr => cr.Id == id);

            if (dbCarRace == null)
            {
                return NotFound($"CarRace with id: {id} not found.");
            }

            _context.Remove(dbCarRace);
            _context.SaveChanges();

            return Ok($"CarRace with id: {id} was successfully deleted.");
        }

        [HttpPut]
        [Route("{carRaceId}/addcar/{carId}")]
        public IActionResult AddCarToCarRaces(int carRaceId, int carId)
        {
            var dbCarRace = _context.CarRaces
                 .Include(cr => cr.Cars)
                 .SingleOrDefault(cr => cr.Id == carRaceId);

            if (dbCarRace == null)
            {
                return NotFound($"CarRace with id: {carRaceId} not found.");
            }

            var dbCar = _context.Cars.SingleOrDefault(c => c.Id == carId);
            if (dbCar == null)
            {
                return NotFound($"Car with id: {carId} not found.");
            }

            dbCarRace.Cars.Add(dbCar);
            _context.SaveChanges();

            return Ok(dbCarRace);
        }

        [HttpPut]
        [Route("{id}/start")]
        public IActionResult StartCarRaces(int id)
        {
            var dbCarRace = _context.CarRaces
                 .Include(cr => cr.Cars)
                 .SingleOrDefault(cr => cr.Id == id);
            if (dbCarRace == null)
            {
                return NotFound($"CarRace with id: {id} not found.");
            }

            dbCarRace.Status = "Started";
            _context.SaveChanges();

            return Ok(dbCarRace);
        }
    }
}
