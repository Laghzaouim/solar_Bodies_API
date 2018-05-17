using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class BodiesContext : DbContext
    {
        public BodiesContext(DbContextOptions<BodiesContext> options) : base(options)
        {
        }
        public DbSet<Planet> Planet { get; set; }
        public DbSet<DwarfPlanet> DwarfPlanet { get; set; }
    }
}
