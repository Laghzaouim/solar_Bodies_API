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

        private readonly SolarBodiesContext context;
        public PlanetsController(SolarBodiesContext context)
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
        public List<Planet> GetAllPlanet(string name, string surface, int? page, string sort, int length = 2, string dir = "asc")
        {
            IQueryable<Planet> query = context.Planets;

            //search or filter
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.name == name);
            if (!string.IsNullOrWhiteSpace(surface))
                query = query.Where(d => d.Surface == surface);

            //pagging
            if (page.HasValue)
                query = query.Skip(page.Value * length);
            //length of a page
            query = query.Take(length);

            //sorting
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "name":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.name);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.name);
                        break;
                    case "diameter":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.Diameter);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.Diameter);
                        break;
                    case "distanceFromSun":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.DistanceFromSun);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.DistanceFromSun);
                        break;
                }
            }

            return query.ToList();
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