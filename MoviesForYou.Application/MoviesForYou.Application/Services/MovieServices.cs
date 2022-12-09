using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;
using System.Collections.Generic;

namespace MoviesForYou.Application.API.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly MoviesDataContext context;
        public MovieServices(MoviesDataContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            try
            {
                var actors = movie.Actors;
                var producer = movie.Producer;
                movie.Actors = null;
                movie.Producer = null;
                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();

                var response = await context.Movies.FindAsync(movie.MovieId);
                if(response != null)
                {
                    response.Actors = actors;
                    response.Producer= producer;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            List<Movie> movies;
            try
            {
                movies = await context.Movies.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return movies;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            try
            {
                var existingMovie = await context.Movies.FindAsync(movie.MovieId);
                if (existingMovie != null)
                {
                    existingMovie.Name = movie.Name;
                    existingMovie.Plot = movie.Plot;
                    existingMovie.DateOfRelease = movie.DateOfRelease;
                    existingMovie.Producer = movie.Producer;
                    existingMovie.Actors = movie.Actors;

                    await context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
