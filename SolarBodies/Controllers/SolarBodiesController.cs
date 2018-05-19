using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Planets.Controllers
{
    [Route("api/v1/")]
    public class SolarBodiesController : Controller
    {

        private static List<SBodies> list = new List<SBodies>();
        private readonly SolarBodiesContext context;

        public SolarBodiesController(SolarBodiesContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<SBodies> GetSolarBodies()
        {
            return context.SBodies.ToList();
        }

    }

}