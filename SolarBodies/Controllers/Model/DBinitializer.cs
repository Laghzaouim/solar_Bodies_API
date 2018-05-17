using System.Linq;

namespace Model
{
    public class DBInitializer{
        public static void Initialize(BodiesContext context){
            context.Database.EnsureCreated();

            //Planet pl = new Planet();

            if(!context.Planet.Any()){

                var Earth = new Planet(){
                    name = "Earth",
                    DistanceFromSun = 1,
                    Surface = "Rocky",
                    Diameter = 12756
                };
                context.Planet.Add(Earth);
                
                var Pluto = new DwarfPlanet(){
                    name = "Pluto",
                    DistanceFromSun = 39.5,
                    Surface = "Rocky",
                    Diameter = 1700
                };
                context.DwarfPlanet.Add(Pluto);
                context.SaveChanges();
            }
        }
    }
}