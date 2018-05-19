using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class SolarBodiesContext : DbContext
    {
        public SolarBodiesContext(DbContextOptions<SolarBodiesContext> options) : base(options)
        {
        }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Moon> Moons { get; set; }
    }
}
