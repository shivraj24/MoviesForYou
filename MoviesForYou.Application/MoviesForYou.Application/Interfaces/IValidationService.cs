using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Interfaces
{
    public interface IValidationService
    {
        bool isValidActor(Actor actor);
        bool isValidMovie(Movie movie);
        bool isValidProducer(Producer producer);

    }
}
