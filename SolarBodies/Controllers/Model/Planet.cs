namespace Model
{
    public class Planet
    {
        public int Id {get; set;}
        public string name { get; set; }
        public string Surface { get; set; }
        public double Diameter { get; set; }
        public double DistanceFromSun { get; set; }
        public Moon Moon { get; set; }
        // int MoonId { get; set; }
    }
}