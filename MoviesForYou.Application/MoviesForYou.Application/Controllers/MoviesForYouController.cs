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
        public async Task<ActionResult<SuccessfulResponse<List<Movie>>>> GetAllMovies()
        {
            var movies = await movieServices.GetAllMoviesAsync();
            return Ok(new SuccessfulResponse<List<Movie>>(movies, "Retrived data successfully"));
        }

        [HttpPost("AddMovie")]
        public async Task<ActionResult<SuccessfulResponse<Movie>>> AddMovie(Movie movie)
        {
            await movieServices.AddMovieAsync(movie);
            return Created("Added Movie successfully",new SuccessfulResponse<Movie>(movie, "Successfully Added"));
        }

        [HttpPut("UpdateMovie")]
        public async Task<ActionResult<SuccessfulResponse<Movie>>> UpdateMovie(Movie movie)
        {
            await movieServices.UpdateMovieAsync(movie);
            return Ok(new SuccessfulResponse<Movie>(movie, "Update successfull"));
        }
    }
}
