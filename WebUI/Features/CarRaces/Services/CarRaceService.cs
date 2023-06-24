using Domain.Entities;

namespace WebUI.Features.CarRaces.Services
{
    public class CarRaceService
    {
        public CarRace RunRace(CarRace carRace)
        {
            var races = new List<Car>();

            foreach (var car in carRace.Cars)
            {
                while (car.DistanceConveredInMiles < carRace.Distance
                    && car.RacedForHours < carRace.TimeLimit)
                {
                    car.RacedForHours++;

                    var random = new Random().Next(1, 101);
                    if (random <= car.MelfunctionChance)
                    {
                        car.MelfunctionChance++;
                    }
                    else
                    {
                        car.DistanceConveredInMiles += car.Speed;
                    }
                    car.RacedForHours++;
                }


                if (car.DistanceConveredInMiles >= carRace.Distance)
                {
                    car.FinishedRace = true;
                }

                races.Add(car);
            }


            carRace.Cars = races
                .OrderBy(c=> c.FinishedRace)
                .ThenByDescending(c => c.DistanceConveredInMiles)
                .ThenByDescending(c => c.RacedForHours)
                .ToList();

            return carRace;
        }
    }
}
