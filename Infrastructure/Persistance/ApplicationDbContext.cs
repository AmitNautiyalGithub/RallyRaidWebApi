using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<MotorBike> MotorBikes { get; set; }
        public DbSet<CarRace> CarRaces { get; set; }
    }
}
