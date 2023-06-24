using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.MotorBikes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoBikeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MotorBike>> GetCars()
        {
            var MotorBikes = new List<MotorBike>();
            MotorBike MotorBike1 = new MotorBike
            {
                TeamName = "MotorBike Team A",
                Speed = 100,
                MelfunctionChance = 0.2,
            };

            MotorBike MotorBike2 = new MotorBike
            {
                TeamName = "MotorBike Team B",
                Speed = 90,
                MelfunctionChance = 0.15,
            };

            MotorBikes.Add(MotorBike1);
            MotorBikes.Add(MotorBike2);

            return Ok(MotorBikes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<MotorBike> GetMotorBike(int id)
        {
            MotorBike MotorBike1 = new MotorBike
            {
                TeamName = "MotorBike Team A",
                Speed = 100,
                MelfunctionChance = 0.2,
            };

            return Ok(MotorBike1);
        }

        [HttpPost]
        public ActionResult<MotorBike> CreateMotorBike(MotorBike motorBike)
        {
            var newMotorBike = new MotorBike
            {
                Id = motorBike.Id,
                TeamName = motorBike.TeamName,
                Speed = motorBike.Speed,
                MelfunctionChance = motorBike.MelfunctionChance
            };

            return Ok(newMotorBike);
        }

        [HttpPut]
        public ActionResult<MotorBike> UpdateMotorBike(MotorBike motorBike)
        {
            var updateMotorBike = new MotorBike
            {
                Id = motorBike.Id,
                TeamName = motorBike.TeamName,
                Speed = motorBike.Speed,
                MelfunctionChance = motorBike.MelfunctionChance
            };

            return Ok(updateMotorBike);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<MotorBike> DeleteMotorBike(int id)
        {

            return Ok($"MotorBike with id {id} was successfully deleted");
        }
    }
}
