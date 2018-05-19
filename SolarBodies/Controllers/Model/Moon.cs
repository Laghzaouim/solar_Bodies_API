

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
    public class Moon
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public double Diameter { get; set; }
        [JsonIgnore]
        public ICollection<Planet> Planets { get; set; } = new List<Planet>();

    
    }
}