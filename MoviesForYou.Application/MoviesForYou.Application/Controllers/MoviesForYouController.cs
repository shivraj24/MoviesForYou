using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesForYouController : ControllerBase
    {
        private readonly IMovieServices movieServices;
        public MoviesForYouController(IMovieServices _movieServices)
        {
            this.movieServices = _movieServices;
        }

        [HttpGet("Movies")]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await movieServices.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpPost("AddMovie")]
        public async Task<ActionResult> AddMovie(Movie? movie)
        {
            var isSuccessful = await movieServices.AddMovieAsync(movie);
            return Ok("Success");
        }

        [HttpPut("UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(Movie? movie)
        {
            var isSuccessful = await movieServices.UpdateMovieAsync(movie);
            return Ok("Success");
        }
    }
}
