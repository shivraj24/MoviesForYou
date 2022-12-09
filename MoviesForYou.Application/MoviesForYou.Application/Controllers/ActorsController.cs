using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MoviesDataContext context;
        public ActorsController(MoviesDataContext _context) 
        {
            context = _context;
        }   
        [HttpPost("addActor")]
        public async Task<IActionResult> AddActor(Actor actor)
        {
            await context.Actors.AddAsync(actor);
            context.SaveChanges();
            return Ok("success");
        } 

        [HttpPut("updateActor")]
        public async Task<IActionResult> UpdateActor(Actor actor)
        {
            var existingActor = await context.Actors.FindAsync(actor.ActorId);
            if (existingActor == null)
            {
                return NotFound("Actor doesn't exist");
            }
            existingActor.Name = actor.Name;
            existingActor.DateOfBirth = actor.DateOfBirth;
            existingActor.Gender = actor.Gender;
            context.SaveChanges();
            return Ok("success");
        }

    }
}
