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
                
                var Moon = new Moon(){
                    name = "Moon",
                    Diameter = 700,

                };
                context.Moon.Add(Moon);
                context.SaveChanges();
            }
        }
    }
}