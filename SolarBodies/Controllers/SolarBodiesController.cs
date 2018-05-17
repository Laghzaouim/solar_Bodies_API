using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace SolarBodies.Controllers
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

        [Route("{id}")]   // api/v1/SolarBodies/2
        [HttpGet]
        public IActionResult GetPlanet(int id)
        {


            return Ok();
        }



        [HttpGet]         // api/v1/SolarBodies
        public List<Planet> GetAllPlanet()
        {


            return context.Planet.ToList();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePlanet(int id)
        {

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreatePlanet([FromBody] Planet newPlanet)
        {


            return Created("", newPlanet);

        }

        [HttpPut]
        public IActionResult UpdatePlanet([FromBody] Planet updatePlanet)
        {

            return Ok();
        }
    }
}