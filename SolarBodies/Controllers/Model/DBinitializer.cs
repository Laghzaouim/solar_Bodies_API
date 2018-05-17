using System.Linq;

namespace Model
{
    public class DBInitializer{
        public static void Initialize(BodiesContext context){
            context.Database.EnsureCreated();

            //Planet pl = new Planet();

            if(!context.Planets.Any()){

                
                var Moon = new Moon(){
                    name = "Moon",
                    Diameter = 700,

                };
                var Earth = new Planet(){
                    name = "Earth",
                    DistanceFromSun = 1,
                    Surface = "Rocky",
                    Diameter = 12756,
                    Moon = Moon
                };
                context.Planets.Add(Earth);
                context.Moons.Add(Moon);
                context.SaveChanges();
            }
        }
    }
}