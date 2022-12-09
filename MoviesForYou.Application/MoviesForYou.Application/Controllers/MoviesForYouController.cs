using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesForYouController : ControllerBase
    {

        [HttpGet("Movies")]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie());
            return Ok(movies);
        }

        [HttpPost("AddMovie")]
        public async Task<ActionResult> AddMovie(Movie? movie)
        {
            return Ok("Success");
        }

        [HttpPut("UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(Movie? movie)
        {
            return Ok("Success");
        }
    }
}
