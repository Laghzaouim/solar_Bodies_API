using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class DBInitializer
    {
        public static object Moons { get; private set; }

        public static void Initialize(SolarBodiesContext context)
        {

            context.Database.EnsureCreated();

            if (!context.Planets.Any())
            {
                var MoonEarth = new Moon()
                {
                    name = "Moon",
                    Diameter = 1737,

                };
                var Earth = new Planet()
                {
                    name = "Earth",
                    DistanceFromSun = 1,
                    Surface = "Rocky",
                    Diameter = 6371,
                    Moon = MoonEarth

                };
                context.Planets.Add(Earth);
                context.Moons.Add(MoonEarth);

                var Deimos = new Moon()
                {
                    name = "Phobos",
                    Diameter = 11,
                };

                var Mars = new Planet()
                {
                    name = "Mars",
                    DistanceFromSun = 1.52,
                    Surface = "Rocky",
                    Diameter = 3390,
                    Moon = Deimos

                };

                context.Planets.Add(Mars);
                context.Moons.Add(Deimos);

                context.SaveChanges();
            }
        }
    }
}