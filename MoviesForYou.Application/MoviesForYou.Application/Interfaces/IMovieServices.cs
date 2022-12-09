using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IMovieServices
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<bool> AddMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);

    }
}
