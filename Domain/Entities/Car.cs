namespace Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public double MelfunctionChance { get; set; }
        public int MelfunctionOccured { get; set; }
        public int Speed { get; set; }
        public int DistanceConveredInMiles { get; set; }
        public int FinishedRace { get; set; }
        public int RacedForHours { get; set; }
    }
}
