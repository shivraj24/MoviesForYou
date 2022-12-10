using MoviesForYou.Application.API.Models;
using MoviesForYou.Application.API.ExceptionHandler;
using MoviesForYou.Application.API.Interfaces;

namespace MoviesForYou.Application.API.Helpers
{
    public class ValidationService : IValidationService
    {
        public bool isValidActor(Actor actor)
        {
            if(string.IsNullOrEmpty(actor.Name)) {
                return false;
            }
            return true;
        }

        public bool isValidMovie(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Name) || movie.DateOfRelease == null)
            {
                return false;
            }
            return true;
        }
        public bool isValidProducer(Producer producer)
        {
            if (string.IsNullOrEmpty(producer.Name))
            {
                return false;
            }
            return true;
        }

    }
}
