using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Data;
using MoviesForYou.Application.API.ExceptionHandler;
using MoviesForYou.Application.API.Helpers;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;
using System.Collections.Generic;

namespace MoviesForYou.Application.API.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly MoviesDataContext context;
        private readonly IValidationService validationService;
        public MovieServices(MoviesDataContext _context, IValidationService _validationService)
        {
            this.context = _context;
            this.validationService = _validationService;
        }
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            if(!validationService.isValidMovie(movie))
            {
                throw new BadRequestException("Invalid request parameter");
            }
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
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
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
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return movies;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            if (movie.MovieId <= 0 && !validationService.isValidMovie(movie))
            {
                throw new BadRequestException("Invalid Request parameter");
            }
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
                    throw new NotFoundException("the movie record doesn't exist in the system");
                }
            }
            catch (NotFoundException exception)
            {
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new InternalServerException(exception.Message);
            }
            return true;
        }
    }
}
