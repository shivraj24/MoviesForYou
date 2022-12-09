using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IMovieServices
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<bool> AddMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);

    }
}
