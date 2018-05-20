using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;


[Route("api/v1/Asteroids")]
public class AsteroidsController : Controller
{
    private static List<Asteroid> list = new List<Asteroid>();
    
    private readonly SolarBodiesContext context;
    public AsteroidsController (SolarBodiesContext context)
    {
        this.context = context;
    }

    
    [Route("{id}")]   // api/v1/Asteroids/2
    [HttpGet]
    public IActionResult GetAsteroid(int id)
    {
        var asteroid = context.Asteroids.Find(id);

        if(asteroid == null)
            return NotFound();

        return Ok(asteroid);
    }

    
    [HttpGet]         // api/v1/Asteroids
    public List<Asteroid> GetAllAsteroid()
    {
        return context.Asteroids.ToList();
    }

    [Route("{id}")]
    [HttpDelete]
    public IActionResult DeleteAsteroid(int id)
    {
        var asteroid = context.Asteroids.Find(id);
        if(asteroid == null){
            return NotFound();
        }

        //Asteroid verwijderen
        context.Asteroids.Remove(asteroid);
        context.SaveChanges();
        //Standaard response 204 bij een gelukte delete
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateAsteroid ([FromBody] Asteroid newAsteroid)
    {

        context.Asteroids.Add(newAsteroid);
        context.SaveChanges();
    

        return Created("", newAsteroid);
     
    }

    [HttpPut]
    public IActionResult UpdateAsteroid([FromBody] Asteroid updateAsteroid)
    {
        var asteroid = context.Asteroids.Find(updateAsteroid.Id);
        if(asteroid == null)
            return NotFound();

        asteroid.name = updateAsteroid.name;
        asteroid.Origin = updateAsteroid.Origin;
        asteroid.Shape = updateAsteroid.Shape;
        asteroid.Diameter = updateAsteroid.Diameter;

        context.SaveChanges();
        return Ok();
    }
}

