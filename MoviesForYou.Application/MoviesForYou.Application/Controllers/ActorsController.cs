using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorServices actorServices;
        public ActorsController(IActorServices _actorServices) 
        {
            this.actorServices = _actorServices;
        }   
        [HttpPost("addActor")]
        public async Task<IActionResult> AddActorAsync(Actor actor)
        {
            var isSuccessful = await actorServices.AddActorAsync(actor);
            return Ok("Successfully Added the Actor");
        } 

        [HttpPut("updateActor")]
        public async Task<IActionResult> UpdateActorAsync(Actor actor)
        {
            var isSuccessful = await actorServices.UpdateActorAsync(actor);
            return Ok("Successfully Updated the actor");
        }
        [HttpGet("actors")]
        public async Task<ActionResult<List<Actor>>> GetAllActorsAsync()
        {
            return await actorServices.GetAllActorsAsync();
        }

    }
}
