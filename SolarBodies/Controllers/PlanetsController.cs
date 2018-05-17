using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var planet = context.Planets
                .Include(d => d.Moon)
                .SingleOrDefault(d => d.Id == id);

            if (planet == null)
                return NotFound();

            return Ok(planet);
        }

        [HttpGet]         // api/v1/planets
        public List<Planet> GetAllPlanet()
        {
            return context.Planets.ToList();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePlanet(int id)
        {
            var planet = context.Planets.Find(id);
            if (planet == null)
                return NotFound();

            context.Planets.Remove(planet);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreatePlanet([FromBody] Planet newPlanet)
        {

            context.Planets.Add(newPlanet);
            context.SaveChanges();


            return Created("", newPlanet);

        }

        [HttpPut]
        public IActionResult UpdatePlanet([FromBody] Planet updatePlanet)
        {
            var planet = context.Planets.Find(updatePlanet.Id);
            if (planet == null)
                return NotFound();

            planet.name = updatePlanet.name;
            planet.Diameter = updatePlanet.Diameter;
            planet.DistanceFromSun = updatePlanet.DistanceFromSun;
            planet.Surface = updatePlanet.Surface;

            context.SaveChanges();

            return Ok(planet);
        }
    }
}