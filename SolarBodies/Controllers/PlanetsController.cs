using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Planets.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlanetsController : Controller
    {
        private static List<Planet> list = new List<Planet>();

        private readonly BodiesContext context;
        public PlanetsController(BodiesContext context)
        {
            this.context = context;
        }

        [Route("{id}")]   // api/v1/planets/2
        [HttpGet]
        public IActionResult GetPlanet(int id)
        {
            var planet = context.Planet.Find(id);

            if (planet == null)
                return NotFound();

            return Ok(planet);
        }



        [HttpGet]         // api/v1/planets
        public List<Planet> GetAllPlanet()
        {
            return context.Planet.ToList();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePlanet(int id)
        {
            var planet = context.Planet.Find(id);
            if (planet == null)
                return NotFound();

            context.Planet.Remove(planet);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreatePlanet([FromBody] Planet newPlanet)
        {

            context.Planet.Add(newPlanet);
            context.SaveChanges();


            return Created("", newPlanet);

        }

        [HttpPut]
        public IActionResult UpdatePlanet([FromBody] Planet updatePlanet)
        {
            var planet = context.Planet.Find(updatePlanet.Id);
            if (planet == null)
                return NotFound();

            planet.name = updatePlanet.name;
            planet.Diameter = updatePlanet.Diameter;
            planet.DistanceFromSun = updatePlanet.DistanceFromSun;
            planet.Description = updatePlanet.Description;
            planet.Surface = updatePlanet.Surface;

            context.SaveChanges();

            return Ok(planet);
        }
    }
}