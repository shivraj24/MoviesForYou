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
        private readonly ILogger<MovieServices> loggerService;

        public MovieServices(MoviesDataContext _context, IValidationService _validationService, ILogger<MovieServices> _loggerService)
        {
            this.context = _context;
            this.validationService = _validationService;
            this.loggerService = _loggerService;
        }
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            if(!validationService.isValidMovie(movie))
            {
                loggerService.LogDebug("Failed the validation for adding movie", movie);
                throw new BadRequestException("Invalid request parameter");
            }
            try
            {
                loggerService.LogInformation("Adding movie to the database....");
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
                loggerService.LogDebug(exception, "Failed adding the movie into the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully added movie to the database....");
            return true;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            List<Movie> movies;
            try
            {
                loggerService.LogInformation("Retrieving movies from the database....");
                movies = await context.Movies.ToListAsync();
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed retrieving the movies from the system");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Successfully retrieved movies from the database....");
            return movies;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            if (movie.MovieId <= 0 && !validationService.isValidMovie(movie))
            {
                loggerService.LogDebug("Failed the validation for updating movie", movie);
                throw new BadRequestException("Invalid Request parameter");
            }
            try
            {
                loggerService.LogInformation("Updating movie to the database....");
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
                loggerService.LogDebug(exception, "Movie to update doesn't exist into the system");
                throw new NotFoundException(exception.Message);
            }
            catch (Exception exception)
            {
                loggerService.LogDebug(exception, "Failed updating the movie into the database");
                throw new InternalServerException(exception.Message);
            }
            loggerService.LogInformation("Updated movie successfully to the database....");
            return true;
        }
    }
}
